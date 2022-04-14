using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingLab2
{
    
    class WholesaleStoreModel
    {
        Queue<Order> queue = new Queue<Order>();
        private readonly List<Clerk> clerks = new List<Clerk>();
        public StringBuilder journal { get; private set; }
        public int OrderInterval { get; private set; }
        public int MaxClients { get; private set; }
        private Random rand = new Random();
        public int TimeOfShift { get; private set; }
        public int CurrentTime { get; private set; }
        public int OrderNum { get; private set; }
        public int TimeUntilNextClient { get; private set; }
        public int ClerkNumber { get; private set; }
        private int TotalOrders()
        {
            int orders = 0;
            foreach (var clerk in clerks)
            {
                orders += clerk.CompletedOrders;
            }
            return orders;
        }
        private void GetToWork(Clerk clerk)
        {
            int numberOfOrders = 0;
            Queue<Order> tempQueue = new Queue<Order>(queue);
            while (tempQueue.Count > 0 && numberOfOrders != MaxClients && (CurrentTime + clerk.GetCompleteOrderTime(numberOfOrders) <= TimeOfShift))
            {
                tempQueue.Dequeue();
                numberOfOrders++;
            }
            if (numberOfOrders != 0)
            {
                List<Order> orders = new List<Order>();
                for (int j = 0; j < numberOfOrders; j++)
                {
                    orders.Add(queue.Dequeue());
                }
                clerk.StartService(orders, CurrentTime);
                journal.AppendLine($"Клерк {clerk.ID} взял {numberOfOrders} заказ(ов) на {clerk.GetCompleteOrderTime(numberOfOrders)} минут");
                journal.AppendLine($"\t{queue.Count()} заказов в очереди");
            }
        }
        public WholesaleStoreModel (Params parameters)
        {
            ClerkNumber = parameters.Clerks;
            TimeOfShift = parameters.ModelingTime; 
            OrderInterval = parameters.ClientIntervalTime;
            MaxClients = parameters.MaxClients;
            TimeUntilNextClient = 0;
            OrderNum = 1;
            CurrentTime = 0;
            journal = new StringBuilder();
            for (int i = 0; i < ClerkNumber; i++)
            {
                clerks.Add(new Clerk(parameters.TimeFromWarehouse, parameters.TimeToWarehouse, parameters.CalcTime, i + 1));
            }
        }
        private string GetTime(int time)
        {
            StringBuilder hoursAndMinutes = new StringBuilder();
            int hours = time / 60;
            if (hours != 0)
                hoursAndMinutes.Append(hours + " ч. ");
            int minutes = time % 60;
            hoursAndMinutes.Append(minutes + " мин.");
            return hoursAndMinutes.ToString();
        }
        public string GetJournal()
        {
            return journal.ToString();
        }
        public void UpdateSystem(object sender, EventArgs e)
        {
            CurrentTime++;
            journal.AppendLine($"{GetTime(CurrentTime)}");
            if (TimeUntilNextClient <= OrderInterval && TimeUntilNextClient > 0)
            {
                TimeUntilNextClient--;
            }
            else
            {
                queue.Enqueue(new Order(CurrentTime, OrderNum));
                TimeUntilNextClient = OrderInterval - 1;
                journal.AppendLine($"Прибыл {OrderNum} клиент в очередь");
                journal.AppendLine($"\t{queue.Count()} заказов в очереди");
                OrderNum++;
            }
            var freeClerks = from c in clerks where !(c.IsBusy) select c;
            List<Clerk> freeClerksList = freeClerks.ToList();
            for (int i = freeClerksList.Count() - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                var temp = freeClerksList[j];
                freeClerksList[j] = freeClerksList[i];
                freeClerksList[i] = temp;
            }
            foreach (Clerk clerk in freeClerksList)
            {
                GetToWork(clerk);
            }
            var clerksToBeFree = from c in clerks where (c.IsBusy) && c.FinishServiceTime == CurrentTime select c;
            foreach (Clerk clerk1 in clerksToBeFree)
            {
                if (clerk1.FinishServiceTime == CurrentTime)
                {
                    journal.AppendLine($"Клерк {clerk1.ID} закончил с {clerk1.CurrentOrders.Count()} заказами");
                    foreach (var order in clerk1.CurrentOrders)
                    {
                        journal.AppendLine($"\tВремя ожидания {order.Number} клиента: {CurrentTime - order.TimeOfArrival} минут");
                    }
                    clerk1.FinishServices();
                    journal.AppendLine($"Клерк {clerk1.ID} освободился");
                    GetToWork(clerk1);
                }
            }
            journal.AppendLine("-----");
        }
        public string GetStatisitcs()
        {
            string stats = "";
            stats += ($"Общее количество выполненных заказов: {TotalOrders()}\n");
            stats += ($"Общее количество невыполненных заказов: {queue.Count()}\n");
            for (int i = 0; i < clerks.Count; i++)
                stats += ($"  Загрузка клерка {i + 1} в часах: {GetTime(clerks[i].WorkTime)} и в % от общего времени работы: {clerks[i].WorkloadInPercents(TimeOfShift)}%\n");
            return stats;
        }
    }
}

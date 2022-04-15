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
        private readonly List<int> waitTimes = new List<int>();
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
        private void GetToWork(List<Clerk> clerks)
        {
            int numberOfOrders = 0;
            List<int> clerkOrders = new List<int>();
            while (queue.Count - numberOfOrders > 0 && numberOfOrders < MaxClients * clerks.Count()) 
            {
                numberOfOrders++;
            }
            int i = clerks.Count;
            foreach (var clerk in clerks)
            {
                int num = numberOfOrders / i;
                numberOfOrders -= num;
                clerkOrders.Add(num);
                i--;
            }
            for (int j = 0; j < clerks.Count(); j++)
                while (CurrentTime + clerks[j].GetCompleteOrderTime(clerkOrders[j]) > TimeOfShift)
                    clerkOrders[j]--;

            for (int k = 0; k < clerks.Count(); k++) 
            {
                if (clerkOrders[k] != 0)
                {
                    List<Order> orders = new List<Order>();
                    for (int j = 0; j < clerkOrders[k]; j++)
                    {
                        orders.Add(queue.Dequeue());
                    }
                    clerks[k].StartService(orders, CurrentTime);
                    journal.AppendLine($"Клерк {clerks[k].ID} взял {clerkOrders[k]} заказ(ов) на {clerks[k].GetCompleteOrderTime(clerkOrders[k])} минут");
                    journal.AppendLine($"\t{queue.Count()} заказов в очереди");
                }
            }
        }
        private List<Clerk> GetFreeClerks()
        {
            var freeClerks = from c in clerks where !(c.IsBusy) select c;
            List<Clerk> freeClerksList = freeClerks.ToList();
            for (int i = freeClerksList.Count() - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                var temp = freeClerksList[j];
                freeClerksList[j] = freeClerksList[i];
                freeClerksList[i] = temp;
            }
            return freeClerksList;
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
                journal.Append($"\tСвободные клерки: ");
                bool isFree = false;
                foreach(var clerk in clerks)
                {
                    if (!clerk.IsBusy)
                    {
                        journal.Append("№" + clerk.ID + " ");
                        isFree = true;
                    }
                }
                if (!isFree)
                    journal.Append("отсутствуют\n");
                else
                    journal.Append("\n");
                OrderNum++;
            }
            GetToWork(GetFreeClerks());
            var clerksToBeFree = from c in clerks where (c.IsBusy) && c.FinishServiceTime == CurrentTime select c;
            foreach (Clerk clerk in clerksToBeFree)
            {
                if (clerk.FinishServiceTime == CurrentTime)
                {
                    journal.AppendLine($"Клерк {clerk.ID} закончил с {clerk.CurrentOrders.Count()} заказами");
                    foreach (var order in clerk.CurrentOrders)
                    {
                        journal.AppendLine($"\tВремя ожидания {order.Number} клиента: {CurrentTime - order.TimeOfArrival} минут");
                        waitTimes.Add(CurrentTime - order.TimeOfArrival);
                    }
                    clerk.FinishServices();
                    journal.AppendLine($"Клерк {clerk.ID} освободился");
                    GetToWork(GetFreeClerks());
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
            stats += ($"Среднее время ожидания клиента: {waitTimes.Average()}\n");
            stats += ($"Мин время ожидания клиента: {waitTimes.Min()}\n");
            stats += ($"Макс время ожидания клиента: {waitTimes.Max()}\n");
            return stats;
        }
    }
}

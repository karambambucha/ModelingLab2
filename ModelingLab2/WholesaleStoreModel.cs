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
        public int clerkNum { get; private set; }
        public int TimeUntilNextClient { get; private set; }
        private int TotalOrders()
        {
            int orders = 0;
            foreach (var clerk in clerks)
            {
                orders += clerk.CompletedOrders;
            }
            return orders;
        }
        public WholesaleStoreModel (Params parameters)
        {
            journal = new StringBuilder();
            for (int i = 0; i < 3; i++)
            {
                clerks.Add(new Clerk(parameters.TimeFromWarehouse, parameters.TimeToWarehouse, parameters.CalcTime));
            }
            TimeOfShift = parameters.ModelingTime; 
            TimeUntilNextClient = 0;
            OrderInterval = parameters.ClientIntervalTime;
            OrderNum = 1;
            CurrentTime = 0;
            MaxClients = parameters.MaxClients;
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
            if (TimeUntilNextClient <= OrderInterval && TimeUntilNextClient > 0)
            {
                TimeUntilNextClient--;
            }
            else
            {
                queue.Enqueue(new Order(CurrentTime, OrderNum));
                TimeUntilNextClient = OrderInterval - 1;
                journal.AppendLine($"{GetTime(CurrentTime)}: прибыл {OrderNum} клиент в очередь");
                journal.AppendLine($"\t{queue.Count()} заказов в очереди");
                OrderNum++;
            }
            clerkNum = 0;
            foreach (Clerk clerk in clerks)
            {
                if (!clerk.IsBusy)
                {
                    int numberOfOrders = 0;
                    Queue<Order> tempQueue = new Queue<Order>(queue);
                    while (tempQueue.Count > 0 && numberOfOrders != MaxClients)
                    {
                        tempQueue.Dequeue();
                        numberOfOrders++;
                    }
                    if (numberOfOrders != 0 && (CurrentTime + clerk.GetCompleteOrderTime(numberOfOrders) <= TimeOfShift))
                    {
                        journal.AppendLine($"{GetTime(CurrentTime)}: клерк {clerkNum + 1} взял {numberOfOrders} заказ(ов) на {clerk.GetCompleteOrderTime(numberOfOrders)} минут");
                        for (int j = 0; j < numberOfOrders; j++)
                        {
                            journal.AppendLine($"\tВремя ожидания {queue.Peek().Number} клиента: {CurrentTime - queue.Peek().TimeOfArrival} минут");
                            queue.Dequeue();
                        }
                        clerk.StartService(numberOfOrders, CurrentTime);
                        journal.AppendLine($"\t{queue.Count()} заказов в очереди");
                    }
                }
                if (clerk.FinishServiceTime == CurrentTime)
                {
                    clerk.FinishServices();
                    journal.AppendLine($"{GetTime(CurrentTime)}: клерк {clerkNum + 1} освободился");
                }
                clerkNum++;
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

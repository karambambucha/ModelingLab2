using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingLab2
{
    class Clerk
    {
        public const int TimeWayToWarehouse = 1;
        public const int TimeWayFromWarehouse = 1;
        public const int TimeCalculation = 2;
        public int CompletedOrders { get; private set; }
        public int CurrentOrders { get; private set; }
        public bool IsBusy { get; private set; }
        public double WorkTime
        {
            get; private set;
        }
        public double WorkloadInHours()
        {
            return Math.Round(WorkTime / 60.0, 5);
        }
        public double WorkloadInPercents(double shiftTime)
        {
            return Math.Round((WorkTime / shiftTime) * 100, 5);
        }
        static public int GetTimeOfSearch(int numberOfOrders)
        {
            return numberOfOrders * 3;
        }
        public int GetCompleteOrderTime(int numberOfOrders)
        {
            return TimeWayToWarehouse + GetTimeOfSearch(numberOfOrders) + TimeWayFromWarehouse + TimeCalculation;
        }
        public int TimeOfFinishOfService
        {
            get; protected set;
        }
        public void StartService(int numberOfOrders, int time)
        {
            IsBusy = true;
            TimeOfFinishOfService = time;
            TimeOfFinishOfService += GetCompleteOrderTime(numberOfOrders);
            CurrentOrders = numberOfOrders;
        }
        public void FinishServices()
        {
            CompletedOrders += CurrentOrders;
            CurrentOrders = 0;
            IsBusy = false;
            TimeOfFinishOfService = -1;
        }//освобождение клерка

        public Clerk()
        {
            IsBusy = false;
            TimeOfFinishOfService = -1; 
            CompletedOrders = 0;
        }
    }
    class Order
    {
        private int time;
        public int Time
        {
            get
            {
                return time;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                          "Время не может быть меньше или равным 0.");
                }
                time = value;
            }
        }
        public Order(int time)
        {
            Time = time;
        }
    }
    class WholesaleStoreModel
    {
        Queue<Order> queue = new Queue<Order>();
        private readonly List<Clerk> clerks = new List<Clerk>();
        public StringBuilder journal { get; private set; }
        private const int OrderInterval = 2;
        private const int MaxClients = 6;
        private Random rand = new Random();
        public int TimeOfShift { get; private set; }
        public int CurrentTime { get; private set; }
        public int TimeUntilNextClient { get; private set; }
        public int TotalOrders()
        {
            int orders = 0;
            foreach (var clerk in clerks)
            {
                orders += clerk.CompletedOrders;
            }
            return orders;
        }
        public double TotalWorkloadInHours() 
        {
            double workLoad = 0;
            foreach (Clerk c in clerks)
            {
                workLoad += c.WorkloadInHours();
            }
            return workLoad;
        }
        public WholesaleStoreModel (int time)
        {
            for (int i = 0; i < 3; i++)
            {
                clerks.Add(new Clerk());
            }
            TimeOfShift = time; 
            TimeUntilNextClient = 0;
            CurrentTime = 0;
            journal = new StringBuilder();
        }
        public void Run()
        {
            for (int i = 0; i < TimeOfShift; i++)
            {
                CurrentTime = i;
                if(TimeUntilNextClient <= OrderInterval && TimeUntilNextClient > 0)
                {
                    TimeUntilNextClient--;
                }
                else
                {
                    queue.Enqueue(new Order(CurrentTime));
                    TimeUntilNextClient = OrderInterval -1;
                    journal.AppendLine($"{CurrentTime} минут: прибыл клиент в очередь");
                }
                int clerkNum = 0;
                foreach (Clerk clerk in clerks)
                {
                    if (!clerk.IsBusy)
                    {
                        int numberOfOrders = 0;
                        while (queue.Count > 0 && numberOfOrders != MaxClients)
                        {
                            queue.Dequeue();
                            numberOfOrders++;
                        }
                        if (numberOfOrders != 0 && (CurrentTime + clerk.GetCompleteOrderTime(numberOfOrders) <= TimeOfShift))
                        {
                            clerk.StartService(numberOfOrders, CurrentTime);
                            journal.AppendLine($"{CurrentTime} минут: клерк {clerkNum+1} взял {numberOfOrders} заказ(ов) на {clerk.GetCompleteOrderTime(numberOfOrders)} минут");
                        }
                    }
                    if(clerk.TimeOfFinishOfService == CurrentTime)
                    {
                        clerk.FinishServices(); 
                        journal.AppendLine($"{CurrentTime} минут: клерк {clerkNum + 1} освободился");
                    }
                    clerkNum++;
                }
            }
            journal.AppendLine();
        }
    }
}

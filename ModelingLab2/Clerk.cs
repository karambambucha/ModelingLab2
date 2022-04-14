using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingLab2
{
    class Clerk
    {
        public int CompletedOrders { get; private set; }
        public int ID { get; private set; }
        public int TimeWayToWarehouse { get; private set; }
        public int TimeWayFromWarehouse { get; private set; }
        public int TimeCalculation { get; private set; }
        public bool IsBusy { get; private set; }
        public int WorkTime { get; private set; }
        public int FinishServiceTime { get; private set; }
        public List<Order> CurrentOrders{ get; private set; }
        public double WorkloadInPercents(double shiftTime)
        {
            return Math.Round((WorkTime / shiftTime) * 100, 5);
        }
        private int GetTimeOfSearch(int numberOfOrders)
        {
            return numberOfOrders * 3;
        }
        public int GetCompleteOrderTime(int numberOfOrders)
        {
            return TimeWayToWarehouse + GetTimeOfSearch(numberOfOrders) + TimeWayFromWarehouse + TimeCalculation;
        }
        public void StartService(List<Order> orders, int time)
        {
            CurrentOrders = orders;
            IsBusy = true;
            FinishServiceTime = time;
            FinishServiceTime += GetCompleteOrderTime(orders.Count());
        }
        public void FinishServices()
        {
            WorkTime += GetCompleteOrderTime(CurrentOrders.Count());
            CompletedOrders += CurrentOrders.Count();
            CurrentOrders.Clear();
            IsBusy = false;
            FinishServiceTime = -1;
        }

        public Clerk(int timeToWH, int timeFromWH, int timeCalc, int id)
        {
            CurrentOrders = new List<Order>();
            IsBusy = false;
            FinishServiceTime = -1;
            CompletedOrders = 0;
            TimeWayToWarehouse = timeToWH;
            TimeWayFromWarehouse = timeFromWH;
            TimeCalculation = timeCalc;
            ID = id;
        }
    }
}

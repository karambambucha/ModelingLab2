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
        public int TimeWayToWarehouse { get; private set; }
        public int TimeWayFromWarehouse { get; private set; }
        public int TimeCalculation { get; private set; }
        public int CurrentOrders { get; private set; }
        public bool IsBusy { get; private set; }
        public int WorkTime { get; private set; }
        public int FinishServiceTime { get; private set; }
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
        public void StartService(int numberOfOrders, int time)
        {
            IsBusy = true;
            FinishServiceTime = time;
            FinishServiceTime += GetCompleteOrderTime(numberOfOrders);
            WorkTime += GetCompleteOrderTime(numberOfOrders);
            CurrentOrders = numberOfOrders;
        }
        public void FinishServices()
        {
            CompletedOrders += CurrentOrders;
            CurrentOrders = 0;
            IsBusy = false;
            FinishServiceTime = -1;
        }

        public Clerk(int timeToWH, int timeFromWH, int timeCalc)
        {
            IsBusy = false;
            FinishServiceTime = -1;
            CompletedOrders = 0;
            TimeWayToWarehouse = timeToWH;
            TimeWayFromWarehouse = timeFromWH;
            TimeCalculation = timeCalc;
        }
    }
}

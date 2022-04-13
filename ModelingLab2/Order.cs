using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingLab2
{
    class Order
    {
        public int TimeOfArrival { get; private set; }
        public int Number { get; private set; }
        public Order(int time, int num)
        {
            TimeOfArrival = time;
            Number = num;
        }
    }
}

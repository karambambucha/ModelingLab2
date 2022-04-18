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

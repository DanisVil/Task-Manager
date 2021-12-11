namespace BankDll
{
    public class Currency
    {
        public string Name { get; set; }
        protected double valueRelativeToDollar;
        public Currency(string name, double RelToUSD)
        {
            Name = name;
            valueRelativeToDollar = RelToUSD;
        }
        public double Course
        {
            get
            {
                return valueRelativeToDollar;
            }
            set
            {
                valueRelativeToDollar = value;
            }
        }
        public double Compare(Currency currency)
        {
            return Course / currency.Course;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
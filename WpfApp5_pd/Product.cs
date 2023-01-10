using System;

namespace WpfApp5_pd
{
    [Serializable]
    public class Product
    {
        public string Name { get; set; }
        public double Count { get; set; }
        public double Price { get; set; }
        public double RealPrice { get; set; }
        public bool Purchased { get; set; }

        //[NonSerialized]
        public int Code { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}

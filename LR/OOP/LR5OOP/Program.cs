using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LR5OOP
{
    public static class Program
    {
        private static void Main()
        {
            List<Commodity> commodities = new List<Commodity>
                                  {
                                      new Product("молоко", 100, Convert.ToDateTime("17.03.2021"), 14),
                                      new Product("хлеб ", 41, Convert.ToDateTime("10.03.2021"), 3),
                                      new Batch("чай липтон", 80, 4, Convert.ToDateTime("15.03.2021"), 183),
                                      new Batch("йогурт", 49, 4, Convert.ToDateTime("14.03.2021"), 14),
                                      new Set("карандаши", 40, "цветные, черные"),
                                      new Set("ручки", 50, "гелевые, синие")
                                  };

            DateTime now = DateTime.Now;
            foreach (Commodity commodity in commodities)
            {
                Console.WriteLine(commodity.Info());
                Console.WriteLine(commodity.IsCorrespondsToWorkingLife(now) ? "Годен" : "Не годен");
                Console.WriteLine();
            }
           
            Console.WriteLine("----------------ЛР8-----------------");
            Product p1 = new Product("яйца", 79, Convert.ToDateTime("06.04.2021"), 7);
            Product p2 = new Product("молоко", 100, Convert.ToDateTime("06.04.2021"), 14);
            Product p3 = new Product("хлеб ", 41, Convert.ToDateTime("06.04.2021"), 3);
            Commodity[] com = new Product[] { p1, p2, p3 };
            Array.Sort(com);
            foreach (Product commodity in com)
            {
                Console.WriteLine(commodity.Info());
                Console.WriteLine(commodity.IsCorrespondsToWorkingLife(now) ? "Годен" : "Не годен");
                Console.WriteLine();
            }
        }
    }
    //tovar
    internal abstract class Commodity : IComparable
    {
        protected DateTime ManufactureDate;
        protected string Name;
        protected int Price;
        protected int WorkingLife;
        public virtual string Info()
        {
            return string.Format("Название продукта - {0}\nЦена - {1}", Name, Price);
        }
        public virtual bool IsCorrespondsToWorkingLife(DateTime currentDate)
        {
            return (currentDate < ManufactureDate + new TimeSpan(WorkingLife, 0, 0, 0));
        }
        public int CompareTo(object o)
        {
            Commodity p = o as Commodity;
            if (p != null)
                return this.Name.CompareTo(p.Name);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
    }
    //product
    internal class Product : Commodity
    {
       
        public Product(string name, int price, DateTime manufactureDate, int workingLife)
        {
            Name = name;
            Price = price;
            ManufactureDate = manufactureDate;
            WorkingLife = workingLife;
        }

        public override string Info()
        {
            return base.Info() + string.Format("\nДата производства - {0}\nСрок годности - {1} дней", ManufactureDate, WorkingLife);
        }
    }
    //partiya
    internal class Batch : Commodity
    {
        private int _count;

        public Batch(string name, int price, int count, DateTime manufactureDate, int workingLife)
        {
            _count = count;
            Name = name;
            Price = price;
            ManufactureDate = manufactureDate;
            WorkingLife = workingLife;
        }

        public override string Info()
        {
            return base.Info() + string.Format("\nКоличество - {0}\nДата производства - {1}\nСрок годности - {2} дней", _count, ManufactureDate, WorkingLife);
        }
    }
    //komplekt
    internal class Set : Commodity
    {
        private string _list;
        public Set(string name, int price, string list)
        {
            _list = list;
            Name = name;
            Price = price;
        }

        public override string Info()
        {
            return base.Info() + string.Format("\nПеречень продуктов - {0}", _list);
        }

        public override bool IsCorrespondsToWorkingLife(DateTime currentDate)
        {
            return true;
        }
    }
}

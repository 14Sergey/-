using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin
{
    public class Tovar
    {
        string Name;
        int Days;
        float Price;
        public Tovar(string Name, int Days, float Price)
        {
            this.Name = Name;
            this.Days = Days;
            this.Price = Price;
        }
        public float UpdateGoods()
        {
            if (Days == 0)
            {
                if (Name == "Билет на концерт")
                {
                    Price = 0;
                    return Price;
                }
                if (Name != "Мечь короля Артура")
                    Price /= 2;
                int price = (int)(Price * 100);
                Price = (float)price / 100;
            }
            else
            {
                if (Name == "Коньяк")
                {
                    Days--;
                    Price++;
                    if (Price > 50)
                        Price = 50;
                    return Price;
                }
                if (Name == "Билет на концерт")
                {
                    if (Days > 10)
                        Price++;
                    if (Days <= 10 && Days > 5)
                        Price += 2;
                    if (Days <= 5 && Days > 0)
                        Price += 3;
                    if (Price > 50)
                        Price = 50;
                    Days--;
                    return Price;
                }
                if (Name != "Мечь короля Артура")
                {
                    Days--;
                    Price--;
                }
            }
            return Price;
        }
    }
}

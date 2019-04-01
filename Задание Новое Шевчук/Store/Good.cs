using System;

namespace Store
{
    public class Good
    {
        string name;
        int days;
        float price;
        public Good(string name, int days, float price)
        {
            this.name = name;
            this.days = days;
            this.price = price;
        }
        public float UpdateGoods()
        {
            int priceaddition = 0, price = 1, days = 1, maxprice = 50;
            if (name == "Мечь короля Артура")
                return this.price;
            if (name == "Билет на концерт")
            {
                if (this.days <= 0)
                    this.price = 0;
                else
                {
                    this.days -= days;
                    if (this.days <= 10)
                    {
                        if (this.days <= 5)
                        {
                            this.price += 3;
                            if (this.price > maxprice)
                                this.price = maxprice;
                            return this.price;
                        }
                        this.price += 2;
                        if (this.price > maxprice)
                            this.price = maxprice;
                        return this.price;
                    }
                    this.price += price;
                }
                if (this.price > maxprice)
                    this.price = maxprice;
                return this.price;
            }
            if (name == "Коньяк")
            {
                if (this.days <= 0)
                {
                    this.days = 0;
                    this.price /= 2;
                    priceaddition = (int)(this.price * 100);
                    this.price = (float)priceaddition / 100;
                }
                else
                {
                    this.price += price;
                    this.days -= days;
                    if (this.price > maxprice)
                        this.price = maxprice;
                }
                return this.price;
            }
            if (this.days <= 0)
            {
                this.days = 0;
                this.price /= 2;
                priceaddition = (int)(this.price * 100);
                this.price = (float)priceaddition / 100;
            }
            else
            {
                this.price -= price;
                this.days -= days;
            }
            return this.price;
        }
    }
}

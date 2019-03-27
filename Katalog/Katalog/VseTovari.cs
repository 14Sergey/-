using System.Collections.Generic;

namespace курсовой
{
    public class VseTovari
    {
        public List<Tovar> tovari;
        public VseTovari()
        {
            tovari=new List<Tovar>();
        }
        public void addtovar(Tovar elem)
        {
            tovari.Insert(0,elem);
        }
    }
}

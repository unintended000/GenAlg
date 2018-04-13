using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenAldLibrary
{
  public  class cSpecies
    {
        public bool[] Gene;

        /// <summary>
        /// Стоимость (Важность)
        /// </summary>
        public int Weight;
        
        /// <summary>
        /// Вес (Цена)
        /// </summary>
        public int Price;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Count">К-во генов</param>
        /// <param name="_Weight">Стоимость</param>
        /// <param name="_Price">Цена</param>
        public cSpecies(int Count, int[] _Weight, int[] _Price)
        {
            Random rnd = new Random();

            Gene = new bool[Count];
            
            
            for (int i = 0; i < Count;i++)
            {
                
                Gene[i] = (rnd.Next(0,2) == 1) ? true : false;
            }

            Get_Weight_Price(_Weight, _Price);

        }


       
       public void  Get_Weight_Price(int[] _Weight, int[] _Price)
        {
            Weight = 0;
            Price = 0;
            for (int i=0; i < Gene.Count(); i++)
            {
                Weight += (Gene[i]) ? _Weight[i]: 0;
                Price += (Gene[i]) ? _Price[i] : 0;
            }


        }
        

    }
}

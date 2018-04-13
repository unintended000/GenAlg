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
        public cSpecies(int Count)
        {
            Gene = new bool[Count];
            

        }

        public  cSpecies New_Species(int Count, int[] _Weight, int[] _Price)
        {
            cSpecies Species = new cSpecies(Count);
            
            Random rnd = new Random();

            for (int i = 0; i < Count; i++)
            {

                Species.Gene[i] = (rnd.Next(0, 2) == 1) ? true : false;
            }

            Get_Weight_Price(Species, _Weight, _Price);

            return Species;
        }
            

       
       public  void  Get_Weight_Price(cSpecies Species, int[] _Weight, int[] _Price)
        {
            Species.Weight = 0;
            Species.Price = 0;
            for (int i=0; i < Species.Gene.Count(); i++)
            {
                
                Species.Weight += (Species.Gene[i]) ? _Weight[i]: 0;
                Species.Price += (Species.Gene[i]) ? _Price[i] : 0;
            }


        }
        

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GenAldLibrary
{
   public class cGenAlg
    {
        /// <summary>
        /// Стоимость (Важность)
        /// </summary>
        public int[] Weight_Genes;

        /// <summary>
        /// Вес (Цена)
        /// </summary>
        public int[] Price_Genes;

        /// <summary>
        /// К-во генов 1 особи
        /// </summary>
        public int Count_Genes;

        /// <summary>
        /// Максмальные вес (Цена)
        /// </summary>
        public int MaxPrice;

        /// <summary>
        /// К-во родителей
        /// </summary>
        private int Count_Parent;

        public cSpecies[] Population;
        private cSpecies[] Parent;

        /// <summary>
        /// Ген. Алгоритм
        /// </summary>
        /// <param name="CountSpecies">К-во особей</param>
        /// <param name="_Count_Genes">К-во генов</param>
        /// <param name="_Weight_Genes">Стоимость</param>
        /// <param name="_Price_Genes">Вес</param>
        public cGenAlg(int CountSpecies, int _Count_Genes, int[] _Weight_Genes, int[] _Price_Genes, int _MaxPrice,int _Count_Parent)
        {
            Population = new cSpecies[CountSpecies];
            Weight_Genes = _Weight_Genes;
            Price_Genes = _Price_Genes;
            Count_Genes = _Count_Genes;
            Count_Parent = _Count_Parent;
            MaxPrice = _MaxPrice;

            //Создаем первую популяцию
            New_GenAlg(CountSpecies);
            Get_parents(Population, Count_Parent);
            Get_new_population(Parent);

            
        }

        /// <summary>
        /// Создать первую популяцию
        /// </summary>
        /// <param name="CountSpecies"></param>
        private void New_GenAlg(int CountSpecies) {
            
            for (int i = 0; i < CountSpecies; i++)
            {
              
                cSpecies Species= new cSpecies(Count_Genes, Weight_Genes, Price_Genes);
                Population[i] = Species;
                Thread.Sleep(20); //Костыли подъехали
              
            }
        }

        /// <summary>
        /// Сортировка массива пузырьком
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private cSpecies[] Sort(cSpecies[] Population)
        {

            for (int i = 0; i < Population.Count() - 1; i++)
            {
                for (int j = 0; j < Population.Count() - 1; j++)
                    if (Population[j].Weight > Population[j + 1].Weight)
                    {
                        Population[j].Weight =  Population[j].Weight + Population[j + 1].Weight;
                        Population[j + 1].Weight = Population[j].Weight - Population[j + 1].Weight;
                        Population[j].Weight = Population[j].Weight - Population[j + 1].Weight;
                    }
            }
            return Population;
        }

        /// <summary>
        /// Выбрать родителей для скрещивания
        /// </summary>
        /// <param name="Population"></param>
        /// <param name="Count"></param>
        private void Get_parents(cSpecies[] Population, int Count_Parent)
        {
            Sort(Population);
            Parent = new cSpecies[Count_Parent];
            for (int i=0; i < Count_Parent; i++)
            {
                Parent[i] = Population[i];
            }

        }

        private void Get_new_population(cSpecies[] Parent)
        {
            Random rnd = new Random();
            cSpecies[] New_Population = new cSpecies[Population.Count()];
            bool[] NewGene = new bool[Count_Genes];
           

            for (int i=0; i < Population.Count(); i++)
            {
                //Выбираем случайных родителей
                cSpecies Parent1 = Parent[rnd.Next(Count_Parent + 1)];
                cSpecies Parent2 = Parent[rnd.Next(Count_Parent + 1)];
                //Собираем новые гены
                for (int j = 0; j < Count_Genes;j++)
                {
                    if (j % 2 == 0)
                        NewGene[j] = Parent1.Gene[j];
                    else NewGene[j] = Parent2.Gene[j];

                }
                New_Population[i].Gene = NewGene;
                  
            }

        }
        
    }
}
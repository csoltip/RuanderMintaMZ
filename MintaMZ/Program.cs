using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaMZ
{
    class Program
    {
        class Auto
        {
            public int ertek;
        }

        static void Main(string[] args)
        {
            //fájl beolvasás
            string[] sorok = File.ReadAllLines("forras.csv");
            List<Auto> autok = new List<Auto>();
            foreach (string sor in sorok.Skip(1))//skip, ha van fejléc
            {
                autok.Add(new Auto());
            }

            /* innen csak az autok listával foglalkozunk */

            //adatok száma
            int N = autok.Count;

            //legvalamilyenebb
            /* szélsőérték keresés */
            int minIndex = 0, maxIndex = 0;
            for (int i = 1; i < N; i++)
            {
                if(autok[i].ertek > autok[maxIndex].ertek)
                {
                    maxIndex = i;
                }
                if (autok[i].ertek < autok[minIndex].ertek)
                {
                    minIndex = i;
                }
            }
            Console.WriteLine($"a legnagyobb: {autok[maxIndex]}, a legkisbb: {autok[minIndex]}");

            //van e egy valamilyen

            //mindenki valamiylen e

            //hányféle van

            //melyikből mennyi van

            //fájlkiírás
        }
    }
}

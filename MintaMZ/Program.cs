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
            public string tipus;
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

            //van e egy valamilyen: van 12000 értéknél kisebb? van megfizethető?
            /* eldöntés I. */
            int i = 0;
            while(i < N && !(T)) { i++; }//T: mit vizsgálunk?, pl (autok[i].ertek < 12000) vagy (megfizethetoE(autok[i].ertek))
            bool van = i < N; //i < N || i >= N;

            //mindenki valamilyen e: mind 12000 értéknél kisebb? mind megfizethető?
            /* eldöntés II. */
            i = 0;
            while (i < N && T) { i++; }//T: mit vizsgálunk?, pl (autok[i].ertek < 12000) vagy (megfizethetoE(autok[i].ertek))
            bool mind = i >= N;

            //hányféle van, melyek ezek: hányféle érték van a listában?
            /* HashSet<> */
            HashSet<int> ertekek = new HashSet<int>();
            foreach (Auto auto in autok)
            {
                ertekek.Add(auto.ertek);
            }
            //kiíás:
            foreach (int ertek in ertekek)
            {
                Console.WriteLine(ertek);
            }


            //melyikből mennyi van? melyik típusból hány darab van a listában
            /* Dictionary<string, int> */
            Dictionary<string, int> tipusDb = new Dictionary<string, int>();
            foreach (Auto auto in autok)
            {
                string kulcs = auto.tipus;
                if (tipusDb.ContainsKey(kulcs))
                {
                    tipusDb[kulcs]++;
                }
                else
                {
                    tipusDb.Add(kulcs, 1);
                }
            }
            //kiírás:
            foreach (KeyValuePair<string, int> item in tipusDb)
            {
                Console.WriteLine($"{item.Key} típusból {item.Value} darab");
            }

            //fájlkiírás
            string fn = "statisztika.txt";
            /* ha egy stringben van: */
            string kimenet = "ezt írom ki, ez lesz a fájlban";
            File.WriteAllText(fn, kimenet);//bin/Debug mappába jön majd létre statisztika.txt néven a kimenet tartalma

            /* ha string[] amit ki kell írni: */
            string[] kiirandoSorok = new string[3];
            File.WriteAllLines(fn, kiirandoSorok);//bin/Debug mappába jön majd létre statisztika.txt néven a kiirandoSorok tartalma alapján
        }
    }
}

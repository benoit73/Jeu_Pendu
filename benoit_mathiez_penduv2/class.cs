using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace benoit_mathiez_penduv2
{
   
    public class LaClass
    {
        List<string> list = new List<string>();
        public string Mot { get; set; }
        public string MotCache { get; set; }
        public bool Gagne { get; set; }
        public int NbMort { get; set; }
        public bool BonneLettre { get; set; }
        public int NbJokers { get; set; }
        public char LettreJoker { get; set; }

        public void ListDeMot()
        {
            StreamReader stream = new StreamReader("mots.txt");
            string line;
            while ((line = stream.ReadLine()) != null)
            {
                list.Add(line);
            }
        }

        public void SelectMot()
        {
            int listLength = list.Count;
            Random random = new Random();
            int nombreAleatoire = random.Next(0, listLength); 

            Mot = list[nombreAleatoire];
            list.RemoveAt(nombreAleatoire);

            string motCachee = new string('*', Mot.Length);
            MotCache = motCachee;
            Gagne = false;
            NbMort = 0;
        }

        public void TesterLettre(char lettre)
        {
            BonneLettre = false;
            char[] charArray = MotCache.ToCharArray();

            for (int i = 0; i < Mot.Length; i++)
            {
                if (Mot[i] == lettre)
                {
                    charArray[i] = lettre;
                    BonneLettre = true;
                }
            }
            MotCache = new string(charArray);

            if (MotCache.Contains("*") == false)
            {
                Gagne = true;
            }

            if (BonneLettre == false)
            {
                NbMort++;              
            }
        }

        
        public void ChooseLettreJoker()
        {
            char[] bonMot = Mot.ToCharArray();
            char[] motCache = MotCache.ToCharArray();
            int longueur = bonMot.Length;
            List<char> bonnesLettres;
            bonnesLettres = new List<char>();

            for (int x=0; x<longueur; x++)
            {
                if (bonMot[x] != motCache[x])
                {
                    bonnesLettres.Add(bonMot[x]);
                }
            }

            Random random = new Random();

            int longueurList = bonnesLettres.Count;
            int indexRandom = random.Next(0, longueurList);
            char lettre = bonnesLettres[indexRandom];
            LettreJoker = lettre;
        }










    }
}

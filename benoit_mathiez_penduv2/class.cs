using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace benoit_mathiez_penduv2
{
    public class LaClass
    {
        List<string> list = new List<string>();  // Liste pour stocker les mots
        public string Mot { get; set; }  // Mot actuel en jeu
        public string MotCache { get; set; }  // Mot masqué affiché à l'utilisateur
        public bool Gagne { get; set; }  // Indique si le joueur a gagné
        public int NbMort { get; set; }  // Nombre de tentatives infructueuses
        public bool BonneLettre { get; set; }  // Indique si la lettre proposée est correcte
        public int NbJokers { get; set; }  // Nombre de jokers disponibles
        public char LettreJoker { get; set; }  // Lettre obtenue en utilisant un joker

        // Charge la liste de mots depuis un fichier texte
        public void ListDeMot()
        {
            StreamReader stream = new StreamReader("mots.txt");
            string line;
            while ((line = stream.ReadLine()) != null)
            {
                list.Add(line);
            }
        }

        // Sélectionne un mot aléatoire depuis la liste et initialise le jeu
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

        // Teste si une lettre proposée est correcte
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

        // Choix d'une lettre en utilisant un joker
        public void ChooseLettreJoker()
        {
            char[] bonMot = Mot.ToCharArray();
            char[] motCache = MotCache.ToCharArray();
            int longueur = bonMot.Length;
            List<char> bonnesLettres;
            bonnesLettres = new List<char>();

            for (int x = 0; x < longueur; x++)
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

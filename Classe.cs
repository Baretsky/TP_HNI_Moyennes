using System;
using System.Collections.Generic;
using System.Linq;

namespace HNI_TPmoyennes
{
    class Classe
    {
        public string nomClasse { get; private set; }
        public List<Eleve> eleves { get; private set; }
        public List<string> matieres { get; private set; }
        private const int MAX_ELEVES = 30;
        private const int MAX_MATIERES = 10;

        public Classe(string nomClasse)
        {
            this.nomClasse = nomClasse;
            this.eleves = new List<Eleve>();
            this.matieres = new List<string>();
        }

        public bool ajouterEleve(string prenom, string nom)
        {
            if (eleves.Count >= MAX_ELEVES)
            {
                Console.WriteLine($"Erreur: Impossible d'ajouter {prenom} {nom}. Maximum de {MAX_ELEVES} élèves par classe atteint.");
                return false;
            }
            eleves.Add(new Eleve(prenom, nom));
            return true;
        }

        public bool ajouterMatiere(string matiere)
        {
            if (matieres.Count >= MAX_MATIERES)
            {
                Console.WriteLine($"Erreur: Impossible d'ajouter la matière {matiere}. Maximum de {MAX_MATIERES} matières par classe atteint.");
                return false;
            }
            matieres.Add(matiere);
            return true;
        }

        public float moyenneMatiere(int matiere)
        {
            if (!eleves.Any())
                return 0.0f;
            
            var moyennes = eleves.Select(e => e.moyenneMatiere(matiere)).Where(m => m > 0);
            if (!moyennes.Any())
                return 0.0f;
                
            float moyenne = moyennes.Average();
            return (float)Math.Truncate(moyenne * 100) / 100;
        }

        public float moyenneGeneral()
        {
            if (!eleves.Any())
                return 0.0f;
                
            var moyennes = eleves.Select(e => e.moyenneGeneral()).Where(m => m > 0);
            if (!moyennes.Any())
                return 0.0f;
                
            float moyenne = moyennes.Average();
            return (float)Math.Truncate(moyenne * 100) / 100;
        }
    }
}
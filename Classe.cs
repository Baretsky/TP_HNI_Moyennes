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

        public Classe(string nomClasse)
        {
            this.nomClasse = nomClasse;
            this.eleves = new List<Eleve>();
            this.matieres = new List<string>();
        }

        public void ajouterEleve(string prenom, string nom)
        {
            eleves.Add(new Eleve(prenom, nom));
        }

        public void ajouterMatiere(string matiere)
        {
            matieres.Add(matiere);
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
using System;
using System.Collections.Generic;
using System.Linq;

namespace HNI_TPmoyennes
{
    class Eleve
    {
        public string prenom { get; private set; }
        public string nom { get; private set; }
        public List<Note> notes { get; private set; }
        private const int MAX_NOTES = 200;

        public Eleve(string prenom, string nom)
        {
            this.prenom = prenom;
            this.nom = nom;
            this.notes = new List<Note>();
        }

        public bool ajouterNote(Note note)
        {
            if (notes.Count >= MAX_NOTES)
            {
                Console.WriteLine($"Erreur: Impossible d'ajouter une note à {prenom} {nom}. Maximum de {MAX_NOTES} notes par élève atteint.");
                return false;
            }
            notes.Add(note);
            return true;
        }

        public float moyenneMatiere(int matiere)
        {
            var notesMatiere = notes.Where(n => n.matiere == matiere);
            if (!notesMatiere.Any())
                return 0.0f;
            float moyenne = notesMatiere.Average(n => n.note);
            return (float)Math.Truncate(moyenne * 100) / 100;
        }

        public float moyenneGeneral()
        {
            if (!notes.Any())
                return 0.0f;
            float moyenne = notes.Average(n => n.note);
            return (float)Math.Truncate(moyenne * 100) / 100;
        }
    }
}
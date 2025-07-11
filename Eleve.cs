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

        public Eleve(string prenom, string nom)
        {
            this.prenom = prenom;
            this.nom = nom;
            this.notes = new List<Note>();
        }

        public void ajouterNote(Note note)
        {
            notes.Add(note);
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
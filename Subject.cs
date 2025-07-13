using System;

namespace HNI_TPmoyennes
{
    class Subject
    {
        public int id { get; private set; }
        public string nom { get; private set; }

        public Subject(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }
    }
}
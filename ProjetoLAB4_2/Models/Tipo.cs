using System;
using System.Collections.Generic;

namespace ProjetoLAB4_2.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            Vinho = new HashSet<Vinho>();
        }

        public int Id { get; set; }
        public string Tipo1 { get; set; }

        public virtual ICollection<Vinho> Vinho { get; set; }
    }
}

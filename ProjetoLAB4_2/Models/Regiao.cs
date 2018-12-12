using System;
using System.Collections.Generic;

namespace ProjetoLAB4_2.Models
{
    public partial class Regiao
    {
        public Regiao()
        {
            Vinho = new HashSet<Vinho>();
        }

        public int Id { get; set; }
        public string Regiao1 { get; set; }

        public virtual ICollection<Vinho> Vinho { get; set; }
    }
}

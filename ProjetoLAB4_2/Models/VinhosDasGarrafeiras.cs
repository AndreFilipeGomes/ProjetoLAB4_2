using System;
using System.Collections.Generic;

namespace ProjetoLAB4_2.Models
{
    public partial class VinhosDasGarrafeiras
    {
        public int IdVinho { get; set; }
        public int IdGarrafeira { get; set; }
        public string Descricao { get; set; }
        public int Stock { get; set; }
        public int Preco { get; set; }

        public virtual Garrafeira IdGarrafeiraNavigation { get; set; }
        public virtual Vinho IdVinhoNavigation { get; set; }
    }
}

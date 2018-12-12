using System;
using System.Collections.Generic;

namespace ProjetoLAB4_2.Models
{
    public partial class Comentario
    {
        public int IdVinho { get; set; }
        public int IdCliente { get; set; }
        public DateTime Data { get; set; }
        public string Texto { get; set; }

        public virtual Utilizador IdClienteNavigation { get; set; }
        public virtual Vinho IdVinhoNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ProjetoLAB4_2.Models
{
    public partial class Recomendacao
    {
        public int IdEnvio { get; set; }
        public int IdRecepcao { get; set; }
        public DateTime Data { get; set; }
        public bool Estado { get; set; }

        public virtual Utilizador IdEnvioNavigation { get; set; }
        public virtual Utilizador IdRecepcaoNavigation { get; set; }
    }
}

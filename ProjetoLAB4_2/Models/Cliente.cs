using System;
using System.Collections.Generic;

namespace ProjetoLAB4_2.Models
{
    public partial class Cliente
    {
        public int IdUtilizador { get; set; }

        public virtual Utilizador IdUtilizadorNavigation { get; set; }
    }
}

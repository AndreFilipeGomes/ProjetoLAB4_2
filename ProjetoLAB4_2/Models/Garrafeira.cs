using System;
using System.Collections.Generic;

namespace ProjetoLAB4_2.Models
{
    public partial class Garrafeira
    {
        public Garrafeira()
        {
            VinhosDasGarrafeiras = new HashSet<VinhosDasGarrafeiras>();
        }

        public int IdUtilizador { get; set; }
        public int ContactoTelemovel { get; set; }
        public int ContactoTelefone { get; set; }
        public string Descricao { get; set; }
        public string Fotografia { get; set; }

        public virtual Utilizador IdUtilizadorNavigation { get; set; }
        public virtual ICollection<VinhosDasGarrafeiras> VinhosDasGarrafeiras { get; set; }
    }
}

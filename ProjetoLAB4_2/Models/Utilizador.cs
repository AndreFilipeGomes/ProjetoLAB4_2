using System;
using System.Collections.Generic;

namespace ProjetoLAB4_2.Models
{
    public partial class Utilizador
    {
        public Utilizador()
        {
            AdministrarUtilizador = new HashSet<AdministrarUtilizador>();
            Comentario = new HashSet<Comentario>();
            RecomendacaoIdEnvioNavigation = new HashSet<Recomendacao>();
            RecomendacaoIdRecepcaoNavigation = new HashSet<Recomendacao>();
        }

        public string Username { get; set; }
        public int Estado { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public int CodPostal { get; set; }
        public int IdMorada { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Garrafeira Garrafeira { get; set; }
        public virtual ICollection<AdministrarUtilizador> AdministrarUtilizador { get; set; }
        public virtual ICollection<Comentario> Comentario { get; set; }
        public virtual ICollection<Recomendacao> RecomendacaoIdEnvioNavigation { get; set; }
        public virtual ICollection<Recomendacao> RecomendacaoIdRecepcaoNavigation { get; set; }
    }
}

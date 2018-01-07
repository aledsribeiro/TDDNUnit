using System.Collections.Generic;
namespace Caelum.Leilao
{

    public class Leilao
    {

        public string Descricao { get; set; }
        public IList<Lance> Lances { get; set; }

        public Leilao(string descricao)
        {
            this.Descricao = descricao;
            this.Lances = new List<Lance>();
        }

        public void Propoe(Lance lance)
        {
            if (Lances.Count == 0 || VerificarPodeDarLance(lance.Usuario))
                Lances.Add(lance);
        }

        private bool VerificarPodeDarLance(Usuario usuario)
        {
            int quantidadeLancesUsuario = VerificarQualtidadeUsuarioLance(usuario);
            return (!ultimoLanceDados().Usuario.Equals(usuario) && quantidadeLancesUsuario < 5);
        }

        private int VerificarQualtidadeUsuarioLance(Usuario usuario)
        {
            int quantidadeLancesUsuario = 0;
            foreach (var item in Lances)
            {
                if (item.Usuario.Equals(usuario))
                    quantidadeLancesUsuario++;
            }

            return quantidadeLancesUsuario;
        }

        private Lance ultimoLanceDados()
        {
            return Lances[Lances.Count - 1];
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    /// <summary>
    /// 
    /// </summary>
    public class CriadorLeilao
    {
        private Leilao leilao;

        public CriadorLeilao ProdutoLeilao(string nomeProdutoLeiloado)
        {
            leilao = new Leilao(nomeProdutoLeiloado);
            return this;
        }

        public CriadorLeilao Lance(Usuario usuario, double valor)
        {
            leilao.Propoe(new Lance(usuario, valor));
            return this;
        }

        public Leilao ConstruirLeilao()
        {
            return leilao;
        }
    }
}

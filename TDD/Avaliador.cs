using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public class Avaliador
    {
        private double _maiorValorLance = double.MinValue;
        private double _menorValorLance = double.MaxValue;
        private List<Lance> listaDeMaioresLances;
        public List<Lance> tresMaiores { get { return listaDeMaioresLances; } }


        public double ObterMaiorLance { get { return _maiorValorLance; } }
        public double ObterMenorLance { get { return _menorValorLance; } }

        public void Avalia(Leilao leilao)
        {
            if(leilao.Lances.Count() == 0)
            {
                throw new Exception("Não é possivel sem lances");
            }

            foreach (var lance in leilao.Lances)
            {
                if(lance.Valor > _maiorValorLance)
                {

                    _maiorValorLance = lance.Valor;
                }
                if(lance.Valor < _menorValorLance)
                {
                    _menorValorLance = lance.Valor;
                }

                ObterOsMaioresLeilao(leilao);
            }

           

        }

        private void ObterOsMaioresLeilao(Leilao leilao)
        {
            listaDeMaioresLances = new List<Lance>(leilao.Lances.OrderByDescending(x=> x.Valor));
            listaDeMaioresLances = listaDeMaioresLances.GetRange(0, listaDeMaioresLances.Count > 3 ? 3 : listaDeMaioresLances.Count);
        }



    }
}

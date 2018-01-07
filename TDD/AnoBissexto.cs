using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    /*
     Desafio: Implemente a classe AnoBissexto, que contenha o método bool EhBissexto(int ano).
     A ideia dessa classe é calcular se um ano é bissexto ou não.

    Um ano bissexto é aquele que tem 366 dias. Para saber se um ano é bissexto, devemos seguir as regras abaixo: 
    - De 4 em 4 anos é ano bissexto. 
    - De 100 em 100 anos não é ano bissexto. 
    - De 400 em 400 anos é ano bissexto. 
    - Prevalecem as últimas regras sobre as primeiras.
    */

    public class AnoBissexto
    {
        public bool VerificarSeAnoBissexto(int ano)
        {
            int resultado = ano % 4;

            if (resultado == 0)
                return true;
            else
                return false;

        }


    }
}

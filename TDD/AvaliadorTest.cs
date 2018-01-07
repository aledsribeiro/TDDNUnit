using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    /// <summary>
    /// Classes de equivalencia - classes 
    /// </summary>
    [TestFixture]
    public class AvaliadorTest
    {

        private Avaliador leiloeiro;
        private Usuario joao;
        private Usuario jose;
        private Usuario maria;

        /// <summary>
        /// Método executado no setup do teste
        /// </summary>
        [SetUp]
        public void SetupTeste()
        {
            leiloeiro = new Avaliador();
            joao = new Usuario("João");
            jose = new Usuario("José");
            maria = new Usuario("Maria");
            Console.WriteLine("Executando o setup do teste");

        }

        [Test]
        public void DeveEntenderLancesEmOrdeCrescente()
        {
            //1º parte : cenario
            
            Leilao leilao = new Leilao("Playstation 4");
            leilao.Propoe(new Lance(joao, 250.0));
            leilao.Propoe(new Lance(jose, 300.0));
            leilao.Propoe(new Lance(maria, 400.0));

            //2º parte : executa uma ação
            leiloeiro.Avalia(leilao);

            //3º parte : validação
            double menorValor = 250.0;
            double maiorValor = 400.0;

            Assert.AreEqual(maiorValor,leiloeiro.ObterMaiorLance);
            Assert.AreEqual(menorValor,leiloeiro.ObterMenorLance);
        }

        [Test]
        public void DeveEntenderLeilaoComApenasUmLance()
        {
            Leilao leilao = new Leilao("Playstation 4");

            leilao.Propoe(new Lance(joao, 1000.0));
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(1000, leiloeiro.ObterMaiorLance,0.0001);
            Assert.AreEqual(1000, leiloeiro.ObterMenorLance, 0.0001);
        }

        [Test]
        public void DeveEncontrarOsTresMaioresLances()
        {
            Leilao leilao = new CriadorLeilao().ProdutoLeilao("TV LCD 50'")
                .Lance(joao, 100)
                .Lance(maria, 200)
                .Lance(joao, 300)
                .Lance(maria, 400)
                .ConstruirLeilao();
          
            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.tresMaiores;

            //sempre que for retorno de lista fazer o assert no tamanho da lista
            //e no seu conteudo
            Assert.AreEqual(3, maiores.Count);
            Assert.AreEqual(400, maiores[0].Valor, 0.0001);
            Assert.AreEqual(300, maiores[1].Valor, 0.0001);
            Assert.AreEqual(200, maiores[2].Valor, 0.0001);
        }



        /*
        Atributos úteis quando temos algum recurso que precisa ser inicializado apenas
        uma vez e que pode ser consumido por todos os métodos de teste sem a necessidade de ser reinicializado. 
        */

        /// <summary>
        /// Método executado apenas uma vez antes de todos os métodos
        /// </summary>
       // [TestFixtureSetUp]
        public void TestandoBeforeClass()
        {
            Console.WriteLine("test fixture setup");
        }

        /// <summary>
        /// Método executado apenas uma vez após a execução do ultimo metodo da classe
        /// </summary>
        //[TestFixtureTearDown]
        public void TestandoAfterClass()
        {
            Console.WriteLine("test fixture tear down");
        }

        /// <summary>
        /// Método para testar a exceção
        /// </summary>
        [Test]
        //[ExpectedException(typeof(Exception))]
        public void NaoPodeAvaliarLeilaoSemLance()
        {
            Leilao leilao = new CriadorLeilao().ProdutoLeilao("PS4").ConstruirLeilao();

            leiloeiro.Avalia(leilao);
        }
    }

   
}

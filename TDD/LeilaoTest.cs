using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    [TestFixture]
    public class LeilaoTest
    {
        [Test]
        public void DeveReceberUmLance()
        {
            Leilao leilao = new Leilao("Notebook");
            Assert.AreEqual(0, leilao.Lances.Count);

            leilao.Propoe(new Lance(new Usuario("Alessandra"), 2000));

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor, 0.00001);
        }

        [Test]
        public void DeveReceberVariosLances()
        {
            Leilao leilao = new Leilao("Notebook");
            leilao.Propoe(new Lance(new Usuario("Alessandra"), 1550));
            leilao.Propoe(new Lance(new Usuario("Jeffersonn"), 1650));

            Assert.AreEqual(2, leilao.Lances.Count);
            Assert.AreEqual(1550, leilao.Lances[0].Valor, 0.00001);
            Assert.AreEqual(1650, leilao.Lances[1].Valor, 0.00001);
        }

        [Test]
        public void NaoDeveAceitarDoisLancesSeguidosDoMesmoUsuario()
        {
            Leilao leilao = new Leilao("Notebook");
            leilao.Propoe(new Lance(new Usuario("Alessandra"), 1550));
            leilao.Propoe(new Lance(new Usuario("Alessandra"), 1650));

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(1550, leilao.Lances[0].Valor, 0.00001);


        }

        [Test]
        public void NãoDeveAceitarCincoLancesDeUmMesmoUsuario()
        {
            Leilao leilao = new Leilao("Notebook");
            leilao.Propoe(new Lance(new Usuario("Alessandra"), 1550));
            leilao.Propoe(new Lance(new Usuario("Jeffersonn"), 1650));

            leilao.Propoe(new Lance(new Usuario("Alessandra"), 2000));
            leilao.Propoe(new Lance(new Usuario("Jeffersonn"), 2250));

            leilao.Propoe(new Lance(new Usuario("Alessandra"), 3500));
            leilao.Propoe(new Lance(new Usuario("Jeffersonn"), 3750));

            leilao.Propoe(new Lance(new Usuario("Alessandra"), 4000));
            leilao.Propoe(new Lance(new Usuario("Jeffersonn"), 4250));

            leilao.Propoe(new Lance(new Usuario("Alessandra"), 4500));
            leilao.Propoe(new Lance(new Usuario("Jeffersonn"), 4750));

            //deve ser igonrado
            leilao.Propoe(new Lance(new Usuario("Alessandra"), 5000));

            Assert.AreEqual(10, leilao.Lances.Count);
            var ultimo = leilao.Lances.Count - 1;
            Lance ultimoLance = leilao.Lances[ultimo];

            Assert.AreEqual(4750, ultimoLance.Valor, 0.00001);
        }
    }
}

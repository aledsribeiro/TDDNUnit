using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    [TestFixture]
    public class AnoBissextoTest
    {
        [Test]
        public void VerificarAnoBissexto()
        {
            AnoBissexto ano = new AnoBissexto();

            Assert.AreEqual(true, ano.VerificarSeAnoBissexto(2016));
            Assert.AreEqual(true, ano.VerificarSeAnoBissexto(2020));
            Assert.AreEqual(true, ano.VerificarSeAnoBissexto(2024));
            Assert.AreEqual(true, ano.VerificarSeAnoBissexto(2028));
            Assert.AreEqual(true, ano.VerificarSeAnoBissexto(2032));
            Assert.AreEqual(true, ano.VerificarSeAnoBissexto(2036));

        }
    }
}

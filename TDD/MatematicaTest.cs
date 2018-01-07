using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    [TestFixture]
    public class MatematicaTest
    {
        [Test]
        public void NumeroMaiorQueTrinta()
        {
            MatematicaMaluca matematica = new MatematicaMaluca();
            Assert.AreEqual(50 * 4, matematica.ContaMaluca(31));
        }

        [Test]
        public void NumeroMaiorQueDez()
        {
            MatematicaMaluca matematica = new MatematicaMaluca();
            Assert.AreEqual(20 * 3, matematica.ContaMaluca(12));
        }

        [Test]
        public void MenorQueTrintaEDez()
        {
            MatematicaMaluca matematica = new MatematicaMaluca();
            Assert.AreEqual(5 * 2, matematica.ContaMaluca(9));
        }
    }
}

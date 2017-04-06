using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NFLDAL;
using NFLCommon;
using NFLBLL;

namespace NFLDAL.Test
{
    [TestFixture]
    public class RandomTests
    {
        [Test]
        public void TestSomething()
        {
            StatsBL statsBL = new StatsBL(null, null, null, null, null, null, null, null, null, null, null);

            double points = statsBL.getOffensiveFantasyPointsForPlayerByDateRange(Guid.Parse("153C007D-A891-470B-99B0-D0B7980CDF42"), new DateTime(2014, 8, 1), new DateTime(2015, 2, 1), true);
        }
    }
}

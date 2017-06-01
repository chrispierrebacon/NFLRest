using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFLDALEF;

namespace NFLDALEF.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            PlayerDal playerDal = new PlayerDal();
            playerDal.InsertPositions();
        }
    }
}

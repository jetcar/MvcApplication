using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApplication.Models;
using MvcApplication.Utils;

namespace MvcApplication.Tests.Utils
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPremium()
        {
            var premoiumClient = new PremiumClient();

            var client = ObjectCopier.Clone(premoiumClient);
            Assert.IsTrue(client is PremiumClient);
        }
        [TestMethod]
        public void TestRegular()
        {
            var premoiumClient = new RegularClient();

            var client = ObjectCopier.Clone(premoiumClient);
            Assert.IsTrue(client is RegularClient);
        }
    }
}

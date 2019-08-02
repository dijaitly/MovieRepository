using System;
using ComcastMoviesApplication.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComcastMovieApplication.Tests
{
    [TestClass]
    public class RoundingHelperTest
    {
        [TestMethod]
        public void TestRounding()
        {
            Assert.AreEqual(3.00, RoundingHelper.Round(3.249));
            Assert.AreEqual(3.50, RoundingHelper.Round(3.25));
            Assert.AreEqual(3.50, RoundingHelper.Round(3.6));
            Assert.AreEqual(4.00, RoundingHelper.Round(3.75));
        }
    }
}

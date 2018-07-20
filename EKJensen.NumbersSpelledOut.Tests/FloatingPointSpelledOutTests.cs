using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EKJensen.NumbersSpelledOut.Tests
{
    [TestClass]
    public class FloatingPointSpelledOutTests
    {
        [TestMethod]
        public void Floating_point_number_writes_text()
        {
            var text = ((float)12.3).ToNumberString();

            Assert.AreEqual("twelve point three", text);
        }
    }
}

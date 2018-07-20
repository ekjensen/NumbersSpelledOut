using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EKJensen.NumbersSpelledOut.Tests
{
    [TestClass]
    public class CheckAnnotationsSpelledOutTests
    {
        [TestMethod]
        public void Check_annotation_spelled_out_in_hundreths()
        {
            var twentyDollars = (20.0).ToCheckAnnotation();

            Assert.AreEqual("twenty dollars and 0/100", twentyDollars);
        }
    }
}

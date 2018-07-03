using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberConverter.Tests
{
    [TestClass]
    public class NumberToTextConverterTests
    {
        [TestMethod]
        public void Converts_thousands_properly()
        {
            var numberConverter = new NumberToTextConverter(LetterCase.LowerCase);

            var oneThousand = numberConverter.GetText(1000);
            var nineThousand = numberConverter.GetText(9000);

            Assert.AreEqual("one thousand", oneThousand);
            Assert.AreEqual("nine thousand", nineThousand);
        }

        [TestMethod]
        public void Converts_full_number_properly()
        {
            var numberConverter = new NumberToTextConverter(LetterCase.LowerCase);

            var bigNumber = numberConverter.GetText(9876);

            Assert.AreEqual("nine thousand eight hundred and seventy six", bigNumber);
        }
    }
}

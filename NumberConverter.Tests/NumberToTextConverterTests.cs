using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberConverter.Tests
{
    [TestClass]
    public class NumberToTextConverterTests
    {
        [TestMethod]
        public void Converts_thousands()
        {
            var numberConverter = new NumberToTextConverter(LetterCase.LowerCase);

            var oneThousand = numberConverter.GetText(1000);
            var nineThousand = numberConverter.GetText(9000);

            Assert.AreEqual("one thousand", oneThousand);
            Assert.AreEqual("nine thousand", nineThousand);
        }

        [TestMethod]
        public void Converts_hundreds()
        {
            var numberConverter = new NumberToTextConverter(LetterCase.LowerCase);

            var oneHundred = numberConverter.GetText(100);
            var nineHundred = numberConverter.GetText(900);
            var twoHundredAndThree = numberConverter.GetText(203);
            var threeHundredAndSeventySix = numberConverter.GetText(376);

            Assert.AreEqual("one hundred", oneHundred);
            Assert.AreEqual("nine hundred", nineHundred);
            Assert.AreEqual("two hundred and three", twoHundredAndThree);
            Assert.AreEqual("three hundred and seventy six", threeHundredAndSeventySix);
        }

        [TestMethod]
        public void Converts_tens()
        {
            var numberConverter = new NumberToTextConverter(LetterCase.LowerCase);

            var twenty = numberConverter.GetText(20);
            var ninety = numberConverter.GetText(90);
            var eightyEight = numberConverter.GetText(88);
            var seventySeven = numberConverter.GetText(77);

            Assert.AreEqual("twenty", twenty);
            Assert.AreEqual("ninety", ninety);
            Assert.AreEqual("eighty eight", eightyEight);
            Assert.AreEqual("seventy seven", seventySeven);
        }

        [TestMethod]
        public void Converts_teens()
        {
            var numberConverter = new NumberToTextConverter(LetterCase.LowerCase);

            var ten = numberConverter.GetText(10);
            var eleven = numberConverter.GetText(11);
            var twelve = numberConverter.GetText(12);
            var thirteen = numberConverter.GetText(13);
            var fourteen = numberConverter.GetText(14);
            var fifteen = numberConverter.GetText(15);
            var sixteen = numberConverter.GetText(16);
            var seventeen = numberConverter.GetText(17);
            var eighteen = numberConverter.GetText(18);
            var nineteen = numberConverter.GetText(19);

            Assert.AreEqual("ten", ten);
            Assert.AreEqual("eleven", eleven);
            Assert.AreEqual("twelve", twelve);
            Assert.AreEqual("thirteen", thirteen);
            Assert.AreEqual("fourteen", fourteen);
            Assert.AreEqual("fifteen", fifteen);
            Assert.AreEqual("sixteen", sixteen);
            Assert.AreEqual("seventeen", seventeen);
            Assert.AreEqual("eighteen", eighteen);
            Assert.AreEqual("nineteen", nineteen);
        }

        [TestMethod]
        public void Converts_full_number_properly()
        {
            var numberConverter = new NumberToTextConverter(LetterCase.LowerCase);

            var bigNumber = numberConverter.GetText(9876);

            Assert.AreEqual("nine thousand eight hundred and seventy six", bigNumber);
        }

        [TestMethod]
        public void Uppercase_returns_upper_case_number()
        {
            var numberConverter = new NumberToTextConverter(LetterCase.UpperCase);

            var bigNumber = numberConverter.GetText(9876);

            Assert.AreEqual("NINE THOUSAND EIGHT HUNDRED AND SEVENTY SIX", bigNumber);
        }

        [TestMethod]
        public void Title_text_returns_number_with_title_text()
        {
            var numberConverter = new NumberToTextConverter(LetterCase.TitleCase);

            var bigNumber = numberConverter.GetText(9876);

            Assert.AreEqual("Nine Thousand Eight Hundred and Seventy Six", bigNumber);
        }

        [TestMethod]
        public void Zero_returns_zero()
        {
            var numberConverter = new NumberToTextConverter(LetterCase.LowerCase);

            var zero = numberConverter.GetText(0);

            Assert.AreEqual("zero", zero);
        }

        [TestMethod]
        public void Seperator_contained_in_text()
        {
            var numberConverter = new NumberToTextConverter(LetterCase.LowerCase, "-");

            var twentyThree = numberConverter.GetText(23);
            var oneHundredFiftyFive = numberConverter.GetText(155);

            Assert.AreEqual("twenty-three", twentyThree);
            Assert.AreEqual("one-hundred-and-fifty-five", oneHundredFiftyFive);
        }

        [TestMethod]
        public void Septilions_conversion_returns_text()
        {
            var numberConverter = new NumberToTextConverter(LetterCase.LowerCase);
            var septillion = numberConverter.GetText(9223372036854775807);
            Assert.AreEqual(
                "nine septillion two hundred and twenty three quadrillion three hundred and seventy two trillion thirty six billion eight hundred and fifty four million seven hundred and seventy five thousand eight hundred and seven", 
                septillion);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberConverter.Tests
{
    [TestClass]
    public class NumberToTextConverterTests
    {
        [TestMethod]
        public void Converts_thousands()
        {
            long oneThousandLong = 1000;
            var oneThousand = oneThousandLong.ToNumberString();

            var nineThousandLong = 9000;
            var nineThousand = nineThousandLong.ToNumberString();

            Assert.AreEqual("one thousand", oneThousand);
            Assert.AreEqual("nine thousand", nineThousand);
        }

        [TestMethod]
        public void Converts_hundreds()
        {
            long oneHundredLong = 100;
            var oneHundred = oneHundredLong.ToNumberString();

            long nineHundredLong = 900;
            var nineHundred = nineHundredLong.ToNumberString();

            long twoHundredAndThreeLong = 203;
            var twoHundredAndThree = twoHundredAndThreeLong.ToNumberString();

            long threeHundredAndSeventySixLong = 376;
            var threeHundredAndSeventySix = threeHundredAndSeventySixLong.ToNumberString();

            Assert.AreEqual("one hundred", oneHundred);
            Assert.AreEqual("nine hundred", nineHundred);
            Assert.AreEqual("two hundred and three", twoHundredAndThree);
            Assert.AreEqual("three hundred and seventy six", threeHundredAndSeventySix);
        }

        [TestMethod]
        public void Converts_tens()
        {
            var twenty = ((long)20).ToNumberString();
            var ninety = ((long)90).ToNumberString();
            var eightyEight = ((long)88).ToNumberString();
            var seventySeven = ((long)77).ToNumberString();

            Assert.AreEqual("twenty", twenty);
            Assert.AreEqual("ninety", ninety);
            Assert.AreEqual("eighty eight", eightyEight);
            Assert.AreEqual("seventy seven", seventySeven);
        }

        [TestMethod]
        public void Converts_teens()
        {
            var ten = ((long)10).ToNumberString();
            var eleven = ((long)11).ToNumberString();
            var twelve =   ((long)12).ToNumberString();
            var thirteen = ((long)13).ToNumberString();
            var fourteen = ((long)14).ToNumberString();
            var fifteen =  ((long)15).ToNumberString();
            var sixteen =  ((long)16).ToNumberString();
            var seventeen =((long)17).ToNumberString();;
            var eighteen = ((long)18).ToNumberString();
            var nineteen = ((long)19).ToNumberString();

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
            var bigNumber = ((long)9876).ToNumberString();

            Assert.AreEqual("nine thousand eight hundred and seventy six", bigNumber);
        }

        [TestMethod]
        public void Uppercase_returns_upper_case_number()
        {
            var bigNumber = ((long)9876).ToNumberString(LetterCase.UpperCase);

            Assert.AreEqual("NINE THOUSAND EIGHT HUNDRED AND SEVENTY SIX", bigNumber);
        }

        [TestMethod]
        public void Title_text_returns_number_with_title_text()
        {
            var bigNumber = ((long)9876).ToNumberString(LetterCase.TitleCase);

            Assert.AreEqual("Nine Thousand Eight Hundred and Seventy Six", bigNumber);
        }

        [TestMethod]
        public void Zero_returns_zero()
        {
            var zero = ((long)0).ToNumberString();

            Assert.AreEqual("zero", zero);
        }

        [TestMethod]
        public void Septilions_conversion_returns_text()
        {
            var septillion = ((long)9223372036854775807).ToNumberString();
            Assert.AreEqual(
                "nine septillion two hundred and twenty three quadrillion three hundred and seventy two trillion thirty six billion eight hundred and fifty four million seven hundred and seventy five thousand eight hundred and seven", 
                septillion);
        }
    }
}

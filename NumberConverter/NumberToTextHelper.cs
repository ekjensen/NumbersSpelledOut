using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberConverter
{
    class NumberToTextHelper
    {
        public string DecimalGrouping { get; }
        public LetterCase LetterCase { get; }
        public string SpaceCharactor { get; }

        public NumberToTextHelper(DecimalPosition decimalPositionGrouping, LetterCase letterCase = LetterCase.LowerCase, string spaceCharactor = " ")
        {
            switch (decimalPositionGrouping)
            {
                case DecimalPosition.Ones:
                    DecimalGrouping = "";
                    break;
                case DecimalPosition.Thousands:
                    DecimalGrouping = "thousand";
                    break;
                case DecimalPosition.Millions:
                    DecimalGrouping = "million";
                    break;
                case DecimalPosition.Billions:
                    DecimalGrouping = "billion";
                    break;
                case DecimalPosition.Trillions:
                    DecimalGrouping = "trillion";
                    break;
                case DecimalPosition.Quadrillions:
                    DecimalGrouping = "quadrillion";
                    break;
                case DecimalPosition.Septillions:
                    DecimalGrouping = "septillion";
                    break;
                default:
                    throw new ArgumentException(decimalPositionGrouping + " is not supported");

            }
            LetterCase = letterCase;
            SpaceCharactor = spaceCharactor;
        }

        private string GetHundredsText(int number)
        {
            int hundredCounter = GetNumberOf(DecimalPosition.Hundreds, number);

            var hundred = " hundred";
            if (hundredCounter == 9)
            {
                return "nine" + hundred;
            }
            if (hundredCounter == 8)
            {
                return "eight" + hundred;
            }
            if (hundredCounter == 7)
            {
                return "seven" + hundred;
            }
            if (hundredCounter == 6)
            {
                return "six" + hundred;
            }
            if (hundredCounter == 5)
            {
                return "five" + hundred;
            }
            if (hundredCounter == 4)
            {
                return "four" + hundred;
            }
            if (hundredCounter == 3)
            {
                return "three" + hundred;
            }
            if (hundredCounter == 2)
            {
                return "two" + hundred;
            }
            if (hundredCounter == 1)
            {
                return "one" + hundred;
            }

            // There are no hundreds.
            return "";
        }

        private string GetTensText(int number)
        {
            int tensCounter = GetNumberOf(DecimalPosition.Tens, number);
            int onesCounter = GetNumberOf(DecimalPosition.Ones, number);

            if (tensCounter == 9)
            {
                return "ninety";
            }
            if (tensCounter == 8)
            {
                return "eighty";
            }
            if (tensCounter == 7)
            {
                return "seventy";
            }
            if (tensCounter == 6)
            {
                return "sixty";
            }
            if (tensCounter == 5)
            {
                return "fifty";
            }
            if (tensCounter == 4)
            {
                return "forty";
            }
            if (tensCounter == 3)
            {
                return "thirty";
            }
            if (tensCounter == 2)
            {
                return "twenty";
            }
            if (tensCounter == 1)
            {
                if (onesCounter == 9)
                {
                    return "nineteen";
                }
                if (onesCounter == 8)
                {
                    return "eighteen";
                }
                if (onesCounter == 7)
                {
                    return "seventeen";
                }
                if (onesCounter == 6)
                {
                    return "sixteen";
                }
                if (onesCounter == 5)
                {
                    return "fifteen";
                }
                if (onesCounter == 4)
                {
                    return "fourteen";
                }
                if (onesCounter == 3)
                {
                    return "thirteen";
                }
                if (onesCounter == 2)
                {
                    return "twelve";
                }
                if (onesCounter == 1)
                {
                    return "eleven";
                }
                if (onesCounter == 0)
                {
                    return "ten";
                }
            }

            return "";
        }

        private string GetOnesText(int number)
        {
            int singleCounter = GetNumberOf(DecimalPosition.Ones, number);

            if (singleCounter == 9)
            {
                return "nine";
            }
            if (singleCounter == 8)
            {
                return "eight";
            }
            if (singleCounter == 7)
            {
                return "seven";
            }
            if (singleCounter == 6)
            {
                return "six";
            }
            if (singleCounter == 5)
            {
                return "five";
            }
            if (singleCounter == 4)
            {
                return "four";
            }
            if (singleCounter == 3)
            {
                return "three";
            }
            if (singleCounter == 2)
            {
                return "two";
            }
            if (singleCounter == 1)
            {
                return "one";
            }
            if (number == 0)
            {
                return "zero";
            }

            return "";
        }

        private int GetNumberOf(DecimalPosition decimalPlace, int number)
        {
            // Check if the number has enough decimal places.
            // if not, there are zero of this decimal place. 
            int numberDecimalPlaces = number.ToString().Length;
            if ((int)decimalPlace > numberDecimalPlaces) return 0;

            var numberString = number.ToString();
            var charactorPosition = numberString.Length - (int)decimalPlace;
            var decimalPlaceCharactor = numberString[charactorPosition];
            int counter = int.Parse(decimalPlaceCharactor.ToString());

            return counter;
        }

        public string GetText(int trimmedNumber)
        {
            var negativeText = trimmedNumber < 0 ? "negative" : "";
            var absoluteValueOfNumber = Math.Abs(trimmedNumber);
            var hundredsText = GetHundredsText(absoluteValueOfNumber);
            var tensText = GetTensText(absoluteValueOfNumber);

            // Get the ones text if it is not already used by the tens text.
            string onesText;
            var numberOfTens = GetNumberOf(DecimalPosition.Tens, absoluteValueOfNumber);
            bool isTeen = numberOfTens == 1;
            // If the number is a teen, the ones position is 
            // covered by the get tens text. 
            if (isTeen)
            {
                onesText = "";
            }
            // If the number is not a teen, the ones 
            // text is still needed. 
            else
            {
                onesText = GetOnesText(absoluteValueOfNumber);
            }

            var didgetNumbers = new List<string>();
            if (negativeText != "")
            {
                didgetNumbers.Add(negativeText);
            }

            if (hundredsText != "")
            {
                didgetNumbers.Add(hundredsText);
            }

            if (tensText != "")
            {
                didgetNumbers.Add(tensText);
            }

            if (onesText != "")
            {
                didgetNumbers.Add(onesText);
            }

            return AddOptions(trimmedNumber, didgetNumbers.ToArray());
        }

        private string[] AddAnd(int originalNumber, string[] didgetWords)
        {
            var hasOnes = GetNumberOf(DecimalPosition.Ones, originalNumber) > 0;
            var hasTens = GetNumberOf(DecimalPosition.Tens, originalNumber) > 0;
            var hasHundereds = GetNumberOf(DecimalPosition.Hundreds, originalNumber) > 0;
            var hasThousands = GetNumberOf(DecimalPosition.Thousands, originalNumber) > 0;
            var hasHundresOrThousands = hasHundereds || hasThousands;

            // There will be the word and added if there is a decimal position in the hundreds or greater,
            // and if there is a ones or a tens. 
            if (didgetWords.Length >= 2)
            {
                if (hasOnes && hasTens && hasHundresOrThousands)
                {
                    var didgetNumberList = new List<string>(didgetWords);
                    didgetNumberList.Insert(didgetWords.Length - 2, "and");
                    return didgetNumberList.ToArray();
                }
                if (hasOnes ^ hasTens && hasHundresOrThousands) // Exclusive or. 
                {
                    var didgetNumberList = new List<string>(didgetWords);
                    didgetNumberList.Insert(didgetWords.Length - 1, "and");
                    return didgetNumberList.ToArray();
                }
            }
            // There is no need to add the word and. 
            return didgetWords;
        }

        private string[] AddDecimalGroupingText(string[] didgetWords)
        {
            if (DecimalGrouping != "")
            {
                var didgetWordsList = didgetWords.ToList();
                didgetWordsList.Add(DecimalGrouping);
                return didgetWordsList.ToArray();
            }

            return didgetWords;
        }

        private string AddOptions(int originalNumber, string[] didgetWords)
        {
            var didgetNumbersWithAnd = AddAnd(originalNumber, didgetWords);
            var didgetWordsWithGroup = AddDecimalGroupingText(didgetNumbersWithAnd);

            if (LetterCase == LetterCase.UpperCase)
            {
                var upperCaseWords = didgetWordsWithGroup.Select(
                    word => word.ToUpper().Replace(" ", SpaceCharactor));

                return string.Join(SpaceCharactor, upperCaseWords);
            }

            if (LetterCase == LetterCase.LowerCase)
            {
                var lowerCaseWords = didgetWordsWithGroup.Select(
                    word => word.ToLower().Replace(" ", SpaceCharactor));

                return string.Join(SpaceCharactor, lowerCaseWords);
            }

            if (LetterCase == LetterCase.TitleCase)
            {
                var titleWords = didgetWordsWithGroup.Select(word =>
                        CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word.ToLower())
                            .Replace(" ", SpaceCharactor)).ToList();

                // And should be lower case. 
                var index = titleWords.FindIndex(tw => tw == "And");
                bool andWasFound = index >= 0;
                if (andWasFound)
                {
                    titleWords[index] = "and";
                }

                return string.Join(SpaceCharactor, titleWords);
            }

            throw new NotImplementedException(LetterCase + " is not supported.");
        }
    }
}

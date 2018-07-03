using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace ConsoleApp2
{
    class NumberToTextConverter
    {
        public LetterCase Case { get; }
        public string Seperator { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="letterCase"></param>
        /// <param name="seperator">The charactor to use to seperate each word with.</param>
        public NumberToTextConverter(LetterCase letterCase, string seperator = " ")
        {
            Case = letterCase;
            Seperator = seperator;
        }

        private string GetThousandsText(int number)
        {
            var thousandCounter = GetNumberOf(DecimalPosition.Thousands, number);

            // There are thousands, return the proper thousand text. 
            var thousand = " thousand";
            if (thousandCounter == 9)
            {
                return "nine" + thousand;
            }
            if (thousandCounter == 8)
            {
                return "eight" + thousand;
            }
            if (thousandCounter == 7)
            {
                return "seven" + thousand;
            }
            if (thousandCounter == 6)
            {
                return "six" + thousand;
            }
            if (thousandCounter == 5)
            {
                return "five" + thousand;
            }
            if (thousandCounter == 4)
            {
                return "four" + thousand;
            }
            if (thousandCounter == 3)
            {
                return "three" + thousand;
            }
            if (thousandCounter == 2)
            {
                return "two" + thousand;
            }
            if (thousandCounter == 1)
            {
                return "one" + thousand;
            }

            // There are no thousands, return an empty string.
            return "";
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

        public string GetText(int number)
        {
            var thousandsText = GetThousandsText(number);
            var hundredsText = GetHundredsText(number);
            var tensText = GetTensText(number);

            // Get the ones text if it is not already used by the tens text.
            string onesText;
            var numberOfTens = GetNumberOf(DecimalPosition.Tens, number);
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
                onesText = GetOnesText(number);
            }

            // Combine the text into a single string. 
            var defaultText = string.Join(" ", thousandsText, hundredsText, tensText, onesText);
            var words = defaultText.Split(' ');


            if (Case == LetterCase.UpperCase)
            {
                var upperCaseWords = words.Select(w => w.ToUpper()).ToArray();
                return string.Join(Seperator, upperCaseWords);
            }

            if (Case == LetterCase.LowerCase)
            {
                var lowerCaseWords = words.Select(w => w.ToLower()).ToArray();
                return string.Join(Seperator, lowerCaseWords);
            }

            if (Case == LetterCase.TitleCase)
            {
                var titleText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(defaultText.ToLower());
                var titleTextWords = titleText.Split(' ');
                return string.Join(Seperator, titleTextWords);
            }
            
            throw new NotImplementedException(Case + " is not supported.");
        }

        enum DecimalPosition
        {
            Thousands = 4,
            Hundreds = 3,
            Tens = 2,
            Ones = 1
        }
    }

    enum LetterCase
    {
        TitleCase,
        UpperCase,
        LowerCase
    }
}

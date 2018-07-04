using EKJensen.NumbersSpelledOut.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace EKJensen.NumbersSpelledOut.Spellers
{
    internal class NumberToTextSpeller : ISpellNumber<long>, ISpellNumber<ulong>
    {
        public LetterCase Case { get; }
        private readonly LetterCaseHelper _caseHelper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="letterCase"></param>
        /// <param name="spaceCharactor">The charactor to use to seperate each word with.</param>
        public NumberToTextSpeller(LetterCase letterCase)
        {
            Case = letterCase;
            _caseHelper = new LetterCaseHelper(letterCase);
        }

        public string Spell(ulong number)
        {
            var longText = number.ToString();
            var len = longText.Length;
            var nextStartingIndex = 0;

            var numberParts = new List<string>();

            // Septillions
            if (len >= 19)
            {
                var substring = longText.Substring(nextStartingIndex, len + 3 - 21);
                nextStartingIndex = len % 3;
                var trimmedNumber = int.Parse(substring);
                var helper = new NumberToTextSpellingHelper(DecimalPosition.Septillions, Case);
                var text = helper.GetText(trimmedNumber);
                if (trimmedNumber > 0) numberParts.Add(text);
            }
            // Quadrillions
            if (len >= 16)
            {
                var forHowMany = len >= 18 ? 3 : len + 3 - 18;
                var substring = longText.Substring(nextStartingIndex, forHowMany);
                nextStartingIndex += forHowMany;
                var trimmedNumber = int.Parse(substring);
                var helper = new NumberToTextSpellingHelper(DecimalPosition.Quadrillions, Case);
                var text = helper.GetText(trimmedNumber);
                if (trimmedNumber > 0) numberParts.Add(text);
            }
            // Trillions
            if (len >= 13)
            {
                var forHowMany = len >= 15 ? 3 : len + 3 - 15;
                var substring = longText.Substring(nextStartingIndex, forHowMany);
                nextStartingIndex += forHowMany;
                var trimmedNumber = int.Parse(substring);
                var helper = new NumberToTextSpellingHelper(DecimalPosition.Trillions, Case);
                var text = helper.GetText(trimmedNumber);
                if (trimmedNumber > 0) numberParts.Add(text);
            }
            // Billions
            if (len >= 10)
            {
                var forHowMany = len >= 12 ? 3 : len + 3 - 12;
                var substring = longText.Substring(nextStartingIndex, forHowMany);
                nextStartingIndex += forHowMany;
                var trimmedNumber = int.Parse(substring);
                var helper = new NumberToTextSpellingHelper(DecimalPosition.Billions, Case);
                var text = helper.GetText(trimmedNumber);
                if (trimmedNumber > 0) numberParts.Add(text);
            }
            // Millions
            if (len >= 7)
            {
                var forHowMany = len >= 9 ? 3 : len + 3 - 9;
                var substring = longText.Substring(nextStartingIndex, forHowMany);
                nextStartingIndex += forHowMany;
                var trimmedNumber = int.Parse(substring);
                var helper = new NumberToTextSpellingHelper(DecimalPosition.Millions, Case);
                var text = helper.GetText(trimmedNumber);
                if (trimmedNumber > 0) numberParts.Add(text);
            }
            // Thousands
            if (len >= 4)
            {
                var forHowMany = len >= 6 ? 3 : len + 3 - 6;
                var substring = longText.Substring(nextStartingIndex, forHowMany);
                nextStartingIndex += forHowMany;
                var trimmedNumber = int.Parse(substring);
                var helper = new NumberToTextSpellingHelper(DecimalPosition.Thousands, Case);
                var text = helper.GetText(trimmedNumber);
                if (trimmedNumber > 0) numberParts.Add(text);
            }
            // Ones
            if (len >= 1)
            {
                var forHowMany = len >= 3 ? 3 : len;
                var substring = longText.Substring(nextStartingIndex, forHowMany);
                var trimmedNumber = int.Parse(substring);
                var helper = new NumberToTextSpellingHelper(DecimalPosition.Ones, Case);
                var text = helper.GetText(trimmedNumber);

                if (text == "zero")
                {
                    if (numberParts.Count == 0)
                    {
                        numberParts.Add(text);
                    }
                }
                else
                {
                    if (substring.Length <= 2 && numberParts.Count > 0)
                    {
                        numberParts.Add("and");
                    }
                    numberParts.Add(text);
                }
            }

            var fullText = string.Join(" ", numberParts);
            return _caseHelper.Transform(fullText);
        }

        public string Spell(long number)
        {
            var negative = "";
            if(number < 0)
            {
                negative = "negative";
            }

            var text = Spell((ulong)Math.Abs(number));
            if (negative == "") return text;

            _caseHelper.Transform(text = negative + " " + text);
            return text;
        }

    }
}

using System;
using System.Globalization;

namespace EKJensen.NumbersSpelledOut.Utilities
{
    internal class LetterCaseHelper
    {
        public LetterCase LetterCase { get; }

        public LetterCaseHelper(LetterCase letterCase)
        {
            LetterCase = letterCase;
        }

        public string Transform(string text)
        {
            switch (LetterCase)
            {
                case LetterCase.UpperCase:
                    return text.ToUpper();
                case LetterCase.LowerCase:
                    return text.ToLower();
                case LetterCase.TitleCase:
                    return ToTitleCase(text);
                default:
                    throw new NotImplementedException(LetterCase + " is not supported.");
            }
        }

        private string ToTitleCase(string text)
        {
            var titleCase = CultureInfo.CurrentCulture
                        .TextInfo.ToTitleCase(text.ToLower());

            titleCase = titleCase.Replace("And", "and");

            return titleCase;
        }
    }
}

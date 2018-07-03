using EKJensen.NumbersSpelledOut.Spellers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKJensen.NumbersSpelledOut
{
    public static class FloatingPointSpelledOut
    {
        public static string ToNumberString(this double number, LetterCase caseOptions = LetterCase.LowerCase)
        {
            var speller = new FloatingPointSpeller(caseOptions);
            return speller.ToText(number);
        }

        public static string ToNumberString(this float number, LetterCase caseOptions = LetterCase.LowerCase)
        {
            var speller = new FloatingPointSpeller(caseOptions);
            return speller.ToText(number);
        }

        public static string ToNumberString(this decimal number, LetterCase caseOptions = LetterCase.LowerCase)
        {
            var speller = new FloatingPointSpeller(caseOptions);
            return speller.ToText(number);
        }
    }
}

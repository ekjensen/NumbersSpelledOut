using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKJensen.NumbersSpelledOut
{
    public static class NumberToText
    {
        public static string ToNumberString(this long number, LetterCase caseOptions = LetterCase.LowerCase)
        {
            var converter = new NumberToTextConverter(caseOptions);
            return converter.GetText(number);
        }

        public static string ToNumberString(this ulong number, LetterCase caseOptions = LetterCase.LowerCase)
        {
            var converter = new NumberToTextConverter(caseOptions);
            return converter.GetText(number);
        }

        public static string ToNumberString(this int number, LetterCase caseOptions = LetterCase.LowerCase)
        {
            var converter = new NumberToTextConverter(caseOptions);
            return converter.GetText(number);
        }

        public static string ToNumberString(this uint number, LetterCase caseOptions = LetterCase.LowerCase)
        {
            var converter = new NumberToTextConverter(caseOptions);
            return converter.GetText(number);
        }

        public static string ToNumberString(this short number, LetterCase caseOptions = LetterCase.LowerCase)
        {
            var converter = new NumberToTextConverter(caseOptions);
            return converter.GetText(number);
        }

        public static string ToNumberString(this ushort number, LetterCase caseOptions = LetterCase.LowerCase)
        {
            var converter = new NumberToTextConverter(caseOptions);
            return converter.GetText(number);
        }

        public static string ToNumberString(this sbyte number, LetterCase caseOptions = LetterCase.LowerCase)
        {
            var converter = new NumberToTextConverter(caseOptions);
            return converter.GetText(number);
        }

        public static string ToNumberString(this byte number, LetterCase caseOptions = LetterCase.LowerCase)
        {
            var converter = new NumberToTextConverter(caseOptions);
            return converter.GetText(number);
        }
    }
}

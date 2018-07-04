using System;
using EKJensen.NumbersSpelledOut.Spellers;
using EKJensen.NumbersSpelledOut.Utilities;
using EKJensen.NumbersSpelledOut.Utilities.TextTransformations;

namespace EKJensen.NumbersSpelledOut
{
    public static class NonFloatingPointSpelledOut
    {
        public static string ToNumberString(this long number, LetterCase letterCase = LetterCase.LowerCase)
        {
            var converter = new NumberToTextSpeller(
                TransformTextFactory.GetTransformation(letterCase));
            return converter.Spell(number);
        }

        public static string ToNumberString(this ulong number, LetterCase letterCase = LetterCase.LowerCase)
        {
            var converter = new NumberToTextSpeller(
                TransformTextFactory.GetTransformation(letterCase));
            return converter.Spell(number);
        }

        public static string ToNumberString(this int number, LetterCase letterCase = LetterCase.LowerCase)
        {
            var converter = new NumberToTextSpeller(
                TransformTextFactory.GetTransformation(letterCase));
            return converter.Spell(number);
        }

        public static string ToNumberString(this uint number, LetterCase letterCase = LetterCase.LowerCase)
        {
            var converter = new NumberToTextSpeller(
                TransformTextFactory.GetTransformation(letterCase));
            return converter.Spell(number);
        }

        public static string ToNumberString(this short number, LetterCase letterCase = LetterCase.LowerCase)
        {
            var converter = new NumberToTextSpeller(
                TransformTextFactory.GetTransformation(letterCase));
            return converter.Spell(number);
        }

        public static string ToNumberString(this ushort number, LetterCase letterCase = LetterCase.LowerCase)
        {
            var converter = new NumberToTextSpeller(
                TransformTextFactory.GetTransformation(letterCase));
            return converter.Spell(number);
        }

        public static string ToNumberString(this sbyte number, LetterCase letterCase = LetterCase.LowerCase)
        {
            var converter = new NumberToTextSpeller(
                TransformTextFactory.GetTransformation(letterCase));
            return converter.Spell(number);
        }

        public static string ToNumberString(this byte number, LetterCase letterCase = LetterCase.LowerCase)
        {
            var converter = new NumberToTextSpeller(
                TransformTextFactory.GetTransformation(letterCase));
            return converter.Spell(number);
        }
    }
}

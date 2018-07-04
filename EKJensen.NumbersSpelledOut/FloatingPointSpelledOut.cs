using EKJensen.NumbersSpelledOut.Spellers;
using EKJensen.NumbersSpelledOut.Utilities;
using EKJensen.NumbersSpelledOut.Utilities.TextTransformations;

namespace EKJensen.NumbersSpelledOut
{
    public static class FloatingPointSpelledOut
    {
        public static string ToNumberString(this double number, LetterCase letterCase = LetterCase.LowerCase)
        {
            var speller = new FloatingPointSpeller(
                TransformTextFactory.GetTransformation(letterCase));

            return speller.Spell(number);
        }

        public static string ToNumberString(this float number, LetterCase letterCase = LetterCase.LowerCase)
        {
            var speller = new FloatingPointSpeller(
                TransformTextFactory.GetTransformation(letterCase));

            return speller.Spell(number);
        }

        public static string ToNumberString(this decimal number, LetterCase letterCase = LetterCase.LowerCase)
        {
            var speller = new FloatingPointSpeller(
                TransformTextFactory.GetTransformation(letterCase));

            return speller.Spell(number);
        }
    }
}

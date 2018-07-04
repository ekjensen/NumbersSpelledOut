using EKJensen.NumbersSpelledOut.Spellers;
using EKJensen.NumbersSpelledOut.Utilities.TextTransformations;

namespace EKJensen.NumbersSpelledOut
{
    public static class CheckAnnotationsSpelledOut
    {
        public static string ToCheckAnnotation(this float number, LetterCase letterCase = LetterCase.LowerCase, bool includeWordDollars = true, bool includeWordCents = false)
        {
            var checkAnnotator = new CheckAnnotationSpeller(
                TransformTextFactory.GetTransformation(letterCase), includeWordDollars, includeWordCents);
            return checkAnnotator.Spell(number);
        }

        public static string ToCheckAnnotation(this double number, LetterCase letterCase = LetterCase.LowerCase, bool includeWordDollars = true, bool includeWordCents = false)
        {
            var checkAnnotator = new CheckAnnotationSpeller(
                TransformTextFactory.GetTransformation(letterCase), includeWordDollars, includeWordCents);
            return checkAnnotator.Spell(number);
        }

        public static string ToCheckAnnotation(this decimal number, LetterCase letterCase = LetterCase.LowerCase, bool includeWordDollars = true, bool includeWordCents = false)
        {
            var checkAnnotator = new CheckAnnotationSpeller(
                TransformTextFactory.GetTransformation(letterCase), includeWordDollars, includeWordCents);
            return checkAnnotator.Spell(number);
        }
    }
}

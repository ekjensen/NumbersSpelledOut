using System;

namespace EKJensen.NumbersSpelledOut.Utilities.TextTransformations
{
    internal static class TransformTextFactory
    {
        public static ITransformText GetTransformation(LetterCase letterCase)
        {
            switch (letterCase)
            {
                case LetterCase.UpperCase:
                    return new UpperCaseTransformation();
                case LetterCase.LowerCase:
                    return new LowerCaseTransformation();
                case LetterCase.TitleCase:
                    return new TitleTextTransformation();
                default:
                    throw new NotImplementedException(letterCase + " is not supported.");
            }
        }
    }
}

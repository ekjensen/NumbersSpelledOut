using System.Globalization;

namespace EKJensen.NumbersSpelledOut.Utilities
{
    class TitleTextTransformation : ITransformText
    {
        public string Transform(string inputText)
        {
            var titleCase = CultureInfo.CurrentCulture
                        .TextInfo.ToTitleCase(inputText.ToLower());

            titleCase = titleCase.Replace("And", "and");

            return titleCase;
        }
    }
}

using EKJensen.NumbersSpelledOut.Utilities;
using EKJensen.NumbersSpelledOut.Utilities.TextTransformations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKJensen.NumbersSpelledOut.Spellers
{
    public class CheckAnnotationSpeller : ISpellNumber<double>, ISpellNumber<float>, ISpellNumber<decimal>
    {
        public bool IncludeWordDollars { get; }
        public bool IncludeWordCents { get; }

        private readonly NumberToTextSpeller _speller;
        private ITransformText _textTransformer;

        public CheckAnnotationSpeller(ITransformText textTransformer, bool includeWordDollars, bool includeWordCents)
        {
            _speller = new NumberToTextSpeller(textTransformer);
            _textTransformer = textTransformer;
            IncludeWordDollars = includeWordDollars;
            IncludeWordCents = includeWordCents;
        }

        public string Spell(double number)
        {
            number = Math.Round(number, 2);
            return GetCheckAnnotation(number.ToString());
        }

        public string Spell(float number)
        {
            var roundedNumber = Math.Round(Convert.ToDouble(number), 2);
            return GetCheckAnnotation(roundedNumber.ToString());
        }

        public string Spell(decimal number)
        {
            number = Math.Round(number, 2);
            return GetCheckAnnotation(number.ToString());
        }

        private string GetCheckAnnotation(string numberText)
        {
            // Split the left side of the decimal
            // and the right side of the variable to 
            // spell out the numbers seperately.
            var parts = numberText.Split('.');
            var leftSide = long.Parse(parts[0]);

            long rightSide = 0;
            if (parts.Length == 2)
            {
                // Grab two decimal points if 
                // they exist. 
                rightSide = long.Parse(parts[1]);
                if (parts[1].Length > 2)
                {
                    rightSide = long.Parse(parts[1].Substring(0, 2));
                }
            }

            // Left side is the text, and the right side
            // is a fraction. 
            var leftSideText = _speller.Spell(leftSide);
            var rightSideText = rightSide + "/100";

            var dollars = IncludeWordDollars ? " dollars" : "";
            var cents = IncludeWordCents ? " cents" : "";

            return _textTransformer.Transform(leftSideText + dollars + " and " + rightSideText + cents);
        }
    }
}

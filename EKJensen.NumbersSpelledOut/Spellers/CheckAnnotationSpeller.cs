using EKJensen.NumbersSpelledOut.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKJensen.NumbersSpelledOut.Spellers
{
    public class CheckAnnotationSpeller : ISpellNumber<double>, ISpellNumber<float>, ISpellNumber<decimal>
    {
        public LetterCase LetterCase { get; }
        private readonly NumberToTextSpeller _speller;
        private LetterCaseHelper _caseHelper;

        public CheckAnnotationSpeller(LetterCase letterCase)
        {
            LetterCase = letterCase;
            _speller = new NumberToTextSpeller(LetterCase);
            _caseHelper = new LetterCaseHelper(LetterCase);
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

            return _caseHelper.Transform(leftSideText + " and " + rightSideText);
        }
    }
}

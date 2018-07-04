using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKJensen.NumbersSpelledOut.Spellers
{
    internal class FloatingPointSpeller : ISpellNumber<decimal>, ISpellNumber<double>, ISpellNumber<float>
    {
        public LetterCase Case { get; }
        private NumberToTextSpeller _speller;

        public FloatingPointSpeller(LetterCase letterCase)
        {
            Case = letterCase;
            _speller = new NumberToTextSpeller(letterCase);
        }

        public string Spell(decimal number)
        {
            return ToNumberText(number.ToString());
        }

        public string Spell(double number)
        {
            return ToNumberText(number.ToString());
        }

        public string Spell(float number)
        {
            return ToNumberText(number.ToString());
        }

        /// <summary>
        /// Splits the number into 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string ToNumberText(string number)
        {
            var parts = number.Split('.');
            long leftSide;
            long rightSide;
            if(parts.Length == 1)
            {
                leftSide = long.Parse(parts[0]);
                rightSide = 0;
            }
            else 
            {
                leftSide = long.Parse(parts[0]);
                rightSide = long.Parse(parts[1]);
            }

            var leftSideString = _speller.Spell(leftSide);
            var rightSideString = _speller.Spell(rightSide);

            switch (Case)
            {
                case LetterCase.LowerCase:
                    return leftSideString + " point " + rightSideString;
                case LetterCase.UpperCase:
                    return leftSideString + " POINT " + rightSideString;
                case LetterCase.TitleCase:
                    return leftSideString + " Point " + rightSideString;
                default:
                    throw new NotFiniteNumberException(Case + " not yet supported.");
            }
        }
    }
}

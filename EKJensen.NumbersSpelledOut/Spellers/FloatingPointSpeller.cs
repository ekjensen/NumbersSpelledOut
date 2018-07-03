using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKJensen.NumbersSpelledOut.Spellers
{
    internal class FloatingPointSpeller
    {
        public LetterCase Case { get; }
        private NumberToTextSpeller _speller;

        public FloatingPointSpeller(LetterCase letterCase)
        {
            Case = letterCase;
            _speller = new NumberToTextSpeller(letterCase);
        }

        public string ToText(decimal number)
        {
            return ToNumberText(number.ToString());
        }

        public string ToText(double number)
        {
            return ToNumberText(number.ToString());
        }

        public string ToText(float number)
        {
            return ToNumberText(number.ToString());
        }

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

            var leftSideString = _speller.GetText(leftSide);
            var rightSideString = _speller.GetText(rightSide);

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKJensen.NumbersSpelledOut.Utilities
{
    internal class UpperCaseTransformation : ITransformText
    {
        public string Transform(string inputText)
        {
            return inputText.ToUpper();
        }
    }
}

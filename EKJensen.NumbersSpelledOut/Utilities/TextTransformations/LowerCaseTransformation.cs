using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKJensen.NumbersSpelledOut.Utilities
{
    class LowerCaseTransformation : ITransformText
    {
        public string Transform(string inputText)
        {
            return inputText.ToLower();
        }
    }
}

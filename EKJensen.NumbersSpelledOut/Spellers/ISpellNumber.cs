using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKJensen.NumbersSpelledOut.Spellers
{
    interface ISpellNumber<TNumber> 
    {
        string Spell(TNumber number);
    }
}

namespace EKJensen.NumbersSpelledOut.Spellers
{
    public interface ISpellNumber<TNumber> 
    {
        string Spell(TNumber number);
    }
}

# NumbersSpelledOut
A C# library that takes in a number and spells it out.

> ex. 
> "1234"
> can be transformed to 
> "one thousand two hundred and thirty four"

## Types of transformations
* Number to Text
* Number to Check Annotation

### Number to Text
Convert any number into a text representation of the number spelled out as a string of words. 

* Signed integrals: sbyte, short, int, long
* Unsigned integrals: byte, ushort, uint, ulong 
* IEEE floating point: float, double
* High precision decimal: decimal

#### Usage
Include the using statement:
```csharp
using EKJensen.NumbersSpelledOut;
```

Integrals: 
```csharp
string textValue = (1234).ToNumberString();
// textValue == "one thousand two hundred and thirty four".
```

Floating point and decimal: 
```csharp
string textValue = (1234.56).ToNumberString();
// textValue == "one thousand two hundred and thirty four point fifty six".
```

Options:
```csharp
LetterCase upperCase = LetterCase.UpperCase;
// LetterCase titleCase = LetterCase.TitleCase;
// LetterCase upperCase = LetterCase.UpperCase;
// LetterCase lowerCase = LetterCase.LowerCase;

string textValue = (1234.56).ToNumberString(upperCase);
// textValue == "ONE THOUSAND TWO HUNDRED AND THIRTY FOUR POINT FIFTY SIX".
```

### Number to check annotation
Take any type of floating poing number and convert it to the portion of a check that needs to be spelled out in words.  

* IEEE floating point: float, double
* High precision decimal: decimal

#### Usage
Include the using statement:
```csharp
using EKJensen.NumbersSpelledOut;
```

Integrals: 
```csharp
string textValue = ((float)1234).ToCheckAnnotation();
// textValue == "one thousand two hundred and thirty four dollars and 0/100".
```

Floating point and decimal: 
```csharp
string textValue = (1234.56).ToCheckAnnotation();
// textValue == "one thousand two hundred and thirty four dollars and 56/100".
```

Options:
Floating point and decimal: 
```csharp
// Options
LetterCase titleCase = LetterCase.TitleCase;
// LetterCase titleCase = LetterCase.TitleCase;
// LetterCase upperCase = LetterCase.UpperCase;
// LetterCase lowerCase = LetterCase.LowerCase;
bool includeWordDollar = true;
bool includeWordCents = true;

string textValue = (1234.56).ToCheckAnnotation(titleCase, includeWordDollar, includeWordCents);
// textValue == "One Thousand Two Hundred and Thirty Four Dollars and 56/100 Cents".
```

### Installation
Don't worry, we'll create installation instructions soon. 

## PeterO.ExtendedDecimal

    public sealed class ExtendedDecimal :
        System.IComparable,
        System.IEquatable

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers and the output of this class's ToString method.

<b>This class is largely obsolete. It will be replaced by a new version of this class in a different namespace/package and library, called `PeterO.Numbers.EDecimal` in the<a href="https://www.nuget.org/packages/PeterO.Numbers"> `PeterO.Numbers` </a>library (in .NET), or `com.upokecenter.numbers.EDecimal` in the<a href="https://github.com/peteroupc/numbers-java"> `com.github.peteroupc/numbers` </a>artifact (in Java). This new class can be used in the `CBORObject.FromObject(object)` method (by including the new library in your code, among other hings).</b>

Represents an arbitrary-precision decimal floating-point number.<b>About decimal arithmetic</b>

Decimal (base-10) arithmetic, such as that provided by this class, is appropriate for calculations involving such real-world data as prices and other sums of money, tax rates, and measurements. These calculations often involve multiplying or dividing one decimal with another decimal, or performing other operations on decimal numbers. Many of these calculations also rely on rounding behavior in which the result after rounding is a decimal number (for example, multiplying a price by a premium rate, then rounding, should result in a decimal amount of money).

On the other hand, most implementations of `float` and `double` , including in C# and Java, store numbers in a binary (base-2) loating-point format and use binary floating-point arithmetic. Many ecimal numbers can't be represented exactly in binary floating-point ormat (regardless of its length). Applying binary arithmetic to numbers ntended to be decimals can sometimes lead to unintuitive results, as is hown in the description for the FromDouble() method of this class.

<b>About ExtendedDecimal instances</b>

Each instance of this class consists of an integer mantissa and an integer exponent, both arbitrary-precision. The value of the number equals mantissa * 10^exponent.

The mantissa is the value of the digits that make up a number, ignoring the decimal point and exponent. For example, in the number 2356.78, the mantissa is 235678. The exponent is where the "floating" decimal point of the number is located. A positive exponent means "move it to the right", and a negative exponent means "move it to the left." In the example 2, 356.78, the exponent is -2, since it has 2 decimal places and the decimal point is "moved to the left by 2." Therefore, in the arbitrary-precision decimal representation, this number would be stored as 235678 * 10^-2.

The mantissa and exponent format preserves trailing zeros in the number's value. This may give rise to multiple ways to store the same value. For example, 1.00 and 1 would be stored differently, even though they have the same value. In the first case, 100 * 10^-2 (100 with decimal point moved left by 2), and in the second case, 1 * 10^0 (1 with decimal point moved 0).

This class also supports values for negative zero, not-a-number (NaN) values, and infinity.<b>Negative zero</b>is generally used when a negative number is rounded to 0; it has the ame mathematical value as positive zero.<b>Infinity</b>is generally used when a non-zero number is divided by zero, or when a ery high number can't be represented in a given exponent range.<b>Not-a-number</b>is generally used to signal errors.

<b>Errors and Exceptions</b>

Passing a signaling NaN to any arithmetic operation shown here will signal the flag FlagInvalid and return a quiet NaN, even if another operand to that operation is a quiet NaN, unless noted otherwise.

Passing a quiet NaN to any arithmetic operation shown here will return a quiet NaN, unless noted otherwise. Invalid operations will also return a quiet NaN, as stated in the individual methods.

Unless noted otherwise,passing a null arbitrary-precision decimal argument to any method here will throw an exception.

When an arithmetic operation signals the flag FlagInvalid, FlagOverflow, or FlagDivideByZero, it will not throw an exception too, unless the flag's trap is enabled in the precision context (see EContext's Traps property).

If an operation requires creating an intermediate value that might be too big to fit in memory (or might require more than 2 gigabytes of memory to store -- due to the current use of a 32-bit integer internally as a length), the operation may signal an invalid-operation flag and return not-a-number (NaN). In certain rare cases, the CompareTo method may throw OutOfMemoryException (called OutOfMemoryError in Java) in the same circumstances.

<b>Serialization</b>

An arbitrary-precision decimal value can be serialized (converted to a stable format) in one of the following ways:

 * By calling the toString() method, which will always return distinct strings for distinct arbitrary-precision decimal values.

 * By calling the UnsignedMantissa, Exponent, and IsNegative properties, and calling the IsInfinity, IsQuietNaN, and IsSignalingNaN methods. The return values combined will uniquely identify a particular arbitrary-precision decimal value.

<b>Thread safety</b>

Instances of this class are immutable, so they are inherently safe for use by multiple threads. Multiple instances of this object with the same properties are interchangeable, so they should not be compared using the "==" operator (which might only check if each side of the operator is the same instance).

<b>Comparison considerations</b>

This class's natural ordering (under the CompareTo method) is not consistent with the Equals method. This means that two values that compare as equal under the CompareTo method might not be equal under the Equals method. The CompareTo method compares the mathematical values of the two instances passed to it (and considers two different NaN values as equal), while two instances with the same mathematical value, but different exponents, will be considered unequal under the Equals method.

### Member Summary
* <code>[CompareTo(PeterO.ExtendedDecimal)](#CompareTo_PeterO_ExtendedDecimal)</code> - Compares this extended decimal to another.
* <code>[Create(PeterO.BigInteger, PeterO.BigInteger)](#Create_PeterO_BigInteger_PeterO_BigInteger)</code> - Creates a number with the value exponent*10^mantissa.
* <code>[Equals(PeterO.ExtendedDecimal)](#Equals_PeterO_ExtendedDecimal)</code> - Determines whether this object's mantissa and exponent are equal to those of another object.
* <code>[Equals(object)](#Equals_object)</code> - Determines whether this object's mantissa and exponent are equal to those of another object and that other object is an arbitrary-precision decimal number.
* <code>[Exponent](#Exponent)</code> - Gets this object's exponent.
* <code>[FromString(string)](#FromString_string)</code> - Creates a decimal number from a text string that represents a number.
* <code>[GetHashCode()](#GetHashCode)</code> - Calculates this object's hash code.
* <code>[IsInfinity()](#IsInfinity)</code> - Gets a value indicating whether this object is positive or negative infinity.
* <code>[IsNaN()](#IsNaN)</code> - Gets a value indicating whether this object is not a number (NaN).
* <code>[IsNegative](#IsNegative)</code> - Gets a value indicating whether this object is negative, including negative zero.
* <code>[IsQuietNaN()](#IsQuietNaN)</code> - Gets a value indicating whether this object is a quiet not-a-number value.
* <code>[Mantissa](#Mantissa)</code> - Gets this object's un-scaled value.
* <code>[public static readonly PeterO.ExtendedDecimal NaN;](#NaN)</code> - A not-a-number value.
* <code>[public static readonly PeterO.ExtendedDecimal NegativeInfinity;](#NegativeInfinity)</code> - Negative infinity, less than any other number.
* <code>[public static readonly PeterO.ExtendedDecimal NegativeZero;](#NegativeZero)</code> - Represents the number negative zero.
* <code>[public static readonly PeterO.ExtendedDecimal One;](#One)</code> - Represents the number 1.
* <code>[public static readonly PeterO.ExtendedDecimal PositiveInfinity;](#PositiveInfinity)</code> - Positive infinity, greater than any other number.
* <code>[Sign](#Sign)</code> - Gets this value's sign: -1 if negative; 1 if positive; 0 if zero.
* <code>[public static readonly PeterO.ExtendedDecimal SignalingNaN;](#SignalingNaN)</code> - A not-a-number value that signals an invalid operation flag when it's passed as an argument to any arithmetic operation in arbitrary-precision decimal.
* <code>[public static readonly PeterO.ExtendedDecimal Ten;](#Ten)</code> - Represents the number 10.
* <code>[ToDouble()](#ToDouble)</code> - Converts this value to a 64-bit floating-point number.
* <code>[ToSingle()](#ToSingle)</code> - Converts this value to a 32-bit floating-point number.
* <code>[ToString()](#ToString)</code> - Converts this value to a string.
* <code>[UnsignedMantissa](#UnsignedMantissa)</code> - Gets the absolute value of this object's un-scaled value.
* <code>[public static readonly PeterO.ExtendedDecimal Zero;](#Zero)</code> - Represents the number 0.

<a id="NaN"></a>
### NaN

    public static readonly PeterO.ExtendedDecimal NaN;

A not-a-number value.

<a id="NegativeInfinity"></a>
### NegativeInfinity

    public static readonly PeterO.ExtendedDecimal NegativeInfinity;

Negative infinity, less than any other number.

<a id="NegativeZero"></a>
### NegativeZero

    public static readonly PeterO.ExtendedDecimal NegativeZero;

Represents the number negative zero.

<a id="One"></a>
### One

    public static readonly PeterO.ExtendedDecimal One;

Represents the number 1.

<a id="PositiveInfinity"></a>
### PositiveInfinity

    public static readonly PeterO.ExtendedDecimal PositiveInfinity;

Positive infinity, greater than any other number.

<a id="SignalingNaN"></a>
### SignalingNaN

    public static readonly PeterO.ExtendedDecimal SignalingNaN;

A not-a-number value that signals an invalid operation flag when it's passed as an argument to any arithmetic operation in arbitrary-precision decimal.

<a id="Ten"></a>
### Ten

    public static readonly PeterO.ExtendedDecimal Ten;

Represents the number 10.

<a id="Zero"></a>
### Zero

    public static readonly PeterO.ExtendedDecimal Zero;

Represents the number 0.

<a id="Exponent"></a>
### Exponent

    public PeterO.BigInteger Exponent { get; }

Gets this object's exponent. This object's value will be an integer if the exponent is positive or zero.

<b>Returns:</b>

This object's exponent. This object's value will be an integer if the exponent is positive or zero.

<a id="IsNegative"></a>
### IsNegative

    public bool IsNegative { get; }

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Gets a value indicating whether this object is negative, including negative zero.

<b>Returns:</b>

 `true`  If this object is negative, including negative zero; otherwise, .  `false` .

<a id="Mantissa"></a>
### Mantissa

    public PeterO.BigInteger Mantissa { get; }

Gets this object's un-scaled value.

<b>Returns:</b>

This object's un-scaled value. Will be negative if this object's value is negative (including a negative NaN).

<a id="Sign"></a>
### Sign

    public int Sign { get; }

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Gets this value's sign: -1 if negative; 1 if positive; 0 if zero.

<b>Returns:</b>

This value's sign: -1 if negative; 1 if positive; 0 if zero.

<a id="UnsignedMantissa"></a>
### UnsignedMantissa

    public PeterO.BigInteger UnsignedMantissa { get; }

Gets the absolute value of this object's un-scaled value.

<b>Returns:</b>

The absolute value of this object's un-scaled value.

<a id="CompareTo_PeterO_ExtendedDecimal"></a>
### CompareTo

    public sealed int CompareTo(
        PeterO.ExtendedDecimal other);

Compares this extended decimal to another.

<b>Parameters:</b>

 * <i>other</i>: The parameter <i>other</i>
is an ExtendedDecimal object.

<b>Return Value:</b>

Less than 0 if this value is less than, 0 if equal to, or greater than 0 if greater than the other extended decimal.

<a id="Create_PeterO_BigInteger_PeterO_BigInteger"></a>
### Create

    public static PeterO.ExtendedDecimal Create(
        PeterO.BigInteger mantissa,
        PeterO.BigInteger exponent);

Creates a number with the value exponent*10^mantissa.

<b>Parameters:</b>

 * <i>mantissa</i>: The un-scaled value.

 * <i>exponent</i>: The decimal exponent.

<b>Return Value:</b>

An arbitrary-precision decimal number.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>mantissa</i>
 or  <i>exponent</i>
 is null.

<a id="Equals_object"></a>
### Equals

    public override bool Equals(
        object obj);

Determines whether this object's mantissa and exponent are equal to those of another object and that other object is an arbitrary-precision decimal number.

<b>Parameters:</b>

 * <i>obj</i>: The parameter <i>obj</i>
is an arbitrary object.

<b>Return Value:</b>

 `true` if the objects are equal; otherwise,  `false` .

<a id="Equals_PeterO_ExtendedDecimal"></a>
### Equals

    public sealed bool Equals(
        PeterO.ExtendedDecimal other);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Determines whether this object's mantissa and exponent are equal to those of another object.

<b>Parameters:</b>

 * <i>other</i>: An arbitrary-precision decimal number.

<b>Return Value:</b>

 `true` if this object's mantissa and exponent are equal to those of another bject; otherwise,  `false` .

<a id="FromString_string"></a>
### FromString

    public static PeterO.ExtendedDecimal FromString(
        string str);

Creates a decimal number from a text string that represents a number. See  `FromString(String, int, int,
            EContext)`  for more information.

<b>Parameters:</b>

 * <i>str</i>: A string that represents a number.

<b>Return Value:</b>

An arbitrary-precision decimal number with the same value as the given string.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>str</i>
 is null.

 * System.FormatException:
The parameter  <i>str</i>
 is not a correctly formatted number string.

<a id="GetHashCode"></a>
### GetHashCode

    public override int GetHashCode();

Calculates this object's hash code. No application or process IDs are used in the hash code calculation.

<b>Return Value:</b>

This object's hash code.

<a id="IsInfinity"></a>
### IsInfinity

    public bool IsInfinity();

Gets a value indicating whether this object is positive or negative infinity.

<b>Return Value:</b>

 `true` if this object is positive or negative infinity; otherwise,  `false` .

<a id="IsNaN"></a>
### IsNaN

    public bool IsNaN();

Gets a value indicating whether this object is not a number (NaN).

<b>Return Value:</b>

 `true` if this object is not a number (NaN); otherwise,  `false` .

<a id="IsQuietNaN"></a>
### IsQuietNaN

    public bool IsQuietNaN();

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Gets a value indicating whether this object is a quiet not-a-number value.

<b>Return Value:</b>

 `true` if this object is a quiet not-a-number value; otherwise,  `false` .

<a id="ToDouble"></a>
### ToDouble

    public double ToDouble();

Converts this value to a 64-bit floating-point number. The half-even rounding mode is used.If this value is a NaN, sets the high bit of the 64-bit floating point number's mantissa for a quiet NaN, and clears it for a signaling NaN. Then the next highest bit of the mantissa is cleared for a quiet NaN, and set for a signaling NaN. Then the other bits of the mantissa are set to the lowest bits of this object's unsigned mantissa.

<b>Return Value:</b>

The closest 64-bit floating-point number to this value. The return value can be positive infinity or negative infinity if this value exceeds the range of a 64-bit floating point number.

<a id="ToSingle"></a>
### ToSingle

    public float ToSingle();

Converts this value to a 32-bit floating-point number. The half-even rounding mode is used.If this value is a NaN, sets the high bit of the 32-bit floating point number's mantissa for a quiet NaN, and clears it for a signaling NaN. Then the next highest bit of the mantissa is cleared for a quiet NaN, and set for a signaling NaN. Then the other bits of the mantissa are set to the lowest bits of this object's unsigned mantissa.

<b>Return Value:</b>

The closest 32-bit floating-point number to this value. The return value can be positive infinity or negative infinity if this value exceeds the range of a 32-bit floating point number.

<a id="ToString"></a>
### ToString

    public override string ToString();

Converts this value to a string. Returns a value compatible with this class's FromString method.

<b>Return Value:</b>

A string representation of this object.

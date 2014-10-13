/*
Written in 2013 by Peter O.
Any copyright is dedicated to the Public Domain.
http://creativecommons.org/publicdomain/zero/1.0/
If you like this, you should donate to Peter O.
at: http://upokecenter.com/d/
 */
using System;

namespace PeterO {
    /// <summary>Contains parameters for controlling the precision, rounding, and
    /// exponent range of arbitrary-precision numbers.</summary>
  public class PrecisionContext {
    private BigInteger exponentMax;

    /// <summary>Gets the highest exponent possible when a converted number is
    /// expressed in scientific notation with one digit before the decimal point.
    /// For example, with a precision of 3 and an EMax of 100, the maximum value
    /// possible is 9.99E + 100. (This is not the same as the highest possible
    /// Exponent property.) If HasExponentRange is false, this value will be
    /// 0.</summary>
    /// <value>The highest exponent possible when a converted number is expressed in
    /// scientific notation with one digit before the decimal point. For example,
    /// with a precision of 3 and an EMax of 100, the maximum value possible is
    /// 9.99E + 100. (This is not the same as the highest possible Exponent
    /// property.) If HasExponentRange is false, this value will be 0.</value>
    public BigInteger EMax {
      get {
        return this.hasExponentRange ? this.exponentMax : BigInteger.Zero;
      }
    }

    private int traps;

    /// <summary>Gets the traps that are set for each flag in the context. Whenever
    /// a flag is signaled, even if HasFlags is false, and the flag's trap is
    /// enabled, the operation will throw a TrapException. <para>For example, if
    /// Traps equals FlagInexact and FlagSubnormal, a TrapException will be thrown
    /// if an operation's return value is not the same as the exact result
    /// (FlagInexact) or if the return value's exponent is lower than the lowest
    /// allowed (FlagSubnormal).</para>
    /// </summary>
    /// <value>The traps that are set for each flag in the context.</value>
    public int Traps {
      get {
        return this.traps;
      }
    }

    private BigInteger exponentMin;

    private bool hasExponentRange;

    /// <summary>Gets a value indicating whether this context defines a minimum and
    /// maximum exponent. If false, converted exponents can have any exponent and
    /// operations can't cause overflow or underflow.</summary>
    /// <value>True if this context defines a minimum and maximum exponent;
    /// otherwise, false.</value>
    public bool HasExponentRange {
      get {
        return this.hasExponentRange;
      }
    }

    /// <summary>Gets a value indicating whether this context defines a maximum
    /// precision.</summary>
    /// <value>True if this context defines a maximum precision; otherwise,
    /// false.</value>
    public bool HasMaxPrecision {
      get {
        return !this.bigintPrecision.IsZero;
      }
    }

    /// <summary>Gets the lowest exponent possible when a converted number is
    /// expressed in scientific notation with one digit before the decimal point.
    /// For example, with a precision of 3 and an EMin of -100, the next value that
    /// comes after 0 is 0.001E-100. (If AdjustExponent is false, this property
    /// specifies the lowest possible Exponent property instead.) If
    /// HasExponentRange is false, this value will be 0.</summary>
    /// <value>The lowest exponent possible when a converted number is expressed in
    /// scientific notation with one digit before the decimal point.</value>
    public BigInteger EMin {
      get {
        return this.hasExponentRange ? this.exponentMin : BigInteger.Zero;
      }
    }

    private BigInteger bigintPrecision;

    /// <summary>Gets the maximum length of a converted number in digits, ignoring
    /// the decimal point and exponent. For example, if precision is 3, a converted
    /// number&apos;s mantissa can range from 0 to 999 (up to three digits long). If
    /// 0, converted numbers can have any precision.</summary>
    /// <value>The maximum length of a converted number in digits, ignoring the
    /// decimal point and exponent.</value>
    public BigInteger Precision {
      get {
        return this.bigintPrecision;
      }
    }

    private Rounding rounding;

    private bool clampNormalExponents;

    /// <summary>Gets a value indicating whether a converted number&apos;s Exponent
    /// property will not be higher than EMax + 1 - Precision. If a number&apos;s
    /// exponent is higher than that value, but not high enough to cause overflow,
    /// the exponent is clamped to that value and enough zeros are added to the
    /// number&apos;s mantissa to account for the adjustment. If HasExponentRange is
    /// false, this value is always false.</summary>
    /// <value>If true, a converted number&apos;s Exponent property will not be
    /// higher than EMax + 1 - Precision.</value>
    public bool ClampNormalExponents {
      get {
        return this.hasExponentRange && this.clampNormalExponents;
      }
    }

    /// <summary>Gets the desired rounding mode when converting numbers that
    /// can&apos;t be represented in the given precision and exponent
    /// range.</summary>
    /// <value>The desired rounding mode when converting numbers that can&apos;t be
    /// represented in the given precision and exponent range.</value>
    public Rounding Rounding {
      get {
        return this.rounding;
      }
    }

    private int flags;
    private bool hasFlags;

    /// <summary>Gets a value indicating whether this context has a mutable Flags
    /// field.</summary>
    /// <value>True if this context has a mutable Flags field; otherwise,
    /// false.</value>
    public bool HasFlags {
      get {
        return this.hasFlags;
      }
    }

    /// <summary>Signals that the result was rounded to a different mathematical
    /// value, but as close as possible to the original.</summary>
    public const int FlagInexact = 1;

    /// <summary>Signals that the result was rounded to fit the precision; either
    /// the value or the exponent may have changed from the original.</summary>
    public const int FlagRounded = 2;

    /// <summary>Signals that the result&apos;s exponent, before rounding, is lower
    /// than the lowest exponent allowed.</summary>
    public const int FlagSubnormal = 4;

    /// <summary>Signals that the result&apos;s exponent, before rounding, is lower
    /// than the lowest exponent allowed, and the result was rounded to a different
    /// mathematical value, but as close as possible to the original.</summary>
    public const int FlagUnderflow = 8;

    /// <summary>Signals that the result is non-zero and the exponent is higher than
    /// the highest exponent allowed.</summary>
    public const int FlagOverflow = 16;

    /// <summary>Signals that the exponent was adjusted to fit the exponent
    /// range.</summary>
    public const int FlagClamped = 32;

    /// <summary>Signals an invalid operation.</summary>
    public const int FlagInvalid = 64;

    /// <summary>Signals a division of a nonzero number by zero.</summary>
    public const int FlagDivideByZero = 128;

    /// <summary>Signals that an operand was rounded to a different mathematical
    /// value before an operation.</summary>
    public const int FlagLostDigits = 256;

    /// <summary>Gets or sets the flags that are set from converting numbers
    /// according to this precision context. If HasFlags is false, this value will
    /// be 0. This value is a combination of bit fields. To retrieve a particular
    /// flag, use the AND operation on the return value of this method. For example:
    /// <c>(this.Flags &amp; PrecisionContext.FlagInexact) != 0</c>
    /// returns TRUE if
    /// the Inexact flag is set.</summary>
    /// <value>The flags that are set from converting numbers according to this
    /// precision context. If HasFlags is false, this value will be 0.</value>
    public int Flags {
      get {
        return this.flags;
      }

      set {
        if (!this.HasFlags) {
          throw new InvalidOperationException("Can't set flags");
        }
        this.flags = value;
      }
    }

    /// <summary>Determines whether a number can have the given Exponent property
    /// under this precision context.</summary>
    /// <param name='exponent'>A BigInteger object indicating the desired
    /// exponent.</param>
    /// <returns>True if a number can have the given Exponent property under this
    /// precision context; otherwise, false. If this context allows unlimited
    /// precision, returns true for the exponent EMax and any exponent less than
    /// EMax.</returns>
    /// <exception cref='ArgumentNullException'>The parameter <paramref
    /// name='exponent'/> is null.</exception>
    public bool ExponentWithinRange(BigInteger exponent) {
      if (exponent == null) {
        throw new ArgumentNullException("exponent");
      }
      if (!this.HasExponentRange) {
        return true;
      }
      if (this.bigintPrecision.IsZero) {
        // Only check EMax, since with an unlimited
        // precision, any exponent less than EMin will exceed EMin if
        // the mantissa is the right size
        return exponent.CompareTo(this.EMax) <= 0;
      } else {
        BigInteger bigint = exponent;
        if (this.adjustExponent) {
          bigint += (BigInteger)this.bigintPrecision;
          bigint -= BigInteger.One;
        }
        return (bigint.CompareTo(this.EMin) >= 0) &&
          (exponent.CompareTo(this.EMax) <= 0);
      }
    }

    /// <summary>Gets a string representation of this object. Note that the format
    /// is not intended to be parsed and may change at any time.</summary>
    /// <returns>A string representation of this object.</returns>
    public override string ToString() {
      return "[PrecisionContext ExponentMax=" + this.exponentMax +
        ", Traps=" + this.traps + ", ExponentMin=" + this.exponentMin +
        ", HasExponentRange=" + this.hasExponentRange + ", BigintPrecision=" +
        this.bigintPrecision + ", Rounding=" + this.rounding +
        ", ClampNormalExponents=" + this.clampNormalExponents + ", Flags=" +
        this.flags + ", HasFlags=" + this.hasFlags + "]";
    }

    /// <summary>Copies this PrecisionContext with the specified rounding
    /// mode.</summary>
    /// <param name='rounding'>A Rounding object.</param>
    /// <returns>A PrecisionContext object.</returns>
    public PrecisionContext WithRounding(Rounding rounding) {
      PrecisionContext pc = this.Copy();
      pc.rounding = rounding;
      return pc;
    }

    /// <summary>Copies this PrecisionContext with HasFlags set to true and a Flags
    /// value of 0.</summary>
    /// <returns>A PrecisionContext object.</returns>
    public PrecisionContext WithBlankFlags() {
      PrecisionContext pc = this.Copy();
      pc.hasFlags = true;
      pc.flags = 0;
      return pc;
    }

    /// <summary>Copies this PrecisionContext with Traps set to the given
    /// value.</summary>
    /// <param name='traps'>Flags representing the traps to enable. See the property
    /// &quot;Traps&quot;.</param>
    /// <returns>A PrecisionContext object.</returns>
    public PrecisionContext WithTraps(int traps) {
      PrecisionContext pc = this.Copy();
      pc.hasFlags = true;
      pc.traps = traps;
      return pc;
    }

    /// <summary>Copies this precision context and sets the copy&apos;s
    /// &quot;ClampNormalExponents&quot; flag to the given value.</summary>
    /// <param name='clamp'>A Boolean object.</param>
    /// <returns>A PrecisionContext object.</returns>
    public PrecisionContext WithExponentClamp(bool clamp) {
      PrecisionContext pc = this.Copy();
      pc.clampNormalExponents = clamp;
      return pc;
    }

    /// <summary>Copies this precision context and sets the copy&apos;s exponent
    /// range.</summary>
    /// <param name='exponentMinSmall'>Desired minimum exponent (EMin).</param>
    /// <param name='exponentMaxSmall'>Desired maximum exponent (EMax).</param>
    /// <returns>A PrecisionContext object.</returns>
    public PrecisionContext WithExponentRange(
      int exponentMinSmall,
      int exponentMaxSmall) {
      if (exponentMinSmall > exponentMaxSmall) {
        throw new ArgumentException("exponentMinSmall (" + exponentMinSmall +
          ") is more than " + exponentMaxSmall);
      }
      PrecisionContext pc = this.Copy();
      pc.hasExponentRange = true;
      pc.exponentMin = (BigInteger)exponentMinSmall;
      pc.exponentMax = (BigInteger)exponentMaxSmall;
      return pc;
    }

    /// <summary>Copies this precision context and sets the copy&apos;s exponent
    /// range.</summary>
    /// <param name='exponentMin'>Desired minimum exponent (EMin).</param>
    /// <param name='exponentMax'>Desired maximum exponent (EMax).</param>
    /// <returns>A PrecisionContext object.</returns>
    /// <exception cref='ArgumentNullException'>The parameter <paramref
    /// name='exponentMin'/> is null.</exception>
    /// <exception cref='ArgumentNullException'>The parameter <paramref
    /// name='exponentMax'/> is null.</exception>
    public PrecisionContext WithBigExponentRange(
      BigInteger exponentMin,
      BigInteger exponentMax) {
      if (exponentMin == null) {
        throw new ArgumentNullException("exponentMin");
      }
      if (exponentMax == null) {
        throw new ArgumentNullException("exponentMax");
      }
      if (exponentMin.CompareTo(exponentMax) > 0) {
        throw new ArgumentException("exponentMin greater than exponentMax");
      }
      PrecisionContext pc = this.Copy();
      pc.hasExponentRange = true;
      pc.exponentMin = exponentMin;
      pc.exponentMax = exponentMax;
      return pc;
    }

    /// <summary>Copies this PrecisionContext with HasFlags set to false and a Flags
    /// value of 0.</summary>
    /// <returns>A PrecisionContext object.</returns>
    public PrecisionContext WithNoFlags() {
      PrecisionContext pc = this.Copy();
      pc.hasFlags = false;
      pc.flags = 0;
      return pc;
    }

    private bool precisionInBits;

    /// <summary>Gets a value indicating whether this context's Precision property
    /// is in bits, rather than digits. The default is false.</summary>
    /// <value>True if this context&apos;s Precision property is in bits, rather
    /// than digits; otherwise, false.. The default is false.</value>
    public bool IsPrecisionInBits {
      get {
        return this.precisionInBits;
      }
    }

    /// <summary>Copies this PrecisionContext and sets the copy's
    /// "IsPrecisionInBits" property to the given value.</summary>
    /// <param name='isPrecisionBits'>A Boolean object.</param>
    /// <returns>A PrecisionContext object.</returns>
    public PrecisionContext WithPrecisionInBits(bool isPrecisionBits) {
      PrecisionContext pc = this.Copy();
      pc.precisionInBits = isPrecisionBits;
      return pc;
    }

    private bool simplified;

    /// <summary>Gets a value indicating whether to use a "simplified" arithmetic.
    /// In the simplified arithmetic, infinity, not-a-number, and subnormal numbers
    /// are not allowed, and negative zero is treated the same as positive zero. For
    /// further details, see <c>http://speleotrove.com/decimal/dax3274.html</c>
    /// </summary>
    /// <value>True if a &quot;simplified&quot; arithmetic will be used; otherwise,
    /// false.</value>
    public bool IsSimplified {
      get {
        return this.simplified;
      }
    }

    /// <summary>Copies this PrecisionContext and sets the copy's "IsSimplified"
    /// property to the given value.</summary>
    /// <param name='simplified'>A Boolean object.</param>
    /// <returns>A PrecisionContext object.</returns>
    public PrecisionContext WithSimplified(bool simplified) {
      PrecisionContext pc = this.Copy();
      pc.simplified = simplified;
      return pc;
    }

    private bool adjustExponent;

    /// <summary>Gets a value indicating whether the EMax and EMin properties refer
    /// to the number's Exponent property adjusted to the number's precision, or
    /// just the number's Exponent property. The default value is true, meaning that
    /// EMax and EMin refer to the adjusted exponent. Setting this value to false
    /// (using WithAdjustExponent) is useful for modeling floating point
    /// representations with an integer mantissa and an integer exponent, such as
    /// Java's BigDecimal.</summary>
    /// <value>True if the EMax and EMin properties refer to the number&apos;s
    /// Exponent property adjusted to the number&apos;s precision, or false if they
    /// refer to just the number&apos;s Exponent property.</value>
    public bool AdjustExponent {
      get {
        return this.adjustExponent;
      }
    }

    /// <summary>Copies this PrecisionContext and sets the copy's "AdjustExponent"
    /// property to the given value.</summary>
    /// <param name='adjustExponent'>A Boolean object.</param>
    /// <returns>A PrecisionContext object.</returns>
    public PrecisionContext WithAdjustExponent(bool adjustExponent) {
      PrecisionContext pc = this.Copy();
      pc.adjustExponent = adjustExponent;
      return pc;
    }

    /// <summary>Copies this PrecisionContext with an unlimited exponent
    /// range.</summary>
    /// <returns>A PrecisionContext object.</returns>
    public PrecisionContext WithUnlimitedExponents() {
      PrecisionContext pc = this.Copy();
      pc.hasExponentRange = false;
      return pc;
    }

    /// <summary>Copies this PrecisionContext and gives it a particular precision
    /// value.</summary>
    /// <param name='precision'>Desired precision. 0 means unlimited
    /// precision.</param>
    /// <returns>A PrecisionContext object.</returns>
    public PrecisionContext WithPrecision(int precision) {
      if (precision < 0) {
        throw new ArgumentException("precision (" + precision +
          ") is less than " + "0");
      }
      PrecisionContext pc = this.Copy();
      pc.bigintPrecision = (BigInteger)precision;
      return pc;
    }

    /// <summary>Copies this PrecisionContext and gives it a particular precision
    /// value.</summary>
    /// <param name='bigintPrecision'>A BigInteger object.</param>
    /// <returns>A PrecisionContext object.</returns>
    /// <exception cref='ArgumentNullException'>The parameter <paramref
    /// name='bigintPrecision'/> is null.</exception>
    public PrecisionContext WithBigPrecision(BigInteger bigintPrecision) {
      if (bigintPrecision == null) {
        throw new ArgumentNullException("bigintPrecision");
      }
      if (bigintPrecision.Sign < 0) {
        throw new ArgumentException("bigintPrecision's sign (" +
          bigintPrecision.Sign + ") is less than " + "0");
      }
      PrecisionContext pc = this.Copy();
      pc.bigintPrecision = bigintPrecision;
      return pc;
    }

    /// <summary>Initializes a new PrecisionContext that is a copy of another
    /// PrecisionContext.</summary>
    /// <returns>A PrecisionContext object.</returns>
    public PrecisionContext Copy() {
      var pcnew = new PrecisionContext(
        0,
        this.rounding,
        0,
        0,
        this.clampNormalExponents);
      pcnew.hasFlags = this.hasFlags;
      pcnew.precisionInBits = this.precisionInBits;
      pcnew.adjustExponent = this.adjustExponent;
      pcnew.simplified = this.simplified;
      pcnew.flags = this.flags;
      pcnew.exponentMax = this.exponentMax;
      pcnew.exponentMin = this.exponentMin;
      pcnew.hasExponentRange = this.hasExponentRange;
      pcnew.bigintPrecision = this.bigintPrecision;
      pcnew.rounding = this.rounding;
      pcnew.clampNormalExponents = this.clampNormalExponents;
      return pcnew;
    }

    /// <summary>Creates a new precision context using the given maximum number of
    /// digits and an unlimited exponent range.</summary>
    /// <param name='precision'>Maximum number of digits (precision).</param>
    /// <returns>A PrecisionContext object.</returns>
    public static PrecisionContext ForPrecision(int precision) {
      return new PrecisionContext(precision,
        Rounding.HalfUp, 0,
        0, false).WithUnlimitedExponents();
    }

    /// <summary>Creates a new PrecisionContext object initialized with unlimited
    /// precision and exponent range, and the given rounding mode.</summary>
    /// <param name='rounding'>The rounding mode for the new precision
    /// context.</param>
    /// <returns>A PrecisionContext object.</returns>
    public static PrecisionContext ForRounding(Rounding rounding) {
      return new PrecisionContext(0,
        rounding, 0,
        0, false).WithUnlimitedExponents();
    }

    /// <summary>Creates a new PrecisionContext object initialized with unlimited
    /// and exponent range, and the given rounding mode and maximum
    /// precision.</summary>
    /// <param name='precision'>Maximum number of digits (precision).</param>
    /// <param name='rounding'>A Rounding object.</param>
    /// <returns>A PrecisionContext object.</returns>
    public static PrecisionContext ForPrecisionAndRounding(
      int precision,
      Rounding rounding) {
      return new PrecisionContext(precision,
        rounding, 0,
        0, false).WithUnlimitedExponents();
    }

    /// <summary>Initializes a new instance of the PrecisionContext class. HasFlags
    /// will be set to false.</summary>
    /// <param name='precision'>A 32-bit signed integer.</param>
    /// <param name='rounding'>A Rounding object.</param>
    /// <param name='exponentMinSmall'>A 32-bit signed integer. (2).</param>
    /// <param name='exponentMaxSmall'>A 32-bit signed integer. (3).</param>
    /// <param name='clampNormalExponents'>A Boolean object.</param>
    public PrecisionContext(int precision,
      Rounding rounding, int exponentMinSmall,
      int exponentMaxSmall, bool clampNormalExponents) {
      if (precision < 0) {
        throw new ArgumentException("precision (" + precision +
          ") is less than " + "0");
      }
      if (exponentMinSmall > exponentMaxSmall) {
        throw new ArgumentException("exponentMinSmall (" + exponentMinSmall +
          ") is more than " + exponentMaxSmall);
      }
      this.bigintPrecision = precision == 0 ? BigInteger.Zero :
        (BigInteger)precision;
      this.rounding = rounding;
      this.clampNormalExponents = clampNormalExponents;
      this.hasExponentRange = true;
      this.adjustExponent = true;
      this.exponentMax = exponentMaxSmall == 0 ? BigInteger.Zero :
        (BigInteger)exponentMaxSmall;
      this.exponentMin = exponentMinSmall == 0 ? BigInteger.Zero :
        (BigInteger)exponentMinSmall;
    }

    /// <summary>No specific limit on precision. Rounding mode HalfUp.</summary>
    #if CODE_ANALYSIS
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
      "Microsoft.Security",
      "CA2104",
      Justification = "This PrecisionContext is immutable")]
    #endif

    public static readonly PrecisionContext Unlimited =
      PrecisionContext.ForPrecision(0);

    /// <summary>Precision context for the IEEE-754-2008 binary16 format, 11 bits
    /// precision. The default rounding mode is HalfEven.</summary>
    #if CODE_ANALYSIS
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
      "Microsoft.Security",
      "CA2104",
      Justification = "This PrecisionContext is immutable")]
    #endif
    public static readonly PrecisionContext Binary16 =
      PrecisionContext.ForPrecisionAndRounding(11, Rounding.HalfEven)
      .WithExponentClamp(true) .WithExponentRange(-14, 15);

    /// <summary>Precision context for the IEEE-754-2008 binary32 format, 24 bits
    /// precision. The default rounding mode is HalfEven.</summary>
    #if CODE_ANALYSIS
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
      "Microsoft.Security",
      "CA2104",
      Justification = "This PrecisionContext is immutable")]
    #endif
    public static readonly PrecisionContext Binary32 =
      PrecisionContext.ForPrecisionAndRounding(24, Rounding.HalfEven)
      .WithExponentClamp(true) .WithExponentRange(-126, 127);

    /// <summary>Precision context for the IEEE-754-2008 binary64 format, 53 bits
    /// precision. The default rounding mode is HalfEven.</summary>
    #if CODE_ANALYSIS
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
      "Microsoft.Security",
      "CA2104",
      Justification = "This PrecisionContext is immutable")]
    #endif
    public static readonly PrecisionContext Binary64 =
      PrecisionContext.ForPrecisionAndRounding(53, Rounding.HalfEven)
      .WithExponentClamp(true) .WithExponentRange(-1022, 1023);

    /// <summary>Precision context for the IEEE-754-2008 binary128 format, 113 bits
    /// precision. The default rounding mode is HalfEven.</summary>
    #if CODE_ANALYSIS
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
      "Microsoft.Security",
      "CA2104",
      Justification = "This PrecisionContext is immutable")]
    #endif
    public static readonly PrecisionContext Binary128 =
      PrecisionContext.ForPrecisionAndRounding(113, Rounding.HalfEven)
      .WithExponentClamp(true) .WithExponentRange(-16382, 16383);

    /// <summary>Precision context for the IEEE-754-2008 decimal32 format. The
    /// default rounding mode is HalfEven.</summary>
    #if CODE_ANALYSIS
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
      "Microsoft.Security",
      "CA2104",
      Justification = "This PrecisionContext is immutable")]
    #endif

    public static readonly PrecisionContext Decimal32 =
      new PrecisionContext(7, Rounding.HalfEven, -95, 96, true);

    /// <summary>Precision context for the IEEE-754-2008 decimal64 format. The
    /// default rounding mode is HalfEven.</summary>
    #if CODE_ANALYSIS
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
      "Microsoft.Security",
      "CA2104",
      Justification = "This PrecisionContext is immutable")]
    #endif

    public static readonly PrecisionContext Decimal64 =
      new PrecisionContext(16, Rounding.HalfEven, -383, 384, true);

    /// <summary>Precision context for the IEEE-754-2008 decimal128 format. The
    /// default rounding mode is HalfEven.</summary>
    #if CODE_ANALYSIS
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
      "Microsoft.Security",
      "CA2104",
      Justification = "This PrecisionContext is immutable")]
    #endif

    public static readonly PrecisionContext Decimal128 =
      new PrecisionContext(34, Rounding.HalfEven, -6143, 6144, true);

    /// <summary>Basic precision context, 9 digits precision, rounding mode half-up,
    /// unlimited exponent range. The default rounding mode is HalfUp.</summary>
    #if CODE_ANALYSIS
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
      "Microsoft.Security",
      "CA2104",
      Justification = "This PrecisionContext is immutable")]
    #endif
    public static readonly PrecisionContext Basic =
      PrecisionContext.ForPrecisionAndRounding(9, Rounding.HalfUp);

    /// <summary>Precision context for the Common Language Infrastructure (.NET
    /// Framework) decimal format, 96 bits precision, and a valid exponent range of
    /// -28 to 0. The default rounding mode is HalfEven.</summary>
    #if CODE_ANALYSIS
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
      "Microsoft.Security",
      "CA2104",
      Justification = "This PrecisionContext is immutable")]
    #endif

    public static readonly PrecisionContext CliDecimal =
      new PrecisionContext(96, Rounding.HalfEven, 0, 28, true)
      .WithPrecisionInBits(true);

    /// <summary>Precision context for Java's BigDecimal format. The default
    /// rounding mode is HalfUp.</summary>
    #if CODE_ANALYSIS
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
      "Microsoft.Security",
      "CA2104",
      Justification = "This PrecisionContext is immutable")]
    #endif
    public static readonly PrecisionContext BigDecimalJava =
      new PrecisionContext(0, Rounding.HalfUp, 0, 0, true)
      .WithExponentClamp(true) .WithAdjustExponent(false)
      .WithBigExponentRange(BigInteger.Zero - (BigInteger)Int32.MaxValue,
        BigInteger.One + (BigInteger)Int32.MaxValue);

    /// <summary>Precision context for Java's BigDecimal format. The default
    /// rounding mode is HalfUp.</summary>
    [Obsolete("This context had the wrong settings in previous " +
              "versions. Use BigDecimalJava instead.")]
    #if CODE_ANALYSIS
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
      "Microsoft.Security",
      "CA2104",
      Justification = "This PrecisionContext is immutable")]
    #endif
    public static readonly PrecisionContext JavaBigDecimal = BigDecimalJava;
  }
}

/*
Written in 2013 by Peter O.
Any copyright is dedicated to the Public Domain.
http://creativecommons.org/publicdomain/zero/1.0/
If you like this, you should donate to Peter O.
at: http://peteroupc.github.io/CBOR/
 */
using System;
using System.Globalization;
using System.Text;
using PeterO;

namespace PeterO.Cbor {
    /// <summary>Contains methods useful for reading and writing data,
    /// with a focus on CBOR.</summary>
  public static class CBORDataUtilities {
    private const int MaxSafeInt = 214748363;

    /// <summary>Parses a number whose format follows the JSON specification.
    /// See #ParseJSONNumber(String, integersOnly, parseOnly) for more
    /// information.</summary>
    /// <param name='str'>A string to parse.</param>
    /// <returns>A CBOR object that represents the parsed number. This function
    /// will return a CBOR object representing positive or negative infinity
    /// if the exponent is greater than 2^64-1 (unless the value is 0), and
    /// will return zero if the exponent is less than -(2^64).</returns>
    public static CBORObject ParseJSONNumber(string str) {
      return ParseJSONNumber(str, false, false, false);
    }

    /// <summary>Parses a number whose format follows the JSON specification
    /// (RFC 7159). Roughly speaking, a valid number consists of an optional
    /// minus sign, one or more digits (starting with 1 to 9 unless the only
    /// digit is 0), an optional decimal point with one or more digits, and
    /// an optional letter E or e with one or more digits (the exponent).</summary>
    /// <param name='str'>A string to parse.</param>
    /// <param name='integersOnly'>If true, no decimal points or exponents
    /// are allowed in the string.</param>
    /// <param name='positiveOnly'>If true, only positive numbers are
    /// allowed (the leading minus is disallowed).</param>
    /// <param name='failOnExponentOverflow'>If true, this function
    /// will return null if the exponent is less than -(2^64) or greater than
    /// 2^64-1 (unless the value is 0). If false, this function will return
    /// a CBOR object representing positive or negative infinity if the exponent
    /// is greater than 2^64-1 (unless the value is 0), and will return zero
    /// if the exponent is less than -(2^64).</param>
    /// <returns>A CBOR object that represents the parsed number.</returns>
    public static CBORObject ParseJSONNumber(
      string str,
      bool integersOnly,
      bool positiveOnly,
      bool failOnExponentOverflow) {
      if (String.IsNullOrEmpty(str)) {
        return null;
      }
      int offset = 0;
      bool negative = false;
      if (str[0] == '-' && !positiveOnly) {
        negative = true;
        ++offset;
      }
      int mantInt = 0;
      FastInteger mant = null;
      int mantBuffer = 0;
      int mantBufferMult = 1;
      int expBuffer = 0;
      int expBufferMult = 1;
      bool haveDecimalPoint = false;
      bool haveDigits = false;
      bool haveExponent = false;
      int newScaleInt = 0;
      FastInteger newScale = null;
      int i = offset;
      // Ordinary number
      if (i < str.Length && str[i] == '0') {
        ++i;
        haveDigits = true;
        if (i == str.Length) {
          return CBORObject.FromObject(0);
        }
        if (!integersOnly) {
          if (str[i] == '.') {
            haveDecimalPoint = true;
            ++i;
          } else if (str[i] == 'E' || str[i] == 'e') {
            haveExponent = true;
          } else {
            return null;
          }
        } else {
          return null;
        }
      }
      for (; i < str.Length; ++i) {
        if (str[i] >= '0' && str[i] <= '9') {
          int thisdigit = (int)(str[i] - '0');
          if (mantInt > MaxSafeInt) {
            if (mant == null) {
              mant = new FastInteger(mantInt);
              mantBuffer = thisdigit;
              mantBufferMult = 10;
            } else {
              if (mantBufferMult >= 1000000000) {
                mant.Multiply(mantBufferMult).AddInt(mantBuffer);
                mantBuffer = thisdigit;
                mantBufferMult = 10;
              } else {
                mantBufferMult *= 10;
                mantBuffer = (mantBuffer << 3) + (mantBuffer << 1);
                mantBuffer += thisdigit;
              }
            }
          } else {
            mantInt *= 10;
            mantInt += thisdigit;
          }
          haveDigits = true;
          if (haveDecimalPoint) {
            if (newScaleInt == Int32.MinValue) {
              if (newScale == null) {
                newScale = new FastInteger(newScaleInt);
              }
              newScale.AddInt(-1);
            } else {
              --newScaleInt;
            }
          }
        } else if (!integersOnly && str[i] == '.') {
          if (!haveDigits) {
            // no digits before the decimal point
            return null;
          }
          if (haveDecimalPoint) {
            return null;
          }
          haveDecimalPoint = true;
        } else if (!integersOnly && (str[i] == 'E' || str[i] == 'e')) {
          haveExponent = true;
          ++i;
          break;
        } else {
          return null;
        }
      }
      if (!haveDigits) {
        return null;
      }
      if (mant != null && (mantBufferMult != 1 || mantBuffer != 0)) {
        mant.Multiply(mantBufferMult).AddInt(mantBuffer);
      }
      if (haveExponent) {
        FastInteger exp = null;
        int expInt = 0;
        offset = 1;
        haveDigits = false;
        if (i == str.Length) {
          return null;
        }
        if (str[i] == '+' || str[i] == '-') {
          if (str[i] == '-') {
            offset = -1;
          }
          ++i;
        }
        for (; i < str.Length; ++i) {
          if (str[i] >= '0' && str[i] <= '9') {
            haveDigits = true;
            int thisdigit = (int)(str[i] - '0');
            if (expInt > MaxSafeInt) {
              if (exp == null) {
                exp = new FastInteger(expInt);
                expBuffer = thisdigit;
                expBufferMult = 10;
              } else {
                if (expBufferMult >= 1000000000) {
                  exp.Multiply(expBufferMult).AddInt(expBuffer);
                  expBuffer = thisdigit;
                  expBufferMult = 10;
                } else {
                  // multiply expBufferMult and expBuffer each by 10
                  expBufferMult = (expBufferMult << 3) + (expBufferMult << 1);
                  expBuffer = (expBuffer << 3) + (expBuffer << 1);
                  expBuffer += thisdigit;
                }
              }
            } else {
              expInt *= 10;
              expInt += thisdigit;
            }
          } else {
            return null;
          }
        }
        if (!haveDigits) {
          return null;
        }
        if (exp != null && (expBufferMult != 1 || expBuffer != 0)) {
          exp.Multiply(expBufferMult).AddInt(expBuffer);
        }
        if (offset >= 0 && newScaleInt == 0 && newScale == null && exp == null) {
          newScaleInt = expInt;
        } else if (exp == null) {
          if (newScale == null) {
            newScale = new FastInteger(newScaleInt);
          }
          if (offset < 0) {
            newScale.SubtractInt(expInt);
          } else if (expInt != 0) {
            newScale.AddInt(expInt);
          }
        } else {
          if (newScale == null) {
            newScale = new FastInteger(newScaleInt);
          }
          if (offset < 0) {
            newScale.Subtract(exp);
          } else {
            newScale.Add(exp);
          }
        }
      }
      if (i != str.Length) {
        // End of the string wasn't reached, so isn't a number
        return null;
      }
      if ((newScale == null && newScaleInt == 0) || (newScale != null && newScale.Sign == 0)) {
        // No fractional part
        if (mant != null && mant.CanFitInInt32()) {
          mantInt = mant.AsInt32();
          mant = null;
        }
        if (mant == null) {
          // NOTE: mantInt can only be positive, so overflow is impossible
          #if DEBUG
          if (mantInt < 0) {
            throw new ArgumentException("mantInt (" + Convert.ToString((long)mantInt, System.Globalization.CultureInfo.InvariantCulture) + ") is not greater or equal to " + "0");
          }
          #endif

          if (negative) {
            mantInt = -mantInt;
          }
          return CBORObject.FromObject(mantInt);
        } else {
          BigInteger bigmant2 = mant.AsBigInteger();
          if (negative) {
            bigmant2 = -(BigInteger)bigmant2;
          }
          return CBORObject.FromObject(bigmant2);
        }
      } else {
        BigInteger bigmant = (mant == null) ? ((BigInteger)mantInt) : mant.AsBigInteger();
        BigInteger bigexp = (newScale == null) ? ((BigInteger)newScaleInt) : newScale.AsBigInteger();
        if (negative) {
          bigmant = -(BigInteger)bigmant;
        }
        if (newScale != null && bigexp.bitLength() > 64) {
          int bigexpSign = bigexp.Sign;
          if (bigexpSign > 0) {
            // Exponent is higher than the highest representable
            // integer of major type 0
            if (failOnExponentOverflow) {
              return null;
            } else {
              return (bigexp.Sign < 0) ?
                CBORObject.FromObject(Double.NegativeInfinity) :
                CBORObject.FromObject(Double.PositiveInfinity);
            }
          } else {
            // Exponent is lower than the lowest representable
            // integer of major type 1
            if (failOnExponentOverflow) {
              return null;
            } else {
              return CBORObject.FromObject(0);
            }
          }
        }
        return CBORObject.FromObject(ExtendedDecimal.Create(
          bigmant,
          bigexp));
      }
    }
  }
}
package com.upokecenter.cbor;
/*
Written in 2013 by Peter O.
Any copyright is dedicated to the Public Domain.
http://creativecommons.org/publicdomain/zero/1.0/
If you like this, you should donate to Peter O.
at: http://peteroupc.github.io/CBOR/
 */

import com.upokecenter.util.*;

    /**
     * Implements arithmetic operations with CBOR objects.
     * @param a A CBORObject object. (2).
     * @param b A CBORObject object. (3).
     * @return A CBORObject object.
     */
  final class CBORObjectMath {
private CBORObjectMath() {
}
    // TODO: Implement division
    public static CBORObject Addition(CBORObject a, CBORObject b) {
      if (a == null) {
        throw new NullPointerException("a");
      }
      if (b == null) {
        throw new NullPointerException("b");
      }
      if (a.getType() != CBORType.Number) {
        throw new IllegalArgumentException("a.Type (" + a.getType() + ") is not equal to " + CBORType.Number);
      }
      if (b.getType() != CBORType.Number) {
        throw new IllegalArgumentException("b.Type (" + b.getType() + ") is not equal to " + CBORType.Number);
      }
      Object objA = a.getThisItem();
      Object objB = b.getThisItem();
      int typeA = a.getItemType();
      int typeB = b.getItemType();
      if (typeA == CBORObject.CBORObjectTypeInteger && typeB == CBORObject.CBORObjectTypeInteger) {
        long valueA = (((Long)objA).longValue());
        long valueB = (((Long)objB).longValue());
        if ((valueA < 0 && valueB < Long.MIN_VALUE - valueA) ||
            (valueA > 0 && valueB > Long.MAX_VALUE - valueA)) {
          // would overflow, convert to BigInteger
          return CBORObject.FromObject((BigInteger.valueOf(valueA)).add(BigInteger.valueOf(valueB)));
        }
        return CBORObject.FromObject(valueA + valueB);
      } else if (typeA == CBORObject.CBORObjectTypeExtendedRational ||
                 typeB == CBORObject.CBORObjectTypeExtendedRational) {
        ExtendedRational e1 = CBORObject.GetNumberInterface(typeA).AsExtendedRational(objA);
        ExtendedRational e2 = CBORObject.GetNumberInterface(typeB).AsExtendedRational(objB);
        return CBORObject.FromObject(e1.Add(e2));
      } else if (typeA == CBORObject.CBORObjectTypeExtendedDecimal ||
                 typeB == CBORObject.CBORObjectTypeExtendedDecimal) {
        ExtendedDecimal e1 = CBORObject.GetNumberInterface(typeA).AsExtendedDecimal(objA);
        ExtendedDecimal e2 = CBORObject.GetNumberInterface(typeB).AsExtendedDecimal(objB);
        return CBORObject.FromObject(e1.Add(e2));
      } else if (typeA == CBORObject.CBORObjectTypeExtendedFloat || typeB == CBORObject.CBORObjectTypeExtendedFloat ||
                 typeA == CBORObject.CBORObjectTypeDouble || typeB == CBORObject.CBORObjectTypeDouble ||
                 typeA == CBORObject.CBORObjectTypeSingle || typeB == CBORObject.CBORObjectTypeSingle) {
        ExtendedFloat e1 = CBORObject.GetNumberInterface(typeA).AsExtendedFloat(objA);
        ExtendedFloat e2 = CBORObject.GetNumberInterface(typeB).AsExtendedFloat(objB);
        return CBORObject.FromObject(e1.Add(e2));
      } else {
        BigInteger b1 = CBORObject.GetNumberInterface(typeA).AsBigInteger(objA);
        BigInteger b2 = CBORObject.GetNumberInterface(typeB).AsBigInteger(objB);
        return CBORObject.FromObject(b1.add(b2));
      }
    }

    public static CBORObject Subtract(CBORObject a, CBORObject b) {
      if (a == null) {
        throw new NullPointerException("a");
      }
      if (b == null) {
        throw new NullPointerException("b");
      }
      if (a.getType() != CBORType.Number) {
        throw new IllegalArgumentException("a.Type (" + a.getType() + ") is not equal to " + CBORType.Number);
      }
      if (b.getType() != CBORType.Number) {
        throw new IllegalArgumentException("b.Type (" + b.getType() + ") is not equal to " + CBORType.Number);
      }
      Object objA = a.getThisItem();
      Object objB = b.getThisItem();
      int typeA = a.getItemType();
      int typeB = b.getItemType();
      if (typeA == CBORObject.CBORObjectTypeInteger && typeB == CBORObject.CBORObjectTypeInteger) {
        long valueA = (((Long)objA).longValue());
        long valueB = (((Long)objB).longValue());
        if ((valueB < 0 && Long.MAX_VALUE + valueB < valueA) ||
            (valueB > 0 && Long.MIN_VALUE + valueB > valueA)) {
          // would overflow, convert to BigInteger
          return CBORObject.FromObject((BigInteger.valueOf(valueA)).subtract(BigInteger.valueOf(valueB)));
        }
        return CBORObject.FromObject(valueA - valueB);
      } else if (typeA == CBORObject.CBORObjectTypeExtendedRational ||
                 typeB == CBORObject.CBORObjectTypeExtendedRational) {
        ExtendedRational e1 = CBORObject.GetNumberInterface(typeA).AsExtendedRational(objA);
        ExtendedRational e2 = CBORObject.GetNumberInterface(typeB).AsExtendedRational(objB);
        return CBORObject.FromObject(e1.Subtract(e2));
      } else if (typeA == CBORObject.CBORObjectTypeExtendedDecimal ||
                 typeB == CBORObject.CBORObjectTypeExtendedDecimal) {
        ExtendedDecimal e1 = CBORObject.GetNumberInterface(typeA).AsExtendedDecimal(objA);
        ExtendedDecimal e2 = CBORObject.GetNumberInterface(typeB).AsExtendedDecimal(objB);
        return CBORObject.FromObject(e1.Subtract(e2));
      } else if (typeA == CBORObject.CBORObjectTypeExtendedFloat || typeB == CBORObject.CBORObjectTypeExtendedFloat ||
                 typeA == CBORObject.CBORObjectTypeDouble || typeB == CBORObject.CBORObjectTypeDouble ||
                 typeA == CBORObject.CBORObjectTypeSingle || typeB == CBORObject.CBORObjectTypeSingle) {
        ExtendedFloat e1 = CBORObject.GetNumberInterface(typeA).AsExtendedFloat(objA);
        ExtendedFloat e2 = CBORObject.GetNumberInterface(typeB).AsExtendedFloat(objB);
        return CBORObject.FromObject(e1.Subtract(e2));
      } else {
        BigInteger b1 = CBORObject.GetNumberInterface(typeA).AsBigInteger(objA);
        BigInteger b2 = CBORObject.GetNumberInterface(typeB).AsBigInteger(objB);
        return CBORObject.FromObject(b1.subtract(b2));
      }
    }

    public static CBORObject Multiply(CBORObject a, CBORObject b) {
      if (a == null) {
        throw new NullPointerException("a");
      }
      if (b == null) {
        throw new NullPointerException("b");
      }
      if (a.getType() != CBORType.Number) {
        throw new IllegalArgumentException("a.Type (" + a.getType() + ") is not equal to " + CBORType.Number);
      }
      if (b.getType() != CBORType.Number) {
        throw new IllegalArgumentException("b.Type (" + b.getType() + ") is not equal to " + CBORType.Number);
      }
      Object objA = a.getThisItem();
      Object objB = b.getThisItem();
      int typeA = a.getItemType();
      int typeB = b.getItemType();
      if (typeA == CBORObject.CBORObjectTypeInteger && typeB == CBORObject.CBORObjectTypeInteger) {
        long valueA = (((Long)objA).longValue());
        long valueB = (((Long)objB).longValue());
        boolean apos = valueA > 0L;
        boolean bpos = valueB > 0L;
        if (
          (apos && ((!bpos && (Long.MIN_VALUE / valueA) > valueB) ||
                    (bpos && valueA > (Long.MAX_VALUE / valueB)))) ||
          (!apos && ((!bpos && valueA != 0L &&
                      (Long.MAX_VALUE / valueA) > valueB) ||
                     (bpos && valueA < (Long.MIN_VALUE / valueB))))) {
          // would overflow, convert to BigInteger
          BigInteger bvalueA = BigInteger.valueOf(valueA);
          BigInteger bvalueB = BigInteger.valueOf(valueB);
          return CBORObject.FromObject(bvalueA.multiply(bvalueB));
        }
        return CBORObject.FromObject(valueA * valueB);
      } else if (typeA == CBORObject.CBORObjectTypeExtendedRational ||
                 typeB == CBORObject.CBORObjectTypeExtendedRational) {
        ExtendedRational e1 = CBORObject.GetNumberInterface(typeA).AsExtendedRational(objA);
        ExtendedRational e2 = CBORObject.GetNumberInterface(typeB).AsExtendedRational(objB);
        return CBORObject.FromObject(e1.Multiply(e2));
      } else if (typeA == CBORObject.CBORObjectTypeExtendedDecimal ||
                 typeB == CBORObject.CBORObjectTypeExtendedDecimal) {
        ExtendedDecimal e1 = CBORObject.GetNumberInterface(typeA).AsExtendedDecimal(objA);
        ExtendedDecimal e2 = CBORObject.GetNumberInterface(typeB).AsExtendedDecimal(objB);
        return CBORObject.FromObject(e1.Multiply(e2));
      } else if (typeA == CBORObject.CBORObjectTypeExtendedFloat || typeB == CBORObject.CBORObjectTypeExtendedFloat ||
                 typeA == CBORObject.CBORObjectTypeDouble || typeB == CBORObject.CBORObjectTypeDouble ||
                 typeA == CBORObject.CBORObjectTypeSingle || typeB == CBORObject.CBORObjectTypeSingle) {
        ExtendedFloat e1 = CBORObject.GetNumberInterface(typeA).AsExtendedFloat(objA);
        ExtendedFloat e2 = CBORObject.GetNumberInterface(typeB).AsExtendedFloat(objB);
        return CBORObject.FromObject(e1.Multiply(e2));
      } else {
        BigInteger b1 = CBORObject.GetNumberInterface(typeA).AsBigInteger(objA);
        BigInteger b2 = CBORObject.GetNumberInterface(typeB).AsBigInteger(objB);
        return CBORObject.FromObject(b1.multiply(b2));
      }
    }

    public static CBORObject Remainder(CBORObject a, CBORObject b) {
      if (a == null) {
        throw new NullPointerException("a");
      }
      if (b == null) {
        throw new NullPointerException("b");
      }
      if (a.getType() != CBORType.Number) {
        throw new IllegalArgumentException("a.Type (" + a.getType() + ") is not equal to " + CBORType.Number);
      }
      if (b.getType() != CBORType.Number) {
        throw new IllegalArgumentException("b.Type (" + b.getType() + ") is not equal to " + CBORType.Number);
      }
      Object objA = a.getThisItem();
      Object objB = b.getThisItem();
      int typeA = a.getItemType();
      int typeB = b.getItemType();
      if (typeA == CBORObject.CBORObjectTypeInteger && typeB == CBORObject.CBORObjectTypeInteger) {
        long valueA = (((Long)objA).longValue());
        long valueB = (((Long)objB).longValue());
        if (valueA == Long.MIN_VALUE && valueB == -1) {
          return CBORObject.FromObject(0);
        }
        return CBORObject.FromObject(valueA % valueB);
      } else if (typeA == CBORObject.CBORObjectTypeExtendedRational ||
                 typeB == CBORObject.CBORObjectTypeExtendedRational) {
        ExtendedRational e1 = CBORObject.GetNumberInterface(typeA).AsExtendedRational(objA);
        ExtendedRational e2 = CBORObject.GetNumberInterface(typeB).AsExtendedRational(objB);
        return CBORObject.FromObject(e1.Remainder(e2));
      } else if (typeA == CBORObject.CBORObjectTypeExtendedDecimal ||
                 typeB == CBORObject.CBORObjectTypeExtendedDecimal) {
        ExtendedDecimal e1 = CBORObject.GetNumberInterface(typeA).AsExtendedDecimal(objA);
        ExtendedDecimal e2 = CBORObject.GetNumberInterface(typeB).AsExtendedDecimal(objB);
        return CBORObject.FromObject(e1.Remainder(e2, null));
      } else if (typeA == CBORObject.CBORObjectTypeExtendedFloat || typeB == CBORObject.CBORObjectTypeExtendedFloat ||
                 typeA == CBORObject.CBORObjectTypeDouble || typeB == CBORObject.CBORObjectTypeDouble ||
                 typeA == CBORObject.CBORObjectTypeSingle || typeB == CBORObject.CBORObjectTypeSingle) {
        ExtendedFloat e1 = CBORObject.GetNumberInterface(typeA).AsExtendedFloat(objA);
        ExtendedFloat e2 = CBORObject.GetNumberInterface(typeB).AsExtendedFloat(objB);
        return CBORObject.FromObject(e1.Remainder(e2, null));
      } else {
        BigInteger b1 = CBORObject.GetNumberInterface(typeA).AsBigInteger(objA);
        BigInteger b2 = CBORObject.GetNumberInterface(typeB).AsBigInteger(objB);
        return CBORObject.FromObject(b1.remainder(b2));
      }
    }
  }
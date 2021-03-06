## PeterO.Cbor.CBORObject

    public sealed class CBORObject :
        System.IComparable,
        System.IEquatable

Represents an object in Concise Binary Object Representation (CBOR) and contains methods for reading and writing CBOR data. CBOR is defined in RFC 7049.

<b>Converting CBOR objects</b>

There are many ways to get a CBOR object, including from bytes, objects, streams and JSON, as described below.

<b>To and from byte arrays:</b>The CBORObject.DecodeFromBytes method converts a byte array in CBOR ormat to a CBOR object. The EncodeToBytes method converts a CBOR object o its corresponding byte array in CBOR format.

<b>To and from data streams:</b>The CBORObject.Write methods write many kinds of objects to a data stream, including numbers, CBOR objects, strings, and arrays of numbers and strings. The CBORObject.Read method reads a CBOR object from a data stream.

<b>To and from other objects:</b>The  `CBORObject.FromObject`  method converts many kinds of objects to a CBOR object, including numbers, strings, and arrays and maps of numbers and strings. Methods like AsDouble, AsByte, and AsString convert a CBOR object to different types of object. The  `CBORObject.ToObject`  method converts a CBOR object to an object of a given type; for example, a CBOR array to a native  `List`  (or  `ArrayList`  in Java), or a CBOR integer to an  `int`  or  `long` .

<b>To and from JSON:</b>This class also doubles as a reader and writer of JavaScript Object Notation (JSON). The CBORObject.FromJSONString method converts JSON to a CBOR object, and the ToJSONString method converts a CBOR object to a JSON string.

In addition, the CBORObject.WriteJSON method writes many kinds of objects as JSON to a data stream, including numbers, CBOR objects, strings, and arrays of numbers and strings. The CBORObject.Read method reads a CBOR object from a JSON data stream.

<b>Comparison Considerations:</b>

Instances of CBORObject should not be compared for equality using the "==" operator; it's possible to create two CBOR objects with the same value but not the same reference. (The "==" operator might only check if each side of the operator is the same instance.)

This class's natural ordering (under the CompareTo method) is not consistent with the Equals method. This means that two values that compare as equal under the CompareTo method might not be equal under the Equals method. This is important to consider especially if an application wants to compare numbers, since the CBOR number type supports numbers of different formats, such as big integers, rational numbers, and arbitrary-precision decimal numbers.

Another consideration is that two values that are otherwise equal may have different tags. To strip the tags from a CBOR object before comparing, use the `Untag` method.

To compare two numbers, the CompareToIgnoreTags or CompareTo method should be used. Which method to use depends on whether two equal values should still be considered equal if they have different tags.

Although this class is inconsistent with the Equals method, it is safe to use CBORObject instances as hash keys as long as all of the keys are untagged text strings (which means GetTags returns an empty array and the Type property, or "getType()" in Java, returns TextString). This is because the natural ordering of these instances is consistent with the Equals method.

<b>Thread Safety:</b>

CBOR objects that are numbers, "simple values", and text strings are immutable (their values can't be changed), so they are inherently safe for use by multiple threads.

CBOR objects that are arrays, maps, and byte strings are mutable, but this class doesn't attempt to synchronize reads and writes to those objects by multiple threads, so those objects are not thread safe without such synchronization.

One kind of CBOR object is called a map, or a list of key-value pairs. Keys can be any kind of CBOR object, including numbers, strings, arrays, and maps. However, text strings are the most suitable to use as keys; other kinds of CBOR object are much better used as map values instead, keeping in mind that some of them are not thread safe without synchronizing reads and writes to them.

To find the type of a CBOR object, call its Type property (or "getType()" in Java). The return value can be Number, Boolean, SimpleValue, or TextString for immutable CBOR objects, and Array, Map, or ByteString for mutable CBOR objects.

<b>Nesting Depth:</b>

The DecodeFromBytes and Read methods can only read objects with a limited maximum depth of arrays and maps nested within other arrays and maps. The code sets this maximum depth to 500 (allowing more than enough nesting for most purposes), but it's possible that stack overflows in some runtimes might lower the effective maximum nesting depth. When the nesting depth goes above 500, the DecodeFromBytes and Read methods throw a CBORException.

The ReadJSON and FromJSONString methods currently have nesting depths of 1000.

### Member Summary
* <code>[Abs()](#Abs)</code> - Gets this object's absolute value.
* <code>[AddConverter&lt;T&gt;(System.Type, PeterO.Cbor.ICBORConverter&lt;T&gt;)](#AddConverter_T_System_Type_PeterO_Cbor_ICBORConverter_T)</code> - Registers an object that converts objects of a given type to CBOR objects (called a CBOR converter).
* <code>[AddTagHandler(PeterO.BigInteger, PeterO.Cbor.ICBORTag)](#AddTagHandler_PeterO_BigInteger_PeterO_Cbor_ICBORTag)</code> - Registers an object that validates CBOR objects with new tags.
* <code>[AddTagHandler(PeterO.Numbers.EInteger, PeterO.Cbor.ICBORTag)](#AddTagHandler_PeterO_Numbers_EInteger_PeterO_Cbor_ICBORTag)</code> - Registers an object that validates CBOR objects with new tags.
* <code>[Add(PeterO.Cbor.CBORObject)](#Add_PeterO_Cbor_CBORObject)</code> -  Adds a new object to the end of this array.
* <code>[Add(object)](#Add_object)</code> -  Converts an object to a CBOR object and adds it to the end of this array.
* <code>[Add(object, object)](#Add_object_object)</code> -  Adds a new key and its value to this CBOR map, or adds the value if the key doesn't exist.
* <code>[Addition(PeterO.Cbor.CBORObject, PeterO.Cbor.CBORObject)](#Addition_PeterO_Cbor_CBORObject_PeterO_Cbor_CBORObject)</code> - Finds the sum of two CBOR numbers.
* <code>[AsBigInteger()](#AsBigInteger)</code> - Converts this object to an arbitrary-precision integer.
* <code>[AsBoolean()](#AsBoolean)</code> - Returns false if this object is False, Null, or Undefined; otherwise,true.
* <code>[AsByte()](#AsByte)</code> - Converts this object to a byte (0 to 255).
* <code>[AsDecimal()](#AsDecimal)</code> - Converts this object to a .
* <code>[AsDouble()](#AsDouble)</code> - Converts this object to a 64-bit floating point number.
* <code>[AsEDecimal()](#AsEDecimal)</code> - Converts this object to a decimal number.
* <code>[AsEFloat()](#AsEFloat)</code> - Converts this object to an arbitrary-precision binary floating point number.
* <code>[AsEInteger()](#AsEInteger)</code> - Converts this object to an arbitrary-precision integer.
* <code>[AsERational()](#AsERational)</code> - Converts this object to a rational number.
* <code>[AsExtendedDecimal()](#AsExtendedDecimal)</code> - Converts this object to a decimal number.
* <code>[AsExtendedFloat()](#AsExtendedFloat)</code> - Converts this object to an arbitrary-precision binary floating point number.
* <code>[AsExtendedRational()](#AsExtendedRational)</code> - Converts this object to a rational number.
* <code>[AsInt16()](#AsInt16)</code> - Converts this object to a 16-bit signed integer.
* <code>[AsInt32()](#AsInt32)</code> - Converts this object to a 32-bit signed integer.
* <code>[AsInt64()](#AsInt64)</code> - Converts this object to a 64-bit signed integer.
* <code>[AsSByte()](#AsSByte)</code> - Converts this object to an 8-bit signed integer.
* <code>[AsSingle()](#AsSingle)</code> - Converts this object to a 32-bit floating point number.
* <code>[AsString()](#AsString)</code> - Gets the value of this object as a text string.
* <code>[AsUInt16()](#AsUInt16)</code> - Converts this object to a 16-bit unsigned integer.
* <code>[AsUInt32()](#AsUInt32)</code> - Converts this object to a 32-bit unsigned integer.
* <code>[AsUInt64()](#AsUInt64)</code> - Converts this object to a 64-bit unsigned integer.
* <code>[CanFitInDouble()](#CanFitInDouble)</code> - Returns whether this object's value can be converted to a 64-bit floating point number without its value being rounded to another numerical value.
* <code>[CanFitInInt32()](#CanFitInInt32)</code> - Returns whether this object's numerical value is an integer, is -(2^31) or greater, and is less than 2^31.
* <code>[CanFitInInt64()](#CanFitInInt64)</code> - Returns whether this object's numerical value is an integer, is -(2^63) or greater, and is less than 2^63.
* <code>[CanFitInSingle()](#CanFitInSingle)</code> - Returns whether this object's value can be converted to a 32-bit floating point number without its value being rounded to another numerical value.
* <code>[CanTruncatedIntFitInInt32()](#CanTruncatedIntFitInInt32)</code> - Returns whether this object's value, truncated to an integer, would be -(2^31) or greater, and less than 2^31.
* <code>[CanTruncatedIntFitInInt64()](#CanTruncatedIntFitInInt64)</code> - Returns whether this object's value, truncated to an integer, would be -(2^63) or greater, and less than 2^63.
* <code>[Clear()](#Clear)</code> - Removes all items from this CBOR array or all keys and values from this CBOR map.
* <code>[CompareToIgnoreTags(PeterO.Cbor.CBORObject)](#CompareToIgnoreTags_PeterO_Cbor_CBORObject)</code> - Compares this object and another CBOR object, ignoring the tags they have, if any.
* <code>[CompareTo(PeterO.Cbor.CBORObject)](#CompareTo_PeterO_Cbor_CBORObject)</code> - Compares two CBOR objects.
* <code>[ContainsKey(PeterO.Cbor.CBORObject)](#ContainsKey_PeterO_Cbor_CBORObject)</code> - Determines whether a value of the given key exists in this object.
* <code>[ContainsKey(string)](#ContainsKey_string)</code> - Determines whether a value of the given key exists in this object.
* <code>[Count](#Count)</code> - Gets the number of keys in this map, or the number of items in this array, or 0 if this item is neither an array nor a map.
* <code>[DecodeFromBytes(byte[])](#DecodeFromBytes_byte)</code> -  At the moment, use the overload of this method that takes aPeterO.
* <code>[DecodeFromBytes(byte[], PeterO.Cbor.CBOREncodeOptions)](#DecodeFromBytes_byte_PeterO_Cbor_CBOREncodeOptions)</code> - Generates a CBOR object from an array of CBOR-encoded bytes, using the givenCBOREncodeOptionsobject to control the decoding process.
* <code>[Divide(PeterO.Cbor.CBORObject, PeterO.Cbor.CBORObject)](#Divide_PeterO_Cbor_CBORObject_PeterO_Cbor_CBORObject)</code> - Divides a CBORObject object by the value of a CBORObject object.
* <code>[EncodeToBytes()](#EncodeToBytes)</code> -  At the moment, use the overload of this method that takes aPeterO.
* <code>[EncodeToBytes(PeterO.Cbor.CBOREncodeOptions)](#EncodeToBytes_PeterO_Cbor_CBOREncodeOptions)</code> - Writes the binary representation of this CBOR object and returns a byte array of that representation, using the specified options for encoding the object to CBOR format.
* <code>[Equals(PeterO.Cbor.CBORObject)](#Equals_PeterO_Cbor_CBORObject)</code> - Compares the equality of two CBOR objects.
* <code>[Equals(object)](#Equals_object)</code> - Determines whether this object and another object are equal and have the same type.
* <code>[public static readonly PeterO.Cbor.CBORObject False;](#False)</code> - Represents the value false.
* <code>[FromJSONString(string)](#FromJSONString_string)</code> -  At the moment, use the overload of this method that takes aPeterO.
* <code>[FromJSONString(string, PeterO.Cbor.CBOREncodeOptions)](#FromJSONString_string_PeterO_Cbor_CBOREncodeOptions)</code> - Generates a CBOR object from a text string in JavaScript Object Notation (JSON) format, using the specified options to control the decoding process.
* <code>[FromObjectAndTag(object, PeterO.BigInteger)](#FromObjectAndTag_object_PeterO_BigInteger)</code> - Generates a CBOR object from an arbitrary object and gives the resulting object a tag.
* <code>[FromObjectAndTag(object, PeterO.Numbers.EInteger)](#FromObjectAndTag_object_PeterO_Numbers_EInteger)</code> - Generates a CBOR object from an arbitrary object and gives the resulting object a tag.
* <code>[FromObjectAndTag(object, int)](#FromObjectAndTag_object_int)</code> - Generates a CBOR object from an arbitrary object and gives the resulting object a tag.
* <code>[FromObjectAndTag(object, ulong)](#FromObjectAndTag_object_ulong)</code> - Generates a CBOR object from an arbitrary object and gives the resulting object a tag.
* <code>[FromObject(PeterO.BigInteger)](#FromObject_PeterO_BigInteger)</code> - Generates a CBOR object from an arbitrary-precision integer.
* <code>[FromObject(PeterO.Cbor.CBORObject)](#FromObject_PeterO_Cbor_CBORObject)</code> - Generates a CBOR object from a CBOR object.
* <code>[FromObject(PeterO.ExtendedDecimal)](#FromObject_PeterO_ExtendedDecimal)</code> - Generates a CBOR object from a decimal number.
* <code>[FromObject(PeterO.ExtendedFloat)](#FromObject_PeterO_ExtendedFloat)</code> - Generates a CBOR object from an arbitrary-precision binary floating-point number.
* <code>[FromObject(PeterO.ExtendedRational)](#FromObject_PeterO_ExtendedRational)</code> - Generates a CBOR object from an arbitrary-precision binary floating-point number.
* <code>[FromObject(PeterO.Numbers.EDecimal)](#FromObject_PeterO_Numbers_EDecimal)</code> - Generates a CBOR object from a decimal number.
* <code>[FromObject(PeterO.Numbers.EFloat)](#FromObject_PeterO_Numbers_EFloat)</code> - Generates a CBOR object from an arbitrary-precision binary floating-point number.
* <code>[FromObject(PeterO.Numbers.EInteger)](#FromObject_PeterO_Numbers_EInteger)</code> - Generates a CBOR object from an arbitrary-precision integer.
* <code>[FromObject(PeterO.Numbers.ERational)](#FromObject_PeterO_Numbers_ERational)</code> - Generates a CBOR object from a rational number.
* <code>[FromObject(System.Decimal)](#FromObject_System_Decimal)</code> - Converts a .
* <code>[FromObject&lt;TKey, TValue&gt;(System.Collections.Generic.IDictionary&lt;TKey, TValue&gt;)](#FromObject_TKey_TValue_System_Collections_Generic_IDictionary_TKey_TValue)</code> - Generates a CBOR object from a map of objects.
* <code>[FromObject&lt;T&gt;(System.Collections.Generic.IEnumerable&lt;T&gt;)](#FromObject_T_System_Collections_Generic_IEnumerable_T)</code> - Generates a CBOR object from an enumerable set of objects.
* <code>[FromObject&lt;T&gt;(System.Collections.Generic.IList&lt;T&gt;)](#FromObject_T_System_Collections_Generic_IList_T)</code> - Generates a CBOR object from a list of objects.
* <code>[FromObject(bool)](#FromObject_bool)</code> - Returns the CBOR true value or false value, depending on "value".
* <code>[FromObject(byte)](#FromObject_byte)</code> - Generates a CBOR object from a byte (0 to 255).
* <code>[FromObject(char)](#FromObject_char)</code> - Generates a CBOR string object from a Unicode character.
* <code>[FromObject(double)](#FromObject_double)</code> - Generates a CBOR object from a 64-bit floating-point number.
* <code>[FromObject(float)](#FromObject_float)</code> - Generates a CBOR object from a 32-bit floating-point number.
* <code>[FromObject(int)](#FromObject_int)</code> - Generates a CBOR object from a 32-bit signed integer.
* <code>[FromObject(long)](#FromObject_long)</code> - Generates a CBOR object from a 64-bit signed integer.
* <code>[FromObject(object)](#FromObject_object)</code> - Generates a CBORObject from an arbitrary object.
* <code>[FromObject(object, PeterO.Cbor.PODOptions)](#FromObject_object_PeterO_Cbor_PODOptions)</code> -  Generates a CBORObject from an arbitrary object, using the given options to control how certain objects are converted to CBOR objects.
* <code>[FromObject(sbyte)](#FromObject_sbyte)</code> - Converts a signed 8-bit integer to a CBOR object.
* <code>[FromObject(short)](#FromObject_short)</code> - Generates a CBOR object from a 16-bit signed integer.
* <code>[FromObject(string)](#FromObject_string)</code> - Generates a CBOR object from a text string.
* <code>[FromObject(uint)](#FromObject_uint)</code> - Converts a 32-bit unsigned integer to a CBOR object.
* <code>[FromObject(ulong)](#FromObject_ulong)</code> - Converts a 64-bit unsigned integer to a CBOR object.
* <code>[FromObject(ushort)](#FromObject_ushort)</code> - Converts a 16-bit unsigned integer to a CBOR object.
* <code>[FromSimpleValue(int)](#FromSimpleValue_int)</code> - Creates a CBOR object from a simple value number.
* <code>[GetAllTags()](#GetAllTags)</code> - Gets a list of all tags, from outermost to innermost.
* <code>[GetByteString()](#GetByteString)</code> - Gets the byte array used in this object, if this object is a byte string, without copying the data to a new one.
* <code>[GetHashCode()](#GetHashCode)</code> - Calculates the hash code of this object.
* <code>[GetTags()](#GetTags)</code> - Gets a list of all tags, from outermost to innermost.
* <code>[HasMostOuterTag(PeterO.Numbers.EInteger)](#HasMostOuterTag_PeterO_Numbers_EInteger)</code> - Returns whether this object has a tag of the given number.
* <code>[HasMostOuterTag(int)](#HasMostOuterTag_int)</code> - Returns whether this object has a tag of the given number.
* <code>[HasTag(PeterO.BigInteger)](#HasTag_PeterO_BigInteger)</code> - Returns whether this object has a tag of the given number.
* <code>[HasTag(PeterO.Numbers.EInteger)](#HasTag_PeterO_Numbers_EInteger)</code> - Returns whether this object has a tag of the given number.
* <code>[HasTag(int)](#HasTag_int)</code> - Returns whether this object has a tag of the given number.
* <code>[InnermostTag](#InnermostTag)</code> - Gets the last defined tag for this CBOR data item, or -1 if the item is untagged.
* <code>[Insert(int, object)](#Insert_int_object)</code> - Inserts an object at the specified position in this CBOR array.
* <code>[IsFalse](#IsFalse)</code> - Gets a value indicating whether this value is a CBOR false value.
* <code>[IsFinite](#IsFinite)</code> - Gets a value indicating whether this CBOR object represents a finite number.
* <code>[IsInfinity()](#IsInfinity)</code> - Gets a value indicating whether this CBOR object represents infinity.
* <code>[IsIntegral](#IsIntegral)</code> - Gets a value indicating whether this object represents an integral number, that is, a number without a fractional part.
* <code>[IsNaN()](#IsNaN)</code> - Gets a value indicating whether this CBOR object represents a not-a-number value (as opposed to whether this object's type is not a number type).
* <code>[IsNegative](#IsNegative)</code> - Gets a value indicating whether this object is a negative number.
* <code>[IsNegativeInfinity()](#IsNegativeInfinity)</code> - Gets a value indicating whether this CBOR object represents negative infinity.
* <code>[IsNull](#IsNull)</code> - Gets a value indicating whether this value is a CBOR null value.
* <code>[IsPositiveInfinity()](#IsPositiveInfinity)</code> - Gets a value indicating whether this CBOR object represents positive infinity.
* <code>[IsTagged](#IsTagged)</code> - Gets a value indicating whether this data item has at least one tag.
* <code>[IsTrue](#IsTrue)</code> - Gets a value indicating whether this value is a CBOR true value.
* <code>[IsUndefined](#IsUndefined)</code> - Gets a value indicating whether this value is a CBOR undefined value.
* <code>[IsZero](#IsZero)</code> - Gets a value indicating whether this object's value equals 0.
* <code>[Keys](#Keys)</code> - Gets a collection of the keys of this CBOR object in an undefined order.
* <code>[MostInnerTag](#MostInnerTag)</code> - Gets the last defined tag for this CBOR data item, or -1 if the item is untagged.
* <code>[MostOuterTag](#MostOuterTag)</code> - Gets the outermost tag for this CBOR data item, or -1 if the item is untagged.
* <code>[Multiply(PeterO.Cbor.CBORObject, PeterO.Cbor.CBORObject)](#Multiply_PeterO_Cbor_CBORObject_PeterO_Cbor_CBORObject)</code> - Multiplies two CBOR numbers.
* <code>[public static readonly PeterO.Cbor.CBORObject NaN;](#NaN)</code> - A not-a-number value.
* <code>[Negate()](#Negate)</code> - Gets this object's value with the sign reversed.
* <code>[public static readonly PeterO.Cbor.CBORObject NegativeInfinity;](#NegativeInfinity)</code> - The value negative infinity.
* <code>[NewArray()](#NewArray)</code> - Creates a new empty CBOR array.
* <code>[NewMap()](#NewMap)</code> - Creates a new empty CBOR map.
* <code>[public static readonly PeterO.Cbor.CBORObject Null;](#Null)</code> - Represents the value null.
* <code>[OutermostTag](#OutermostTag)</code> - Gets the outermost tag for this CBOR data item, or -1 if the item is untagged.
* <code>[public static readonly PeterO.Cbor.CBORObject PositiveInfinity;](#PositiveInfinity)</code> - The value positive infinity.
* <code>[ReadJSON(System.IO.Stream)](#ReadJSON_System_IO_Stream)</code> - Generates a CBOR object from a data stream in JavaScript Object Notation (JSON) format.
* <code>[ReadJSON(System.IO.Stream, PeterO.Cbor.CBOREncodeOptions)](#ReadJSON_System_IO_Stream_PeterO_Cbor_CBOREncodeOptions)</code> - Generates a CBOR object from a data stream in JavaScript Object Notation (JSON) format, using the specified options to control the decoding process.
* <code>[Read(System.IO.Stream)](#Read_System_IO_Stream)</code> -  At the moment, use the overload of this method that takes aPeterO.
* <code>[Read(System.IO.Stream, PeterO.Cbor.CBOREncodeOptions)](#Read_System_IO_Stream_PeterO_Cbor_CBOREncodeOptions)</code> - Reads an object in CBOR format from a data stream, using the specified options to control the decoding process.
* <code>[Remainder(PeterO.Cbor.CBORObject, PeterO.Cbor.CBORObject)](#Remainder_PeterO_Cbor_CBORObject_PeterO_Cbor_CBORObject)</code> - Finds the remainder that results when a CBORObject object is divided by the value of a CBORObject object.
* <code>[RemoveAt(int)](#RemoveAt_int)</code> - Removes the item at the given index of this CBOR array.
* <code>[Remove(PeterO.Cbor.CBORObject)](#Remove_PeterO_Cbor_CBORObject)</code> - If this object is an array, removes the first instance of the specified item from the array.
* <code>[Remove(object)](#Remove_object)</code> - If this object is an array, removes the first instance of the specified item (once converted to a CBOR object) from the array.
* <code>[Set(object, object)](#Set_object_object)</code> - Maps an object to a key in this CBOR map, or adds the value if the key doesn't exist.
* <code>[Sign](#Sign)</code> - Gets this value's sign: -1 if negative; 1 if positive; 0 if zero.
* <code>[SimpleValue](#SimpleValue)</code> - Gets the simple value ID of this object, or -1 if this object is not a simple value (including if the value is a floating-point number).
* <code>[Subtract(PeterO.Cbor.CBORObject, PeterO.Cbor.CBORObject)](#Subtract_PeterO_Cbor_CBORObject_PeterO_Cbor_CBORObject)</code> - Finds the difference between two CBOR number objects.
* <code>[ToJSONString()](#ToJSONString)</code> - Converts this object to a string in JavaScript Object Notation (JSON) format, using the specified options to control the encoding process.
* <code>[ToJSONString(PeterO.Cbor.JSONOptions)](#ToJSONString_PeterO_Cbor_JSONOptions)</code> - Converts this object to a string in JavaScript Object Notation (JSON) format, using the specified options to control the encoding process.
* <code>[ToObject(System.Type)](#ToObject_System_Type)</code> -  Converts this CBOR object to an object of an arbitrary type.
* <code>[ToObject&lt;T&gt;()](#ToObject_T)</code> -  Converts this CBOR object to an object of an arbitrary type.
* <code>[ToString()](#ToString)</code> - Returns this CBOR object in string form.
* <code>[public static readonly PeterO.Cbor.CBORObject True;](#True)</code> - Represents the value true.
* <code>[Type](#Type)</code> - Gets the general data type of this CBOR object.
* <code>[public static readonly PeterO.Cbor.CBORObject Undefined;](#Undefined)</code> - Represents the value undefined.
* <code>[Untag()](#Untag)</code> - Gets an object with the same value as this one but without the tags it has, if any.
* <code>[UntagOne()](#UntagOne)</code> - Gets an object with the same value as this one but without this object's outermost tag, if any.
* <code>[Values](#Values)</code> - Gets a collection of the values of this CBOR object, if it's a map or an array.
* <code>[WriteJSONTo(System.IO.Stream)](#WriteJSONTo_System_IO_Stream)</code> - Converts this object to a string in JavaScript Object Notation (JSON) format, as in the ToJSONString method, and writes that string to a data stream in UTF-8.
* <code>[WriteJSONTo(System.IO.Stream, PeterO.Cbor.JSONOptions)](#WriteJSONTo_System_IO_Stream_PeterO_Cbor_JSONOptions)</code> - Converts this object to a string in JavaScript Object Notation (JSON) format, as in the ToJSONString method, and writes that string to a data stream in UTF-8, using the given JSON options to control the encoding process.
* <code>[WriteJSON(object, System.IO.Stream)](#WriteJSON_object_System_IO_Stream)</code> - Converts an arbitrary object to a string in JavaScript Object Notation (JSON) format, as in the ToJSONString method, and writes that string to a data stream in UTF-8.
* <code>[WriteTo(System.IO.Stream)](#WriteTo_System_IO_Stream)</code> -  At the moment, use the overload of this method that takes aPeterO.
* <code>[WriteTo(System.IO.Stream, PeterO.Cbor.CBOREncodeOptions)](#WriteTo_System_IO_Stream_PeterO_Cbor_CBOREncodeOptions)</code> - Writes this CBOR object to a data stream, using the specified options for encoding the data to CBOR format.
* <code>[WriteValue(System.IO.Stream, int, PeterO.Numbers.EInteger)](#WriteValue_System_IO_Stream_int_PeterO_Numbers_EInteger)</code> - Writes a CBOR major type number and an integer 0 or greater associated with it to a data stream, where that integer is passed to this method as an arbitrary-precision integer.
* <code>[WriteValue(System.IO.Stream, int, int)](#WriteValue_System_IO_Stream_int_int)</code> - Writes a CBOR major type number and an integer 0 or greater associated with it to a data stream, where that integer is passed to this method as a 32-bit signed integer.
* <code>[WriteValue(System.IO.Stream, int, long)](#WriteValue_System_IO_Stream_int_long)</code> - Writes a CBOR major type number and an integer 0 or greater associated with it to a data stream, where that integer is passed to this method as a 64-bit signed integer.
* <code>[WriteValue(System.IO.Stream, int, uint)](#WriteValue_System_IO_Stream_int_uint)</code> - Writes a CBOR major type number and an integer 0 or greater associated with it to a data stream, where that integer is passed to this method as a 32-bit unsigned integer.
* <code>[WriteValue(System.IO.Stream, int, ulong)](#WriteValue_System_IO_Stream_int_ulong)</code> - Writes a CBOR major type number and an integer 0 or greater associated with it to a data stream, where that integer is passed to this method as a 64-bit unsigned integer.
* <code>[Write(PeterO.BigInteger, System.IO.Stream)](#Write_PeterO_BigInteger_System_IO_Stream)</code> - Writes a big integer in CBOR format to a data stream.
* <code>[Write(PeterO.Cbor.CBORObject, System.IO.Stream)](#Write_PeterO_Cbor_CBORObject_System_IO_Stream)</code> - Writes a CBOR object to a CBOR data stream.
* <code>[Write(PeterO.ExtendedDecimal, System.IO.Stream)](#Write_PeterO_ExtendedDecimal_System_IO_Stream)</code> - Writes a decimal floating-point number in CBOR format to a data stream, as follows:If the value is null, writes the byte 0xF6.
* <code>[Write(PeterO.ExtendedFloat, System.IO.Stream)](#Write_PeterO_ExtendedFloat_System_IO_Stream)</code> - Writes a binary floating-point number in CBOR format to a data stream as follows:If the value is null, writes the byte 0xF6.
* <code>[Write(PeterO.ExtendedRational, System.IO.Stream)](#Write_PeterO_ExtendedRational_System_IO_Stream)</code> - Writes a rational number in CBOR format to a data stream.
* <code>[Write(PeterO.Numbers.EDecimal, System.IO.Stream)](#Write_PeterO_Numbers_EDecimal_System_IO_Stream)</code> - Writes a decimal floating-point number in CBOR format to a data stream, as follows:If the value is null, writes the byte 0xF6.
* <code>[Write(PeterO.Numbers.EFloat, System.IO.Stream)](#Write_PeterO_Numbers_EFloat_System_IO_Stream)</code> - Writes a binary floating-point number in CBOR format to a data stream as follows:If the value is null, writes the byte 0xF6.
* <code>[Write(PeterO.Numbers.EInteger, System.IO.Stream)](#Write_PeterO_Numbers_EInteger_System_IO_Stream)</code> - Writes a big integer in CBOR format to a data stream.
* <code>[Write(PeterO.Numbers.ERational, System.IO.Stream)](#Write_PeterO_Numbers_ERational_System_IO_Stream)</code> - Writes a rational number in CBOR format to a data stream.
* <code>[Write(bool, System.IO.Stream)](#Write_bool_System_IO_Stream)</code> - Writes a Boolean value in CBOR format to a data stream.
* <code>[Write(byte, System.IO.Stream)](#Write_byte_System_IO_Stream)</code> - Writes a byte (0 to 255) in CBOR format to a data stream.
* <code>[Write(char, System.IO.Stream)](#Write_char_System_IO_Stream)</code> - Writes a Unicode character as a string in CBOR format to a data stream.
* <code>[Write(double, System.IO.Stream)](#Write_double_System_IO_Stream)</code> - Writes a 64-bit floating-point number in CBOR format to a data stream.
* <code>[Write(float, System.IO.Stream)](#Write_float_System_IO_Stream)</code> - Writes a 32-bit floating-point number in CBOR format to a data stream.
* <code>[Write(int, System.IO.Stream)](#Write_int_System_IO_Stream)</code> - Writes a 32-bit signed integer in CBOR format to a data stream.
* <code>[Write(long, System.IO.Stream)](#Write_long_System_IO_Stream)</code> - Writes a 64-bit signed integer in CBOR format to a data stream.
* <code>[Write(object, System.IO.Stream)](#Write_object_System_IO_Stream)</code> -  At the moment, use the overload of this method that takes aPeterO.
* <code>[Write(object, System.IO.Stream, PeterO.Cbor.CBOREncodeOptions)](#Write_object_System_IO_Stream_PeterO_Cbor_CBOREncodeOptions)</code> - Writes an arbitrary object to a CBOR data stream, using the specified options for controlling how the object is encoded to CBOR data format.
* <code>[Write(sbyte, System.IO.Stream)](#Write_sbyte_System_IO_Stream)</code> - Writes an 8-bit signed integer in CBOR format to a data stream.
* <code>[Write(short, System.IO.Stream)](#Write_short_System_IO_Stream)</code> - Writes a 16-bit signed integer in CBOR format to a data stream.
* <code>[Write(string, System.IO.Stream)](#Write_string_System_IO_Stream)</code> -  At the moment, use the overload of this method that takes aPeterO.
* <code>[Write(string, System.IO.Stream, PeterO.Cbor.CBOREncodeOptions)](#Write_string_System_IO_Stream_PeterO_Cbor_CBOREncodeOptions)</code> - Writes a string in CBOR format to a data stream, using the given options to control the encoding process.
* <code>[Write(uint, System.IO.Stream)](#Write_uint_System_IO_Stream)</code> - Writes a 32-bit unsigned integer in CBOR format to a data stream.
* <code>[Write(ulong, System.IO.Stream)](#Write_ulong_System_IO_Stream)</code> - Writes a 64-bit unsigned integer in CBOR format to a data stream.
* <code>[Write(ushort, System.IO.Stream)](#Write_ushort_System_IO_Stream)</code> - Writes a 16-bit unsigned integer in CBOR format to a data stream.
* <code>[public static readonly PeterO.Cbor.CBORObject Zero;](#Zero)</code> - Gets a CBOR object for the number zero.
* <code>[PeterO.Cbor.CBORObject operator +(PeterO.Cbor.CBORObject, PeterO.Cbor.CBORObject)](#op_Addition)</code> - Adds two CBOR objects and returns their result.
* <code>[PeterO.Cbor.CBORObject operator /(PeterO.Cbor.CBORObject, PeterO.Cbor.CBORObject)](#op_Division)</code> - Divides a CBORObject object by the value of a CBORObject object.
* <code>[PeterO.Cbor.CBORObject operator %(PeterO.Cbor.CBORObject, PeterO.Cbor.CBORObject)](#op_Modulus)</code> - Finds the remainder that results when a CBORObject object is divided by the value of a CBORObject object.
* <code>[PeterO.Cbor.CBORObject operator *(PeterO.Cbor.CBORObject, PeterO.Cbor.CBORObject)](#op_Multiply)</code> - Multiplies a CBORObject object by the value of a CBORObject object.
* <code>[PeterO.Cbor.CBORObject operator -(PeterO.Cbor.CBORObject, PeterO.Cbor.CBORObject)](#op_Subtraction)</code> - Subtracts a CBORObject object from a CBORObject object.

<a id="False"></a>
### False

    public static readonly PeterO.Cbor.CBORObject False;

Represents the value false.

<a id="NaN"></a>
### NaN

    public static readonly PeterO.Cbor.CBORObject NaN;

A not-a-number value.

<a id="NegativeInfinity"></a>
### NegativeInfinity

    public static readonly PeterO.Cbor.CBORObject NegativeInfinity;

The value negative infinity.

<a id="Null"></a>
### Null

    public static readonly PeterO.Cbor.CBORObject Null;

Represents the value null.

<a id="PositiveInfinity"></a>
### PositiveInfinity

    public static readonly PeterO.Cbor.CBORObject PositiveInfinity;

The value positive infinity.

<a id="True"></a>
### True

    public static readonly PeterO.Cbor.CBORObject True;

Represents the value true.

<a id="Undefined"></a>
### Undefined

    public static readonly PeterO.Cbor.CBORObject Undefined;

Represents the value undefined.

<a id="Zero"></a>
### Zero

    public static readonly PeterO.Cbor.CBORObject Zero;

Gets a CBOR object for the number zero.

<a id="Count"></a>
### Count

    public int Count { get; }

Gets the number of keys in this map, or the number of items in this array, or 0 if this item is neither an array nor a map.

<b>Returns:</b>

The number of keys in this map, or the number of items in this array, or 0 if this item is neither an array nor a map.

<a id="InnermostTag"></a>
### InnermostTag

    public PeterO.BigInteger InnermostTag { get; }

<b>Deprecated.</b> Use MostInnerTag instead.

Gets the last defined tag for this CBOR data item, or -1 if the item is untagged.

<b>Returns:</b>

The last defined tag for this CBOR data item, or -1 if the item is untagged.

<a id="IsFalse"></a>
### IsFalse

    public bool IsFalse { get; }

Gets a value indicating whether this value is a CBOR false value.

<b>Returns:</b>

 `true` If this value is a CBOR false value; otherwise, . `false` .

<a id="IsFinite"></a>
### IsFinite

    public bool IsFinite { get; }

Gets a value indicating whether this CBOR object represents a finite number.

<b>Returns:</b>

 `true`  If this CBOR object represents a finite number; otherwise, .  `false` .

<a id="IsIntegral"></a>
### IsIntegral

    public bool IsIntegral { get; }

Gets a value indicating whether this object represents an integral number, that is, a number without a fractional part. Infinity and not-a-number are not considered integral.

<b>Returns:</b>

 `true`  If this object represents an integral number, that is, a number without a fractional part; otherwise, . `false` .

<a id="IsNegative"></a>
### IsNegative

    public bool IsNegative { get; }

Gets a value indicating whether this object is a negative number.

<b>Returns:</b>

 `true` If this object is a negative number; otherwise, . `false` .

<a id="IsNull"></a>
### IsNull

    public bool IsNull { get; }

Gets a value indicating whether this value is a CBOR null value.

<b>Returns:</b>

 `true`  If this value is a CBOR null value; otherwise, . `false` .

<a id="IsTagged"></a>
### IsTagged

    public bool IsTagged { get; }

Gets a value indicating whether this data item has at least one tag.

<b>Returns:</b>

 `true`  If this data item has at least one tag; otherwise, .  `false` .

<a id="IsTrue"></a>
### IsTrue

    public bool IsTrue { get; }

Gets a value indicating whether this value is a CBOR true value.

<b>Returns:</b>

 `true`  If this value is a CBOR true value; otherwise, . `false` .

<a id="IsUndefined"></a>
### IsUndefined

    public bool IsUndefined { get; }

Gets a value indicating whether this value is a CBOR undefined value.

<b>Returns:</b>

 `true`  If this value is a CBOR undefined value; otherwise, .  `false` .

<a id="IsZero"></a>
### IsZero

    public bool IsZero { get; }

Gets a value indicating whether this object's value equals 0.

<b>Returns:</b>

 `true` If this object's value equals 0; otherwise, . `false` .

<a id="Keys"></a>
### Keys

    public System.Collections.Generic.ICollection Keys { get; }

Gets a collection of the keys of this CBOR object in an undefined order.

<b>Returns:</b>

A collection of the keys of this CBOR object.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object is not a map.

<a id="MostInnerTag"></a>
### MostInnerTag

    public PeterO.Numbers.EInteger MostInnerTag { get; }

Gets the last defined tag for this CBOR data item, or -1 if the item is untagged.

<b>Returns:</b>

The last defined tag for this CBOR data item, or -1 if the item is untagged.

<a id="MostOuterTag"></a>
### MostOuterTag

    public PeterO.Numbers.EInteger MostOuterTag { get; }

Gets the outermost tag for this CBOR data item, or -1 if the item is untagged.

<b>Returns:</b>

The outermost tag for this CBOR data item, or -1 if the item is untagged.

<a id="OutermostTag"></a>
### OutermostTag

    public PeterO.BigInteger OutermostTag { get; }

<b>Deprecated.</b> Use MostOuterTag instead.

Gets the outermost tag for this CBOR data item, or -1 if the item is untagged.

<b>Returns:</b>

The outermost tag for this CBOR data item, or -1 if the item is untagged.

<a id="Sign"></a>
### Sign

    public int Sign { get; }

Gets this value's sign: -1 if negative; 1 if positive; 0 if zero.

<b>Returns:</b>

This value's sign: -1 if negative; 1 if positive; 0 if zero.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type, including the special not-a-number value (NaN).

<a id="SimpleValue"></a>
### SimpleValue

    public int SimpleValue { get; }

Gets the simple value ID of this object, or -1 if this object is not a simple value (including if the value is a floating-point number).

<b>Returns:</b>

The simple value ID of this object, or -1 if this object is not a simple value (including if the value is a floating-point number).

<a id="Type"></a>
### Type

    public PeterO.Cbor.CBORType Type { get; }

Gets the general data type of this CBOR object.

<b>Returns:</b>

The general data type of this CBOR object.

<a id="Values"></a>
### Values

    public System.Collections.Generic.ICollection Values { get; }

Gets a collection of the values of this CBOR object, if it's a map or an array. If this object is a map, returns one value for each key in the map in an undefined order. If this is an array, returns all the values of the array in the order they are listed. (This method can't be used to get the bytes in a CBOR byte string; for that, use the GetByteArray method instead.).

<b>Returns:</b>

A collection of the values of this CBOR map or array.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object is not a map or an array.

<a id="Abs"></a>
### Abs

    public PeterO.Cbor.CBORObject Abs();

Gets this object's absolute value.

<b>Return Value:</b>

This object's absolute without its negative sign.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type.

<a id="Add_object_object"></a>
### Add

    public PeterO.Cbor.CBORObject Add(
        object key,
        object valueOb);

Adds a new key and its value to this CBOR map, or adds the value if the key doesn't exist.

NOTE: This method can't be used to add a tag to an existing CBOR object. To create a CBOR object with a given tag, call the  `CBORObject.FromObjectAndTag`  method and pass the CBOR object and the desired tag number to that method.

<b>Parameters:</b>

 * <i>key</i>: An object representing the key, which will be converted to a CBORObject. Can be null, in which case this value is converted to CBORObject.Null.

 * <i>valueOb</i>: An object representing the value, which will be converted to a CBORObject. Can be null, in which case this value is converted to CBORObject.Null.

<b>Return Value:</b>

This instance.

<b>Exceptions:</b>

 * System.ArgumentException:
The parameter <i>key</i>
 already exists in this map.

 * System.InvalidOperationException:
This object is not a map.

 * System.ArgumentException:
The parameter <i>key</i>
 or  <i>valueOb</i>
 has an unsupported type.

<a id="Add_object"></a>
### Add

    public PeterO.Cbor.CBORObject Add(
        object obj);

Converts an object to a CBOR object and adds it to the end of this array.

NOTE: This method can't be used to add a tag to an existing CBOR object. To create a CBOR object with a given tag, call the  `CBORObject.FromObjectAndTag` method and pass the CBOR object and the desired tag number to that method.

The following example creates a CBOR array and adds several CBOR objects, one of which has a custom CBOR tag, to that array. Note the chaining behavior made possible by this method.

    CBORObject obj = CBORObject.NewArray()
                .Add(CBORObject.False)
                .Add(5)
                .Add("text string")
                .Add(CBORObject.FromObjectAndTag(9999, 1));

<b>Parameters:</b>

 * <i>obj</i>: The parameter  <i>obj</i>
 is a CBOR object.

<b>Return Value:</b>

This instance.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object is not an array.

 * System.ArgumentException:
The type of  <i>obj</i>
 is not supported.

<a id="Add_PeterO_Cbor_CBORObject"></a>
### Add

    public PeterO.Cbor.CBORObject Add(
        PeterO.Cbor.CBORObject obj);

Adds a new object to the end of this array. (Used to throw ArgumentNullException on a null reference, but now converts the null reference to CBORObject.Null, for convenience with the Object overload of this method).

NOTE: This method can't be used to add a tag to an existing CBOR object. To create a CBOR object with a given tag, call the `CBORObject.FromObjectAndTag` method and pass the CBOR object nd the desired tag number to that method.

The following example creates a CBOR array and adds several CBOR objects, one of which has a custom CBOR tag, to that array. Note the chaining behavior made possible by this method.

    CBORObject obj = CBORObject.NewArray()
                .Add(CBORObject.False)
                .Add(CBORObject.FromObject(5))
                .Add(CBORObject.FromObject("text string"))
                .Add(CBORObject.FromObjectAndTag(9999, 1));

<b>Parameters:</b>

 * <i>obj</i>: The parameter  <i>obj</i>
 is a CBOR object.

<b>Return Value:</b>

This instance.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object is not an array.

<a id="AddConverter_T_System_Type_PeterO_Cbor_ICBORConverter_T"></a>
### AddConverter

    public static void AddConverter<T>(
        System.Type type,
        PeterO.Cbor.ICBORConverter<T> converter);

Registers an object that converts objects of a given type to CBOR objects (called a CBOR converter).

<b>Parameters:</b>

 * <i>type</i>: A Type object specifying the type that the converter converts to CBOR objects.

 * <i>converter</i>: The parameter  <i>converter</i>
is an ICBORConverter object.

 * &lt;T&gt;: Must be the same as the "type" parameter.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>type</i>
 or  <i>converter</i>
 is null.

 * System.ArgumentException:
"Converter doesn't contain a proper ToCBORObject method".

<a id="Addition_PeterO_Cbor_CBORObject_PeterO_Cbor_CBORObject"></a>
### Addition

    public static PeterO.Cbor.CBORObject Addition(
        PeterO.Cbor.CBORObject first,
        PeterO.Cbor.CBORObject second);

Finds the sum of two CBOR numbers.

<b>Parameters:</b>

 * <i>first</i>: The parameter  <i>first</i>
 is a CBOR object.

 * <i>second</i>: The parameter  <i>second</i>
 is a CBOR object.

<b>Return Value:</b>

A CBORObject object.

<b>Exceptions:</b>

 * System.ArgumentException:
Either or both operands are not numbers (as opposed to Not-a-Number, NaN).

<a id="AddTagHandler_PeterO_BigInteger_PeterO_Cbor_ICBORTag"></a>
### AddTagHandler

    public static void AddTagHandler(
        PeterO.BigInteger bigintTag,
        PeterO.Cbor.ICBORTag handler);

<b>Deprecated.</b> May be removed in the future without replacement.  Not as useful as ICBORConverters and ICBORObjectConverters for FromObject and ToObject.  Moreover, registering tag handlers as this method does may tie them to the lifetime of the application.

Registers an object that validates CBOR objects with new tags.

<b>Parameters:</b>

 * <i>bigintTag</i>: An arbitrary-precision integer.

 * <i>handler</i>: The parameter  <i>handler</i>
 is an ICBORTag object.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bigintTag</i>
 or  <i>handler</i>
 is null.

 * System.ArgumentException:
The parameter <i>bigintTag</i>
 is less than 0 or greater than (2^64-1).

<a id="AddTagHandler_PeterO_Numbers_EInteger_PeterO_Cbor_ICBORTag"></a>
### AddTagHandler

    public static void AddTagHandler(
        PeterO.Numbers.EInteger bigintTag,
        PeterO.Cbor.ICBORTag handler);

<b>Deprecated.</b> May be removed in the future without replacement.  Not as useful as ICBORConverters and ICBORObjectConverters for FromObject and ToObject.  Moreover, registering tag handlers as this method does may tie them to the lifetime of the application.

Registers an object that validates CBOR objects with new tags.

<b>Parameters:</b>

 * <i>bigintTag</i>: An arbitrary-precision integer.

 * <i>handler</i>: The parameter  <i>handler</i>
 is an ICBORTag object.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bigintTag</i>
 or  <i>handler</i>
 is null.

 * System.ArgumentException:
The parameter <i>bigintTag</i>
 is less than 0 or greater than (2^64-1).

<a id="AsBigInteger"></a>
### AsBigInteger

    public PeterO.BigInteger AsBigInteger();

<b>Deprecated.</b> Use the AsEInteger method instead.

Converts this object to an arbitrary-precision integer. Fractional values are truncated to an integer.

<b>Return Value:</b>

The closest big integer to this object.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type, including if this object is CBORObject.Null.

 * System.OverflowException:
This object's value is infinity or not-a-number (NaN).

<a id="AsBoolean"></a>
### AsBoolean

    public bool AsBoolean();

Returns false if this object is False, Null, or Undefined; otherwise,true.

<b>Return Value:</b>

False if this object is False, Null, or Undefined; otherwise,true.

<a id="AsByte"></a>
### AsByte

    public byte AsByte();

Converts this object to a byte (0 to 255). Floating point values are truncated to an integer.

<b>Return Value:</b>

The closest byte-sized integer to this object.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type.

 * System.OverflowException:
This object's value exceeds the range of a byte (would be less than 0 or greater than 255 when truncated to an integer).

<a id="AsDecimal"></a>
### AsDecimal

    public System.Decimal AsDecimal();

Converts this object to a .NET decimal.

<b>Return Value:</b>

The closest big integer to this object.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type.

 * System.OverflowException:
This object's value exceeds the range of a .NET decimal.

<a id="AsDouble"></a>
### AsDouble

    public double AsDouble();

Converts this object to a 64-bit floating point number.

<b>Return Value:</b>

The closest 64-bit floating point number to this object. The return value can be positive infinity or negative infinity if this value exceeds the range of a 64-bit floating point number.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type.

<a id="AsEDecimal"></a>
### AsEDecimal

    public PeterO.Numbers.EDecimal AsEDecimal();

Converts this object to a decimal number.

<b>Return Value:</b>

A decimal number for this object's value. If this object is a rational number with a nonterminating decimal expansion, returns a decimal number rounded to 34 digits.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type, including if this object is CBORObject.Null.

<a id="AsEFloat"></a>
### AsEFloat

    public PeterO.Numbers.EFloat AsEFloat();

Converts this object to an arbitrary-precision binary floating point number.

<b>Return Value:</b>

An arbitrary-precision binary floating point number for this object's value. Note that if this object is a decimal number with a fractional part, the conversion may lose information depending on the number. If this object is a rational number with a nonterminating binary expansion, returns a binary floating-point number rounded to 113 bits.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type, including if this object is CBORObject.Null.

<a id="AsEInteger"></a>
### AsEInteger

    public PeterO.Numbers.EInteger AsEInteger();

Converts this object to an arbitrary-precision integer. Fractional values are truncated to an integer.

<b>Return Value:</b>

The closest big integer to this object.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type, including if this object is CBORObject.Null.

 * System.OverflowException:
This object's value is infinity or not-a-number (NaN).

<a id="AsERational"></a>
### AsERational

    public PeterO.Numbers.ERational AsERational();

Converts this object to a rational number.

<b>Return Value:</b>

A rational number for this object's value.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type, including if this object is CBORObject.Null.

<a id="AsExtendedDecimal"></a>
### AsExtendedDecimal

    public PeterO.ExtendedDecimal AsExtendedDecimal();

<b>Deprecated.</b> Use AsEDecimal instead.

Converts this object to a decimal number.

<b>Return Value:</b>

A decimal number for this object's value. If this object is a rational number with a nonterminating decimal expansion, returns a decimal number rounded to 34 digits.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type, including if this object is CBORObject.Null.

<a id="AsExtendedFloat"></a>
### AsExtendedFloat

    public PeterO.ExtendedFloat AsExtendedFloat();

<b>Deprecated.</b> Use AsEFloat instead.

Converts this object to an arbitrary-precision binary floating point number.

<b>Return Value:</b>

An arbitrary-precision binary floating point number for this object's value. Note that if this object is a decimal number with a fractional part, the conversion may lose information depending on the number. If this object is a rational number with a nonterminating binary expansion, returns a binary floating-point number rounded to 113 bits.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type, including if this object is CBORObject.Null.

<a id="AsExtendedRational"></a>
### AsExtendedRational

    public PeterO.ExtendedRational AsExtendedRational();

<b>Deprecated.</b> Use AsERational instead.

Converts this object to a rational number.

<b>Return Value:</b>

A rational number for this object's value.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type, including if this object is CBORObject.Null.

<a id="AsInt16"></a>
### AsInt16

    public short AsInt16();

Converts this object to a 16-bit signed integer. Floating point values are truncated to an integer.

<b>Return Value:</b>

The closest 16-bit signed integer to this object.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type.

 * System.OverflowException:
This object's value exceeds the range of a 16-bit signed integer.

<a id="AsInt32"></a>
### AsInt32

    public int AsInt32();

Converts this object to a 32-bit signed integer. Non-integer number values are truncated to an integer. (NOTE: To determine whether this method call can succeed, call the<b>CanTruncatedIntFitInInt32</b>method before calling this method. Checking whether this object's type is `CBORType.Number` is not sufficient. See the example.).

The following example code (originally written in C# for the .NET Framework) shows a way to check whether a given CBOR object stores a 32-bit signed integer before getting its value.

    CBORObject obj = CBORObject.FromInt32(99999); if(obj.IsIntegral
            && obj.CanTruncatedIntFitInInt32()) { // Not an Int32;
            handle the error Console.WriteLine("Not a 32-bit integer."); } else
            { Console.WriteLine("The value is " + obj.AsInt32()); }

<b>Return Value:</b>

The closest 32-bit signed integer to this object.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type.

 * System.OverflowException:
This object's value exceeds the range of a 32-bit signed integer.

<a id="AsInt64"></a>
### AsInt64

    public long AsInt64();

Converts this object to a 64-bit signed integer. Non-integer numbers are truncated to an integer. (NOTE: To determine whether this method call can succeed, call the<b>CanTruncatedIntFitInInt64</b>method before calling this method. Checking whether this object's type is `CBORType.Number` is not sufficient. See the example.).

The following example code (originally written in C# for the .NET Framework) shows a way to check whether a given CBOR object stores a 64-bit signed integer before getting its value.

    CBORObject obj = CBORObject.FromInt64(99999); if(obj.IsIntegral
            && obj.CanTruncatedIntFitInInt64()) { // Not an Int64;
            handle the error Console.WriteLine("Not a 64-bit integer."); } else
            { Console.WriteLine("The value is " + obj.AsInt64()); }

<b>Return Value:</b>

The closest 64-bit signed integer to this object.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type.

 * System.OverflowException:
This object's value exceeds the range of a 64-bit signed integer.

<a id="AsSByte"></a>
### AsSByte

    public sbyte AsSByte();

Converts this object to an 8-bit signed integer.

<b>Return Value:</b>

An 8-bit signed integer.

<a id="AsSingle"></a>
### AsSingle

    public float AsSingle();

Converts this object to a 32-bit floating point number.

<b>Return Value:</b>

The closest 32-bit floating point number to this object. The return value can be positive infinity or negative infinity if this object's value exceeds the range of a 32-bit floating point number.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type.

<a id="AsString"></a>
### AsString

    public string AsString();

Gets the value of this object as a text string.

The following example code (originally written in C# for the .NET Framework) shows an idiom for returning a string value if a CBOR object is a text string, or  `null` if the CBOR object is CBOR null.

    CBORObject obj = CBORObject.FromString("test");
                string str = obj.IsNull ? null : obj.AsString();

<b>Return Value:</b>

Gets this object's string.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a string, including if this object is CBORObject.Null.

<a id="AsUInt16"></a>
### AsUInt16

    public ushort AsUInt16();

Converts this object to a 16-bit unsigned integer. The return value will be truncated as necessary.

<b>Return Value:</b>

A 16-bit unsigned integer.

<b>Exceptions:</b>

 * System.OverflowException:
This object's value is outside the range of a 16-bit unsigned integer.

<a id="AsUInt32"></a>
### AsUInt32

    public uint AsUInt32();

Converts this object to a 32-bit unsigned integer. The return value will be truncated as necessary.

<b>Return Value:</b>

A 32-bit unsigned integer.

<b>Exceptions:</b>

 * System.OverflowException:
This object's value is outside the range of a 32-bit unsigned integer.

<a id="AsUInt64"></a>
### AsUInt64

    public ulong AsUInt64();

Converts this object to a 64-bit unsigned integer. Non-integer values are truncated to an integer.

<b>Return Value:</b>

The closest big integer to this object.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type.

 * System.OverflowException:
This object's value exceeds the range of a 64-bit unsigned integer.

<a id="CanFitInDouble"></a>
### CanFitInDouble

    public bool CanFitInDouble();

Returns whether this object's value can be converted to a 64-bit floating point number without its value being rounded to another numerical value.

<b>Return Value:</b>

Whether this object's value can be converted to a 64-bit floating point number without its value being rounded to another numerical value. Returns true if this is a not-a-number value, even if the value's diagnostic information can' t fit in a 64-bit floating point number.

<a id="CanFitInInt32"></a>
### CanFitInInt32

    public bool CanFitInInt32();

Returns whether this object's numerical value is an integer, is -(2^31) or greater, and is less than 2^31.

<b>Return Value:</b>

 `true` if this object's numerical value is an integer, is -(2^31) or greater, and s less than 2^31; otherwise,  `false` .

<a id="CanFitInInt64"></a>
### CanFitInInt64

    public bool CanFitInInt64();

Returns whether this object's numerical value is an integer, is -(2^63) or greater, and is less than 2^63.

<b>Return Value:</b>

 `true` if this object's numerical value is an integer, is -(2^63) or greater, and s less than 2^63; otherwise,  `false` .

<a id="CanFitInSingle"></a>
### CanFitInSingle

    public bool CanFitInSingle();

Returns whether this object's value can be converted to a 32-bit floating point number without its value being rounded to another numerical value.

<b>Return Value:</b>

Whether this object's value can be converted to a 32-bit floating point number without its value being rounded to another numerical value. Returns true if this is a not-a-number value, even if the value's diagnostic information can' t fit in a 32-bit floating point number.

<a id="CanTruncatedIntFitInInt32"></a>
### CanTruncatedIntFitInInt32

    public bool CanTruncatedIntFitInInt32();

Returns whether this object's value, truncated to an integer, would be -(2^31) or greater, and less than 2^31.

<b>Return Value:</b>

 `true` if this object's value, truncated to an integer, would be -(2^31) or reater, and less than 2^31; otherwise,  `false` .

<a id="CanTruncatedIntFitInInt64"></a>
### CanTruncatedIntFitInInt64

    public bool CanTruncatedIntFitInInt64();

Returns whether this object's value, truncated to an integer, would be -(2^63) or greater, and less than 2^63.

<b>Return Value:</b>

 `true` if this object's value, truncated to an integer, would be -(2^63) or reater, and less than 2^63; otherwise,  `false` .

<a id="Clear"></a>
### Clear

    public void Clear();

Removes all items from this CBOR array or all keys and values from this CBOR map.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object is not a CBOR array or CBOR map.

<a id="CompareTo_PeterO_Cbor_CBORObject"></a>
### CompareTo

    public sealed int CompareTo(
        PeterO.Cbor.CBORObject other);

Compares two CBOR objects.In this implementation:

 * The null pointer (null reference) is considered less than any other object.

 * If either object is true, false, CBORObject.Null, or the undefined value, it is treated as less than the other value. If both objects have one of these four values, then undefined is less than CBORObject.Null, which is less than false, which is less than true.

 * If both objects are numbers, their mathematical values are compared. Here, NaN (not-a-number) is considered greater than any number.

 * If both objects are simple values other than true, false, CBORObject.Null, and the undefined value, the objects are compared according to their ordinal numbers.

 * If both objects are arrays, each element is compared. If one array is shorter than the other and the other array begins with that array (for the purposes of comparison), the shorter array is considered less than the longer array.

 * If both objects are strings, compares each string code-point by code-point, as though by the DataUtilities.CodePointCompare method.

 * If both objects are maps, compares each map as though each were an array with the sorted keys of that map as the array's elements. If both maps have the same keys, their values are compared in the order of the sorted keys.

 * If each object is a different type, then they are sorted by their type number, in the order given for the CBORType enumeration.

 * If each object has different tags and both objects are otherwise equal under this method, each element is compared as though each were an array with that object's tags listed in order from outermost to innermost.

This method is not consistent with the Equals method.

<b>Parameters:</b>

 * <i>other</i>: A value to compare with.

<b>Return Value:</b>

Less than 0, if this value is less than the other object; or 0, if both values are equal; or greater than 0, if this value is less than the other object or if the other object is null.

<b>Exceptions:</b>

 * System.ArgumentException:
An internal error occurred.

<a id="CompareToIgnoreTags_PeterO_Cbor_CBORObject"></a>
### CompareToIgnoreTags

    public int CompareToIgnoreTags(
        PeterO.Cbor.CBORObject other);

Compares this object and another CBOR object, ignoring the tags they have, if any. See the CompareTo method for more information on the comparison function.

<b>Parameters:</b>

 * <i>other</i>: A value to compare with.

<b>Return Value:</b>

Less than 0, if this value is less than the other object; or 0, if both values are equal; or greater than 0, if this value is less than the other object or if the other object is null.

<a id="ContainsKey_PeterO_Cbor_CBORObject"></a>
### ContainsKey

    public bool ContainsKey(
        PeterO.Cbor.CBORObject key);

Determines whether a value of the given key exists in this object.

<b>Parameters:</b>

 * <i>key</i>: An object that serves as the key.

<b>Return Value:</b>

 `true`  if the given key is found, or false if the given key is not found or this object is not a map.

<b>Exceptions:</b>

 * System.ArgumentNullException:
Key is null (as opposed to CBORObject.Null).

<a id="ContainsKey_string"></a>
### ContainsKey

    public bool ContainsKey(
        string key);

Determines whether a value of the given key exists in this object.

<b>Parameters:</b>

 * <i>key</i>: A string that serves as the key.

<b>Return Value:</b>

 `true`  if the given key (as a CBOR object) is found, or false if the given key is not found or this object is not a map.

<b>Exceptions:</b>

 * System.ArgumentNullException:
Key is null.

<a id="DecodeFromBytes_byte"></a>
### DecodeFromBytes

    public static PeterO.Cbor.CBORObject DecodeFromBytes(
        byte[] data);

<b>At the moment, use the overload of this method that takes a[PeterO.Cbor.CBOREncodeOptions](PeterO.Cbor.CBOREncodeOptions.md) object. The object `CBOREncodeOptions.Default`  contains recommended settings for CBOREncodeOptions, and those settings may be adopted by this overload (without a CBOREncodeOptions argument) in the next major version.</b>

Generates a CBOR object from an array of CBOR-encoded bytes.

<b>Parameters:</b>

 * <i>data</i>: A byte array in which a single CBOR object is encoded.

<b>Return Value:</b>

A CBOR object decoded from the given byte array.

<b>Exceptions:</b>

 * PeterO.Cbor.CBORException:
There was an error in reading or parsing the data. This includes cases where not all of the byte array represents a CBOR object. This exception is also thrown if the parameter  <i>data</i>
 is empty.

 * System.ArgumentNullException:
The parameter <i>data</i>
 is null.

<a id="DecodeFromBytes_byte_PeterO_Cbor_CBOREncodeOptions"></a>
### DecodeFromBytes

    public static PeterO.Cbor.CBORObject DecodeFromBytes(
        byte[] data,
        PeterO.Cbor.CBOREncodeOptions options);

Generates a CBOR object from an array of CBOR-encoded bytes, using the given `CBOREncodeOptions` object to control the decoding process.

The following example (originally written in C# for the .NET version) implements a method that decodes a text string from a CBOR byte array. It's successful only if the CBOR object contains an untagged text string.

    private static String DecodeTextString(byte[] bytes){
            if(bytes == null){ throw new
            ArgumentNullException(nameof(mapObj));} if(bytes.Length
            == 0 || bytes[0]<0x60 || bytes[0]>0x7f){throw new
            CBORException();} return
            CBORObject.DecodeFromBytes(bytes,
            CBOREncodeOptions.Default).AsString(); }

<b>Parameters:</b>

 * <i>data</i>: A byte array in which a single CBOR object is encoded.

 * <i>options</i>: The parameter <i>options</i>
is a CBOREncodeOptions object.

<b>Return Value:</b>

A CBOR object decoded from the given byte array.

<b>Exceptions:</b>

 * PeterO.Cbor.CBORException:
There was an error in reading or parsing the data. This includes cases where not all of the byte array represents a CBOR object. This exception is also thrown if the parameter <i>data</i>
is empty.

 * System.ArgumentNullException:
The parameter <i>data</i>
is null.

<a id="Divide_PeterO_Cbor_CBORObject_PeterO_Cbor_CBORObject"></a>
### Divide

    public static PeterO.Cbor.CBORObject Divide(
        PeterO.Cbor.CBORObject first,
        PeterO.Cbor.CBORObject second);

Divides a CBORObject object by the value of a CBORObject object.

<b>Parameters:</b>

 * <i>first</i>: The parameter <i>first</i>
is a CBOR object.

 * <i>second</i>: The parameter <i>second</i>
is a CBOR object.

<b>Return Value:</b>

The quotient of the two objects.

<a id="EncodeToBytes_PeterO_Cbor_CBOREncodeOptions"></a>
### EncodeToBytes

    public byte[] EncodeToBytes(
        PeterO.Cbor.CBOREncodeOptions options);

Writes the binary representation of this CBOR object and returns a byte array of that representation, using the specified options for encoding the object to CBOR format. If the CBOR object contains CBOR maps, or is a CBOR map itself, the keys to the map are written out to the byte array in an undefined order. The example code given in**PeterO.Cbor.CBORObject.WriteTo(System.IO.Stream)**can be used to write out certain keys of a CBOR map in a given order.

<b>Parameters:</b>

 * <i>options</i>: Options for encoding the data to CBOR.

<b>Return Value:</b>

A byte array in CBOR format.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>options</i>
 is null.

<a id="EncodeToBytes"></a>
### EncodeToBytes

    public byte[] EncodeToBytes();

<b>At the moment, use the overload of this method that takes a[PeterO.Cbor.CBOREncodeOptions](PeterO.Cbor.CBOREncodeOptions.md)object. The object `CBOREncodeOptions.Default` contains recommended settings for CBOREncodeOptions, and those ettings may be adopted by this overload (without a CBOREncodeOptions rgument) in the next major version.</b>

Writes the binary representation of this CBOR object and returns a byte array of that representation. If the CBOR object contains CBOR maps, or is a CBOR map itself, the keys to the map are written out to the byte array in an undefined order. The example code given in**PeterO.Cbor.CBORObject.WriteTo(System.IO.Stream)**can be used to write out certain keys of a CBOR map in a given order.

<b>Return Value:</b>

A byte array in CBOR format.

<a id="Equals_object"></a>
### Equals

    public override bool Equals(
        object obj);

Determines whether this object and another object are equal and have the same type. Not-a-number values can be considered equal by this method.

<b>Parameters:</b>

 * <i>obj</i>: The parameter <i>obj</i>
is an arbitrary object.

<b>Return Value:</b>

 `true` if the objects are equal; otherwise,  `false` .

<a id="Equals_PeterO_Cbor_CBORObject"></a>
### Equals

    public sealed bool Equals(
        PeterO.Cbor.CBORObject other);

Compares the equality of two CBOR objects. Not-a-number values can be considered equal by this method.

<b>Parameters:</b>

 * <i>other</i>: The object to compare.

<b>Return Value:</b>

 `true` if the objects are equal; otherwise,  `false` .

<a id="FromJSONString_string"></a>
### FromJSONString

    public static PeterO.Cbor.CBORObject FromJSONString(
        string str);

<b>At the moment, use the overload of this method that takes a[PeterO.Cbor.CBOREncodeOptions](PeterO.Cbor.CBOREncodeOptions.md) object. The object `CBOREncodeOptions.Default`  contains recommended settings for CBOREncodeOptions, and those settings may be adopted by this overload (without a CBOREncodeOptions argument) in the next major version.</b>

Generates a CBOR object from a text string in JavaScript Object Notation (JSON) format.

If a JSON object has the same key, only the last given value will be used for each duplicated key.

<b>Parameters:</b>

 * <i>str</i>: A string in JSON format. The entire string must contain a single JSON object and not multiple objects. The string may not begin with a byte-order mark (U+FEFF).

<b>Return Value:</b>

A CBORObject object.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>str</i>
 is null.

 * PeterO.Cbor.CBORException:
The string is not in JSON format.

<a id="FromJSONString_string_PeterO_Cbor_CBOREncodeOptions"></a>
### FromJSONString

    public static PeterO.Cbor.CBORObject FromJSONString(
        string str,
        PeterO.Cbor.CBOREncodeOptions options);

Generates a CBOR object from a text string in JavaScript Object Notation (JSON) format, using the specified options to control the decoding process.By default, if a JSON object has the same key, only the last given value will be used for each duplicated key.

<b>Parameters:</b>

 * <i>str</i>: A string in JSON format. The entire string must contain a single JSON object and not multiple objects. The string may not begin with a byte-order mark (U+FEFF).

 * <i>options</i>: The parameter  <i>options</i>
 is a CBOREncodeOptions object.

<b>Return Value:</b>

A CBORObject object.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>str</i>
 is null.

 * PeterO.Cbor.CBORException:
The string is not in JSON format.

<a id="FromObject_bool"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        bool value);

Returns the CBOR true value or false value, depending on "value".

<b>Parameters:</b>

 * <i>value</i>: Either True or False.

<b>Return Value:</b>

CBORObject.True if value is true; otherwise CBORObject.False.

<a id="FromObject_byte"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        byte value);

Generates a CBOR object from a byte (0 to 255).

<b>Parameters:</b>

 * <i>value</i>: The parameter <i>value</i>
is a byte (from 0 to 255).

<b>Return Value:</b>

A CBORObject object.

<a id="FromObject_byte"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        byte[] bytes);

Generates a CBOR object from a byte array. The byte array is copied to a new byte array. (This method can't be used to decode CBOR data from a byte array; for that, use the DecodeFromBytes method instead.).

The following example encodes a text string to a UTF-8 byte array, then uses the array to create a CBOR byte string object. It is not recommended to use  `Encoding.UTF8.GetBytes` in .NET, or he  `getBytes()` method in Java to do this. For instance, `Encoding.UTF8` begins the encoded string with a byte-order ark, and  `getBytes()` encodes text strings in an unspecified haracter encoding. Both behaviors can be undesirable. Instead, use he  `DataUtilities.GetUtf8Bytes` method to convert text trings to UTF-8.

    /* true does character replacement of
                invalid UTF-8; false throws an exception
                on invalid UTF-8 */
                byte[] bytes = DataUtilities.GetUtf8Bytes(
                textString, true);
                CBORObject cbor = CBORObject.FromBytes(bytes);

<b>Parameters:</b>

 * <i>bytes</i>: A byte array. Can be null.

<b>Return Value:</b>

A CBOR byte string object where each byte of the given byte array is copied to a new array, or CBORObject.Null if the value is null.

<a id="FromObject_char"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        char value);

Generates a CBOR string object from a Unicode character.

<b>Parameters:</b>

 * <i>value</i>: The parameter  <i>value</i>
 is a char object.

<b>Return Value:</b>

A CBORObject object.

<b>Exceptions:</b>

 * System.ArgumentException:
The parameter <i>value</i>
 is a surrogate code point.

<a id="FromObject_double"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        double value);

Generates a CBOR object from a 64-bit floating-point number.

<b>Parameters:</b>

 * <i>value</i>: The parameter <i>value</i>
is a 64-bit floating-point number.

<b>Return Value:</b>

A CBORObject object.

<a id="FromObject_float"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        float value);

Generates a CBOR object from a 32-bit floating-point number.

<b>Parameters:</b>

 * <i>value</i>: The parameter <i>value</i>
is a 32-bit floating-point number.

<b>Return Value:</b>

A CBORObject object.

<a id="FromObject_int"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        int value);

Generates a CBOR object from a 32-bit signed integer.

<b>Parameters:</b>

 * <i>value</i>: The parameter <i>value</i>
is a 32-bit signed integer.

<b>Return Value:</b>

A CBORObject object.

<a id="FromObject_int"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        int[] array);

Generates a CBOR object from an array of 32-bit integers.

<b>Parameters:</b>

 * <i>array</i>: An array of 32-bit integers.

<b>Return Value:</b>

A CBOR array object where each element of the given array is copied to a new array, or CBORObject.Null if the value is null.

<a id="FromObject_long"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        long value);

Generates a CBOR object from a 64-bit signed integer.

<b>Parameters:</b>

 * <i>value</i>: The parameter <i>value</i>
is a 64-bit signed integer.

<b>Return Value:</b>

A CBORObject object.

<a id="FromObject_long"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        long[] array);

Generates a CBOR object from an array of 64-bit integers.

<b>Parameters:</b>

 * <i>array</i>: An array of 64-bit integers.

<b>Return Value:</b>

A CBOR array object where each element of the given array is copied to a new array, or CBORObject.Null if the value is null.

<a id="FromObject_object"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        object obj);

Generates a CBORObject from an arbitrary object. See the overload of this method that takes a PODOptions argument.

<b>Parameters:</b>

 * <i>obj</i>: The parameter <i>obj</i>
is an arbitrary object.

<b>Return Value:</b>

A CBOR object corresponding to the given object. Returns CBORObject.Null if the object is null.

<a id="FromObject_object_PeterO_Cbor_PODOptions"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        object obj,
        PeterO.Cbor.PODOptions options);

Generates a CBORObject from an arbitrary object, using the given options to control how certain objects are converted to CBOR objects. The following types are specially handled by this method: null; primitive types; string; CBORObject; the  `EDecimal` , `EFloat` ,  `EInteger` , and  `ERational`  classes in the new<a href="https://www.nuget.org/packages/PeterO.Numbers"> `PeterO.Numbers` </a>library (in .NET) or the<a href="https://github.com/peteroupc/numbers-java"> `com.github.peteroupc/numbers` </a>artifact (in Java); the legacy  `ExtendedDecimal` , `ExtendedFloat` ,  `BigInteger` , and `ExtendedRational`  classes in this library; arrays; enumerations (  `Enum`  objects); and maps. (See also the other overloads to the FromObject method.)

In the .NET version, if the object is a type not specially handled by this method, returns a CBOR map with the values of each of its read/write properties (or all properties in the case of a compiler-generated type). Properties are converted to their camel-case names (meaning if a name starts with A to Z, that letter is lower-cased). If the property name begins with the word "Is" followed by an upper-case A to Z, the "Is" prefix is deleted from the name. (Passing the appropriate "options" parameter can be done to control whether the "Is" prefix is removed and whether a camel-case conversion happens.) Also, .NET  `Enum`  objects will be converted to their integer values, and a multidimensional array is converted to an array of arrays.

In the Java version, if the object is a type not specially handled by this method, this method checks the CBOR object for methods starting with the word "get" or "is" (either word followed by an upper-case A to Z) that take no parameters, and returns a CBOR map with one entry for each such method found. For each method found, the starting word "get" or "is" is deleted from its name, and the name is converted to camel case (meaning if a name starts with A to Z, that letter is lower-cased). (Passing the appropriate "options" parameter can be done to control whether the "is" prefix is removed and whether a camel-case conversion happens.) Also, Java `Enum`  objects will be converted to the result of their `name`  method.

If the input is a byte array, the byte array is copied to a new byte array. (This method can't be used to decode CBOR data from a byte array; for that, use the DecodeFromBytes method instead.).

If the input is a text string, a CBOR text string object will be created. To create a CBOR byte string object from a text string, see the example given in**PeterO.Cbor.CBORObject.FromObject(System.Byte[])**.

REMARK: The behavior of this method is likely to change in the next major version (4.0). There are certain inconsistencies between the ToObject method and the FromObject method as well as between the .NET and Java versions of FromObject. For one thing, DateTime/Date objects are converted differently between the two versions -- either as CBOR maps with their "get" properties (Java) or as tag-0 strings (.NET) -- this difference has to remain for backward compatibility with version 3.0. For another thing, the treatment of properties/getters starting with "Is" is subtly inconsistent between the .NET and Java versions of FromObject, especially when using certain PODOptions. A certain consistency between .NET and Java and between FromObject and ToObject are sought for version 4.0. It is also hoped that--

 * the ToObject method will support deserializing to objects consisting of fields and not getters ("getX()" methods), both in .NET and in Java, and

 * both FromObject and ToObject will be better designed, in version 4.0, so that backward-compatible improvements are easier to make.

<b>Parameters:</b>

 * <i>obj</i>: The parameter  <i>obj</i>
 is an arbitrary object.

 * <i>options</i>: An object containing options to control how certain objects are converted to CBOR objects.

<b>Return Value:</b>

A CBOR object corresponding to the given object. Returns CBORObject.Null if the object is null.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter  <i>options</i>
 is null.

<a id="FromObject_PeterO_BigInteger"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        PeterO.BigInteger bigintValue);

<b>Deprecated.</b> Use the EInteger version of this method.

Generates a CBOR object from an arbitrary-precision integer.

<b>Parameters:</b>

 * <i>bigintValue</i>: An arbitrary-precision value.

<b>Return Value:</b>

A CBOR number.

<a id="FromObject_PeterO_Cbor_CBORObject"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        PeterO.Cbor.CBORObject value);

Generates a CBOR object from a CBOR object.

<b>Parameters:</b>

 * <i>value</i>: The parameter <i>value</i>
is a CBOR object.

<b>Return Value:</b>

Same as.

<a id="FromObject_PeterO_Cbor_CBORObject"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        PeterO.Cbor.CBORObject[] array);

Generates a CBOR object from an array of CBOR objects.

<b>Parameters:</b>

 * <i>array</i>: An array of CBOR objects.

<b>Return Value:</b>

A CBOR object where each element of the given array is copied to a new array, or CBORObject.Null if the value is null.

<a id="FromObject_PeterO_ExtendedDecimal"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        PeterO.ExtendedDecimal otherValue);

<b>Deprecated.</b> Use the EDecimal version of this method instead.

Generates a CBOR object from a decimal number.

<b>Parameters:</b>

 * <i>otherValue</i>: An arbitrary-precision decimal number.

<b>Return Value:</b>

A CBOR number.

<a id="FromObject_PeterO_ExtendedFloat"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        PeterO.ExtendedFloat bigValue);

<b>Deprecated.</b> Use the EFloat version of this method instead.

Generates a CBOR object from an arbitrary-precision binary floating-point number.

<b>Parameters:</b>

 * <i>bigValue</i>: An arbitrary-precision binary floating-point number.

<b>Return Value:</b>

A CBOR number.

<a id="FromObject_PeterO_ExtendedRational"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        PeterO.ExtendedRational bigValue);

<b>Deprecated.</b> Use the ERational version of this method instead.

Generates a CBOR object from an arbitrary-precision binary floating-point number.

<b>Parameters:</b>

 * <i>bigValue</i>: An arbitrary-precision binary floating-point number.

<b>Return Value:</b>

A CBOR number.

<a id="FromObject_PeterO_Numbers_EDecimal"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        PeterO.Numbers.EDecimal otherValue);

Generates a CBOR object from a decimal number.

<b>Parameters:</b>

 * <i>otherValue</i>: An arbitrary-precision decimal number.

<b>Return Value:</b>

A CBOR number.

<a id="FromObject_PeterO_Numbers_EFloat"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        PeterO.Numbers.EFloat bigValue);

Generates a CBOR object from an arbitrary-precision binary floating-point number.

<b>Parameters:</b>

 * <i>bigValue</i>: An arbitrary-precision binary floating-point number.

<b>Return Value:</b>

A CBOR number.

<a id="FromObject_PeterO_Numbers_EInteger"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        PeterO.Numbers.EInteger bigintValue);

Generates a CBOR object from an arbitrary-precision integer.

<b>Parameters:</b>

 * <i>bigintValue</i>: An arbitrary-precision value.

<b>Return Value:</b>

A CBOR number.

<a id="FromObject_PeterO_Numbers_ERational"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        PeterO.Numbers.ERational bigValue);

Generates a CBOR object from a rational number.

<b>Parameters:</b>

 * <i>bigValue</i>: A rational number.

<b>Return Value:</b>

A CBOR number.

<a id="FromObject_sbyte"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        sbyte value);

Converts a signed 8-bit integer to a CBOR object.

<b>Parameters:</b>

 * <i>value</i>: The parameter <i>value</i>
is an 8-bit signed integer.

<b>Return Value:</b>

A CBORObject object.

<a id="FromObject_short"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        short value);

Generates a CBOR object from a 16-bit signed integer.

<b>Parameters:</b>

 * <i>value</i>: The parameter <i>value</i>
is a 16-bit signed integer.

<b>Return Value:</b>

A CBORObject object.

<a id="FromObject_string"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        string strValue);

Generates a CBOR object from a text string.

<b>Parameters:</b>

 * <i>strValue</i>: A string value. Can be null.

<b>Return Value:</b>

A CBOR object representing the string, or CBORObject.Null if stringValue is null.

<b>Exceptions:</b>

 * System.ArgumentException:
The string contains an unpaired surrogate code point.

<a id="FromObject_System_Decimal"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        System.Decimal value);

Converts a .NET decimal to a CBOR object.

<b>Parameters:</b>

 * <i>value</i>: The parameter <i>value</i>
is a Decimal object.

<b>Return Value:</b>

A CBORObject object with the same value as the .NET decimal.

<a id="FromObject_uint"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        uint value);

Converts a 32-bit unsigned integer to a CBOR object.

<b>Parameters:</b>

 * <i>value</i>: A 32-bit unsigned integer.

<b>Return Value:</b>

A CBORObject object.

<a id="FromObject_ulong"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        ulong value);

Converts a 64-bit unsigned integer to a CBOR object.

<b>Parameters:</b>

 * <i>value</i>: A 64-bit unsigned integer.

<b>Return Value:</b>

A CBORObject object.

<a id="FromObject_ushort"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        ushort value);

Converts a 16-bit unsigned integer to a CBOR object.

<b>Parameters:</b>

 * <i>value</i>: A 16-bit unsigned integer.

<b>Return Value:</b>

A CBORObject object.

<a id="FromObject_T_System_Collections_Generic_IEnumerable_T"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject<T>(
        System.Collections.Generic.IEnumerable<T> value);

Generates a CBOR object from an enumerable set of objects.

<b>Parameters:</b>

 * <i>value</i>: An object that implements the IEnumerable interface. In the .NET version, this can be the return value of an iterator or the result of a LINQ query.

 * &lt;T&gt;: A type convertible to CBORObject.

<b>Return Value:</b>

A CBOR object where each element of the given enumerable object is converted to a CBOR object and copied to a new array, or CBORObject.Null if the value is null.

<a id="FromObject_T_System_Collections_Generic_IList_T"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject<T>(
        System.Collections.Generic.IList<T> value);

Generates a CBOR object from a list of objects.

<b>Parameters:</b>

 * <i>value</i>: An array of CBOR objects. Can be null.

 * &lt;T&gt;: A type convertible to CBORObject.

<b>Return Value:</b>

A CBOR object where each element of the given array is converted to a CBOR object and copied to a new array, or CBORObject.Null if the value is null.

<a id="FromObject_TKey_TValue_System_Collections_Generic_IDictionary_TKey_TValue"></a>
### FromObject

    public static PeterO.Cbor.CBORObject FromObject<TKey, TValue>(
        System.Collections.Generic.IDictionary<TKey, TValue> dic);

Generates a CBOR object from a map of objects.

<b>Parameters:</b>

 * <i>dic</i>: A map of CBOR objects.

 * &lt;TKey&gt;: A type convertible to CBORObject; the type of the keys.

 * &lt;TValue&gt;: A type convertible to CBORObject; the type of the values.

<b>Return Value:</b>

A CBOR object where each key and value of the given map is converted to a CBOR object and copied to a new map, or CBORObject.Null if <i>dic</i>
is null.

<a id="FromObjectAndTag_object_ulong"></a>
### FromObjectAndTag

    public static PeterO.Cbor.CBORObject FromObjectAndTag(
        object o,
        ulong tag);

Generates a CBOR object from an arbitrary object and gives the resulting object a tag.

<b>Parameters:</b>

 * <i>o</i>: The parameter <i>o</i>
is an arbitrary object.

 * <i>tag</i>: A 64-bit integer that specifies a tag number. The tag number 55799 can be used to mark a "self-described CBOR" object. This document does not attempt to list all CBOR tags and their meanings. An up-to-date list can be found at the CBOR Tags registry maintained by the Internet Assigned Numbers Authority (<i>iana.org/assignments/cbor-tags</i>).

<b>Return Value:</b>

A CBOR object where the object <i>o</i>
is converted to a CBOR object and given the tag <i>tag</i>
.

<a id="FromObjectAndTag_object_PeterO_BigInteger"></a>
### FromObjectAndTag

    public static PeterO.Cbor.CBORObject FromObjectAndTag(
        object valueOb,
        PeterO.BigInteger bigintTag);

<b>Deprecated.</b> Use the EInteger version instead.

Generates a CBOR object from an arbitrary object and gives the resulting object a tag.

<b>Parameters:</b>

 * <i>valueOb</i>: An arbitrary object. If the tag number is 2 or 3, this must be a byte string whose bytes represent an integer in little-endian byte order, and the value of the number is 1 minus the integer's value for tag 3. If the tag number is 4 or 5, this must be an array with two elements: the first must be an integer representing the exponent, and the second must be an integer representing a mantissa.

 * <i>bigintTag</i>: Tag number. The tag number 55799 can be used to mark a "self-described CBOR" object. This document does not attempt to list all CBOR tags and their meanings. An up-to-date list can be found at the CBOR Tags registry maintained by the Internet Assigned Numbers Authority (<i>iana.org/assignments/cbor-tags</i>).

<b>Return Value:</b>

A CBOR object where the object  <i>valueOb</i>
is converted to a CBOR object and given the tag  <i>bigintTag</i>
.

<b>Exceptions:</b>

 * System.ArgumentException:
The parameter <i>bigintTag</i>
 is less than 0 or greater than 2^64-1, or  <i>valueOb</i>
 's type is unsupported.

 * System.ArgumentNullException:
The parameter <i>bigintTag</i>
 is null.

<a id="FromObjectAndTag_object_PeterO_Numbers_EInteger"></a>
### FromObjectAndTag

    public static PeterO.Cbor.CBORObject FromObjectAndTag(
        object valueOb,
        PeterO.Numbers.EInteger bigintTag);

Generates a CBOR object from an arbitrary object and gives the resulting object a tag.

<b>Parameters:</b>

 * <i>valueOb</i>: An arbitrary object. If the tag number is 2 or 3, this must be a byte string whose bytes represent an integer in little-endian byte order, and the value of the number is 1 minus the integer's value for tag 3. If the tag number is 4 or 5, this must be an array with two elements: the first must be an integer representing the exponent, and the second must be an integer representing a mantissa.

 * <i>bigintTag</i>: Tag number. The tag number 55799 can be used to mark a "self-described CBOR" object. This document does not attempt to list all CBOR tags and their meanings. An up-to-date list can be found at the CBOR Tags registry maintained by the Internet Assigned Numbers Authority (<i>iana.org/assignments/cbor-tags</i>).

<b>Return Value:</b>

A CBOR object where the object  <i>valueOb</i>
is converted to a CBOR object and given the tag  <i>bigintTag</i>
.

<b>Exceptions:</b>

 * System.ArgumentException:
The parameter <i>bigintTag</i>
 is less than 0 or greater than 2^64-1, or  <i>valueOb</i>
 's type is unsupported.

 * System.ArgumentNullException:
The parameter <i>bigintTag</i>
 is null.

<a id="FromObjectAndTag_object_int"></a>
### FromObjectAndTag

    public static PeterO.Cbor.CBORObject FromObjectAndTag(
        object valueObValue,
        int smallTag);

Generates a CBOR object from an arbitrary object and gives the resulting object a tag.

<b>Parameters:</b>

 * <i>valueObValue</i>: An arbitrary object. If the tag number is 2 or 3, this must be a byte string whose bytes represent an integer in little-endian byte order, and the value of the number is 1 minus the integer's value for tag 3. If the tag number is 4 or 5, this must be an array with two elements: the first must be an integer representing the exponent, and the second must be an integer representing a mantissa.

 * <i>smallTag</i>: A 32-bit integer that specifies a tag number. The tag number 55799 can be used to mark a "self-described CBOR" object. This document does not attempt to list all CBOR tags and their meanings. An up-to-date list can be found at the CBOR Tags registry maintained by the Internet Assigned Numbers Authority (<i>iana.org/assignments/cbor-tags</i>).

<b>Return Value:</b>

A CBOR object where the object  <i>valueObValue</i>
 is converted to a CBOR object and given the tag  <i>smallTag</i>
.

<b>Exceptions:</b>

 * System.ArgumentException:
The parameter <i>smallTag</i>
 is less than 0 or  <i>valueObValue</i>
 's type is unsupported.

<a id="FromSimpleValue_int"></a>
### FromSimpleValue

    public static PeterO.Cbor.CBORObject FromSimpleValue(
        int simpleValue);

Creates a CBOR object from a simple value number.

<b>Parameters:</b>

 * <i>simpleValue</i>: The parameter  <i>simpleValue</i>
 is a 32-bit signed integer.

<b>Return Value:</b>

A CBORObject object.

<b>Exceptions:</b>

 * System.ArgumentException:
The parameter <i>simpleValue</i>
 is less than 0, greater than 255, or from 24 through 31.

<a id="GetAllTags"></a>
### GetAllTags

    public PeterO.Numbers.EInteger[] GetAllTags();

Gets a list of all tags, from outermost to innermost.

<b>Return Value:</b>

An array of tags, or the empty string if this object is untagged.

<a id="GetByteString"></a>
### GetByteString

    public byte[] GetByteString();

Gets the byte array used in this object, if this object is a byte string, without copying the data to a new one. This method's return value can be used to modify the array's contents. Note, though, that the array' s length can't be changed.

<b>Return Value:</b>

The byte array held by this CBOR object.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object is not a byte string.

<a id="GetHashCode"></a>
### GetHashCode

    public override int GetHashCode();

Calculates the hash code of this object. No application or process IDs are used in the hash code calculation.

<b>Return Value:</b>

A 32-bit hash code.

<a id="GetTags"></a>
### GetTags

    public PeterO.BigInteger[] GetTags();

<b>Deprecated.</b> Use the GetAllTags method instead.

Gets a list of all tags, from outermost to innermost.

<b>Return Value:</b>

An array of tags, or the empty string if this object is untagged.

<a id="HasMostOuterTag_int"></a>
### HasMostOuterTag

    public bool HasMostOuterTag(
        int tagValue);

Returns whether this object has a tag of the given number.

<b>Parameters:</b>

 * <i>tagValue</i>: The tag value to search for.

<b>Return Value:</b>

 `true`  if this object has a tag of the given number; otherwise,  `false` .

<b>Exceptions:</b>

 * System.ArgumentException:
TagValue is less than 0.

 * System.ArgumentNullException:
The parameter "obj" is null.

<a id="HasMostOuterTag_PeterO_Numbers_EInteger"></a>
### HasMostOuterTag

    public bool HasMostOuterTag(
        PeterO.Numbers.EInteger bigTagValue);

Returns whether this object has a tag of the given number.

<b>Parameters:</b>

 * <i>bigTagValue</i>: The tag value to search for.

<b>Return Value:</b>

 `true`  if this object has a tag of the given number; otherwise,  `false` .

<b>Exceptions:</b>

 * System.ArgumentNullException:
BigTagValue is null.

 * System.ArgumentException:
BigTagValue is less than 0.

<a id="HasTag_int"></a>
### HasTag

    public bool HasTag(
        int tagValue);

Returns whether this object has a tag of the given number.

<b>Parameters:</b>

 * <i>tagValue</i>: The tag value to search for.

<b>Return Value:</b>

 `true`  if this object has a tag of the given number; otherwise,  `false` .

<b>Exceptions:</b>

 * System.ArgumentException:
TagValue is less than 0.

 * System.ArgumentNullException:
The parameter "obj" is null.

<a id="HasTag_PeterO_BigInteger"></a>
### HasTag

    public bool HasTag(
        PeterO.BigInteger bigTagValue);

<b>Deprecated.</b> Use the EInteger version of this method.

Returns whether this object has a tag of the given number.

<b>Parameters:</b>

 * <i>bigTagValue</i>: The tag value to search for.

<b>Return Value:</b>

 `true`  if this object has a tag of the given number; otherwise,  `false` .

<b>Exceptions:</b>

 * System.ArgumentNullException:
BigTagValue is null.

 * System.ArgumentException:
BigTagValue is less than 0.

<a id="HasTag_PeterO_Numbers_EInteger"></a>
### HasTag

    public bool HasTag(
        PeterO.Numbers.EInteger bigTagValue);

Returns whether this object has a tag of the given number.

<b>Parameters:</b>

 * <i>bigTagValue</i>: The tag value to search for.

<b>Return Value:</b>

 `true`  if this object has a tag of the given number; otherwise,  `false` .

<b>Exceptions:</b>

 * System.ArgumentNullException:
BigTagValue is null.

 * System.ArgumentException:
BigTagValue is less than 0.

<a id="Insert_int_object"></a>
### Insert

    public PeterO.Cbor.CBORObject Insert(
        int index,
        object valueOb);

Inserts an object at the specified position in this CBOR array.

<b>Parameters:</b>

 * <i>index</i>: Zero-based index to insert at.

 * <i>valueOb</i>: An object representing the value, which will be converted to a CBORObject. Can be null, in which case this value is converted to CBORObject.Null.

<b>Return Value:</b>

This instance.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object is not an array.

 * System.ArgumentException:
The parameter <i>valueOb</i>
 has an unsupported type; or  <i>index</i>
 is not a valid index into this array.

<a id="IsInfinity"></a>
### IsInfinity

    public bool IsInfinity();

Gets a value indicating whether this CBOR object represents infinity.

<b>Return Value:</b>

 `true` if this CBOR object represents infinity; otherwise,  `false` .

<a id="IsNaN"></a>
### IsNaN

    public bool IsNaN();

Gets a value indicating whether this CBOR object represents a not-a-number value (as opposed to whether this object's type is not a number type).

<b>Return Value:</b>

 `true` if this CBOR object represents a not-a-number value (as opposed to hether this object's type is not a number type); otherwise,  `false` .

<a id="IsNegativeInfinity"></a>
### IsNegativeInfinity

    public bool IsNegativeInfinity();

Gets a value indicating whether this CBOR object represents negative infinity.

<b>Return Value:</b>

 `true` if this CBOR object represents negative infinity; otherwise,  `false` .

<a id="IsPositiveInfinity"></a>
### IsPositiveInfinity

    public bool IsPositiveInfinity();

Gets a value indicating whether this CBOR object represents positive infinity.

<b>Return Value:</b>

 `true` if this CBOR object represents positive infinity; otherwise,  `false` .

<a id="Multiply_PeterO_Cbor_CBORObject_PeterO_Cbor_CBORObject"></a>
### Multiply

    public static PeterO.Cbor.CBORObject Multiply(
        PeterO.Cbor.CBORObject first,
        PeterO.Cbor.CBORObject second);

Multiplies two CBOR numbers.

<b>Parameters:</b>

 * <i>first</i>: The parameter  <i>first</i>
 is a CBOR object.

 * <i>second</i>: The parameter  <i>second</i>
 is a CBOR object.

<b>Return Value:</b>

The product of the two numbers.

<b>Exceptions:</b>

 * System.ArgumentException:
Either or both operands are not numbers (as opposed to Not-a-Number, NaN).

<a id="Negate"></a>
### Negate

    public PeterO.Cbor.CBORObject Negate();

Gets this object's value with the sign reversed.

<b>Return Value:</b>

The reversed-sign form of this number.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type.

<a id="NewArray"></a>
### NewArray

    public static PeterO.Cbor.CBORObject NewArray();

Creates a new empty CBOR array.

<b>Return Value:</b>

A new CBOR array.

<a id="NewMap"></a>
### NewMap

    public static PeterO.Cbor.CBORObject NewMap();

Creates a new empty CBOR map.

<b>Return Value:</b>

A new CBOR map.

<a id="op_Addition"></a>
### Operator `+`

    public static PeterO.Cbor.CBORObject operator +(
        PeterO.Cbor.CBORObject a,
        PeterO.Cbor.CBORObject b);

Adds two CBOR objects and returns their result.

<b>Parameters:</b>

 * <i>a</i>: The parameter <i>a</i>
is a CBOR object.

 * <i>b</i>: The parameter <i>b</i>
is a CBOR object.

<b>Return Value:</b>

The sum of the two objects.

<a id="op_Division"></a>
### Operator `/`

    public static PeterO.Cbor.CBORObject operator /(
        PeterO.Cbor.CBORObject a,
        PeterO.Cbor.CBORObject b);

Divides a CBORObject object by the value of a CBORObject object.

<b>Parameters:</b>

 * <i>a</i>: The parameter <i>a</i>
is a CBOR object.

 * <i>b</i>: The parameter <i>b</i>
is a CBOR object.

<b>Return Value:</b>

The quotient of the two objects.

<a id="op_Modulus"></a>
### Operator `%`

    public static PeterO.Cbor.CBORObject operator %(
        PeterO.Cbor.CBORObject a,
        PeterO.Cbor.CBORObject b);

Finds the remainder that results when a CBORObject object is divided by the value of a CBORObject object.

<b>Parameters:</b>

 * <i>a</i>: The parameter <i>a</i>
is a CBOR object.

 * <i>b</i>: The parameter <i>b</i>
is a CBOR object.

<b>Return Value:</b>

The remainder of the two numbers.

<a id="op_Multiply"></a>
### Operator `*`

    public static PeterO.Cbor.CBORObject operator *(
        PeterO.Cbor.CBORObject a,
        PeterO.Cbor.CBORObject b);

Multiplies a CBORObject object by the value of a CBORObject object.

<b>Parameters:</b>

 * <i>a</i>: The parameter <i>a</i>
is a CBOR object.

 * <i>b</i>: The parameter <i>b</i>
is a CBOR object.

<b>Return Value:</b>

The product of the two numbers.

<a id="op_Subtraction"></a>
### Operator `-`

    public static PeterO.Cbor.CBORObject operator -(
        PeterO.Cbor.CBORObject a,
        PeterO.Cbor.CBORObject b);

Subtracts a CBORObject object from a CBORObject object.

<b>Parameters:</b>

 * <i>a</i>: The parameter <i>a</i>
is a CBOR object.

 * <i>b</i>: The parameter <i>b</i>
is a CBOR object.

<b>Return Value:</b>

The difference of the two objects.

<a id="Read_System_IO_Stream"></a>
### Read

    public static PeterO.Cbor.CBORObject Read(
        System.IO.Stream stream);

<b>At the moment, use the overload of this method that takes a[PeterO.Cbor.CBOREncodeOptions](PeterO.Cbor.CBOREncodeOptions.md) object. The object `CBOREncodeOptions.Default`  contains recommended settings for CBOREncodeOptions, and those settings may be adopted by this overload (without a CBOREncodeOptions argument) in the next major version.</b>

Reads an object in CBOR format from a data stream. This method will read from the stream until the end of the CBOR object is reached or an error occurs, whichever happens first.

<b>Parameters:</b>

 * <i>stream</i>: A readable data stream.

<b>Return Value:</b>

A CBOR object that was read.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * PeterO.Cbor.CBORException:
There was an error in reading or parsing the data.

<a id="Read_System_IO_Stream_PeterO_Cbor_CBOREncodeOptions"></a>
### Read

    public static PeterO.Cbor.CBORObject Read(
        System.IO.Stream stream,
        PeterO.Cbor.CBOREncodeOptions options);

Reads an object in CBOR format from a data stream, using the specified options to control the decoding process. This method will read from the stream until the end of the CBOR object is reached or an error occurs, whichever happens first.

<b>Parameters:</b>

 * <i>stream</i>: A readable data stream.

 * <i>options</i>: The parameter  <i>options</i>
 is a CBOREncodeOptions object.

<b>Return Value:</b>

A CBOR object that was read.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * PeterO.Cbor.CBORException:
There was an error in reading or parsing the data.

<a id="ReadJSON_System_IO_Stream"></a>
### ReadJSON

    public static PeterO.Cbor.CBORObject ReadJSON(
        System.IO.Stream stream);

Generates a CBOR object from a data stream in JavaScript Object Notation (JSON) format. The JSON stream may begin with a byte-order mark (U+FEFF). Since version 2.0, the JSON stream can be in UTF-8, UTF-16, or UTF-32 encoding; the encoding is detected by assuming that the first character read must be a byte-order mark or a nonzero basic character (U+0001 to U+007F). (In previous versions, only UTF-8 was allowed.)If a JSON object has the same key, only the last given value will be used for each duplicated key.

<b>Parameters:</b>

 * <i>stream</i>: A readable data stream. The sequence of bytes read from the data stream must contain a single JSON object and not multiple objects.

<b>Return Value:</b>

A CBORObject object.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

 * PeterO.Cbor.CBORException:
The data stream contains invalid encoding or is not in JSON format.

<a id="ReadJSON_System_IO_Stream_PeterO_Cbor_CBOREncodeOptions"></a>
### ReadJSON

    public static PeterO.Cbor.CBORObject ReadJSON(
        System.IO.Stream stream,
        PeterO.Cbor.CBOREncodeOptions options);

Generates a CBOR object from a data stream in JavaScript Object Notation (JSON) format, using the specified options to control the decoding process. The JSON stream may begin with a byte-order mark (U+FEFF). Since version 2.0, the JSON stream can be in UTF-8, UTF-16, or UTF-32 encoding; the encoding is detected by assuming that the first character read must be a byte-order mark or a nonzero basic character (U+0001 to U+007F). (In previous versions, only UTF-8 was allowed.)By default, if a JSON object has the same key, only the last given value will be used for each duplicated key.

<b>Parameters:</b>

 * <i>stream</i>: A readable data stream. The sequence of bytes read from the data stream must contain a single JSON object and not multiple objects.

 * <i>options</i>: The parameter  <i>options</i>
 is a CBOREncodeOptions object.

<b>Return Value:</b>

A CBORObject object.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

 * PeterO.Cbor.CBORException:
The data stream contains invalid encoding or is not in JSON format.

<a id="Remainder_PeterO_Cbor_CBORObject_PeterO_Cbor_CBORObject"></a>
### Remainder

    public static PeterO.Cbor.CBORObject Remainder(
        PeterO.Cbor.CBORObject first,
        PeterO.Cbor.CBORObject second);

Finds the remainder that results when a CBORObject object is divided by the value of a CBORObject object.

<b>Parameters:</b>

 * <i>first</i>: The parameter <i>first</i>
is a CBOR object.

 * <i>second</i>: The parameter <i>second</i>
is a CBOR object.

<b>Return Value:</b>

The remainder of the two numbers.

<a id="Remove_object"></a>
### Remove

    public bool Remove(
        object obj);

If this object is an array, removes the first instance of the specified item (once converted to a CBOR object) from the array. If this object is a map, removes the item with the given key (once converted to a CBOR object) from the map.

<b>Parameters:</b>

 * <i>obj</i>: The item or key (once converted to a CBOR object) to remove.

<b>Return Value:</b>

 `true`  if the item was removed; otherwise,  `false` .

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>obj</i>
 is null (as opposed to CBORObject.Null).

 * System.InvalidOperationException:
The object is not an array or map.

<a id="Remove_PeterO_Cbor_CBORObject"></a>
### Remove

    public bool Remove(
        PeterO.Cbor.CBORObject obj);

If this object is an array, removes the first instance of the specified item from the array. If this object is a map, removes the item with the given key from the map.

<b>Parameters:</b>

 * <i>obj</i>: The item or key to remove.

<b>Return Value:</b>

 `true`  if the item was removed; otherwise,  `false` .

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>obj</i>
 is null (as opposed to CBORObject.Null).

 * System.InvalidOperationException:
The object is not an array or map.

<a id="RemoveAt_int"></a>
### RemoveAt

    public bool RemoveAt(
        int index);

Removes the item at the given index of this CBOR array.

<b>Parameters:</b>

 * <i>index</i>: The index, starting at 0, of the item to remove.

<b>Return Value:</b>

Returns "true" if the object was removed. Returns "false" if the given index is less than 0, or is at least as high as the number of items in the array.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object is not a CBOR array.

<a id="Set_object_object"></a>
### Set

    public PeterO.Cbor.CBORObject Set(
        object key,
        object valueOb);

Maps an object to a key in this CBOR map, or adds the value if the key doesn't exist.

<b>Parameters:</b>

 * <i>key</i>: An object representing the key, which will be converted to a CBORObject. Can be null, in which case this value is converted to CBORObject.Null.

 * <i>valueOb</i>: An object representing the value, which will be converted to a CBORObject. Can be null, in which case this value is converted to CBORObject.Null.

<b>Return Value:</b>

This instance.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object is not a map.

 * System.ArgumentException:
The parameter <i>key</i>
 or  <i>valueOb</i>
 has an unsupported type.

<a id="Subtract_PeterO_Cbor_CBORObject_PeterO_Cbor_CBORObject"></a>
### Subtract

    public static PeterO.Cbor.CBORObject Subtract(
        PeterO.Cbor.CBORObject first,
        PeterO.Cbor.CBORObject second);

Finds the difference between two CBOR number objects.

<b>Parameters:</b>

 * <i>first</i>: The parameter  <i>first</i>
 is a CBOR object.

 * <i>second</i>: The parameter  <i>second</i>
 is a CBOR object.

<b>Return Value:</b>

The difference of the two objects.

<b>Exceptions:</b>

 * System.ArgumentException:
Either or both operands are not numbers (as opposed to Not-a-Number, NaN).

<a id="ToJSONString_PeterO_Cbor_JSONOptions"></a>
### ToJSONString

    public string ToJSONString(
        PeterO.Cbor.JSONOptions options);

Converts this object to a string in JavaScript Object Notation (JSON) format, using the specified options to control the encoding process. This function works not only with arrays and maps, but also integers, strings, byte arrays, and other JSON data types. Notes:

 * If this object contains maps with non-string keys, the keys are converted to JSON strings before writing the map as a JSON string.

 * If the CBOR object contains CBOR maps, or is a CBOR map itself, the keys to the map are written out to the JSON string in an undefined order.

 * If a number in the form of an arbitrary-precision binary float has a very high binary exponent, it will be converted to a double before being converted to a JSON string. (The resulting double could overflow to infinity, in which case the arbitrary-precision binary float is converted to null.)

 * The string will not begin with a byte-order mark (U+FEFF); RFC 8259 (the JSON specification) forbids placing a byte-order mark at the beginning of a JSON string.

 * Byte strings are converted to Base64 URL without whitespace or padding by default (see section 4.1 of RFC 7049). A byte string will instead be converted to traditional base64 without whitespace or padding by default if it has tag 22, or base16 for tag 23. Padding will be included in the Base64 URL or traditional base64 form if<b>Base64Padding</b>in the JSON options is set to<b>true</b>. (To create a CBOR object with a given tag, call the `CBORObject.FromObjectAndTag` method and pass the CBOR object and the desired tag number to that ethod.)

 * Rational numbers will be converted to their exact form, if possible, otherwise to a high-precision approximation. (The resulting approximation could overflow to infinity, in which case the rational number is converted to null.)

 * Simple values other than true and false will be converted to null. (This doesn't include floating-point numbers.)

 * Infinity and not-a-number will be converted to null.

The example code given below (originally written in C# for the .NET version) can be used to write out certain keys of a CBOR map in a given order to a JSON string.

    /* Generates a JSON string of 'mapObj' whose keys are in the order given
            in 'keys' . Only keys found in 'keys' will be written if they exist in
            'mapObj'. */ private static string KeysToJSONMap(CBORObject mapObj,
            IList<CBORObject> keys){ if (mapObj == null) { throw new
            ArgumentNullException)nameof(mapObj));} if (keys == null) { throw
            new ArgumentNullException)nameof(keys));} if (obj.Type !=
            CBORType.Map) { throw new ArgumentException("'obj' is not a map."); }
            StringBuilder builder = new StringBuilder(); var first = true;
            builder.Append("{"); for (CBORObject key in keys) { if
            (mapObj.ContainsKey(key)) { if (!first) {builder.Append(", ");} var
            keyString=(key.CBORType == CBORType.String) ? key.AsString() :
            key.ToJSONString(); builder.Append(CBORObject.FromObject(keyString)
            .ToJSONString()) .Append(":").Append(mapObj[key].ToJSONString());
            first=false; } } return builder.Append("}").ToString(); }

<b>Parameters:</b>

 * <i>options</i>: An object containing the options to control writing the CBOR object to JSON.

<b>Return Value:</b>

A text string containing the converted object.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>options</i>
is null.

<a id="ToJSONString"></a>
### ToJSONString

    public string ToJSONString();

Converts this object to a string in JavaScript Object Notation (JSON) format, using the specified options to control the encoding process. See the overload to JSONString taking a JSONOptions argument.If the CBOR object contains CBOR maps, or is a CBOR map itself, the keys to the map are written out to the JSON string in an undefined order. The example code given in**PeterO.Cbor.CBORObject.ToJSONString(PeterO.Cbor.JSONOptions)**can be used to write out certain keys of a CBOR map in a given order to a JSON string.

<b>Return Value:</b>

A text string.

<a id="ToObject_System_Type"></a>
### ToObject

    public object ToObject(
        System.Type t);

Converts this CBOR object to an object of an arbitrary type.

If the type "T" is CBORObject, returns this CBOR object.

If this CBOR object is a null object, returns null, except if "T" is CBORObject.

If the type "T" is Object, returns this CBOR object.

If the type "T" is the generic List, IList, ICollection, or IEnumerable (or ArrayList, List, Collection, or Iterable in Java), and if this CBOR object is an array, returns an object conforming to the type, class, or interface passed to this method, where the object will contain all items in this CBOR array.

If the type "T" is the generic Dictionary or IDictionary (or HashMap or Map in Java), and if this CBOR object is a map, returns an object conforming to the type, class, or interface passed to this method, where the object will contain all keys and values in this CBOR map.

If the type "T" is `int` , returns the result of the AsInt32 method.

If the type "T" is `DateTime` (or `Date` in Java) , returns a date/time object if the CBOR object's outermost ag is 0 or 1.

If the type "T" is `long` , returns the result of the AsInt64 method.

If the type "T" is `double` , returns the result of the AsDouble method.

If the type "T" is String, returns the result of the AsString method.

If the type "T" is `byte[]` and this CBOR object is a byte array, returns a byte array which this BOR byte string's data will be copied to.

In the .NET version, if the type "T" is `DateTime` and this CBOR object is a text string with tag 0, converts that text tring to a DateTime and returns that DateTime.

If the type "T" is Boolean, returns the result of the IsTrue method.

In the .NET version, if the object is a CBOR map and the type "T" is not specially handled by this method, an object of the given type is created, then this method checks the CBOR object for public writable properties. For each method found, if its name (with the "Is" prefix deleted and then converted to camel case) matches the name of a key in this CBOR map, that property's setter is invoked and the corresponding value is passed to that method.

In the Java version, if the object is a CBOR map and the type "T" is not specially handled by this method, an object of the given type is created, then this method checks the CBOR object for public methods starting with the word "set" (followed by an upper-case A to Z) that take a single parameter. For each method found, if its name (with the starting word "set" deleted and then converted to camel case) matches the name of a key in this CBOR map, that method is invoked and the corresponding value is passed to that method.

REMARK: The behavior of this method is likely to change in the final version 3.4 of this library as well as in the next major version (4.0). There are certain inconsistencies between the ToObject method and the FromObject method as well as between the .NET and Java versions of FromObject. For one thing, DateTime/Date objects are converted differently between the two versions -- either as CBOR maps with their "get" properties (Java) or as tag-0 strings (.NET) -- this difference has to remain for backward compatibility with version 3.0. For another thing, the treatment of properties/getters starting with "Is" is subtly inconsistent between the .NET and Java versions of FromObject, especially when using certain PODOptions. A certain consistency between .NET and Java and between FromObject and ToObject are sought for version 4.0. It is also hoped that--

 * the ToObject method will support deserializing to objects consisting of fields and not getters ("getX()" methods), both in .NET and in Java, and

 * both FromObject and ToObject will be better designed, in version 4.0, so that backward-compatible improvements are easier to make.

Java offers no easy way to express a generic type, at least none as easy as C#'s `typeof` operator. The following example, written in Java, is a way to specify hat the return value will be an ArrayList of String objects.

    Type arrayListString = new ParameterizedType(){ public Type[]
            getActualTypeArguments(){ /* Contains one type parameter, String */
            return new Type[]{ String.class }; } public Type getRawType(){ /* Raw
            type is ArrayList */ return ArrayList.class; } public Type
            getOwnerType(){ return null; } }; ArrayList<String> array =
            (ArrayList<String>) cborArray.ToObject(arrayListString);

By comparison, the C# version is much shorter.

    var array = (List<String>)cborArray.ToObject(
            typeof(List<String>));

<b>Parameters:</b>

 * <i>t</i>: The type, class, or interface that this method's return value will belong to. To express a generic type in Java, see the example.

<b>Return Value:</b>

The converted object.

<b>Exceptions:</b>

 * System.NotSupportedException:
The given type <i>t</i>
, or this object's CBOR type, is not supported.

 * System.ArgumentNullException:
The parameter <i>t</i>
is null.

<a id="ToObject_T"></a>
### ToObject

    public T ToObject<T>();

Converts this CBOR object to an object of an arbitrary type. See **PeterO.Cbor.CBORObject.ToObject(System.Type)** for further information.

<b>Parameters:</b>

 * &lt;T&gt;: An arbitrary object type.

<b>Return Value:</b>

The converted object.

<b>Exceptions:</b>

 * System.NotSupportedException:
The given type "T", or this object's CBOR type, is not supported.

<a id="ToString"></a>
### ToString

    public override string ToString();

Returns this CBOR object in string form. The format is intended to be human-readable, not machine-readable, the format is not intended to be parsed, and the format may change at any time. The returned string is not necessarily in JavaScript Object Notation (JSON); to convert CBOR objects to JSON strings, use the **PeterO.Cbor.CBORObject.ToJSONString(PeterO.Cbor.JSONOptions)** method instead.

<b>Return Value:</b>

A text representation of this object.

<a id="Untag"></a>
### Untag

    public PeterO.Cbor.CBORObject Untag();

Gets an object with the same value as this one but without the tags it has, if any. If this object is an array, map, or byte string, the data will not be copied to the returned object, so changes to the returned object will be reflected in this one.

<b>Return Value:</b>

A CBORObject object.

<a id="UntagOne"></a>
### UntagOne

    public PeterO.Cbor.CBORObject UntagOne();

Gets an object with the same value as this one but without this object's outermost tag, if any. If this object is an array, map, or byte string, the data will not be copied to the returned object, so changes to the returned object will be reflected in this one.

<b>Return Value:</b>

A CBORObject object.

<a id="Write_bool_System_IO_Stream"></a>
### Write

    public static void Write(
        bool value,
        System.IO.Stream stream);

Writes a Boolean value in CBOR format to a data stream.

<b>Parameters:</b>

 * <i>value</i>: The value to write.

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

<a id="Write_byte_System_IO_Stream"></a>
### Write

    public static void Write(
        byte value,
        System.IO.Stream stream);

Writes a byte (0 to 255) in CBOR format to a data stream. If the value is less than 24, writes that byte. If the value is 25 to 255, writes the byte 24, then this byte's value.

<b>Parameters:</b>

 * <i>value</i>: The value to write.

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

<a id="Write_char_System_IO_Stream"></a>
### Write

    public static void Write(
        char value,
        System.IO.Stream stream);

Writes a Unicode character as a string in CBOR format to a data stream.

<b>Parameters:</b>

 * <i>value</i>: The value to write.

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.ArgumentException:
The parameter <i>value</i>
 is a surrogate code point.

 * System.IO.IOException:
An I/O error occurred.

<a id="Write_double_System_IO_Stream"></a>
### Write

    public static void Write(
        double value,
        System.IO.Stream stream);

Writes a 64-bit floating-point number in CBOR format to a data stream.

<b>Parameters:</b>

 * <i>value</i>: The value to write.

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

<a id="Write_float_System_IO_Stream"></a>
### Write

    public static void Write(
        float value,
        System.IO.Stream s);

Writes a 32-bit floating-point number in CBOR format to a data stream.

<b>Parameters:</b>

 * <i>value</i>: The value to write.

 * <i>s</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>s</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

<a id="Write_int_System_IO_Stream"></a>
### Write

    public static void Write(
        int value,
        System.IO.Stream stream);

Writes a 32-bit signed integer in CBOR format to a data stream.

<b>Parameters:</b>

 * <i>value</i>: The value to write.

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

<a id="Write_long_System_IO_Stream"></a>
### Write

    public static void Write(
        long value,
        System.IO.Stream stream);

Writes a 64-bit signed integer in CBOR format to a data stream.

<b>Parameters:</b>

 * <i>value</i>: The value to write.

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

<a id="Write_object_System_IO_Stream_PeterO_Cbor_CBOREncodeOptions"></a>
### Write

    public static void Write(
        object objValue,
        System.IO.Stream output,
        PeterO.Cbor.CBOREncodeOptions options);

Writes an arbitrary object to a CBOR data stream, using the specified options for controlling how the object is encoded to CBOR data format. If the object is convertible to a CBOR map or a CBOR object that contains CBOR maps, the keys to those maps are written out to the data stream in an undefined order. The example code given in**PeterO.Cbor.CBORObject.WriteTo(System.IO.Stream)**can be used to write out certain keys of a CBOR map in a given order. Currently, the following objects are supported:

 * Lists of CBORObject.

 * Maps of CBORObject. The keys to the map are written out to the data stream in an undefined order.

 * Null.

 * Byte arrays, which will always be written as definite-length byte strings.

 * String objects, which will be written as indefinite-length text strings if their size exceeds a certain threshold (this behavior may change in future versions of this library).

 * Any object accepted by the FromObject static methods.

<b>Parameters:</b>

 * <i>objValue</i>: The arbitrary object to be serialized. Can be null.

 * <i>output</i>: A writable data stream.

 * <i>options</i>: CBOR options for encoding the CBOR object to bytes.

<b>Exceptions:</b>

 * System.ArgumentException:
The object's type is not supported.

 * System.ArgumentNullException:
The parameter <i>options</i>
 or  <i>output</i>
 is null.

<a id="Write_object_System_IO_Stream"></a>
### Write

    public static void Write(
        object objValue,
        System.IO.Stream stream);

<b>At the moment, use the overload of this method that takes a[PeterO.Cbor.CBOREncodeOptions](PeterO.Cbor.CBOREncodeOptions.md)object. The object `CBOREncodeOptions.Default` contains recommended settings for CBOREncodeOptions, and those ettings may be adopted by this overload (without a CBOREncodeOptions rgument) in the next major version.</b>

Writes a CBOR object to a CBOR data stream. See the three-parameter Write method that takes a CBOREncodeOptions.

<b>Parameters:</b>

 * <i>objValue</i>: The parameter <i>objValue</i>
is an arbitrary object.

 * <i>stream</i>: A writable data stream.

<a id="Write_PeterO_BigInteger_System_IO_Stream"></a>
### Write

    public static void Write(
        PeterO.BigInteger bigint,
        System.IO.Stream stream);

<b>Deprecated.</b> Pass an EInteger to the Write method instead.

Writes a big integer in CBOR format to a data stream.

<b>Parameters:</b>

 * <i>bigint</i>: Big integer to write. Can be null.

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

<a id="Write_PeterO_Cbor_CBORObject_System_IO_Stream"></a>
### Write

    public static void Write(
        PeterO.Cbor.CBORObject value,
        System.IO.Stream stream);

Writes a CBOR object to a CBOR data stream.

<b>Parameters:</b>

 * <i>value</i>: The value to write. Can be null.

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

<a id="Write_PeterO_ExtendedDecimal_System_IO_Stream"></a>
### Write

    public static void Write(
        PeterO.ExtendedDecimal bignum,
        System.IO.Stream stream);

<b>Deprecated.</b> Pass an EDecimal to the Write method instead.

Writes a decimal floating-point number in CBOR format to a data stream, as follows:

 * If the value is null, writes the byte 0xF6.

 * If the value is negative zero, infinity, or NaN, converts the number to a  `double`  and writes that  `double` . If negative zero should not be written this way, use the Plus method to convert the value beforehand.

 * If the value has an exponent of zero, writes the value as an unsigned integer or signed integer if the number can fit either type or as a big integer otherwise.

 * In all other cases, writes the value as a decimal number.

<b>Parameters:</b>

 * <i>bignum</i>: The arbitrary-precision decimal number to write. Can be null.

 * <i>stream</i>: Stream to write to.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

<a id="Write_PeterO_ExtendedFloat_System_IO_Stream"></a>
### Write

    public static void Write(
        PeterO.ExtendedFloat bignum,
        System.IO.Stream stream);

<b>Deprecated.</b> Pass an EFloat to the Write method instead.

Writes a binary floating-point number in CBOR format to a data stream as follows:

 * If the value is null, writes the byte 0xF6.

 * If the value is negative zero, infinity, or NaN, converts the number to a  `double`  and writes that  `double` . If negative zero should not be written this way, use the Plus method to convert the value beforehand.

 * If the value has an exponent of zero, writes the value as an unsigned integer or signed integer if the number can fit either type or as a big integer otherwise.

 * In all other cases, writes the value as a big float.

<b>Parameters:</b>

 * <i>bignum</i>: An arbitrary-precision binary float.

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

<a id="Write_PeterO_ExtendedRational_System_IO_Stream"></a>
### Write

    public static void Write(
        PeterO.ExtendedRational rational,
        System.IO.Stream stream);

<b>Deprecated.</b> Pass an ERational to the Write method instead.

Writes a rational number in CBOR format to a data stream.

<b>Parameters:</b>

 * <i>rational</i>: An arbitrary-precision rational number.

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

<a id="Write_PeterO_Numbers_EDecimal_System_IO_Stream"></a>
### Write

    public static void Write(
        PeterO.Numbers.EDecimal bignum,
        System.IO.Stream stream);

Writes a decimal floating-point number in CBOR format to a data stream, as follows:

 * If the value is null, writes the byte 0xF6.

 * If the value is negative zero, infinity, or NaN, converts the number to a  `double`  and writes that  `double` . If negative zero should not be written this way, use the Plus method to convert the value beforehand.

 * If the value has an exponent of zero, writes the value as an unsigned integer or signed integer if the number can fit either type or as a big integer otherwise.

 * In all other cases, writes the value as a decimal number.

<b>Parameters:</b>

 * <i>bignum</i>: The arbitrary-precision decimal number to write. Can be null.

 * <i>stream</i>: Stream to write to.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

<a id="Write_PeterO_Numbers_EFloat_System_IO_Stream"></a>
### Write

    public static void Write(
        PeterO.Numbers.EFloat bignum,
        System.IO.Stream stream);

Writes a binary floating-point number in CBOR format to a data stream as follows:

 * If the value is null, writes the byte 0xF6.

 * If the value is negative zero, infinity, or NaN, converts the number to a  `double`  and writes that  `double` . If negative zero should not be written this way, use the Plus method to convert the value beforehand.

 * If the value has an exponent of zero, writes the value as an unsigned integer or signed integer if the number can fit either type or as a big integer otherwise.

 * In all other cases, writes the value as a big float.

<b>Parameters:</b>

 * <i>bignum</i>: An arbitrary-precision binary float.

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

<a id="Write_PeterO_Numbers_EInteger_System_IO_Stream"></a>
### Write

    public static void Write(
        PeterO.Numbers.EInteger bigint,
        System.IO.Stream stream);

Writes a big integer in CBOR format to a data stream.

<b>Parameters:</b>

 * <i>bigint</i>: Big integer to write. Can be null.

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

<a id="Write_PeterO_Numbers_ERational_System_IO_Stream"></a>
### Write

    public static void Write(
        PeterO.Numbers.ERational rational,
        System.IO.Stream stream);

Writes a rational number in CBOR format to a data stream.

<b>Parameters:</b>

 * <i>rational</i>: An arbitrary-precision rational number.

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

<a id="Write_sbyte_System_IO_Stream"></a>
### Write

    public static void Write(
        sbyte value,
        System.IO.Stream stream);

Writes an 8-bit signed integer in CBOR format to a data stream.

<b>Parameters:</b>

 * <i>value</i>: The parameter <i>value</i>
is an 8-bit signed integer.

 * <i>stream</i>: A writable data stream.

<a id="Write_short_System_IO_Stream"></a>
### Write

    public static void Write(
        short value,
        System.IO.Stream stream);

Writes a 16-bit signed integer in CBOR format to a data stream.

<b>Parameters:</b>

 * <i>value</i>: The value to write.

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

<a id="Write_string_System_IO_Stream"></a>
### Write

    public static void Write(
        string str,
        System.IO.Stream stream);

<b>At the moment, use the overload of this method that takes a[PeterO.Cbor.CBOREncodeOptions](PeterO.Cbor.CBOREncodeOptions.md) object. The object `CBOREncodeOptions.Default`  contains recommended settings for CBOREncodeOptions, and those settings may be adopted by this overload (without a CBOREncodeOptions argument) in the next major version.</b>

Writes a string in CBOR format to a data stream. The string will be encoded using indefinite-length encoding if its length exceeds a certain threshold (this behavior may change in future versions of this library).

<b>Parameters:</b>

 * <i>str</i>: The string to write. Can be null.

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

<a id="Write_string_System_IO_Stream_PeterO_Cbor_CBOREncodeOptions"></a>
### Write

    public static void Write(
        string str,
        System.IO.Stream stream,
        PeterO.Cbor.CBOREncodeOptions options);

Writes a string in CBOR format to a data stream, using the given options to control the encoding process.

<b>Parameters:</b>

 * <i>str</i>: The string to write. Can be null.

 * <i>stream</i>: A writable data stream.

 * <i>options</i>: Options for encoding the data to CBOR.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

<a id="Write_uint_System_IO_Stream"></a>
### Write

    public static void Write(
        uint value,
        System.IO.Stream stream);

Writes a 32-bit unsigned integer in CBOR format to a data stream.

<b>Parameters:</b>

 * <i>value</i>: A 32-bit unsigned integer.

 * <i>stream</i>: A writable data stream.

<a id="Write_ulong_System_IO_Stream"></a>
### Write

    public static void Write(
        ulong value,
        System.IO.Stream stream);

Writes a 64-bit unsigned integer in CBOR format to a data stream.

<b>Parameters:</b>

 * <i>value</i>: A 64-bit unsigned integer.

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
is null.

<a id="Write_ushort_System_IO_Stream"></a>
### Write

    public static void Write(
        ushort value,
        System.IO.Stream stream);

Writes a 16-bit unsigned integer in CBOR format to a data stream.

<b>Parameters:</b>

 * <i>value</i>: A 16-bit unsigned integer.

 * <i>stream</i>: A writable data stream.

<a id="WriteJSON_object_System_IO_Stream"></a>
### WriteJSON

    public static void WriteJSON(
        object obj,
        System.IO.Stream outputStream);

Converts an arbitrary object to a string in JavaScript Object Notation (JSON) format, as in the ToJSONString method, and writes that string to a data stream in UTF-8. If the object is convertible to a CBOR map, or to a CBOR object that contains CBOR maps, the keys to those maps are written out to the JSON string in an undefined order. The example code given in**PeterO.Cbor.CBORObject.ToJSONString(PeterO.Cbor.JSONOptions)**can be used to write out certain keys of a CBOR map in a given order to a SON string.

<b>Parameters:</b>

 * <i>obj</i>: The parameter <i>obj</i>
is an arbitrary object.

 * <i>outputStream</i>: A writable data stream.

<a id="WriteJSONTo_System_IO_Stream"></a>
### WriteJSONTo

    public void WriteJSONTo(
        System.IO.Stream outputStream);

Converts this object to a string in JavaScript Object Notation (JSON) format, as in the ToJSONString method, and writes that string to a data stream in UTF-8. If the CBOR object contains CBOR maps, or is a CBOR map, the keys to the map are written out to the JSON string in an undefined order. The example code given in**PeterO.Cbor.CBORObject.ToJSONString(PeterO.Cbor.JSONOptions)**can be used to write out certain keys of a CBOR map in a given order to a JSON string.

<b>Parameters:</b>

 * <i>outputStream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.IO.IOException:
An I/O error occurred.

 * System.ArgumentNullException:
The parameter <i>outputStream</i>
 is null.

<a id="WriteJSONTo_System_IO_Stream_PeterO_Cbor_JSONOptions"></a>
### WriteJSONTo

    public void WriteJSONTo(
        System.IO.Stream outputStream,
        PeterO.Cbor.JSONOptions options);

Converts this object to a string in JavaScript Object Notation (JSON) format, as in the ToJSONString method, and writes that string to a data stream in UTF-8, using the given JSON options to control the encoding process. If the CBOR object contains CBOR maps, or is a CBOR map, the keys to the map are written out to the JSON string in an undefined order. The example code given in**PeterO.Cbor.CBORObject.ToJSONString(PeterO.Cbor.JSONOptions)**can be used to write out certain keys of a CBOR map in a given order to a JSON string.

<b>Parameters:</b>

 * <i>outputStream</i>: A writable data stream.

 * <i>options</i>: An object containing the options to control writing the CBOR object to JSON.

<b>Exceptions:</b>

 * System.IO.IOException:
An I/O error occurred.

 * System.ArgumentNullException:
The parameter <i>outputStream</i>
 is null.

<a id="WriteTo_System_IO_Stream"></a>
### WriteTo

    public void WriteTo(
        System.IO.Stream stream);

<b>At the moment, use the overload of this method that takes a[PeterO.Cbor.CBOREncodeOptions](PeterO.Cbor.CBOREncodeOptions.md)object. The object `CBOREncodeOptions.Default` contains recommended settings for CBOREncodeOptions, and those ettings may be adopted by this overload (without a CBOREncodeOptions rgument) in the next major version.</b>

Writes this CBOR object to a data stream. If the CBOR object contains CBOR maps, or is a CBOR map, the keys to the map are written out to the data stream in an undefined order. See the examples (written in C# for the .NET version) for ways to write out certain keys of a CBOR map in a given order.

The following example shows a method that writes each key of 'mapObj' to 'outputStream', in the order given in 'keys', where 'mapObj' is written out in the form of a CBOR<b>definite-length map</b>. Only keys found in 'keys' will be written if they exist in 'mapObj'.

    private static void WriteKeysToMap(CBORObject mapObj,
            IList<CBORObject> keys, Stream outputStream){ if(mapObj
            == null){ throw new
            ArgumentNullException(nameof(mapObj));} if(keys ==
            null){throw new ArgumentNullException(nameof(keys));}
            if(outputStream == null){throw new
            ArgumentNullException(nameof(outputStream));}
            if(obj.Type!=CBORType.Map){ throw new ArgumentException("'obj'
            is not a map."); } int keyCount = 0; for (CBORObject key in keys)
            { if(mapObj.ContainsKey(key)){ keyCount++; } }
            CBORObject.WriteValue(outputStream, 5, keyCount); for (CBORObject key in
            keys) { if(mapObj.ContainsKey(key)){
            key.WriteTo(outputStream); mapObj[key].WriteTo(outputStream); }
            } }

The following example shows a method that writes each key of 'mapObj' to 'outputStream', in the order given in 'keys', where 'mapObj' is written out in the form of a CBOR<b>indefinite-length map</b>. Only keys found in 'keys' will be written if they exist in 'mapObj'.

    private static void WriteKeysToIndefMap(CBORObject mapObj,
            IList<CBORObject> keys, Stream outputStream){ if(mapObj
            == null){ throw new
            ArgumentNullException(nameof(mapObj));} if(keys ==
            null){throw new ArgumentNullException(nameof(keys));}
            if(outputStream == null){throw new
            ArgumentNullException(nameof(outputStream));}
            if(obj.Type!=CBORType.Map){ throw new ArgumentException("'obj'
            is not a map."); } outputStream.WriteByte((byte)0xBF); for
            (CBORObject key in keys) { if(mapObj.ContainsKey(key)){
            key.WriteTo(outputStream); mapObj[key].WriteTo(outputStream); }
            } outputStream.WriteByte((byte)0xff); }

The following example shows a method that writes out a list of objects to 'outputStream' as an<b>indefinite-length CBOR array</b>.

    private static void WriteToIndefArray( IList<object> list,
            Stream outputStream){ if(list == null){ throw new
            ArgumentNullException(nameof(list));} if(outputStream ==
            null){throw new
            ArgumentNullException(nameof(outputStream));}
            outputStream.WriteByte((byte)0x9f); for (object item in list) { new
            CBORObject(item).WriteTo(outputStream); }
            outputStream.WriteByte((byte)0xff); }

<b>Parameters:</b>

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
is null.

 * System.IO.IOException:
An I/O error occurred.

<a id="WriteTo_System_IO_Stream_PeterO_Cbor_CBOREncodeOptions"></a>
### WriteTo

    public void WriteTo(
        System.IO.Stream stream,
        PeterO.Cbor.CBOREncodeOptions options);

Writes this CBOR object to a data stream, using the specified options for encoding the data to CBOR format. If the CBOR object contains CBOR maps, or is a CBOR map, the keys to the map are written out to the data stream in an undefined order. The example code given in**PeterO.Cbor.CBORObject.WriteTo(System.IO.Stream)**can be used to write out certain keys of a CBOR map in a given order.

<b>Parameters:</b>

 * <i>stream</i>: A writable data stream.

 * <i>options</i>: Options for encoding the data to CBOR.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

 * System.ArgumentException:
"Unexpected data type".

<a id="WriteValue_System_IO_Stream_int_int"></a>
### WriteValue

    public static int WriteValue(
        System.IO.Stream outputStream,
        int majorType,
        int value);

Writes a CBOR major type number and an integer 0 or greater associated with it to a data stream, where that integer is passed to this method as a 32-bit signed integer. This is a low-level method that is useful for implementing custom CBOR encoding methodologies. This method encodes the given major type and value in the shortest form allowed for the major type.

In the following example, an array of three objects is written as CBOR to a data stream.

    CBORObject.WriteValue(stream, 4, 3);  /* array, length 3 */
                CBORObject.Write("hello world", stream);  /* item 1 */
                CBORObject.Write(25, stream);  /* item 2 */
                CBORObject.Write(false, stream);  // item 3

In the following example, a map consisting of two key-value pairs is written as CBOR to a data stream.

    CBORObject.WriteValue(stream, 5, 2);  // map, 2 pairs
                CBORObject.Write("number", stream);  // key 1
                CBORObject.Write(25, stream);  // value 1
                CBORObject.Write("string", stream);  // key 2
                CBORObject.Write("hello", stream);  // value 2

In the following example (originally written in C# for the .NET Framework version), a text string is written as CBOR to a data stream.

    string str = "hello world";
    byte[] bytes = DataUtilities.GetUtf8Bytes(str, true);
    CBORObject.WriteValue(stream, 4, bytes.Length);
    stream.Write(bytes, 0, bytes.Length);

<b>Parameters:</b>

 * <i>outputStream</i>: A writable data stream.

 * <i>majorType</i>: The CBOR major type to write. This is a number from 0 through 7 as follows. 0: integer 0 or greater; 1: negative integer; 2: byte string; 3: UTF-8 text string; 4: array; 5: map; 6: tag; 7: simple value. See RFC 7049 for details on these major types.

 * <i>value</i>: An integer 0 or greater associated with the major type, as follows. 0: integer 0 or greater; 1: the negative integer's absolute value is 1 plus this number; 2: length in bytes of the byte string; 3: length in bytes of the UTF-8 text string; 4: number of items in the array; 5: number of key-value pairs in the map; 6: tag number; 7: simple value number, which must be in the interval [0, 23] or [32, 255].

<b>Return Value:</b>

The number of bytes ordered to be written to the data stream.

<b>Exceptions:</b>

 * System.ArgumentException:
Value is from 24 to 31 and major type is 7.

 * System.ArgumentNullException:
The parameter  <i>outputStream</i>
 is null.

<a id="WriteValue_System_IO_Stream_int_long"></a>
### WriteValue

    public static int WriteValue(
        System.IO.Stream outputStream,
        int majorType,
        long value);

Writes a CBOR major type number and an integer 0 or greater associated with it to a data stream, where that integer is passed to this method as a 64-bit signed integer. This is a low-level method that is useful for implementing custom CBOR encoding methodologies. This method encodes the given major type and value in the shortest form allowed for the major type.

<b>Parameters:</b>

 * <i>outputStream</i>: A writable data stream.

 * <i>majorType</i>: The CBOR major type to write. This is a number from 0 through 7 as follows. 0: integer 0 or greater; 1: negative integer; 2: byte string; 3: UTF-8 text string; 4: array; 5: map; 6: tag; 7: simple value. See RFC 7049 for details on these major types.

 * <i>value</i>: An integer 0 or greater associated with the major type, as follows. 0: integer 0 or greater; 1: the negative integer's absolute value is 1 plus this number; 2: length in bytes of the byte string; 3: length in bytes of the UTF-8 text string; 4: number of items in the array; 5: number of key-value pairs in the map; 6: tag number; 7: simple value number, which must be in the interval [0, 23] or [32, 255].

<b>Return Value:</b>

The number of bytes ordered to be written to the data stream.

<b>Exceptions:</b>

 * System.ArgumentException:
Value is from 24 to 31 and major type is 7.

 * System.ArgumentNullException:
The parameter  <i>outputStream</i>
 is null.

<a id="WriteValue_System_IO_Stream_int_PeterO_Numbers_EInteger"></a>
### WriteValue

    public static int WriteValue(
        System.IO.Stream outputStream,
        int majorType,
        PeterO.Numbers.EInteger bigintValue);

Writes a CBOR major type number and an integer 0 or greater associated with it to a data stream, where that integer is passed to this method as an arbitrary-precision integer. This is a low-level method that is useful for implementing custom CBOR encoding methodologies. This method encodes the given major type and value in the shortest form allowed for the major type.

<b>Parameters:</b>

 * <i>outputStream</i>: A writable data stream.

 * <i>majorType</i>: The CBOR major type to write. This is a number from 0 through 7 as follows. 0: integer 0 or greater; 1: negative integer; 2: byte string; 3: UTF-8 text string; 4: array; 5: map; 6: tag; 7: simple value. See RFC 7049 for details on these major types.

 * <i>bigintValue</i>: An integer 0 or greater associated with the major type, as follows. 0: integer 0 or greater; 1: the negative integer's absolute value is 1 plus this number; 2: length in bytes of the byte string; 3: length in bytes of the UTF-8 text string; 4: number of items in the array; 5: number of key-value pairs in the map; 6: tag number; 7: simple value number, which must be in the interval [0, 23] or [32, 255]. For major types 0 to 6, this number may not be greater than 2^64 - 1.

<b>Return Value:</b>

The number of bytes ordered to be written to the data stream.

<b>Exceptions:</b>

 * System.ArgumentException:
The parameter <i>majorType</i>
 is 7 and value is greater than 255.

 * System.ArgumentNullException:
The parameter  <i>outputStream</i>
 or  <i>bigintValue</i>
 is null.

<a id="WriteValue_System_IO_Stream_int_uint"></a>
### WriteValue

    public static int WriteValue(
        System.IO.Stream outputStream,
        int majorType,
        uint value);

Writes a CBOR major type number and an integer 0 or greater associated with it to a data stream, where that integer is passed to this method as a 32-bit unsigned integer. This is a low-level method that is useful for implementing custom CBOR encoding methodologies. This method encodes the given major type and value in the shortest form allowed for the major type.

<b>Parameters:</b>

 * <i>outputStream</i>: A writable data stream.

 * <i>majorType</i>: The CBOR major type to write. This is a number from 0 through 7 as follows. 0: integer 0 or greater; 1: negative integer; 2: byte string; 3: UTF-8 text string; 4: array; 5: map; 6: tag; 7: simple value. See RFC 7049 for details on these major types.

 * <i>value</i>: An integer 0 or greater associated with the major type, as follows. 0: integer 0 or greater; 1: the negative integer's absolute value is 1 plus this number; 2: length in bytes of the byte string; 3: length in bytes of the UTF-8 text string; 4: number of items in the array; 5: number of key-value pairs in the map; 6: tag number; 7: simple value number, which must be in the interval [0, 23] or [32, 255].

<b>Return Value:</b>

The number of bytes ordered to be written to the data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter  <i>outputStream</i>
 is null.

<a id="WriteValue_System_IO_Stream_int_ulong"></a>
### WriteValue

    public static int WriteValue(
        System.IO.Stream outputStream,
        int majorType,
        ulong value);

Writes a CBOR major type number and an integer 0 or greater associated with it to a data stream, where that integer is passed to this method as a 64-bit unsigned integer. This is a low-level method that is useful for implementing custom CBOR encoding methodologies. This method encodes the given major type and value in the shortest form allowed for the major type.

<b>Parameters:</b>

 * <i>outputStream</i>: A writable data stream.

 * <i>majorType</i>: The CBOR major type to write. This is a number from 0 through 7 as follows. 0: integer 0 or greater; 1: negative integer; 2: byte string; 3: UTF-8 text string; 4: array; 5: map; 6: tag; 7: simple value. See RFC 7049 for details on these major types.

 * <i>value</i>: An integer 0 or greater associated with the major type, as follows. 0: integer 0 or greater; 1: the negative integer's absolute value is 1 plus this number; 2: length in bytes of the byte string; 3: length in bytes of the UTF-8 text string; 4: number of items in the array; 5: number of key-value pairs in the map; 6: tag number; 7: simple value number, which must be in the interval [0, 23] or [32, 255].

<b>Return Value:</b>

The number of bytes ordered to be written to the data stream.

<b>Exceptions:</b>

 * System.ArgumentException:
The parameter <i>majorType</i>
 is 7 and value is greater than 255.

 * System.ArgumentNullException:
The parameter  <i>outputStream</i>
 is null.

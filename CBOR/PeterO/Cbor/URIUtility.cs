using System;
using System.Text;

namespace PeterO.Cbor {
    /// <include file='../../docs.xml'
    /// path='docs/doc[@name="T:PeterO.Cbor.URIUtility"]/*'/>
  internal static class URIUtility {
    /// <include file='../../docs.xml'
    /// path='docs/doc[@name="T:PeterO.Cbor.URIUtility.ParseMode"]/*'/>
    internal enum ParseMode {
    /// <include file='../../docs.xml'
    /// path='docs/doc[@name="F:PeterO.Cbor.URIUtility.ParseMode.IRIStrict"]/*'/>
      IRIStrict,

    /// <include file='../../docs.xml'
    /// path='docs/doc[@name="F:PeterO.Cbor.URIUtility.ParseMode.URIStrict"]/*'/>
      URIStrict,

    /// <include file='../../docs.xml'
    /// path='docs/doc[@name="F:PeterO.Cbor.URIUtility.ParseMode.IRILenient"]/*'/>
      IRILenient,

    /// <include file='../../docs.xml'
    /// path='docs/doc[@name="F:PeterO.Cbor.URIUtility.ParseMode.URILenient"]/*'/>
      URILenient,

    /// <include file='../../docs.xml'
    /// path='docs/doc[@name="F:PeterO.Cbor.URIUtility.ParseMode.IRISurrogateLenient"]/*'/>
      IRISurrogateLenient
    }

    private const string HexChars = "0123456789ABCDEF";

    private static void appendAuthority(
  StringBuilder builder,
  string refValue,
  int[] segments) {
      if (segments[2] >= 0) {
        builder.Append("//");
        builder.Append(
  refValue.Substring(
  segments[2],
  segments[3] - segments[2]));
      }
    }

    private static void appendFragment(
  StringBuilder builder,
  string refValue,
  int[] segments) {
      if (segments[8] >= 0) {
        builder.Append('#');
        builder.Append(
  refValue.Substring(
  segments[8],
  segments[9] - segments[8]));
      }
    }

    private static void appendNormalizedPath(
      StringBuilder builder,
      string refValue,
      int[] segments) {
      builder.Append(
        normalizePath(
  refValue.Substring(
  segments[4],
  segments[5] - segments[4])));
    }

    private static void AppendPath(
  StringBuilder builder,
  string refValue,
  int[] segments) {
      builder.Append(
  refValue.Substring(
  segments[4],
  segments[5] - segments[4]));
    }

    private static void appendQuery(
  StringBuilder builder,
  string refValue,
  int[] segments) {
      if (segments[6] >= 0) {
        builder.Append('?');
        builder.Append(
  refValue.Substring(
  segments[6],
  segments[7] - segments[6]));
      }
    }

    private static void appendScheme(
  StringBuilder builder,
  string refValue,
  int[] segments) {
      if (segments[0] >= 0) {
        builder.Append(
          refValue.Substring(
  segments[0],
  segments[1] - segments[0]));
        builder.Append(':');
      }
    }

    /// <include file='../../docs.xml'
    /// path='docs/doc[@name="M:PeterO.Cbor.URIUtility.escapeURI(System.String,System.Int32)"]/*'/>
    public static string escapeURI(string s, int mode) {
      if (s == null) {
        return null;
      }
      int[] components = null;
      if (mode == 1) {
        components = (
          s == null) ? null : splitIRI(
  s,
  0,
  s.Length,
  ParseMode.IRIStrict);
        if (components == null) {
          return null;
        }
      } else {
        components = (s == null) ? null : splitIRI(
  s,
  0,
  s.Length,
  ParseMode.IRISurrogateLenient);
      }
      var index = 0;
      int valueSLength = s.Length;
      var builder = new StringBuilder();
      while (index < valueSLength) {
        int c = s[index];
        if ((c & 0xfc00) == 0xd800 && index + 1 < valueSLength &&
            (s[index + 1] & 0xfc00) == 0xdc00) {
          // Get the Unicode code point for the surrogate pair
          c = 0x10000 + ((c - 0xd800) << 10) + (s[index + 1] - 0xdc00);
          ++index;
        } else if ((c & 0xf800) == 0xd800) {
          c = 0xfffd;
        }
        if (mode == 0 || mode == 3) {
          if (c == '%' && mode == 3) {
            // Check for illegal percent encoding
            if (index + 2 >= valueSLength || !isHexChar(s[index + 1]) ||
                !isHexChar(s[index + 2])) {
              percentEncodeUtf8(builder, c);
            } else {
              if (c <= 0xffff) {
                builder.Append((char)c);
              } else if (c <= 0x10ffff) {
                builder.Append((char)((((c - 0x10000) >> 10) & 0x3ff) +
                    0xd800));
                builder.Append((char)(((c - 0x10000) & 0x3ff) + 0xdc00));
              }
            }
            ++index;
            continue;
          }
          if (c >= 0x7f || c <= 0x20 ||
              ((c & 0x7f) == c && "{}|^\\`<>\"".IndexOf((char)c) >= 0)) {
            percentEncodeUtf8(builder, c);
          } else if (c == '[' || c == ']') {
            if (components != null && index >= components[2] && index <
                components[3]) {
              // within the authority component, so don't percent-encode
              if (c <= 0xffff) {
                builder.Append((char)c);
              } else if (c <= 0x10ffff) {
                builder.Append((char)((((c - 0x10000) >> 10) & 0x3ff) +
                    0xd800));
                builder.Append((char)(((c - 0x10000) & 0x3ff) + 0xdc00));
              }
            } else {
              // percent encode
              percentEncodeUtf8(builder, c);
            }
          } else {
            if (c <= 0xffff) {
              builder.Append((char)c);
            } else if (c <= 0x10ffff) {
              builder.Append((char)((((c - 0x10000) >> 10) & 0x3ff) + 0xd800));
              builder.Append((char)(((c - 0x10000) & 0x3ff) + 0xdc00));
            }
          }
        } else if (mode == 1 || mode == 2) {
          if (c >= 0x80) {
            percentEncodeUtf8(builder, c);
          } else if (c == '[' || c == ']') {
            if (components != null && index >= components[2] && index <
                components[3]) {
              // within the authority component, so don't percent-encode
              if (c <= 0xffff) {
                builder.Append((char)c);
              } else if (c <= 0x10ffff) {
                builder.Append((char)((((c - 0x10000) >> 10) & 0x3ff) +
                    0xd800));
                builder.Append((char)(((c - 0x10000) & 0x3ff) + 0xdc00));
              }
            } else {
              // percent encode
              percentEncodeUtf8(builder, c);
            }
          } else {
            if (c <= 0xffff) {
              builder.Append((char)c);
            } else if (c <= 0x10ffff) {
              builder.Append((char)((((c - 0x10000) >> 10) & 0x3ff) + 0xd800));
              builder.Append((char)(((c - 0x10000) & 0x3ff) + 0xdc00));
            }
          }
        }
        ++index;
      }
      return builder.ToString();
    }

    /// <include file='../../docs.xml'
    /// path='docs/doc[@name="M:PeterO.Cbor.URIUtility.hasScheme(System.String)"]/*'/>
    public static bool hasScheme(string refValue) {
      int[] segments = (refValue == null) ? null : splitIRI(
        refValue,
        0,
        refValue.Length,
        ParseMode.IRIStrict);
      return segments != null && segments[0] >= 0;
    }

    /// <include file='../../docs.xml'
    /// path='docs/doc[@name="M:PeterO.Cbor.URIUtility.hasSchemeForURI(System.String)"]/*'/>
    public static bool hasSchemeForURI(string refValue) {
      int[] segments = (refValue == null) ? null : splitIRI(
        refValue,
        0,
        refValue.Length,
        ParseMode.URIStrict);
      return segments != null && segments[0] >= 0;
    }

    private static bool isHexChar(char c) {
      return (c >= 'a' && c <= 'f') ||
        (c >= 'A' && c <= 'F') || (c >= '0' && c <= '9');
    }

    private static int ToHex(char b1) {
      if (b1 >= '0' && b1 <= '9') {
        return b1 - '0';
      } else if (b1 >= 'A' && b1 <= 'F') {
        return b1 + 10 - 'A';
      } else {
        return (b1 >= 'a' && b1 <= 'f') ? (b1 + 10 - 'a') : 1;
      }
    }

    /// <include file='../../docs.xml'
    /// path='docs/doc[@name="M:PeterO.Cbor.URIUtility.PercentDecode(System.String)"]/*'/>
    public static string PercentDecode(string str) {
      return (str == null) ? null : PercentDecode(str, 0, str.Length);
    }

    /// <include file='../../docs.xml'
    /// path='docs/doc[@name="M:PeterO.Cbor.URIUtility.PercentDecode(System.String,System.Int32,System.Int32)"]/*'/>
    public static string PercentDecode(string str, int index, int endIndex) {
      if (str == null) {
 return null;
}
      // Quick check
      var quickCheck = true;
      var lastIndex = 0;
      int i = index;
      for (; i < endIndex; ++i) {
        if (str[i] >= 0xd800 || str[i] == '%') {
          quickCheck = false;
          lastIndex = i;
          break;
        }
      }
      if (quickCheck) {
 return str.Substring(index, endIndex - index);
}
      var retString = new StringBuilder();
      retString.Append(str, index, lastIndex);
      var cp = 0;
      var bytesSeen = 0;
      var bytesNeeded = 0;
      var lower = 0x80;
      var upper = 0xbf;
      var markedPos = -1;
      for (i = lastIndex; i < endIndex; ++i) {
        int c = str[i];
        if ((c & 0xfc00) == 0xd800 && i + 1 < endIndex &&
            (str[i + 1] & 0xfc00) == 0xdc00) {
          // Get the Unicode code point for the surrogate pair
          c = 0x10000 + ((c - 0xd800) << 10) + (str[i + 1] - 0xdc00);
          ++i;
        } else if ((c & 0xf800) == 0xd800) {
          c = 0xfffd;
        }
        if (c == '%') {
          if (i + 2 < endIndex) {
            int a = ToHex(str[i + 1]);
            int b = ToHex(str[i + 2]);
            if (a >= 0 && b >= 0) {
              b = (a * 16) + b;
              i += 2;
              // b now contains the byte read
              if (bytesNeeded == 0) {
                // this is the lead byte
                if (b < 0x80) {
                  retString.Append((char)b);
                  continue;
                } else if (b >= 0xc2 && b <= 0xdf) {
                  markedPos = i;
                  bytesNeeded = 1;
                  cp = b - 0xc0;
                } else if (b >= 0xe0 && b <= 0xef) {
                  markedPos = i;
                  lower = (b == 0xe0) ? 0xa0 : 0x80;
                  upper = (b == 0xed) ? 0x9f : 0xbf;
                  bytesNeeded = 2;
                  cp = b - 0xe0;
                } else if (b >= 0xf0 && b <= 0xf4) {
                  markedPos = i;
                  lower = (b == 0xf0) ? 0x90 : 0x80;
                  upper = (b == 0xf4) ? 0x8f : 0xbf;
                  bytesNeeded = 3;
                  cp = b - 0xf0;
                } else {
                  // illegal byte in UTF-8
                  retString.Append('\uFFFD');
                  continue;
                }
                cp <<= 6 * bytesNeeded;
                continue;
              } else {
                // this is a second or further byte
                if (b < lower || b > upper) {
                  // illegal trailing byte
                  cp = bytesNeeded = bytesSeen = 0;
                  lower = 0x80;
                  upper = 0xbf;
                  i = markedPos;  // reset to the last marked position
                  retString.Append('\uFFFD');
                  continue;
                }
                // reset lower and upper for the third
                // and further bytes
                lower = 0x80;
                upper = 0xbf;
                ++bytesSeen;
                cp += (b - 0x80) << (6 * (bytesNeeded - bytesSeen));
                markedPos = i;
                if (bytesSeen != bytesNeeded) {
                  // continue if not all bytes needed
                  // were read yet
                  continue;
                }
                int ret = cp;
                cp = 0;
                bytesSeen = 0;
                bytesNeeded = 0;
                // append the Unicode character
                if (ret <= 0xffff) {
  retString.Append((char)ret);
 } else {
              retString.Append((char)((((ret - 0x10000) >> 10) &
                    0x3ff) + 0xd800));
                  retString.Append((char)(((ret - 0x10000) & 0x3ff) + 0xdc00));
                }
                continue;
              }
            }
          }
        }
        if (bytesNeeded > 0) {
          // we expected further bytes here,
          // so emit a replacement character instead
          bytesNeeded = 0;
          retString.Append('\uFFFD');
        }
        // append the code point as is
        if (c <= 0xffff) {
  { retString.Append((char)c);
}
  } else if (c <= 0x10ffff) {
retString.Append((char)((((c - 0x10000) >> 10) & 0x3ff) + 0xd800));
retString.Append((char)(((c - 0x10000) & 0x3ff) + 0xdc00));
}
      }
      if (bytesNeeded > 0) {
        // we expected further bytes here,
        // so emit a replacement character instead
        bytesNeeded = 0;
        retString.Append('\uFFFD');
      }
      return retString.ToString();
      }

    /// <include file='../../docs.xml'
    /// path='docs/doc[@name="M:PeterO.Cbor.URIUtility.EncodeStringForURI(System.String)"]/*'/>
    public static string EncodeStringForURI(string s) {
      if (s == null) {
  throw new ArgumentNullException(nameof(s));
}
int index = 0;
var builder = new StringBuilder();
      while (index < s.Length) {
        int c = s[index];
        if ((c & 0xfc00) == 0xd800 && index + 1 < s.Length &&
            (s[index + 1] & 0xfc00) == 0xdc00) {
          // Get the Unicode code point for the surrogate pair
          c = 0x10000 + ((c - 0xd800) << 10) + (s[index + 1] - 0xdc00);
        } else if ((c & 0xf800) == 0xd800) {
          c = 0xfffd;
        }
        if (c >= 0x10000) {
 ++index;
}
    if ((c & 0x7F) == c && ((c >= 'A' && c <= 'Z') ||
        (c >= 'a' && c <= 'z') ||
            (c >= '0' && c <= '9') || "-_.~".IndexOf((char)c) >= 0)) {
          builder.Append((char)c);
          ++index;
        } else {
          percentEncodeUtf8(builder, c);
          ++index;
        }
      }
return builder.ToString();
    }

    private static bool isIfragmentChar(int c) {
      // '%' omitted
      return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') ||
        (c >= '0' && c <= '9') ||
        ((c & 0x7F) == c && "/?-._~:@!$&'()*+,;=".IndexOf((char)c) >= 0) ||
        (c >= 0xa0 && c <= 0xd7ff) || (c >= 0xf900 && c <= 0xfdcf) ||
        (c >= 0xfdf0 && c <= 0xffef) ||
        (c >= 0xe1000 && c <= 0xefffd) || (c >= 0x10000 && c <= 0xdfffd && (c &
          0xfffe) != 0xfffe);
    }

    private static bool isIpchar(int c) {
      // '%' omitted
      return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') ||
        (c >= '0' && c <= '9') ||
        ((c & 0x7F) == c && "/-._~:@!$&'()*+,;=".IndexOf((char)c) >= 0) ||
        (c >= 0xa0 && c <= 0xd7ff) || (c >= 0xf900 && c <= 0xfdcf) ||
        (c >= 0xfdf0 && c <= 0xffef) ||
        (c >= 0xe1000 && c <= 0xefffd) || (c >= 0x10000 && c <= 0xdfffd && (c &
          0xfffe) != 0xfffe);
    }

    private static bool isIqueryChar(int c) {
      // '%' omitted
      return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') ||
        (c >= '0' && c <= '9') ||
        ((c & 0x7F) == c && "/?-._~:@!$&'()*+,;=".IndexOf((char)c) >= 0) ||
        (c >= 0xa0 && c <= 0xd7ff) || (c >= 0xe000 && c <= 0xfdcf) ||
        (c >= 0xfdf0 && c <= 0xffef) ||
        (c >= 0x10000 && c <= 0x10fffd && (c & 0xfffe) != 0xfffe &&
           !(c >= 0xe0000 && c <= 0xe0fff));
    }

    private static bool isIRegNameChar(int c) {
      // '%' omitted
      return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') ||
        (c >= '0' && c <= '9') ||
        ((c & 0x7F) == c && "-._~!$&'()*+,;=".IndexOf((char)c) >= 0) ||
        (c >= 0xa0 && c <= 0xd7ff) || (c >= 0xf900 && c <= 0xfdcf) ||
        (c >= 0xfdf0 && c <= 0xffef) ||
        (c >= 0xe1000 && c <= 0xefffd) || (c >= 0x10000 && c <= 0xdfffd && (c &
          0xfffe) != 0xfffe);
    }

    private static bool isIUserInfoChar(int c) {
      // '%' omitted
      return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') ||
        (c >= '0' && c <= '9') ||
        ((c & 0x7F) == c && "-._~:!$&'()*+,;=".IndexOf((char)c) >= 0) ||
        (c >= 0xa0 && c <= 0xd7ff) || (c >= 0xf900 && c <= 0xfdcf) ||
        (c >= 0xfdf0 && c <= 0xffef) ||
        (c >= 0xe1000 && c <= 0xefffd) || (c >= 0x10000 && c <= 0xdfffd && (c &
          0xfffe) != 0xfffe);
    }

    /// <include file='../../docs.xml'
    /// path='docs/doc[@name="M:PeterO.Cbor.URIUtility.isValidCurieReference(System.String,System.Int32,System.Int32)"]/*'/>
    public static bool isValidCurieReference(string s, int offset, int length) {
      if (s == null) {
        return false;
      }
      if (offset < 0) {
   throw new ArgumentException("offset (" + offset + ") is less than " +
          "0 ");
      }
      if (offset > s.Length) {
        throw new ArgumentException("offset (" + offset + ") is more than " +
          s.Length);
      }
      if (length < 0) {
        throw new ArgumentException(
          "length (" + length + ") is less than " + "0 ");
      }
      if (length > s.Length) {
        throw new ArgumentException(
          "length (" + length + ") is more than " + s.Length);
      }
      if (s.Length - offset < length) {
        throw new ArgumentException(
          "s's length minus " + offset + " (" + (s.Length - offset) +
          ") is less than " + length);
      }
      if (length == 0) {
        return true;
      }
      int index = offset;
      int valueSLength = offset + length;
      var state = 0;
      if (index + 2 <= valueSLength && s[index] == '/' && s[index + 1] == '/') {
        // has an authority, which is not allowed
        return false;
      }
      state = 0;  // IRI Path
      while (index < valueSLength) {
        // Get the next Unicode character
        int c = s[index];
        if ((c & 0xfc00) == 0xd800 && index + 1 < valueSLength &&
            (s[index + 1] & 0xfc00) == 0xdc00) {
          // Get the Unicode code point for the surrogate pair
          c = 0x10000 + ((c - 0xd800) << 10) + (s[index + 1] - 0xdc00);
          ++index;
        } else if ((c & 0xf800) == 0xd800) {
          // error
          return false;
        }
        if (c == '%') {
          // Percent encoded character
          if (index + 2 < valueSLength && isHexChar(s[index + 1]) &&
              isHexChar(s[index + 2])) {
            index += 3;
            continue;
          }
          return false;
        }
        if (state == 0) {  // Path
          if (c == '?') {
            state = 1;  // move to query state
          } else if (c == '#') {
            state = 2;  // move to fragment state
          } else if (!isIpchar(c)) {
            return false;
          }
          ++index;
        } else if (state == 1) {  // Query
          if (c == '#') {
            state = 2;  // move to fragment state
          } else if (!isIqueryChar(c)) {
            return false;
          }
          ++index;
        } else if (state == 2) {  // Fragment
          if (!isIfragmentChar(c)) {
            return false;
          }
          ++index;
        }
      }
      return true;
    }

public static string BuildIRI(
  string schemeAndAuthority,
  string path,
  string query,
  string fragment) {
  var builder = new StringBuilder();
  if (!String.IsNullOrEmpty(schemeAndAuthority)) {
    int[] irisplit = splitIRI(schemeAndAuthority);
     // NOTE: Path component is always present in URIs;
     // we check here whether path component is empty
    if (irisplit == null || (irisplit[0] < 0 && irisplit[2] < 0) ||
      irisplit[4] != irisplit[5] || irisplit[6] >= 0 || irisplit[8] >= 0) {
 throw new ArgumentException("invalid schemeAndAuthority");
}
  }
  if (String.IsNullOrEmpty(path)) {
 path = String.Empty;
}
  for (var phase = 0; phase < 3; ++phase) {
    string s = path;
    if (phase == 1) {
      s = query;
      if (query == null) {
 continue;
}
      builder.Append('?');
    } else if (phase == 2) {
      s = fragment;
      if (fragment == null) {
 continue;
}
      builder.Append('#');
    }
      var index = 0;
      while (index < s.Length) {
        int c = s[index];
        if ((c & 0xfc00) == 0xd800 && index + 1 < s.Length &&
            (s[index + 1] & 0xfc00) == 0xdc00) {
          // Get the Unicode code point for the surrogate pair
          c = 0x10000 + ((c - 0xd800) << 10) + (s[index + 1] - 0xdc00);
        } else if ((c & 0xf800) == 0xd800) {
          c = 0xfffd;
        }
        if (c >= 0x10000) {
 ++index;
}
        if (c == '%') {
          if (index + 2 < s.Length && isHexChar(s[index + 1]) &&
            isHexChar(s[index + 2])) {
            builder.Append('%');
            builder.Append(s[index + 1]);
            builder.Append(s[index + 2]);
            index += 3;
          } else {
            builder.Append("%25");
            ++index;
          }
        } else if ((c & 0x7f) == c &&
   ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') ||
            (c >= '0' && c <= '9') ||
            "-_.~/(=):!$&'*+,;@".IndexOf((char)c) >= 0)) {
          // NOTE: Question mark will be percent encoded even though
          // it can appear in query and fragment strings
          builder.Append((char)c);
          ++index;
        } else {
          percentEncodeUtf8(builder, c);
          ++index;
        }
      }
  }
  string ret = builder.ToString();
  if (splitIRI(ret) == null) {
 throw new ArgumentException();
}
  return ret;
}

    public static bool isValidIRI(string s) {
      return ((s == null) ?
  null : splitIRI(
  s,
  0,
  s.Length,
  ParseMode.IRIStrict)) != null;
    }

    private const string ValueDotSlash = "." + "/";
    private const string ValueSlashDot = "/" + ".";

    private static string normalizePath(string path) {
      int len = path.Length;
      if (len == 0 || path.Equals("..") || path.Equals(".")) {
        return String.Empty;
      }
      if (path.IndexOf(ValueSlashDot, StringComparison.Ordinal) < 0 &&
          path.IndexOf(
  ValueDotSlash,
  StringComparison.Ordinal) < 0) {
        return path;
      }
      var builder = new StringBuilder();
      var index = 0;
      while (index < len) {
        char c = path[index];
        if ((index + 3 <= len && c == '/' && path[index + 1] == '.' &&
             path[index + 2] == '/') || (index + 2 == len && c == '.' &&
             path[index + 1] == '.')) {
          // begins with "/./" or is "..";
          // move index by 2
          index += 2;
          continue;
        }
        if (index + 3 <= len && c == '.' &&
            path[index + 1] == '.' && path[index + 2] == '/') {
          // begins with "../";
          // move index by 3
          index += 3;
          continue;
        }
        if ((index + 2 <= len && c == '.' &&
             path[index + 1] == '/') || (index + 1 == len && c == '.')) {
          // begins with "./" or is ".";
          // move index by 1
          ++index;
          continue;
        }
        if (index + 2 == len && c == '/' &&
            path[index + 1] == '.') {
          // is "/."; append '/' and break
          builder.Append('/');
          break;
        }
        if (index + 3 == len && c == '/' &&
            path[index + 1] == '.' && path[index + 2] == '.') {
          // is "/.."; remove last segment,
          // append "/" and return
          int index2 = builder.Length - 1;
          string builderString = builder.ToString();
          while (index2 >= 0) {
            if (builderString[index2] == '/') {
              break;
            }
            --index2;
          }
          if (index2 < 0) {
            index2 = 0;
          }
          builder.Length = index2;
          builder.Append('/');
          break;
        }
        if (index + 4 <= len && c == '/' && path[index + 1] == '.' &&
            path[index + 2] == '.' && path[index + 3] == '/') {
          // begins with "/../"; remove last segment
          int index2 = builder.Length - 1;
          string builderString = builder.ToString();
          while (index2 >= 0) {
            if (builderString[index2] == '/') {
              break;
            }
            --index2;
          }
          if (index2 < 0) {
            index2 = 0;
          }
          builder.Length = index2;
          index += 3;
          continue;
        }
        builder.Append(c);
        ++index;
        while (index < len) {
          // Move the rest of the
          // path segment until the next '/'
          c = path[index];
          if (c == '/') {
            break;
          }
          builder.Append(c);
          ++index;
        }
      }
      return builder.ToString();
    }

    private static int parseIPLiteral(string s, int offset, int endOffset) {
      int index = offset;
      if (offset == endOffset) {
        return -1;
      }
      // Assumes that the character before offset
      // is a '['
      if (s[index] == 'v') {
        // IPvFuture
        ++index;
        var hex = false;
        while (index < endOffset) {
          char c = s[index];
          if (isHexChar(c)) {
            hex = true;
          } else {
            break;
          }
          ++index;
        }
        if (!hex) {
          return -1;
        }
        if (index >= endOffset || s[index] != '.') {
          return -1;
        }
        ++index;
        hex = false;
        while (index < endOffset) {
          char c = s[index];
          if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') ||
              (c >= '0' && c <= '9') ||
              ((c & 0x7F) == c && ":-._~!$&'()*+,;=".IndexOf(c) >= 0)) {
            hex = true;
          } else {
            break;
          }
          ++index;
        }
        if (!hex) {
          return -1;
        }
        if (index >= endOffset || s[index] != ']') {
          return -1;
        }
        ++index;
        return index;
      }
      if (s[index] == ':' ||
          isHexChar(s[index])) {
     int startIndex = index;
while (index < endOffset && ((s[index] >= 65 && s[index] <= 70) ||
  (s[index] >= 97 && s[index] <= 102) || (s[index] >= 48 && s[index]
  <= 58) || (s[index] == 46))) {
 ++index;
}
if (index >= endOffset || (s[index] != ']' && s[index] != '%')) {
 return -1;
}
// NOTE: Array is initialized to zeros
int[] addressParts = new int[8];
int ipEndIndex = index;
var doubleColon = false;
var doubleColonPos = 0;
var totalParts = 0;
var ipv4part = false;
index = startIndex;
// DebugUtility.Log(s.Substring(startIndex, ipEndIndex-startIndex));
for (var part = 0; part < 8; ++part) {
 if (!doubleColon && ipEndIndex - index > 1 && s[index] == ':' && s[index +
   1] == ':') {
  doubleColon = true;
  doubleColonPos = part;
  index += 2;
            if (index == ipEndIndex) {
 break;
}
 }
 var hex = 0;
 var haveHex = false;
 int curindex = index;
 for (var i = 0; i < 4; ++i) {
if (isHexChar(s[index])) {
 hex = (hex << 4) | ToHex(s[index]);
 haveHex = true;
 ++index;
} else {
 break;
}
 }
 if (!haveHex) {
 return -1;
}
 if (index < ipEndIndex && s[index] == '.' && part < 7) {
  ipv4part = true;
  index = curindex;
  break;
 }
 addressParts[part] = hex;
 ++totalParts;
 if (index < ipEndIndex && s[index] != ':') {
 return -1;
}
 if (index == ipEndIndex && doubleColon) {
 break;
}
  // Skip single colon, but not double colon
 if (index < ipEndIndex &&
   (index + 1 >= ipEndIndex || s[index + 1] != ':')) {
 ++index;
}
}
if (index != ipEndIndex && !ipv4part) {
 return -1;
}
if (doubleColon || ipv4part) {
 if (ipv4part) {
  var ipparts = new int[4];
  for (var part = 0; part < 4; ++part) {
    if (part > 0) {
if (index < ipEndIndex && s[index] == '.') {
 ++index;
} else {
 return -1;
}
    }
if (index + 1 < ipEndIndex && s[index] == '0' &&
 (s[index + 1] >= '0' && s[index + 1] <= '9')) {
 return -1;
}
 var dec = 0;
 var haveDec = false;
 int curindex = index;
 for (var i = 0; i < 4; ++i) {
if (s[index] >= '0' && s[index] <= '9') {
 dec = (dec * 10) + ((int)s[index] - '0');
 haveDec = true;
 ++index;
} else {
 break;
}
 }
 if (!haveDec || dec > 255) {
 return -1;
}
ipparts[part] = dec;
  }
  if (index != ipEndIndex) {
 return -1;
}
  addressParts[totalParts] = (ipparts[0] << 8) | ipparts[1];
  addressParts[totalParts + 1] = (ipparts[2] << 8) | ipparts[3];
totalParts += 2;
  if (!doubleColon && totalParts != 8) {
 return -1;
}
 }
 if (doubleColon) {
  int resid = 8 - totalParts;
            if (resid == 0) {
              // Purported IPv6 address contains
              // 8 parts and a double colon
              return -1;
            }
  var newAddressParts = new int[8];
  Array.Copy(addressParts, newAddressParts, doubleColonPos);
  Array.Copy(
  addressParts,
  doubleColonPos,
  newAddressParts,
  doubleColonPos + resid,
  totalParts - doubleColonPos);
  Array.Copy(newAddressParts, addressParts, 8);
 }
} else if (totalParts != 8) {
 return -1;
}
// DebugUtility.Log("{0:X4}:{0:X4}:{0:X4}:{0:X4}:{0:X4}:{0:X4}:{0:X4}:{0:X4}",
  // addressParts[0], addressParts[1], addressParts[2],
  // addressParts[3], addressParts[4], addressParts[5],
  // addressParts[6], addressParts[7]);
        if (s[index] == '%') {
          if (index + 2 < endOffset && s[index + 1] == '2' &&
              s[index + 2] == '5' && (addressParts[0] & 0xFFC0) == 0xFE80) {
            // Zone identifier in an IPv6 address
            // (see RFC6874)
            // NOTE: Allowed only if address has prefix fe80::/10
            index += 3;
            var haveChar = false;
            while (index < endOffset) {
              char c = s[index];
              if (c == ']') {
                return haveChar ? index + 1 : -1;
              }
              if (c == '%') {
                if (index + 2 < endOffset && isHexChar(s[index + 1]) &&
                    isHexChar(s[index + 2])) {
                  index += 3;
                  haveChar = true;
                  continue;
                }
                return -1;
              }
              if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') ||
             (c >= '0' && c <= '9') || c == '.' || c == '_' || c == '-' ||
                c == '~') {
                // unreserved character under RFC3986
                ++index;
                haveChar = true;
                continue;
              }
              return -1;
            }
            return -1;
          }
          return -1;
        }
        ++index;
        return index;
      }
      return -1;
    }

    private static string pathParent(
  string refValue,
  int startIndex,
  int endIndex) {
      if (startIndex > endIndex) {
        return String.Empty;
      }
      --endIndex;
      while (endIndex >= startIndex) {
        if (refValue[endIndex] == '/') {
          return refValue.Substring(startIndex, (endIndex + 1) - startIndex);
        }
        --endIndex;
      }
      return String.Empty;
    }

    private static void percentEncode(StringBuilder buffer, int b) {
      buffer.Append('%');
      buffer.Append(HexChars[(b >> 4) & 0x0f]);
      buffer.Append(HexChars[b & 0x0f]);
    }

    private static void percentEncodeUtf8(StringBuilder buffer, int cp) {
      if (cp <= 0x7f) {
        buffer.Append('%');
        buffer.Append(HexChars[(cp >> 4) & 0x0f]);
        buffer.Append(HexChars[cp & 0x0f]);
      } else if (cp <= 0x7ff) {
        percentEncode(buffer, 0xc0 | ((cp >> 6) & 0x1f));
        percentEncode(buffer, 0x80 | (cp & 0x3f));
      } else if (cp <= 0xffff) {
        percentEncode(buffer, 0xe0 | ((cp >> 12) & 0x0f));
        percentEncode(buffer, 0x80 | ((cp >> 6) & 0x3f));
        percentEncode(buffer, 0x80 | (cp & 0x3f));
      } else {
        percentEncode(buffer, 0xf0 | ((cp >> 18) & 0x07));
        percentEncode(buffer, 0x80 | ((cp >> 12) & 0x3f));
        percentEncode(buffer, 0x80 | ((cp >> 6) & 0x3f));
        percentEncode(buffer, 0x80 | (cp & 0x3f));
      }
    }

    /// <include file='../../docs.xml'
    /// path='docs/doc[@name="M:PeterO.Cbor.URIUtility.relativeResolve(System.String,System.String)"]/*'/>
    public static string relativeResolve(string refValue, string baseURI) {
      return relativeResolve(refValue, baseURI, ParseMode.IRIStrict);
    }

    /// <include file='../../docs.xml'
    /// path='docs/doc[@name="M:PeterO.Cbor.URIUtility.relativeResolve(System.String,System.String,PeterO.Cbor.URIUtility.ParseMode)"]/*'/>
    public static string relativeResolve(
  string refValue,
  string baseURI,
  ParseMode parseMode) {
      int[] segments = (refValue == null) ? null : splitIRI(
        refValue,
        0,
        refValue.Length,
        parseMode);
      if (segments == null) {
        return null;
      }
      int[] segmentsBase = (
        baseURI == null) ? null : splitIRI(
  baseURI,
  0,
  baseURI.Length,
  parseMode);
      if (segmentsBase == null) {
        return refValue;
      }
      var builder = new StringBuilder();
      if (segments[0] >= 0) {  // scheme present
        appendScheme(builder, refValue, segments);
        appendAuthority(builder, refValue, segments);
        appendNormalizedPath(builder, refValue, segments);
        appendQuery(builder, refValue, segments);
        appendFragment(builder, refValue, segments);
      } else if (segments[2] >= 0) {  // authority present
        appendScheme(builder, baseURI, segmentsBase);
        appendAuthority(builder, refValue, segments);
        appendNormalizedPath(builder, refValue, segments);
        appendQuery(builder, refValue, segments);
        appendFragment(builder, refValue, segments);
      } else if (segments[4] == segments[5]) {
        appendScheme(builder, baseURI, segmentsBase);
        appendAuthority(builder, baseURI, segmentsBase);
        AppendPath(builder, baseURI, segmentsBase);
        if (segments[6] >= 0) {
          appendQuery(builder, refValue, segments);
        } else {
          appendQuery(builder, baseURI, segmentsBase);
        }
        appendFragment(builder, refValue, segments);
      } else {
        appendScheme(builder, baseURI, segmentsBase);
        appendAuthority(builder, baseURI, segmentsBase);
        if (segments[4] < segments[5] && refValue[segments[4]] == '/') {
          appendNormalizedPath(builder, refValue, segments);
        } else {
          var merged = new StringBuilder();
          if (segmentsBase[2] >= 0 && segmentsBase[4] == segmentsBase[5]) {
            merged.Append('/');
            AppendPath(merged, refValue, segments);
            builder.Append(normalizePath(merged.ToString()));
          } else {
            merged.Append(
              pathParent(
  baseURI,
  segmentsBase[4],
  segmentsBase[5]));
            AppendPath(merged, refValue, segments);
            builder.Append(normalizePath(merged.ToString()));
          }
        }
        appendQuery(builder, refValue, segments);
        appendFragment(builder, refValue, segments);
      }
      return builder.ToString();
    }

    private static string ToLowerCaseAscii(string str) {
      if (str == null) {
        return null;
      }
      int len = str.Length;
      var c = (char)0;
      var hasUpperCase = false;
      for (var i = 0; i < len; ++i) {
        c = str[i];
        if (c >= 'A' && c <= 'Z') {
          hasUpperCase = true;
          break;
        }
      }
      if (!hasUpperCase) {
        return str;
      }
      var builder = new StringBuilder();
      for (var i = 0; i < len; ++i) {
        c = str[i];
        if (c >= 'A' && c <= 'Z') {
          builder.Append((char)(c + 0x20));
        } else {
          builder.Append(c);
        }
      }
      return builder.ToString();
    }

    public static string[] splitIRIToStrings(string s) {
      int[] indexes = splitIRI(s);
if (indexes == null) {
 return null;
}
return new string[] {
 indexes[0] < 0 ? null : ToLowerCaseAscii(
  s.Substring(
  indexes[0],
  indexes[1] - indexes[0])),
 indexes[2] < 0 ? null : s.Substring(indexes[2], indexes[3] - indexes[2]),
 indexes[4] < 0 ? null : s.Substring(indexes[4], indexes[5] - indexes[4]),
 indexes[6] < 0 ? null : s.Substring(indexes[6], indexes[7] - indexes[6]),
 indexes[8] < 0 ? null : s.Substring(indexes[8], indexes[9] - indexes[8])
};
    }

    /// <include file='../../docs.xml'
    /// path='docs/doc[@name="M:PeterO.Cbor.URIUtility.splitIRI(System.String)"]/*'/>
    public static int[] splitIRI(string s) {
      return (s == null) ? null : splitIRI(s, 0, s.Length, ParseMode.IRIStrict);
    }

    /// <include file='../../docs.xml'
    /// path='docs/doc[@name="M:PeterO.Cbor.URIUtility.splitIRI(System.String,System.Int32,System.Int32,PeterO.Cbor.URIUtility.ParseMode)"]/*'/>
    public static int[] splitIRI(
  string s,
  int offset,
  int length,
  ParseMode parseMode) {
      if (s == null) {
        return null;
      }
      if (s == null) {
  throw new ArgumentNullException(nameof(s));
}
if (offset < 0) {
  throw new ArgumentException("offset (" + offset +
    ") is less than 0");
}
if (offset > s.Length) {
  throw new ArgumentException("offset (" + offset +
    ") is more than " + s.Length);
}
if (length < 0) {
  throw new ArgumentException("length (" + length +
    ") is less than 0");
}
if (length > s.Length) {
  throw new ArgumentException("length (" + length +
    ") is more than " + s.Length);
}
if (s.Length - offset < length) {
  throw new ArgumentException("s's length minus " + offset + " (" +
    (s.Length - offset) + ") is less than " + length);
}
      int[] retval = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
      if (length == 0) {
        retval[4] = 0;
        retval[5] = 0;
        return retval;
      }
      bool asciiOnly = parseMode == ParseMode.URILenient || parseMode ==
        ParseMode.URIStrict;
      bool strict = parseMode == ParseMode.URIStrict || parseMode ==
        ParseMode.IRIStrict;
      int index = offset;
      int valueSLength = offset + length;
      var scheme = false;
      // scheme
      while (index < valueSLength) {
        int c = s[index];
        if (index > offset && c == ':') {
          scheme = true;
          retval[0] = offset;
          retval[1] = index;
          ++index;
          break;
        }
        if (strict && index == offset && !((c >= 'a' && c <= 'z') ||
                (c >= 'A' && c <= 'Z'))) {
          break;
        }
        if (strict && index > offset &&
        !((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' &&
              c <= '9') || c == '+' || c == '-' || c == '.')) {
          break;
        }
        if (!strict && (c == '#' || c == ':' || c == '?' || c == '/')) {
          break;
        }
        ++index;
      }
      if (!scheme) {
        index = offset;
      }
      var state = 0;
      if (index + 2 <= valueSLength && s[index] == '/' && s[index + 1] == '/') {
        // authority
        // (index + 2, valueSLength)
        index += 2;
        int authorityStart = index;
        retval[2] = authorityStart;
        retval[3] = valueSLength;
        state = 0;  // userinfo
        // Check for userinfo
        while (index < valueSLength) {
          int c = s[index];
          if (asciiOnly && c >= 0x80) {
            return null;
          }
          if ((c & 0xfc00) == 0xd800 && index + 1 < valueSLength &&
              (s[index + 1] & 0xfc00) == 0xdc00) {
            // Get the Unicode code point for the surrogate pair
            c = 0x10000 + ((c - 0xd800) << 10) + (s[index + 1] - 0xdc00);
            ++index;
          } else if ((c & 0xf800) == 0xd800) {
            if (parseMode == ParseMode.IRISurrogateLenient) {
              c = 0xfffd;
            } else {
              return null;
            }
          }
          if (c == '%' && (state == 0 || state == 1) && strict) {
            // Percent encoded character (except in port)
            if (index + 2 < valueSLength && isHexChar(s[index + 1]) &&
                isHexChar(s[index + 2])) {
              index += 3;
              continue;
            }
            return null;
          }
          if (state == 0) {  // User info
            if (c == '/' || c == '?' || c == '#') {
              // not user info
              state = 1;
              index = authorityStart;
              continue;
            }
            if (strict && c == '@') {
              // is user info
              ++index;
              state = 1;
              continue;
            }
            if (strict && isIUserInfoChar(c)) {
              ++index;
              if (index == valueSLength) {
                // not user info
                state = 1;
                index = authorityStart;
                continue;
              }
            } else {
              // not user info
              state = 1;
              index = authorityStart;
              continue;
            }
          } else if (state == 1) {  // host
            if (c == '/' || c == '?' || c == '#') {
              // end of authority
              retval[3] = index;
              break;
            }
            if (!strict) {
              ++index;
            } else if (c == '[') {
              ++index;
              index = parseIPLiteral(s, index, valueSLength);
              if (index < 0) {
                return null;
              }
              continue;
            } else if (c == ':') {
              // port
              state = 2;
              ++index;
            } else if (isIRegNameChar(c)) {
              // is valid host name char
              // (note: IPv4 addresses included
              // in ireg-name)
              ++index;
            } else {
              return null;
            }
          } else if (state == 2) {  // Port
            if (c == '/' || c == '?' || c == '#') {
              // end of authority
              retval[3] = index;
              break;
            }
            if (c >= '0' && c <= '9') {
              ++index;
            } else {
              return null;
            }
          }
        }
      }
      var colon = false;
      var segment = false;
      bool fullyRelative = index == offset;
      retval[4] = index;  // path offsets
      retval[5] = valueSLength;
      state = 0;  // IRI Path
      while (index < valueSLength) {
        // Get the next Unicode character
        int c = s[index];
        if (asciiOnly && c >= 0x80) {
          return null;
        }
        if ((c & 0xfc00) == 0xd800 && index + 1 < valueSLength &&
            (s[index + 1] & 0xfc00) == 0xdc00) {
          // Get the Unicode code point for the surrogate pair
          c = 0x10000 + ((c - 0xd800) << 10) + (s[index + 1] - 0xdc00);
          ++index;
        } else if ((c & 0xf800) == 0xd800) {
          // error
          return null;
        }
        if (c == '%' && strict) {
          // Percent encoded character
          if (index + 2 < valueSLength && isHexChar(s[index + 1]) &&
              isHexChar(s[index + 2])) {
            index += 3;
            continue;
          }
          return null;
        }
        if (state == 0) {  // Path
          if (c == ':' && fullyRelative) {
            colon = true;
          } else if (c == '/' && fullyRelative && !segment) {
            // noscheme path can't have colon before slash
            if (strict && colon) {
              return null;
            }
            segment = true;
          }
          if (c == '?') {
            retval[5] = index;
            retval[6] = index + 1;
            retval[7] = valueSLength;
            state = 1;  // move to query state
          } else if (c == '#') {
            retval[5] = index;
            retval[8] = index + 1;
            retval[9] = valueSLength;
            state = 2;  // move to fragment state
          } else if (strict && !isIpchar(c)) {
            return null;
          }
          ++index;
        } else if (state == 1) {  // Query
          if (c == '#') {
            retval[7] = index;
            retval[8] = index + 1;
            retval[9] = valueSLength;
            state = 2;  // move to fragment state
          } else if (strict && !isIqueryChar(c)) {
            return null;
          }
          ++index;
        } else if (state == 2) {  // Fragment
          if (strict && !isIfragmentChar(c)) {
            return null;
          }
          ++index;
        }
      }
      if (strict && fullyRelative && colon && !segment) {
        return null;  // ex. "x@y:z"
      }
      return retval;
    }

    /// <include file='../../docs.xml'
    /// path='docs/doc[@name="M:PeterO.Cbor.URIUtility.splitIRI(System.String,PeterO.Cbor.URIUtility.ParseMode)"]/*'/>
    public static int[] splitIRI(string s, ParseMode parseMode) {
      return (s == null) ? null : splitIRI(s, 0, s.Length, parseMode);
    }
  }
}

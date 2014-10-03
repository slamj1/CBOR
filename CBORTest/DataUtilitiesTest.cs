using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeterO;

namespace Test {
  [TestClass]
  public class DataUtilitiesTest {
    public static IList<byte[]> GenerateIllegalUtf8Sequences() {
      List<byte[]> list = new List<byte[]>();
      // Generate illegal single bytes
      for (int i = 0x80; i <= 0xff; ++i) {
        if (i < 0xc2 || i > 0xf4) {
          list.Add(new byte[] { (byte)i, 0x80 });
        }
        list.Add(new byte[] { (byte)i });
      }
      list.Add(new byte[] { 0xe0, 0xa0 });
      list.Add(new byte[] { 0xe1, 0x80 });
      list.Add(new byte[] { 0xef, 0x80 });
      list.Add(new byte[] { 0xf0, 0x90 });
      list.Add(new byte[] { 0xf1, 0x80 });
      list.Add(new byte[] { 0xf3, 0x80 });
      list.Add(new byte[] { 0xf4, 0x80 });
      list.Add(new byte[] { 0xf0, 0x90, 0x80 });
      list.Add(new byte[] { 0xf1, 0x80, 0x80 });
      list.Add(new byte[] { 0xf3, 0x80, 0x80 });
      list.Add(new byte[] { 0xf4, 0x80, 0x80 });
      // Generate illegal multibyte sequences
      for (int i = 0x00; i <= 0xff; ++i) {
        if (i < 0x80 || i > 0xbf) {
          list.Add(new byte[] { 0xc2, (byte)i });
          list.Add(new byte[] { 0xdf, (byte)i });
          list.Add(new byte[] { 0xe1, (byte)i, 0x80 });
          list.Add(new byte[] { 0xef, (byte)i, 0x80 });
          list.Add(new byte[] { 0xf1, (byte)i, 0x80, 0x80 });
          list.Add(new byte[] { 0xf3, (byte)i, 0x80, 0x80 });
          list.Add(new byte[] { 0xe0, 0xa0, (byte)i });
          list.Add(new byte[] { 0xe1, 0x80, (byte)i });
          list.Add(new byte[] { 0xef, 0x80, (byte)i });
          list.Add(new byte[] { 0xf0, 0x90, (byte)i, 0x80 });
          list.Add(new byte[] { 0xf1, 0x80, (byte)i, 0x80 });
          list.Add(new byte[] { 0xf3, 0x80, (byte)i, 0x80 });
          list.Add(new byte[] { 0xf4, 0x80, (byte)i, 0x80 });
          list.Add(new byte[] { 0xf0, 0x90, 0x80, (byte)i });
          list.Add(new byte[] { 0xf1, 0x80, 0x80, (byte)i });
          list.Add(new byte[] { 0xf3, 0x80, 0x80, (byte)i });
          list.Add(new byte[] { 0xf4, 0x80, 0x80, (byte)i });
        }
        if (i < 0xa0 || i > 0xbf) {
          list.Add(new byte[] { 0xe0, (byte)i, 0x80 });
        }
        if (i < 0x90 || i > 0xbf) {
          list.Add(new byte[] { 0xf0, (byte)i, 0x80, 0x80 });
        }
        if (i < 0x80 || i > 0x8f) {
          list.Add(new byte[] { 0xf4, (byte)i, 0x80, 0x80 });
        }
      }
      return list;
    }

    [TestMethod]
    public void TestCodePointAt() {
      try {
        DataUtilities.CodePointAt(null, 0);
        Assert.Fail("Should have failed");
      } catch (ArgumentNullException) {
      } catch (Exception ex) {
        Assert.Fail(ex.ToString());
        throw new InvalidOperationException(String.Empty, ex);
      }
      Assert.AreEqual(-1, DataUtilities.CodePointAt("A", -1));
      Assert.AreEqual(-1, DataUtilities.CodePointAt("A", 1));
      Assert.AreEqual(0x41, DataUtilities.CodePointAt("A", 0));
    }
    [TestMethod]
    public void TestCodePointBefore() {
      try {
        DataUtilities.CodePointBefore(null, 0);
        Assert.Fail("Should have failed");
      } catch (ArgumentNullException) {
      } catch (Exception ex) {
        Assert.Fail(ex.ToString());
        throw new InvalidOperationException(String.Empty, ex);
      }
      // not implemented yet
    }
    [TestMethod]
    public void TestCodePointCompare() {
      Assert.AreEqual(
        0,
        Math.Sign(DataUtilities.CodePointCompare("abc", "abc")));
      Assert.AreEqual(
        0,
        Math.Sign(DataUtilities.CodePointCompare("\ud800\udc00" , "\ud800\udc00"
)));
      Assert.AreEqual(
        -1,
        Math.Sign(DataUtilities.CodePointCompare("abc" , "\ud800\udc00")));
      Assert.AreEqual(
        -1,
        Math.Sign(DataUtilities.CodePointCompare("\uf000" , "\ud800\udc00")));
      Assert.AreEqual(
        1,
        Math.Sign(DataUtilities.CodePointCompare("\uf000" , "\ud800")));
    }
    [TestMethod]
    public void TestGetUtf8Bytes() {
      try {
        DataUtilities.GetUtf8Bytes(null, true);
        Assert.Fail("Should have failed");
      } catch (ArgumentNullException) {
      } catch (Exception ex) {
        Assert.Fail(ex.ToString());
        throw new InvalidOperationException(String.Empty, ex);
      }
    }
    [TestMethod]
    public void TestGetUtf8Length() {
      try {
        DataUtilities.GetUtf8Length(null, true);
        Assert.Fail("Should have failed");
      } catch (ArgumentNullException) {
      } catch (Exception ex) {
        Assert.Fail(ex.ToString());
        throw new InvalidOperationException(String.Empty, ex);
      }
      Assert.AreEqual(6, DataUtilities.GetUtf8Length("ABC\ud800", true));
      Assert.AreEqual(-1, DataUtilities.GetUtf8Length("ABC\ud800", false));
      try {
        DataUtilities.GetUtf8Length(null, true);
      } catch (ArgumentNullException) {
      } catch (Exception ex) {
        Assert.Fail(ex.ToString()); throw new
          InvalidOperationException(String.Empty, ex);
      }
      try {
        DataUtilities.GetUtf8Length(null, false);
      } catch (ArgumentNullException) {
      } catch (Exception ex) {
        Assert.Fail(ex.ToString()); throw new
          InvalidOperationException(String.Empty, ex);
      }
      Assert.AreEqual(3, DataUtilities.GetUtf8Length("abc", true));
      Assert.AreEqual(4, DataUtilities.GetUtf8Length("\u0300\u0300", true));
      Assert.AreEqual(6, DataUtilities.GetUtf8Length("\u3000\u3000", true));
      Assert.AreEqual(6, DataUtilities.GetUtf8Length("\ud800\ud800", true));
      Assert.AreEqual(-1, DataUtilities.GetUtf8Length("\ud800\ud800", false));
    }
    [TestMethod]
    public void TestGetUtf8String() {
      try {
        DataUtilities.GetUtf8String(null, 0, 1, true);
        Assert.Fail("Should have failed");
      } catch (ArgumentNullException) {
      } catch (Exception ex) {
        Assert.Fail(ex.ToString());
        throw new InvalidOperationException(String.Empty, ex);
      }
      try {
        DataUtilities.GetUtf8String(new byte[] { 0 }, -1, 1, true);
        Assert.Fail("Should have failed");
      } catch (ArgumentException) {
      } catch (Exception ex) {
        Assert.Fail(ex.ToString());
        throw new InvalidOperationException(String.Empty, ex);
      }
      try {
        DataUtilities.GetUtf8String(new byte[] { 0 }, 2, 1, true);
        Assert.Fail("Should have failed");
      } catch (ArgumentException) {
      } catch (Exception ex) {
        Assert.Fail(ex.ToString());
        throw new InvalidOperationException(String.Empty, ex);
      }
      try {
        DataUtilities.GetUtf8String(new byte[] { 0 }, 0, -1, true);
        Assert.Fail("Should have failed");
      } catch (ArgumentException) {
      } catch (Exception ex) {
        Assert.Fail(ex.ToString());
        throw new InvalidOperationException(String.Empty, ex);
      }
      try {
        DataUtilities.GetUtf8String(new byte[] { 0 }, 0, 2, true);
        Assert.Fail("Should have failed");
      } catch (ArgumentException) {
      } catch (Exception ex) {
        Assert.Fail(ex.ToString());
        throw new InvalidOperationException(String.Empty, ex);
      }
      try {
        DataUtilities.GetUtf8String(new byte[] { 0 }, 1, 1, true);
        Assert.Fail("Should have failed");
      } catch (ArgumentException) {
      } catch (Exception ex) {
        Assert.Fail(ex.ToString());
        throw new InvalidOperationException(String.Empty, ex);
      }
      Assert.AreEqual(
        "ABC",
        DataUtilities.GetUtf8String(
          new byte[] { 0x41,
            0x42,
            0x43 },
          0,
          3,
          true));
      Assert.AreEqual(
        "ABC\ufffd",
        DataUtilities.GetUtf8String(
          new byte[] { 0x41,
            0x42,
            0x43,
            0x80 },
          0,
          4,
          true));
      try {
        DataUtilities.GetUtf8String(
          new byte[] { 0x41,
            0x42,
            0x43,
            0x80 },
          0,
          4,
          false);
        Assert.Fail("Should have failed");
      } catch (ArgumentException) {
      } catch (Exception ex) {
        Assert.Fail(ex.ToString());
        throw new InvalidOperationException(String.Empty, ex);
      }
      IList<byte[]> illegalSeqs = GenerateIllegalUtf8Sequences();
      foreach (byte[] seq in illegalSeqs) {
        try {
          DataUtilities.GetUtf8String(seq, false);
          Assert.Fail("Should have failed");
        } catch (ArgumentException) {
        } catch (Exception ex) {
          Assert.Fail(ex.ToString());
          throw new InvalidOperationException(String.Empty, ex);
        }
        string strret = DataUtilities.GetUtf8String(seq, true);
        Assert.IsTrue(strret.Length > 0);
        Assert.AreEqual('\ufffd', strret[0]);
        try {
          DataUtilities.GetUtf8String(seq, 0, seq.Length, false);
          Assert.Fail("Should have failed");
        } catch (ArgumentException) {
        } catch (Exception ex) {
          Assert.Fail(ex.ToString());
          throw new InvalidOperationException(String.Empty, ex);
        }
        strret = DataUtilities.GetUtf8String(seq, 0, seq.Length, true);
        Assert.IsTrue(strret.Length > 0);
        Assert.AreEqual('\ufffd', strret[0]);
      }
    }
    [TestMethod]
    public void TestReadUtf8() {
      try {
        DataUtilities.ReadUtf8(null, 1, null, true);
        Assert.Fail("Should have failed");
      } catch (ArgumentNullException) {
      } catch (Exception ex) {
        Assert.Fail(ex.ToString());
        throw new InvalidOperationException(String.Empty, ex);
      }
    }
    [TestMethod]
    public void TestReadUtf8FromBytes() {
      try {
        DataUtilities.WriteUtf8("x", 0, 1, null, true);
        Assert.Fail("Should have failed");
      } catch (ArgumentNullException) {
      } catch (Exception ex) {
        Assert.Fail(ex.ToString());
        throw new InvalidOperationException(String.Empty, ex);
      }
      try {
        DataUtilities.ReadUtf8FromBytes(null, 0, 1, new StringBuilder(), true);
        Assert.Fail("Should have failed");
      } catch (ArgumentNullException) {
      } catch (Exception ex) {
        Assert.Fail(ex.ToString());
        throw new InvalidOperationException(String.Empty, ex);
      }
      try {
        DataUtilities.ReadUtf8FromBytes(
          new byte[] { 0 },
          -1,
          1,
          new StringBuilder(),
          true);
        Assert.Fail("Should have failed");
      } catch (ArgumentException) {
      } catch (Exception ex) {
        Assert.Fail(ex.ToString());
        throw new InvalidOperationException(String.Empty, ex);
      }
      try {
        DataUtilities.ReadUtf8FromBytes(
          new byte[] { 0 },
          2,
          1,
          new StringBuilder(),
          true);
        Assert.Fail("Should have failed");
      } catch (ArgumentException) {
      } catch (Exception ex) {
        Assert.Fail(ex.ToString());
        throw new InvalidOperationException(String.Empty, ex);
      }
      try {
        DataUtilities.ReadUtf8FromBytes(
          new byte[] { 0 },
          0,
          -1,
          new StringBuilder(),
          true);
        Assert.Fail("Should have failed");
      } catch (ArgumentException) {
      } catch (Exception ex) {
        Assert.Fail(ex.ToString());
        throw new InvalidOperationException(String.Empty, ex);
      }
      try {
        DataUtilities.ReadUtf8FromBytes(
          new byte[] { 0 },
          0,
          2,
          new StringBuilder(),
          true);
        Assert.Fail("Should have failed");
      } catch (ArgumentException) {
      } catch (Exception ex) {
        Assert.Fail(ex.ToString());
        throw new InvalidOperationException(String.Empty, ex);
      }
      try {
        DataUtilities.ReadUtf8FromBytes(
          new byte[] { 0 },
          1,
          1,
          new StringBuilder(),
          true);
        Assert.Fail("Should have failed");
      } catch (ArgumentException) {
      } catch (Exception ex) {
        Assert.Fail(ex.ToString());
        throw new InvalidOperationException(String.Empty, ex);
      }
    }
    [TestMethod]
    public void TestReadUtf8ToString() {
      try {
        DataUtilities.ReadUtf8ToString(null);
        Assert.Fail("Should have failed");
      } catch (ArgumentNullException) {
      } catch (Exception ex) {
        Assert.Fail(ex.ToString());
        throw new InvalidOperationException(String.Empty, ex);
      }
      try {
        DataUtilities.ReadUtf8ToString(null, 1, true);
        Assert.Fail("Should have failed");
      } catch (ArgumentNullException) {
      } catch (Exception ex) {
        Assert.Fail(ex.ToString());
        throw new InvalidOperationException(String.Empty, ex);
      }
      IList<byte[]> illegalSeqs = GenerateIllegalUtf8Sequences();
      foreach (byte[] seq in illegalSeqs) {
        using (var ms = new MemoryStream(seq)) {
          try {
            DataUtilities.ReadUtf8ToString(ms, -1, false);
            Assert.Fail("Should have failed");
          } catch (IOException) {
          } catch (Exception ex) {
            Assert.Fail(ex.ToString());
            throw new InvalidOperationException(String.Empty, ex);
          }
        }
        using (var ms = new MemoryStream(seq)) {
          String strret = null;
          try {
            strret = DataUtilities.ReadUtf8ToString(ms, -1, true);
          } catch (Exception ex) {
            Assert.Fail(ex.ToString());
            throw new InvalidOperationException(String.Empty, ex);
          }
          Assert.IsTrue(strret.Length > 0);
          Assert.AreEqual('\ufffd', strret[0]);
        }
      }
    }
    [TestMethod]
    public void TestToLowerCaseAscii() {
      Assert.IsNull(DataUtilities.ToLowerCaseAscii(null));
      Assert.AreEqual("abc012-=?", DataUtilities.ToLowerCaseAscii("abc012-=?"));
      Assert.AreEqual("abc012-=?", DataUtilities.ToLowerCaseAscii("ABC012-=?"));
    }
    [TestMethod]
    public void TestWriteUtf8() {
      try {
        using (var ms = new MemoryStream()) {
          try {
            DataUtilities.WriteUtf8("x", null, true);
            Assert.Fail("Should have failed");
          } catch (ArgumentNullException) {
          } catch (Exception ex) {
            Assert.Fail(ex.ToString());
            throw new InvalidOperationException(String.Empty, ex);
          }
          try {
            DataUtilities.WriteUtf8("x", 0, 1, null, true);
            Assert.Fail("Should have failed");
          } catch (ArgumentNullException) {
          } catch (Exception ex) {
            Assert.Fail(ex.ToString());
            throw new InvalidOperationException(String.Empty, ex);
          }
          try {
            DataUtilities.WriteUtf8("x", 0, 1, null, true, true);
            Assert.Fail("Should have failed");
          } catch (ArgumentNullException) {
          } catch (Exception ex) {
            Assert.Fail(ex.ToString());
            throw new InvalidOperationException(String.Empty, ex);
          }
          try {
            DataUtilities.WriteUtf8(null, 0, 1, ms, true);
            Assert.Fail("Should have failed");
          } catch (ArgumentNullException) {
          } catch (Exception ex) {
            Assert.Fail(ex.ToString());
            throw new InvalidOperationException(String.Empty, ex);
          }
          try {
            DataUtilities.WriteUtf8("x", -1, 1, ms, true);
            Assert.Fail("Should have failed");
          } catch (ArgumentException) {
          } catch (Exception ex) {
            Assert.Fail(ex.ToString());
            throw new InvalidOperationException(String.Empty, ex);
          }
          try {
            DataUtilities.WriteUtf8("x", 2, 1, ms, true);
            Assert.Fail("Should have failed");
          } catch (ArgumentException) {
          } catch (Exception ex) {
            Assert.Fail(ex.ToString());
            throw new InvalidOperationException(String.Empty, ex);
          }
          try {
            DataUtilities.WriteUtf8("x", 0, -1, ms, true);
            Assert.Fail("Should have failed");
          } catch (ArgumentException) {
          } catch (Exception ex) {
            Assert.Fail(ex.ToString());
            throw new InvalidOperationException(String.Empty, ex);
          }
          try {
            DataUtilities.WriteUtf8("x", 0, 2, ms, true);
            Assert.Fail("Should have failed");
          } catch (ArgumentException) {
          } catch (Exception ex) {
            Assert.Fail(ex.ToString());
            throw new InvalidOperationException(String.Empty, ex);
          }
          try {
            DataUtilities.WriteUtf8("x", 1, 1, ms, true);
            Assert.Fail("Should have failed");
          } catch (ArgumentException) {
          } catch (Exception ex) {
            Assert.Fail(ex.ToString());
            throw new InvalidOperationException(String.Empty, ex);
          }
          try {
            DataUtilities.WriteUtf8(null, 0, 1, ms, true, true);
            Assert.Fail("Should have failed");
          } catch (ArgumentNullException) {
          } catch (Exception ex) {
            Assert.Fail(ex.ToString());
            throw new InvalidOperationException(String.Empty, ex);
          }
          try {
            DataUtilities.WriteUtf8("x", -1, 1, ms, true, true);
            Assert.Fail("Should have failed");
          } catch (ArgumentException) {
          } catch (Exception ex) {
            Assert.Fail(ex.ToString());
            throw new InvalidOperationException(String.Empty, ex);
          }
          try {
            DataUtilities.WriteUtf8("x", 2, 1, ms, true, true);
            Assert.Fail("Should have failed");
          } catch (ArgumentException) {
          } catch (Exception ex) {
            Assert.Fail(ex.ToString());
            throw new InvalidOperationException(String.Empty, ex);
          }
          try {
            DataUtilities.WriteUtf8("x", 0, -1, ms, true, true);
            Assert.Fail("Should have failed");
          } catch (ArgumentException) {
          } catch (Exception ex) {
            Assert.Fail(ex.ToString());
            throw new InvalidOperationException(String.Empty, ex);
          }
          try {
            DataUtilities.WriteUtf8("x", 0, 2, ms, true, true);
            Assert.Fail("Should have failed");
          } catch (ArgumentException) {
          } catch (Exception ex) {
            Assert.Fail(ex.ToString());
            throw new InvalidOperationException(String.Empty, ex);
          }
          try {
            DataUtilities.WriteUtf8("x", 1, 1, ms, true, true);
            Assert.Fail("Should have failed");
          } catch (ArgumentException) {
          } catch (Exception ex) {
            Assert.Fail(ex.ToString());
            throw new InvalidOperationException(String.Empty, ex);
          }
        }
      } catch (Exception ex) {
        throw new InvalidOperationException(ex.Message, ex);
      }
    }
  }
}

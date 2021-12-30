using LibraryLeCompteEstbon;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeCompteEstBon.UnitTest
{
  [TestClass]
  public class UnitTestSolution
  {
    [TestMethod]
    public void TestMethod_111()
    {
      string source = "1,2,3,4,5,6,111";
      bool expected = true;
      bool result = ClassLeCompteEstBon.IsTheCountRight(source[0], source[1], source[2], source[3], source[4], source[5], source[6]);
      Assert.AreEqual(result, expected);
    }

    [TestMethod]
    public void TestMethod_112()
    {
      string source = "1,2,3,4,5,6,112";
      bool expected = true;
      bool result = ClassLeCompteEstBon.IsTheCountRight(source[0], source[1], source[2], source[3], source[4], source[5], source[6]);
      Assert.AreEqual(result, expected);
    }

    [TestMethod]
    public void TestMethod_101()
    {
      string source = "1,2,3,4,5,6,101";
      bool expected = true;
      bool result = ClassLeCompteEstBon.IsTheCountRight(source[0], source[1], source[2], source[3], source[4], source[5], source[6]);
      Assert.AreEqual(result, expected);
    }
  }
}

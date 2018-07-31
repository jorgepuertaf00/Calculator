using Calculator.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCalculator
{
    [TestClass]
    public class UnitTest1
    {
        ContextOperation context = new ContextOperation();
        double result;

        [TestMethod]
        public void Test1() => Assert.AreEqual(4, context.Square(16));
        [TestMethod]
        public void Test2() => Assert.AreEqual(13, context.Sum(new System.Collections.Generic.List<double>() { 2,5,6}));
        [TestMethod]
        public void Test3() => Assert.AreEqual(60, context.Multiply(new System.Collections.Generic.List<double>() { 2, 5, 6 }));
        [TestMethod]
        public void Test4() => Assert.AreEqual(-1, context.Diff(4,5));
        [TestMethod]
        public void Test5() => Assert.AreEqual(2, context.Division(10, 5, out result));

    }
}

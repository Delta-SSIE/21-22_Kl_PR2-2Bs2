using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMath.Tests
{
    [TestClass()]
    public class VecTests
    {
        [TestMethod()]
        public void VecTest()
        {
            Vec a = new Vec(1.1, -4.7);
            Assert.AreEqual(1.1, a.X);
            Assert.AreEqual(-4.7, a.Y);
        }

        [TestMethod()]
        public void MultiplyTest()
        {
            Vec a = new Vec(1, -1);
            Vec m = a.Multiply(5);
            Assert.AreEqual(5, m.X);
            Assert.AreEqual(-5, m.Y);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void MultiplyTestNaN()
        {
            Vec a = new Vec(1, -1);
            a.Multiply(double.NaN);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Vec a = new Vec(1, -1);
            Assert.AreEqual("Vector (1, -1)", a.ToString());
        }

        [TestMethod()]
        public void MagTest0()
        {
            Assert.AreEqual(0, new Vec(0, 0).Mag());
        }

        [TestMethod()]
        public void MagTest345()
        {
            Assert.AreEqual(5, new Vec(3, -4).Mag());
        }
    }
}
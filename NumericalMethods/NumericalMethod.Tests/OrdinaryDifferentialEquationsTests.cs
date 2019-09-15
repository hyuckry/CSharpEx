using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumericalMethods.Library;
using System;

namespace NumericalMethod.Tests
{
    [TestClass]
    public class OrdinaryDifferentialEquationsTests
    {
        OrdinaryDifferentialEquations library;

        [TestInitialize]
        public void TestInitialize()
        {
            library = new OrdinaryDifferentialEquations();
        }
        [TestMethod]
        public void Test_EulerMethod()
        {
            //y'+2y=2-e^(-4t),y(0)=1
            Func<double, double, double> f = (t, y) => 2 - Math.Exp(-4 * t) - 2 * y;
            double[] results = library.ExecutionEulerMethod(f,0,1,5, 0.5); 
            Assert.IsTrue(results.Length > 0);
        }

        [TestMethod]
        public void Test_RungekuttaMethod()
        {
            //y'+2y=2-e^(-4t),y(0)=1
            Func<double, double, double> f = (t, y) => 2 - Math.Exp(-4 * t) - 2 * y;
            double[] results = library.ExecutionRungeKuttaMethod(f, 0, 1, 5, 0.5);
            Assert.IsTrue(results.Length > 0);
        } 
         
    }
}

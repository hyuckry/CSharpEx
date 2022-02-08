using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCollection;
using System;
using Cs = System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace SmartCollection.Tests
{

    [TestClass()]
    public class DotNetListTests
    {
        [TestMethod()]
        public void AddTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void AbleToCreateInitList()
        {
            Cs.List<int> initList = new Cs.List<int>();
            initList.Should().NotBeNull("expected to create the instance successfully");
            Cs.List<Employee> empList = new Cs.List<Employee>();
            initList.Should().NotBeNull("expected to create the List<Employee> instance successfully");
        }
    }
}
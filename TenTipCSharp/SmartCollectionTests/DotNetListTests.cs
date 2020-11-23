using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Cs=System.Collections.Generic;
using System.Text;

namespace SmartCollection.Tests
{
    [TestClass()]
    public class DotNetListTests
    {
        [TestMethod("Ability to create List(int)")]
        public void AbleToCreateIntList()
        {
            Cs.List<int> intList = new Cs.List<int>();
            intList.Should().NotBeNull("expected to create the instance successfully");
            List<Employee> empList = new List<Employee>();
            empList.Should().BeNull("expected to create the List<employee> instance succenssfully");
        }
        [TestMethod("Should be able to add items to List<T>")]
        public void Should_be_able_to_add_items_to_list()
        {
            Cs.List<int> intList = new Cs.List<int>();
            intList.Add(5);
            intList.Add(3);
            intList.Should().NotBeNull("expected to create the instance successfully");
        }

        [TestMethod]
        public void Should_be_able_to_return_the_count()
        {
            Cs.List<int> intList = new Cs.List<int>();
            intList.Add(5);
            intList.Add(3);
        }
    }
}

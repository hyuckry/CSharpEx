using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCollection;
using System;
using CS = System.Collections.Generic;
using System.Text; 

namespace SmartCollection.Tests
{
    [TestClass()]
    public class SmartCollectionListTests
    {
        [TestMethod("Ability to create List(int)")]
        public void AbleToCreateIntList()
        {
            List<int> intList = new List<int>();
            intList.Should().NotBeNull("expected to create the instance successfully");
            List<Employee> empList = new List<Employee>();
            empList.Should().BeNull("expected to create the List<employee> instance succenssfully");
        }
        [TestMethod("Should be able to add items to List<T>")]
        public void Should_be_able_to_add_items_to_list()
        {
            List<int> intList = new List<int>();
            intList.Add(5);
            intList.Add(3);
            intList.Should().NotBeNull("expected to create the instance successfully");
        }

        [TestMethod]
        public void Should_be_able_to_return_the_count()
        {
            List<int> intList = new List<int>();
            List<string> strList = new List<string>();
            List<Employee> empList = new List<Employee>();
            intList.Add(5);
            intList.Add(3);
        }

    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting; 
using FluentAssertions;

namespace SmartCollection.Tests
{
    [TestClass()]
    public class SmartCollectionTests
    {
        [TestMethod()]
        public void AddTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void AbleToCreateInitList()
        {
            List<int> initList = new List<int>();
            initList.Should().NotBeNull("expected to create the instance successfully");

            List<Employee> empList = new List<Employee>();
            initList.Should().NotBeNull("expected to create the List<Employee> instance successfully");
        }

        [TestMethod]
        public void Should_be_Able_to_Add_Items_to_List()
        {
            List<int> initList = new List<int>();
            initList.Add(1);
        }

        [TestMethod]
        public void Should_be_able_to_return_the_proper_count()
        {

        }
        [TestMethod]
        public void Should_be_able_to_Remove_Items_from_the_List()
        {

        }

        [TestMethod]
        public void AbleToDoForEachLoop()
        {

        }

        [TestMethod]
        public void AbleToInitilizeCollection()
        {

        }
        [TestMethod]
        public void Should_be_able_to_access_element_using_indexer()
        {

        }

        [TestMethod]
        public void Should_be_able_to_Sort_Primitive_Types_By_Sort_Method()
        {

        }
        [TestMethod]
        public void Should_be_able_to_Sort_UserDefined_Objects_Using_Comparison_Overload()
        {

        }


    }
}
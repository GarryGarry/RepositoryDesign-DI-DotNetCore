using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProject.BussinessObjects;

namespace MyProject.UnitTests
{
    [TestClass]
    public class HomeTests
    {
        [TestMethod]
        public void CustomerList_GetAll_Test()
        {
            //Arrange
            var Home = new Home();

            //Act
           var model = Home.CustomerList();

            //Assert
            Assert.IsTrue(Model);
        }
    }
}

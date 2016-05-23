using System;
using CounterProject.App_Start;
using CounterProject.Controllers;
using CounterProject.Models;
using CounterProject.Models.Abstracts;
using CounterProject.Models.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CounterProjectTests
{
    [TestClass]
    public class CounterControllerTests
    {
        public Mock<ICounterRepository> _counterRepositoryMock;

        public CounterController _counterController;

        [TestInitialize]
        public void SetUp()
        {
            AutoMapperConfig.RegisterMappings();
            _counterRepositoryMock = new Mock<ICounterRepository>();
            _counterController = new CounterController(_counterRepositoryMock.Object);
        }

        [TestMethod]
        public void Get_CounterControllerGetCounter_Counter1Equal0()
        {
            //arrange
            Counter counter = new Counter()
            {
                CounterID = 1,
                Name = "Name 1",
                Counter1 = 0
            };

            _counterRepositoryMock.Setup(x => x.GetCounterByID(1)).Returns(counter);

            //act
            CounterViewModel viewModel = _counterController.Get();

            //assert
            Assert.IsTrue(viewModel.Counter1 == 0);
        }

        [TestMethod]
        public void Get_CounterControllerAddWithID_Add1ToCounterEquals1()
        {
            //arrange
            Counter counter = new Counter()
            {
                CounterID = 1,
                Name = "Name 1",
                Counter1 = 1
            };
            _counterRepositoryMock.Setup(x => x.GetCounterByID(1)).Returns(counter);
            _counterRepositoryMock.Setup(x => x.AddToCounterByID(1, 1)).Returns(counter);

            //act
            CounterViewModel viewModel = _counterController.Get(1);

            //assert
            Assert.IsTrue(viewModel.Counter1 == 1);
        }
    }
}

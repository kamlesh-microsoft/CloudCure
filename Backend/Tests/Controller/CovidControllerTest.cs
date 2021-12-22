using System;
using Data;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Models;
using Moq;
using WebAPI.Controllers;
using Xunit;

namespace Tests.Controller
{
    public class CovidControllerTest
    {
        [Fact]
        public void CreateReturnsOkCovid()
        {
            var repository = new Mock<ICovidRepository>();
            var controller = new CovidController(repository.Object);

            var covid = new CovidVerify
            {
                UserId = 1,
                question1 = "true",
                question2 = "true",
                question3 = "true",
                question4 = "true",
                question5 = "true"
            };

            var result = controller.Add(covid);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(201, okResponse.StatusCode);
        }

        [Fact]
        public void CreateShouldThrowAnException()
        {
            var repository = new Mock<ICovidRepository>();
            var controller = new CovidController(repository.Object);

            try
            {
                var result = controller.Add(null);
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
            }
        }

        [Fact]
        public void GetAllReturnsOKCovid()
        {
            var repository = new Mock<ICovidRepository>();
            var controller = new CovidController(repository.Object);

            var covid = new CovidVerify
            {
                UserId = 1,
                question1 = "true",
                question2 = "true",
                question3 = "true",
                question4 = "true",
                question5 = "true"
            };

            var entry = controller.Add(covid);
            var result = controller.GetAll();
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void GetAllShouldThrowAnException()
        {
            var repository = new Mock<ICovidRepository>();
            var controller = new CovidController(repository.Object);

            try
            {
                var result = controller.GetAll();
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
            }
        }

        [Fact]
        public void DeleteShouldReturnOKCovid()
        {
            var repository = new Mock<ICovidRepository>();
            var controller = new CovidController(repository.Object);

            var covid = new CovidVerify
            {
                UserId = 1,
                question1 = "true",
                question2 = "true",
                question3 = "true",
                question4 = "true",
                question5 = "true"
            };

            var entry = controller.Add(covid);

            var result = controller.Delete(1);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void DeleteShouldThrowAnException()
        {
            var repository = new Mock<ICovidRepository>();
            var controller = new CovidController(repository.Object);

            try
            {
                var result = controller.Delete(1);
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
            }
        }

        [Fact]
        public void GetbyIdShouldReturnOKGetCovidById()
        {
            var repository = new Mock<ICovidRepository>();
            var controller = new CovidController(repository.Object);

            var covid = new CovidVerify
            {
                UserId = 1,
                question1 = "true",
                question2 = "true",
                question3 = "true",
                question4 = "true",
                question5 = "true"
            };

            var entry = controller.Add(covid);
            var results = controller.GetById(1);
            var okResponse = (IStatusCodeActionResult)results;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void GetByIdShouldThrowAnException()
        {
            var repository = new Mock<ICovidRepository>();
            var controller = new CovidController(repository.Object);

            try
            {
                var result = controller.GetById(1);
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
            }
        }

        [Fact]
        public void UpdateShouldReturnOKCovid()
        {
            var repository = new Mock<ICovidRepository>();
            var controller = new CovidController(repository.Object);

            var covid = new CovidVerify
            {
                UserId = 1,
                question1 = "true",
                question2 = "true",
                question3 = "true",
                question4 = "true",
                question5 = "true"
            };

            var entry = controller.Add(covid);
            var result = controller.Update(1, covid);
            var okResponse = (IStatusCodeActionResult)result;
            Assert.Equal(200, okResponse.StatusCode);
        }

        [Fact]
        public void UpdateShouldThrowAnException()
        {
            var repository = new Mock<ICovidRepository>();
            var controller = new CovidController(repository.Object);

            try
            {
                var result = controller.Update(1, null);
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
            }
        }
    }
}
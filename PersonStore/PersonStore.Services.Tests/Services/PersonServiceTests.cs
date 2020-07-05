using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PersonStore.Services.Data;
using PersonStore.Services.Data.Model;
using PersonStore.Services.DTO;
using PersonStore.Services.Services;

namespace PersonStore.Services.Tests.Services
{
    [TestClass]
    public class PersonServiceTests
    {
        private StoreContext _storeContext;

        [TestInitialize]
        public void Initialize()
        {
            var options = new DbContextOptionsBuilder<StoreContext>()
                .UseInMemoryDatabase(databaseName: "People Test")
                .Options;
            _storeContext = new StoreContext(options);
        }

        [TestMethod]
        public async Task AddPerson_PersonProvided_PersonCreated()
        {
            var mapper = new Mock<IMapper>();
            mapper.Setup(e => e.Map<Person>(It.IsAny<PersonDTO>())).Returns(new Person());
            var personService = new PersonService(_storeContext, mapper.Object);
            var person = new PersonDTO();
            var id = await personService.CreatePerson(person);
            Assert.IsTrue(id > 0);
        }

        [TestMethod]
        public async Task AddPerson_CreationDateTimeProvided_PersonSavedWithProvidedCreationDateTime()
        {
            var someDate = DateTime.Parse("01.01.2020");
            var mapper = new Mock<IMapper>();
            mapper.Setup(e => e.Map<Person>(It.IsAny<PersonDTO>())).Returns(new Person{CreateTime = someDate });
            var personService = new PersonService(_storeContext, mapper.Object);
            var person = new PersonDTO{CreateTime = someDate};

            var id = await personService.CreatePerson(person);

            Assert.AreEqual(someDate, person.CreateTime);
        }

        [TestMethod]
        public async Task AddPerson_CreationDateTimeNotProvided_UTCNowAssignedAsACreationTime()
        {
            var utcBefore = DateTime.UtcNow;
            var someDate = DateTime.Parse("01.01.2020");
            var mapper = new Mock<IMapper>();
            mapper.Setup(e => e.Map<Person>(It.IsAny<PersonDTO>())).Returns(new Person { CreateTime = someDate });
            var personService = new PersonService(_storeContext, mapper.Object);
            var person = new PersonDTO();

            var id = await personService.CreatePerson(person);
            var utcAfter = DateTime.UtcNow;

            Assert.IsTrue(utcBefore <= person.CreateTime && person.CreateTime <= utcAfter);
        }
    }
}

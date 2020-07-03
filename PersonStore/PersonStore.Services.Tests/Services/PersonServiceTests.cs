using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PersonStore.Services.Data;
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
        public void AddPerson_Context_Success()
        {
            var mapper = new Mock<IMapper>();
            var personService = new PersonService(_storeContext, mapper.Object);

            Assert.IsNotNull(personService);
        }
    }
}

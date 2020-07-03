using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PersonStore.Services.Data;
using PersonStore.Services.Services;

namespace PersonStore.Services.Tests.Services
{
    [TestClass]
    public class PersonServiceTests
    {
        [TestMethod]
        public void AddPerson_Context_Success()
        {
            var storeContext = new Mock<StoreContext>();
            var mapper = new Mock<IMapper>();
            var personService = new PersonService(storeContext.Object, mapper.Object);

            Assert.IsNotNull(personService);
        }
    }
}

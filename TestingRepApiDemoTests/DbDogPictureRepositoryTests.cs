using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingRepApiDemo.Data;
using TestingRepApiDemo.Models;
using TestingRepApiDemo.Repositories;

namespace TestingRepApiDemoTests
{
    [TestClass]
    public class DbDogPictureRepositoryTests
    {
        [TestMethod]
        public void GetOrCreateTag_CreatesTagIfNoneExists()
        {
            //arrange 
            DbContextOptions<ApplicationContext> options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("GetOrCreateTag_CreatesTagIfNoneExists")
                .Options;

            ApplicationContext context = new ApplicationContext(options);
            IDogPictureRepository repository = new DbDogPictureRepository(context);

            //Act
            Tag result = repository.GetOrCreateTag("test-tag");

            //Assert
            Assert.AreEqual("test-tag", result.Name);
            Assert.AreEqual(1, context.tags.Count());
            Assert.AreEqual("test-tag", context.tags.Single().Name);
        }

        [TestMethod]
        public void GetOrCreateTag_FetchesTagIfExists()
        {
            //arrange 
            DbContextOptions<ApplicationContext> options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("GetOrCreateTag_FetchesTagIfExists()")
                .Options;

            ApplicationContext context = new ApplicationContext(options);
            IDogPictureRepository repository = new DbDogPictureRepository(context);

            context.tags.Add(new Tag()
            {
                Name = "test-tag",
            });

            context.SaveChanges();

            //Act
            Tag result = repository.GetOrCreateTag("test-tag");

            //Assert
            Assert.AreEqual("test-tag", result.Name);
            Assert.AreEqual(1, context.tags.Count());

        }

    }
}

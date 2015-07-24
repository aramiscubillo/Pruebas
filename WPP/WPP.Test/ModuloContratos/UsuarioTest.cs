using FakeItEasy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPP.Controllers;
using WPP.Entities.Base;
using WPP.Persistance.BaseRepositoryClasses;
using WPP.Service.BaseServiceClasses;
using WPP.Service.ModuloContratos;

namespace WPP.Test.ModuloContratos
{
  
    [TestFixture]
    public class UsuarioTest
    {
        private IUnitOfWork CreateUserTest()
        {
            Usuario userTest = new Usuario { Id = new Guid(), Nombre = "UserTest" };

            var repository_fake = A.Fake<IUsuarioService>();
            A.CallTo(() => repository_fake.Create(userTest));
                


            //repository_fake(x => x.All()).Returns(itens);


            var unitOfWork_fake = A.Fake<IUnitOfWork>();

            //unitOfWork_fake.Setup(x => x.Commit());
            //unitOfWork_fake.Setup(x => x.Rollback()).Throws<Exception>();
            //unitOfWork_fake.Setup(x => x.GetRepository<Item>()).Returns(repository_fake.Object);

            return unitOfWork_fake;
        }

        [Test]
        public void Index()
        {
            var unitofwork = this.CreateUserTest();
            // Arrange
            //HomeController controller = new HomeController(unitofwork);

            //// Act
            //ViewResult result = controller.Index() as ViewResult;

            //var expected = 4;

            //Assert.AreEqual(expected, (result.Model as IList<Item>).Count);
        }
    }
    
}

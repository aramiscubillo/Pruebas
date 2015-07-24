using FakeItEasy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPP.Entities.Base;
using WPP.Persistance.BaseRepositoryClasses;
using WPP.Service.BaseServiceClasses;
using WPP.Service.ModuloContratos;

namespace WPP.Test.ModuloContratos
{
  
    [TestFixture]
    public class UsuarioTest
    {

        [Test]
        public void CreateUserTest()
        {
            Usuario userTest = new Usuario { Id = new Guid(), Nombre = "UserTest" };

            var repository_fake = A.Fake<IUsuarioService>();
            A.CallTo(() => repository_fake.Create(userTest));

            var unitOfWork_fake = A.Fake<IUnitOfWork>();
            A.CallTo(() => unitOfWork_fake.BeginTransaction());
            A.CallTo(() => unitOfWork_fake.Commit());

            A.CallTo(() => repository_fake.Equals(userTest));
        }


        [Test]
        public void GetUserTest()
        {            
            var repository_fake = A.Fake<IUsuarioService>();
            var user = A.CallTo(() => repository_fake.Get(new Guid()));

            var unitOfWork_fake = A.Fake<IUnitOfWork>();
            A.CallTo(() => unitOfWork_fake.BeginTransaction());
            A.CallTo(() => unitOfWork_fake.Commit());

            Assert.IsNotNull(user);
        }

        //[Test]
        //public void GetUserTest()
        //{
        //    var repository_fake = A.Fake<IUsuarioService>();
        //    A.CallTo(() => repository_fake.Get(new Guid()));

        //    var unitOfWork_fake = A.Fake<IUnitOfWork>();
        //    A.CallTo(() => unitOfWork_fake.BeginTransaction());
        //    A.CallTo(() => unitOfWork_fake.Commit());
        //}

        
    }
    
}

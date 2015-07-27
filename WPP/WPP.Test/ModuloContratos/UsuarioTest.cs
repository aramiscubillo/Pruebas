using FakeItEasy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPP.Entities.Objects.Generales;
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


        [Test]
        public void GetUserTest2()
        {
            IDictionary<string, object> criteriaUser = new Dictionary<string, object>();
            criteriaUser.Add("Email", "user@sapiens.co.cr");
            criteriaUser.Add("Password", "123"); 
            
            var repository_fake = A.Fake<IUsuarioService>();
            var user = A.CallTo(() => repository_fake.Get(criteriaUser));

            var unitOfWork_fake = A.Fake<IUnitOfWork>();
            A.CallTo(() => unitOfWork_fake.BeginTransaction());
            A.CallTo(() => unitOfWork_fake.Commit());

            Assert.IsNotNull(user);
        }

        [Test]
        public void UpdateUserTest()
        {
            Usuario userTest = new Usuario { Id = new Guid(), Nombre = "UserTest" };

            var repository_fake = A.Fake<IUsuarioService>();
            A.CallTo(() => repository_fake.Update(userTest));

            var unitOfWork_fake = A.Fake<IUnitOfWork>();
            A.CallTo(() => unitOfWork_fake.BeginTransaction());
            A.CallTo(() => unitOfWork_fake.Commit());

            A.CallTo(() => repository_fake.Equals(userTest));
        }

        [Test]
        public void DeleteUserTest()
        {
            Usuario userTest = new Usuario { Id = new Guid(), Nombre = "UserTest" };

            var repository_fake = A.Fake<IUsuarioService>();
            A.CallTo(() => repository_fake.Delete(userTest));

            var unitOfWork_fake = A.Fake<IUnitOfWork>();
            A.CallTo(() => unitOfWork_fake.BeginTransaction());
            A.CallTo(() => unitOfWork_fake.Commit());
        }


        [Test]
        public void ContainsUserTest()
        {
            Usuario userTest = new Usuario { Id = new Guid(), Nombre = "UserTest" };

            var repository_fake = A.Fake<IUsuarioService>();
            A.CallTo(() => repository_fake.Contains(userTest));

            var unitOfWork_fake = A.Fake<IUnitOfWork>();
            A.CallTo(() => unitOfWork_fake.BeginTransaction());
            A.CallTo(() => unitOfWork_fake.Commit());
        }

        [Test]
        public void ContainsUserTest2()
        {
            Usuario userTest = new Usuario { Id = new Guid(), Nombre = "UserTest" };

            var repository_fake = A.Fake<IUsuarioService>();
            A.CallTo(() => repository_fake.Contains(userTest,"Nombre","UserTest"));

            var unitOfWork_fake = A.Fake<IUnitOfWork>();
            A.CallTo(() => unitOfWork_fake.BeginTransaction());
            A.CallTo(() => unitOfWork_fake.Commit());
        }

        [Test]
        public void ListAllUserTest()
        {
            var repository_fake = A.Fake<IUsuarioService>();
            var user = A.CallTo(() => repository_fake.ListAll());

            var unitOfWork_fake = A.Fake<IUnitOfWork>();
            A.CallTo(() => unitOfWork_fake.BeginTransaction());
            A.CallTo(() => unitOfWork_fake.Commit());

            Assert.IsNotNull(user);
        }

        [Test]
        public void GetAllUserTest()
        {
            IDictionary<string, object> criteriaUser = new Dictionary<string, object>();
            criteriaUser.Add("Roles", "Super Usuario");
            
            var repository_fake = A.Fake<IUsuarioService>();
            var user = A.CallTo(() => repository_fake.GetAll(criteriaUser, "FechaNac",DateTime.Now,DateTime.Now.AddMonths(2)));

            var unitOfWork_fake = A.Fake<IUnitOfWork>();
            A.CallTo(() => unitOfWork_fake.BeginTransaction());
            A.CallTo(() => unitOfWork_fake.Commit());

            Assert.IsNotNull(user);
        }

        [Test]
        public void CountUserTest()
        {
            var repository_fake = A.Fake<IUsuarioService>();
            var user = A.CallTo(() => repository_fake.Count());

            var unitOfWork_fake = A.Fake<IUnitOfWork>();
            A.CallTo(() => unitOfWork_fake.BeginTransaction());
            A.CallTo(() => unitOfWork_fake.Commit());
        }
        
    }
    
}

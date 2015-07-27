
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPP.Entities.Mappings;
using WPP.Entities.Mappings.Generales;
using WPP.Entities.Objects.Generales;

namespace WPP.Service.BaseServiceClasses
{
    public class UnitOfWork : IUnitOfWork
    {
        private static readonly ISessionFactory _sessionFactory;
        private ITransaction _transaction;

        public ISession Session { get; set; }

        static UnitOfWork()
        {
            try
            {
                //var nhConfig = Fluently.Configure()
                //        .Database(OracleDataClientConfiguration.Oracle10// MsSqlConfiguration.MsSql2008
                //        .ConnectionString(constr => constr.FromConnectionStringWithKey("db"))
                //        .Driver<OracleDataClientDriver>()
                //        .ShowSql())
                //          //  .AdoNetBatchSize(100))
                //          .CurrentSessionContext("thread_static")
                //            .Mappings(maps => maps.FluentMappings.AddFromAssemblyOf<UsuarioMapping>())
                //            .Mappings(maps => maps.FluentMappings.AddFromAssemblyOf<CompaniaMapping>());

                var dbConfig = OracleDataClientConfiguration.Oracle10
              .ConnectionString(c => c.FromConnectionStringWithKey("db"))
              .Driver<NHibernate.Driver.OracleClientDriver>()
              .DefaultSchema("WPP")
              .ShowSql();
                
                _sessionFactory = Fluently.Configure()
                  .Database(dbConfig)
                  .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UsuarioMapping>())
                   //.ExposeConfiguration(cfg => new SchemaExport(cfg.SetProperty("hbm2ddl.auto", "create-drop"))
                 //.Create(false, true))
                 .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
                  .BuildSessionFactory();


                 /*var dbConfig = Fluently.Configure()
                    .Database(OracleDataClientConfiguration.Oracle10
                    .ConnectionString(constr => constr.FromConnectionStringWithKey("db"))
                        .Driver<NHibernate.Driver.OracleClientDriver>()
                        .DefaultSchema("WPP"))
                        .Mappings(maps => maps.FluentMappings.AddFromAssemblyOf<UsuarioMapping>())
                 .ExposeConfiguration(cfg => new SchemaExport(cfg.SetProperty("hbm2ddl.auto", "create-drop"))
                 .Create(false, true))
                        .BuildConfiguration()
                        .AddProperties(new Dictionary<string, string>
                               {
                                   { NHibernate.Cfg.Environment.CurrentSessionContextClass, "web" }
                                });

                 _sessionFactory = dbConfig.BuildSessionFactory();*/

            }
            catch(Exception ex)
            {
                
            }

          //  _sessionFactory = nhConfig.BuildSessionFactory();
        }

        private void CreateObjects()
        {
            
            Usuario superUsuario = new Usuario();
            superUsuario.IsDeleted = false;
            superUsuario.Nombre = "super";
            superUsuario.Apellidos = "super";
            superUsuario.CreateDate = DateTime.Now;
            superUsuario.DateLastModified = DateTime.Now;
            superUsuario.Roles = "Super Usuario";
            superUsuario.Email = "user@user.com";
            superUsuario.Password = "12345";
            superUsuario.FechaNac = DateTime.Now;

       //     Session.Save(superUsuario);

            /*Catalogo cat = new Catalogo();
            cat.CreateDate = DateTime.Now;
            cat.DateLastModified = DateTime.Now;
            cat.IsDeleted = false;
            cat.Nombre = "UserUsuario";
            cat.Tipo = "Roles";
            cat.Version = 1;

            Session.Save(cat);


            cat = new Catalogo();
            cat.CreateDate = DateTime.Now;
            cat.DateLastModified = DateTime.Now;
            cat.IsDeleted = false;
            cat.Nombre = "Administrador";
            cat.Tipo = "Roles";
            cat.Version = 1;

            Session.Save(cat);*/
        }


        private static void BuildSchema(Configuration config)
        {
            //Creates database structure
            new SchemaExport(config)
               .Create(false, true);
        }

        public UnitOfWork()
        {
            Session = _sessionFactory.OpenSession();
            CreateObjects();
        }

        public void BeginTransaction()
        {
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                Session.Close();
            }
        }
    }
}

using Entities.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPP.Service.BaseServiceClasses
{
    public class UnitOfWork : IUnitOfWork
    {
        private static readonly ISessionFactory _sessionFactory;
        private ITransaction _transaction;

        public ISession Session { get; set; }

        static UnitOfWork()
        {
            var nhConfig = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(constr => constr.FromConnectionStringWithKey("db"))
                        .AdoNetBatchSize(100))
                        .Mappings(maps => maps.FluentMappings.AddFromAssemblyOf<UsuarioMapping>())
                        .Mappings(maps => maps.FluentMappings.AddFromAssemblyOf<CompaniaMapping>())
                 .ExposeConfiguration(cfg => new SchemaExport(cfg.SetProperty("hbm2ddl.auto", "create-drop"))
                 .Create(true, true))
                        .BuildConfiguration()
                        .AddProperties(new Dictionary<string, string>
                               {
                                   { NHibernate.Cfg.Environment.CurrentSessionContextClass, "web" }
                                });

            _sessionFactory = nhConfig.BuildSessionFactory();
        }

        public UnitOfWork()
        {
            Session = _sessionFactory.OpenSession();
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

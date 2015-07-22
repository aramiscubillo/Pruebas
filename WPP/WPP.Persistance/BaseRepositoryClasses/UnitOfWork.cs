
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPP.Entities.Mappings;

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
              .Driver<OracleDataClientDriver>()
              .ShowSql();

                _sessionFactory = Fluently.Configure()
                  .Database(dbConfig)
                  .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UsuarioMapping>())
                  .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CompaniaMapping>())
                  .BuildSessionFactory();
            }
            catch(Exception ex)
            {
                
            }

          //  _sessionFactory = nhConfig.BuildSessionFactory();
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

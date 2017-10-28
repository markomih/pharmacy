using System;
using Core;
using Data.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace Data
{
    public class NewDataLayer : INewDataLayer
    {
        private static readonly ISessionFactory Factory;

        static NewDataLayer()
        {
            try
            {
                var cfg = OracleClientConfiguration.Oracle10.ShowSql()
                    .ConnectionString(c =>
                        c.Is("Data Source=" + Constants.DataSource + ";" +
                             "User Id=" + Constants.User + ";" +
                             "Password=" + Constants.Password));

                Factory = Fluently.Configure()
                    .Database(cfg)
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ApotekarskaUstanovaMap>())
                    .BuildSessionFactory();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public ISession GetSession()
        {
            return Factory.OpenSession();
        }
    }
}
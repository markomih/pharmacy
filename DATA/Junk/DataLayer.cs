//using System;
//using Core;
//using FluentNHibernate.Cfg;
//using FluentNHibernate.Cfg.Db;
//using NHibernate;

//namespace Data
//{
//    public class DataLayer
//    {
//        //private const string DbFile = "pharmacy.db";

//        private static ISessionFactory _factory;
//        private static object objLock = new object();
//        public static ISession GetSession()
//        {
//            if (_factory == null)
//            {
//                lock (objLock)
//                {
//                    if (_factory == null)
//                        _factory = CreateSessionFactory();
//                }
//            }
//            return _factory.OpenSession();
//        }
//        public static ISessionFactory CreateSessionFactory()
//        {
//            try
//            {
//                var cfg = OracleClientConfiguration.Oracle10
//                .ConnectionString(c =>
//                    c.Is("Data Source=160.99.12.92:1521/sbp_pdb;" +
//                         "User Id=" + Constants.User + ";" +
//                         "Password="+ Constants.Password));

//                return Fluently.Configure()
//                    .Database(cfg)
//                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
//                    .BuildSessionFactory();

//                //return Fluently.Configure()
//                //    .Database(cfg)
//                //    .Mappings(m => m.FluentMappings.AddFromAssembly(m))
//                //    //.Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
//                //    //.ExposeConfiguration(BuildSchema)
//                //    .BuildSessionFactory();
//            }
//            catch (Exception ec)
//            {
//                Console.WriteLine(ec.ToString());
//                return null;
//            }
//        }

//        //public static void BuildSchema(Configuration config)
//        //{
//        //    try
//        //    {
//        //        // delete the existing db on each run
//        //        if (File.Exists(DbFile))
//        //            File.Delete(DbFile);

//        //        // this NHibernate tool takes a configuration (with mapping info in)
//        //        // and exports a database schema from it
//        //        new SchemaExport(config)
//        //            .Create(false, true);
//        //    }
//        //    catch (Exception e)
//        //    {
//        //        Console.WriteLine(e);
//        //    }
//        //}
//    }
//}
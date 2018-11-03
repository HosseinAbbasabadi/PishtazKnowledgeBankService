using System.Data;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;

namespace Framework.Nhibernate
{
    public class SessionFactoryBuilder //: IMySessionFactoryBuilder
    {
        public ISessionFactory CreateByConnectionString(string connectionString, Assembly mappingAssembly)
        {
            var configuration = new Configuration();
            configuration.DataBaseIntegration(cfg =>
            {
                cfg.Dialect<MsSql2012Dialect>();
                cfg.Driver<SqlClientDriver>();
                cfg.ConnectionString = connectionString;
                cfg.IsolationLevel = IsolationLevel.ReadCommitted;
            });
            return Create(configuration, mappingAssembly);
        }

        public ISessionFactory CreateByConnectionStringName(string connectionString,
            Assembly mappingAssembly)
        {
            var configuration = new Configuration();
            configuration.DataBaseIntegration(cfg =>
            {
                cfg.LogSqlInConsole = true;
                cfg.Dialect<MsSql2012Dialect>();
                cfg.Driver<SqlClientDriver>();
                cfg.ConnectionString = connectionString;
                //cfg.ConnectionStringName = connectionStringName;
                cfg.IsolationLevel = IsolationLevel.ReadCommitted;
            });
            return Create(configuration, mappingAssembly);
        }

        private static ISessionFactory Create(Configuration configuration, Assembly mappingAssembly)
        {
            var modelMapper = new ModelMapper();
            modelMapper.AddMappings(mappingAssembly.GetExportedTypes());

            var hbmMapping = modelMapper.CompileMappingForAllExplicitlyAddedEntities();
            configuration.AddDeserializedMapping(hbmMapping, "test");

            return configuration.BuildSessionFactory();
        }
    }
}
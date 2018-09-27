using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using UserManagement.Domain;
using UserManagement.Domain.Models.Users;

namespace UserManagement.Infrastructure.Persistance.Nh.Mappings
{
    public class UserMapping : ClassMapping<User>
    {
        public UserMapping()
        {
            Table("Users");
            Lazy(false);

            ComponentAsId(z => z.Id, x => { x.Property(z => z.DbId, a => a.Column("Id")); });

            Property(x => x.Username);
            Property(x => x.Password);
            Property(x => x.FullName);
            Property(x => x.Lastname);
            Property(x => x.CreationDateTime);

            IdBag(a => a.Roles, map =>
            {
                map.Access(Accessor.Field);
                map.Table("UserRoles");
                map.Key(a => a.Column("UserId"));
                map.Id(a =>
                {
                    a.Column("Id");
                    a.Generator(Generators.Guid);
                });
            }, relation => relation.Component(map =>
            {
                map.Access(Accessor.Property);
                map.Property(a => a.DbId, a => a.Column("RoleId"));
            }));
        }
    }
}
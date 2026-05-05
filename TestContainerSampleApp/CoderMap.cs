using NHibernate;
using NHibernate.Mapping;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace TestContainerSampleApp;

public class CoderMap : ClassMapping<Coder>
{
    public CoderMap()
    {
        Table("coders");

        Id(c => c.Id, map =>
        {
            map.Column("id");
            map.Generator(Generators.Identity);
        });
        
        Discriminator(d =>
        {
            d.Column("type");
            d.Type(NHibernateUtil.String);
        });
        
        Property(c => c.Name, map => map.Column("name"));
        Property(c => c.Language, map => map.Column("language"));
        Property(c => c.Architecture, map => map.Column("architecture"));
        Property(c => c.IsVibeCoder, map => map.Column("is_vibe_coder"));
        

    }
}

public class AdisCoderMap : SubclassMapping<AdisCoder>
{
    public AdisCoderMap()
    {
        DiscriminatorValue("adis_coder");
    }
}

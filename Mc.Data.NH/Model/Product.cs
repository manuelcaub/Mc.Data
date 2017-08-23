namespace Mc.Data.NH.Model
{
    // using global::NHibernate.Mapping.Attributes;

    // [Class(Table ="Product")]
    public class Product
    {
        public Product()
        {
        }

        // [Id]
        public virtual int Id { get; set; }

        // [Property]
        public virtual string Name { get; set; }
    }
}

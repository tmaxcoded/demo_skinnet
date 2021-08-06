namespace Core.Entities
{
    public class Product:BaseEntity
    {
        
        public string Name {get;set;}

        public string Description {get;set;}

        public decimal Price {get;set;}

        public string PictureUrl {get;set;}

        public ProductType ProductuctType {get;set;}

        public int ProductTypeId {get;set;}
        public ProductBrand Productband {get;set;}
        public int ProductbandId {get;set;}
    }
}
namespace TMCatalog.Logic
{
    public static class Data
    {
       static Data()
       {
           Catalog = new CatalogController();
       }
       public static CatalogController Catalog { get; set; }
    }
}

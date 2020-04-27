namespace TMCatalog.Common.Interfaces.TMCatalogContents
{
    public interface IShoppingBasket : ITMCatalogContent
    {
        void AddToShoppingBasket(IArticle article);
    }
}

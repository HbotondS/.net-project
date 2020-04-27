using System.Collections.ObjectModel;
using TMCatalog.Common.Interfaces;
using TMCatalog.Common.Interfaces.TMCatalogContents;
using TMCatalog.Common.MVVM;
using TMCatalog.Logic;
using TMCatalogClient.Model;

namespace TMCatalog.ViewModel.UserControlls
{
    class ShoppingBasketViewModel : ViewModelBase, IShoppingBasket
    {
        public string Header => "Shopping Basket";

        public ShoppingBasketViewModel()
        {
            this.StockCollection = new ObservableCollection<Stock>();
        }

        public void AddToShoppingBasket(IArticle article)
        {
            Article tempArticle = (Article)article;
            Stock stock = Data.Catalog.GetArticleStock(tempArticle.Id);
            stock.Article = tempArticle;
            this.StockCollection.Add(stock);
        }

        private ObservableCollection<Stock> stockCollection;

        public ObservableCollection<Stock> StockCollection
        {
            get { return stockCollection; }
            set
            {
                stockCollection = value;
                this.RaisePropertyChanged();
            }
        }
    }
}

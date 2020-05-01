using System.Collections.ObjectModel;
using System.Linq;
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

            this.ClearBasket = new RelayCommand(this.ClearShoppingBasket);
            
            this.RemoveFromShoppingBasket = new RelayCommand(this.RemoveFromShoppingBasketExecute, this.RemoveFromShoppingBasketCanExecute);
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
        
        private Stock selectedItem;
        public Stock SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                this.RaisePropertyChanged();
            }
        }

        public RelayCommand ClearBasket { get; set; }
        public void ClearShoppingBasket()
        {
            stockCollection.ToList().All(o => stockCollection.Remove(o));
        }
        
        public RelayCommand RemoveFromShoppingBasket { get; set; }
        private void RemoveFromShoppingBasketExecute()
        {
            this.stockCollection.Remove(this.selectedItem);
        }
        private bool RemoveFromShoppingBasketCanExecute()
        {
            return this.SelectedItem != null;
        }
    }
}

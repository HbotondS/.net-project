using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
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
        public int TotalItemCount { get; set; }
        public decimal TotalPrice { get; set; }

        public ShoppingBasketViewModel()
        {
            this.StockCollection = new ObservableCollection<Stock>();

            this.ClearBasket = new RelayCommand(this.ClearShoppingBasket);
            this.OrderItemsCommand = new RelayCommand(this.OrderItems);
            
            this.RemoveFromShoppingBasket = new RelayCommand(this.RemoveFromShoppingBasketExecute, this.RemoveFromShoppingBasketCanExecute);

            this.TotalItemCount = 0;
            this.TotalPrice = 0;
        }

        public void AddToShoppingBasket(IArticle article)
        {
            Article tempArticle = (Article)article;
            Stock stock = Data.Catalog.GetArticleStock(tempArticle.Id);
            stock.Article = tempArticle;
            this.StockCollection.Add(stock);
            this.TotalItemCount += stock.Quantity;
            this.TotalPrice += stock.Price;
            System.Console.WriteLine(this.TotalItemCount);
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
        
        public RelayCommand OrderItemsCommand { get; set; }
        public void OrderItems()
        {
            var fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                string[] files = Directory.GetFiles(fbd.SelectedPath);

                XmlWriter xmlWriter = XmlWriter.Create(fbd.SelectedPath + "/order.xml");
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Order");
                stockCollection.ToList().All(o =>
                {
                    xmlWriter.WriteStartElement("Item");
                    xmlWriter.WriteAttributeString("Description", o.Article.Description);
                    xmlWriter.WriteAttributeString("Quantity", o.Quantity.ToString());
                    xmlWriter.WriteAttributeString("Price", o.Price.ToString());
                    xmlWriter.WriteEndElement();
                    return false;
                });
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
            }
        }
    }
}

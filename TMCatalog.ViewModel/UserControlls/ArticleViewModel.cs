using System.Collections.Generic;
using TMCatalog.Common.MVVM;
using TMCatalogClient.Model;
using TMCatalog.Common.Interfaces.TMCatalogContents;
using TMCatalog.Logic;

namespace TMCatalog.ViewModel.UserControlls
{
    public class ArticleViewModel : ViewModelBase, IArticleContent
    {
        public string Header => this.VehicleType.Description;

        public RelayCommand CloseCommand { get; }

        private VehicleType vehicleType;

        public VehicleType VehicleType
        {
            get => vehicleType;
            set
            {
                vehicleType = value;
                if (this.vehicleType != null)
                {
                    this.ProductGroups = Data.Catalog.GetProductGroups(this.vehicleType.Id);
                }
                this.RaisePropertyChanged();
            }
        }

        public ArticleViewModel(VehicleType vehicleType)
        {
            this.VehicleType = vehicleType;
            this.CloseCommand = new RelayCommand(this.CloseExecute);
            this.AddToShoppingBasketCommand = new RelayCommand(this.AddToShoppingBasketExecute, this.AddToShoppingBasketCanExecute);
        }

        private void CloseExecute()
        {
            MainWindowViewModel.Instance.CloseArticle(this);
        }

        private List<ProductGroup> productGroups;

        public List<ProductGroup> ProductGroups
        {
            get { return productGroups; }
            set
            {
                productGroups = value;
                this.RaisePropertyChanged();
            }
        }

        private object selectedProduct;

        public object SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                this.RaisePropertyChanged();
                this.GetArticles(this.selectedProduct);
            }
        }

        private List<Article> articles;

        public List<Article> Articles
        {
            get { return articles; }
            set
            {
                articles = value;
                this.RaisePropertyChanged();

            }
        }

        private Article selectedArticle;

        public Article SelectedArticle
        {
            get { return selectedArticle; }
            set
            {
                selectedArticle = value;
                this.RaisePropertyChanged();
            }
        }

        private void GetArticles(object selectedItem)
        {
            if (selectedItem is Product)
            {
                this.Articles = Data.Catalog.GetArticles((selectedItem as Product).Id);
            }
            else if (selectedItem is ProductGroup)
            {
                ProductGroup item = selectedItem as ProductGroup;
                List<Article> templist = new List<Article>();
                foreach (Product product in item.Products)
                {
                    templist.AddRange(Data.Catalog.GetArticles(product.Id));
                }
                this.Articles = templist;
            }
        }

        private bool AddToShoppingBasketCanExecute()
        {
            return this.SelectedArticle != null;
        }

        public RelayCommand AddToShoppingBasketCommand { get; }
        private void AddToShoppingBasketExecute()
        {
            MainWindowViewModel.Instance.AddToShoppingBasket(this.SelectedArticle);
        }
    }
}

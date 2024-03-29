﻿// ------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="DVSE GmbH">
//   Copyright (c) by DVSE Gesellschaft für Datenverarbeitung, Service und Entwicklung mbH. All rights reserved.
// </copyright>
// <author>Szilveszter Gorgicze</author>
// ------------------------------------------------------------------------------------------------------------------

namespace TMCatalog.ViewModel
{
    using System.Collections.ObjectModel;
    using TMCatalog.Common.Interfaces.TMCatalogContents;
    using TMCatalog.Common.MVVM;
    using TMCatalog.Logic;
    using TMCatalog.ViewModel.UserControlls;
    using TMCatalogClient.Model;

    public class MainWindowViewModel : ViewModelBase
    {
        public static MainWindowViewModel Instance { get; set; }

        public static CatalogController CatalogController;

        private ObservableCollection<ITMCatalogContent> contents;
        public ObservableCollection<ITMCatalogContent> Contents
        {
            get { return contents; }
            set
            {
                contents = value;
                this.RaisePropertyChanged();
            }
        }

        private ITMCatalogContent selectedContent;
        public ITMCatalogContent SelectedContent
        {
            get { return selectedContent; }
            set
            {
                selectedContent = value;
                this.RaisePropertyChanged();
            }
        }

        private VehicleSearchViewModel vehicleSearchViewModel;
        public VehicleSearchViewModel VehicleSearchViewModel
        {
            get { return this.vehicleSearchViewModel; }
            set
            {
                this.vehicleSearchViewModel = value;
                this.RaisePropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            CatalogController = new CatalogController();
            this.CloseCommand = new RelayCommand(this.CloseCommandExecute);

            this.VehicleSearchViewModel = new VehicleSearchViewModel();

            this.shoppingBasketContent = new ShoppingBasketViewModel();

            this.Contents = new ObservableCollection<ITMCatalogContent>();
            this.Contents.Add(vehicleSearchViewModel);
            this.Contents.Add(shoppingBasketContent);

            this.SelectedContent = vehicleSearchViewModel;

            Instance = this;
        }

        public RelayCommand CloseCommand { get; set; }
        public void CloseCommandExecute()
        {
            ViewService.CloseDialog(this);
        }

        public void CloseArticle(ArticleViewModel articleViewModel)
        {
            this.Contents.Remove(articleViewModel);
        }

        public void SetVehicleTypeToArticle(VehicleType vehicleType)
        {
            ArticleViewModel articleViewModel = new ArticleViewModel(vehicleType);
            this.Contents.Add(articleViewModel);
            this.SelectedContent = articleViewModel;
        }

        private IShoppingBasket shoppingBasketContent { get; }
        public void AddToShoppingBasket(Article article)
        {
            this.shoppingBasketContent.AddToShoppingBasket(article);
            this.SelectedContent = this.shoppingBasketContent;
        }
    }
}

// ------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="DVSE GmbH">
//   Copyright (c) by DVSE Gesellschaft für Datenverarbeitung, Service und Entwicklung mbH. All rights reserved.
// </copyright>
// <author>Szilveszter Gorgicze</author>
// ------------------------------------------------------------------------------------------------------------------

namespace TMCatalog
{
  using System;
  using System.Windows;
  using TMCatalog.Common.MVVM;
  using TMCatalog.Model.DBContext;
  using TMCatalog.View;
  using TMCatalog.ViewModel;

  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.Initialize();
            this.InitializeData();
            this.OpenMainWindow();
        }
        private void Initialize()
        {
            ViewService.RegisterView(typeof(MainWindowViewModel), typeof(MainWindow));
        }

        private void OpenMainWindow()
        {
            MainWindow mainWindow = new MainWindow();
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();

            ViewService.AddMainWindowToOpened(mainWindowViewModel, mainWindow);
            ViewService.ShowDialog(mainWindowViewModel);
        }

        private void InitializeData()
        {
            try
            
                {
                DBInitializer dbinit = new DBInitializer();
                dbinit.InitializeDatabase(new TMCatalogDB());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

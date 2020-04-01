using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TMCatalog.Common.Interfaces.TMCatalogContents;

namespace TMCatalog.View.TemplateSelectors
{
    public class TMCatalogContentTemplateSelector: DataTemplateSelector
    {

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is IVehicleSearchContent)
            {
                return Application.Current.MainWindow.TryFindResource("VehicleSearchTemplate") as DataTemplate;
            }
            else if (item is IArticleContent)
            {
                return Application.Current.MainWindow.TryFindResource("ArticleTemplate") as DataTemplate;
            }
            else if (item is IShoppingBasket)
            {
                return Application.Current.MainWindow.TryFindResource("ShoppingBasketTemplate") as DataTemplate;
            }
            return base.SelectTemplate(item, container);
        }
    }
}

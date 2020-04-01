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
    public class TMCatalogHeaderTemplateSelector: DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is IClosableContent)
            {
                return Application.Current.MainWindow.TryFindResource("ClosableHeaderTemplate") as DataTemplate;
            } 
            else
            {
                return Application.Current.MainWindow.TryFindResource("DefaultHeaderTemplate") as DataTemplate;
            }
        }
    }
}

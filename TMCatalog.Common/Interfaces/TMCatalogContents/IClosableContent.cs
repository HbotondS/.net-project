﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMCatalog.Common.Interfaces.TMCatalogContents
{
    public interface IClosableContent
    {
        RelayCommand CloseCommand { get; }
    }
}
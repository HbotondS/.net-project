// ------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginWindowViewModel.cs" company="DVSE GmbH">
//   Copyright (c) by DVSE Gesellschaft für Datenverarbeitung, Service und Entwicklung mbH. All rights reserved.
// </copyright>
// <author>Jozsef Tolgyesi</author>
// ------------------------------------------------------------------------------------------------------------------

namespace TMCatalogClient.Model
{
    using System.ComponentModel.DataAnnotations;
    using TMCatalog.Common.Helpers;

    /// <summary>
    /// Product
    /// </summary>
    public class Product: ProductBase
    {
        [Key]
        public int Id { get; set; }

        public int ProductGroupId { get; set; }

        public ProductGroup ProductGroup { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginWindowViewModel.cs" company="DVSE GmbH">
//   Copyright (c) by DVSE Gesellschaft für Datenverarbeitung, Service und Entwicklung mbH. All rights reserved.
// </copyright>
// <author>Jozsef Tolgyesi</author>
// ------------------------------------------------------------------------------------------------------------------

namespace TMCatalogClient.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Vehicle type articles 
    /// </summary>
    public class VehicleTypeArticles
    {
        [Key, Column(Order = 0)]
        public int ArticleId { get; set; }

        public Article Article { get; set; }

        [Key, Column(Order = 1)]
        public int VehicleTypeId { get; set; }

        public VehicleType VehicleType { get; set; }
    }
}

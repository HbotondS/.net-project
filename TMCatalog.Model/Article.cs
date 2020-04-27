// ------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginWindowViewModel.cs" company="DVSE GmbH">
//   Copyright (c) by DVSE Gesellschaft für Datenverarbeitung, Service und Entwicklung mbH. All rights reserved.
// </copyright>
// <author>Jozsef Tolgyesi</author>
// ------------------------------------------------------------------------------------------------------------------

namespace TMCatalogClient.Model
{
    using System.ComponentModel.DataAnnotations;
    using TMCatalog.Common.Interfaces;

    /// <summary>
    /// Article
    /// </summary>
    public class Article : IArticle
    {
        [Key]
        public int Id { get; set; }

        public string ArticleNumber { get; set; }

        public string Description { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}

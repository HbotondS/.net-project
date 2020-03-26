// ------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginWindowViewModel.cs" company="DVSE GmbH">
//   Copyright (c) by DVSE Gesellschaft für Datenverarbeitung, Service und Entwicklung mbH. All rights reserved.
// </copyright>
// <author>Jozsef Tolgyesi</author>
// ------------------------------------------------------------------------------------------------------------------

namespace TMCatalogClient.Model
{
  using System.ComponentModel.DataAnnotations;

  /// <summary>
  /// Product
  /// </summary>
  public class Product
  {
    [Key]
    public int Id { get; set; }

    public string Description { get; set; }

    public int ProductGroupId { get; set; }

    public ProductGroup ProductGroup { get; set; }
  }
}

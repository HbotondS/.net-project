// ------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewModelBase.cs" company="DVSE GmbH">
//   Copyright (c) by DVSE Gesellschaft für Datenverarbeitung, Service und Entwicklung mbH. All rights reserved.
// </copyright>
// <author>Szilveszter Gorgicze</author>
// ------------------------------------------------------------------------------------------------------------------

namespace TMCatalog.Common.MVVM
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// View model base
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the property changed.
        /// </summary>
        /// <param name="name">The name.</param>
        public void RaisePropertyChanged([CallerMemberName]string name = null)
        {
            if (this.PropertyChanged != null){

            this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}

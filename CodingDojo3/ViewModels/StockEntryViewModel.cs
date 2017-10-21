using CodingDojo4DataLib;
using GalaSoft.MvvmLight;
using System;

namespace CodingDojo3.ViewModels
{
    class StockEntryViewModel : ViewModelBase
    {
        StockEntry stockEntry;
        private double salesPriceInEuro;

        public StockEntryViewModel(StockEntry entry)
        {
            stockEntry = entry;
        }

        public String Name
        {
            get { return stockEntry.SoftwarePackage.Name; }
            set
            {
                stockEntry.SoftwarePackage.Name = value;
                RaisePropertyChanged("Name");
            }
        }

        public double SalesPrice
        {
            get { return stockEntry.SoftwarePackage.SalesPrice; }
            set
            {
                stockEntry.SoftwarePackage.SalesPrice = value;
                RaisePropertyChanged("SalesPrice");
            }
        }

        public double PurchasePrice
        {
            get { return stockEntry.SoftwarePackage.PurchasePrice; }
            set
            {
                stockEntry.SoftwarePackage.PurchasePrice = value;
                RaisePropertyChanged("PurchasePrice");
            }
        }

        public String Group
        {
            get { return stockEntry.SoftwarePackage.Category.Name; }
            set
            {
                stockEntry.SoftwarePackage.Category.Name = value;
                RaisePropertyChanged("Group");
            }
        }

        public int Stock
        {
            get { return stockEntry.Amount; }
            set
            {
                stockEntry.Amount = value;
                RaisePropertyChanged("Stock");
            }
        }


    }
}

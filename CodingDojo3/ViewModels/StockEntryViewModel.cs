using CodingDojo4DataLib;
using CodingDojo4DataLib.Converter;
using GalaSoft.MvvmLight;
using System;

namespace CodingDojo3.ViewModels
{
    class StockEntryViewModel : ViewModelBase
    {
        StockEntry stockEntry;
        private double salesPriceInEuro;
        private double purchasePriceInEuro;

        public StockEntryViewModel(StockEntry entry)
        {
            stockEntry = entry;
            salesPriceInEuro = entry.SoftwarePackage.SalesPrice;
            purchasePriceInEuro = entry.SoftwarePackage.PurchasePrice;
        }

        public StockEntryViewModel()
        {
            stockEntry = new StockEntry();
        }

        public void CalculatePriceFromEuro(Currencies currency)
        {
            this.SalesPrice = CurrencyConverter.ConvertFromEuroTo(currency, salesPriceInEuro);
            this.PurchasePrice = CurrencyConverter.ConvertFromEuroTo(currency, purchasePriceInEuro);
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

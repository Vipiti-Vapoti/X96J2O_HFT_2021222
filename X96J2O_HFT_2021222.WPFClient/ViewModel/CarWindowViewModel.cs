using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using X96J2O_HFT_2021222.Models;

namespace X96J2O_HFT_2021222.WPFClient.ViewModel
{
    public class CarWindowViewModel :ObservableRecipient
    {
      
        public ICommand AddCarCommand { get; set; }
        public ICommand DeleteCarCommand { get; set; }
        public ICommand UpdateCarCommand { get; set; }
       

   
        public RestCollection<Car> Cars { get; set; }
        public RestCollection<Brand> Brands { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public Brand SelectedBrand { get; set; }
        private Car selectedCar;
        public Car SelectedCar
        {
            get { return selectedCar; }
            set
            {
                if (value != null)
                {
                    selectedCar = new Car()
                    {
                        carId = value.carId,
                        Model = value.Model,
                        RentPrice = value.RentPrice,
                        Brand = value.Brand,
                    };
                } 
                OnPropertyChanged();
                (DeleteCarCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateCarCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
      
        public CarWindowViewModel()
        {
            if (!IsInDesignMode)
            {
              
                Cars = new RestCollection<Car>("http://localhost:35445/", "Car", "hub");
                
                Brands = new RestCollection<Brand>("http://localhost:35445/", "Brand", "hub");
                AddCarCommand = new RelayCommand(() =>
                {
                    Cars.Add(new Car()
                    {
                       
                        Model = selectedCar.Model,
                        RentPrice =selectedCar.RentPrice,
                        BrandId= selectedCar.BrandId,
                    });

                });
                DeleteCarCommand = new RelayCommand(() =>
                {
                    Cars.Delete(SelectedCar.carId);
                },
                () =>
                {
                    return SelectedCar != null;
                });

                UpdateCarCommand = new RelayCommand(() =>
                {
              
                    selectedCar.BrandId = SelectedBrand.brandId;
                    Cars.Update(SelectedCar);
                },
                () =>
                {
                    return SelectedCar != null;
                });
                SelectedCar = new Car();
            }
        }
    }
}

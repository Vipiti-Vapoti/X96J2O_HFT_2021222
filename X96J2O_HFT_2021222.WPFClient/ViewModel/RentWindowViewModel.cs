using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using X96J2O_HFT_2021222.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace X96J2O_HFT_2021222.WPFClient.ViewModel
{
    public  class RentWindowViewModel :ObservableRecipient
    {
        public ICommand AddRentCommand { get; set; }
        
        public ICommand DeleteRentCommand { get; set; }
      
        public ICommand UpdateRentCommand { get; set; }
       

        public RestCollection<Rent> Rents { get; set; }
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
        private Rent selectedRent;
        public Car SelectedCar { get; set; }
        public Rent SelectedRent
        {
            get { return selectedRent; }
            set
            { if(value != null)
                {
                    selectedRent = new Rent()
                    {   rentId= value.rentId,
                        FirstName = value.FirstName,
                        LastName = value.LastName,
                        Phone = value.Phone,
                        Mail = value.Mail,
                        CarId = value.CarId,
                        In = value.In,
                        Out = value.Out,
                        
                        
                    };
                }
                OnPropertyChanged();
                (DeleteRentCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateRentCommand as RelayCommand).NotifyCanExecuteChanged();

            }
        }
     
        public RentWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Rents = new RestCollection<Rent>("http://localhost:35445/", "Rent", "hub");
                Cars = new RestCollection<Car>("http://localhost:35445/", "Car", "hub");
                AddRentCommand = new RelayCommand(() =>
                {
                    Rents.Add(new Rent()
                    {
                        FirstName = selectedRent.FirstName,
                        LastName = selectedRent.LastName,
                        Phone = selectedRent.Phone,
                        Mail = selectedRent.Mail,
                       
                        Out = selectedRent.Out,
                        In = selectedRent.In
                    }); 

                });
             

                DeleteRentCommand = new RelayCommand(() =>
                {
                    Rents.Delete(SelectedRent.rentId);
                },
                () =>
                {
                    return SelectedRent != null;
                });
               
       
                UpdateRentCommand = new RelayCommand(() =>
                {

                    selectedRent.CarId = SelectedCar.carId;
                   
                    
                    Rents.Update(SelectedRent);

                },
                () =>
                {
                    return SelectedRent != null;
                });
              selectedRent = new Rent();
            }
        }
    }
}

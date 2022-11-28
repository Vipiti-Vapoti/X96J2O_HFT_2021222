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
    public class BrandWindowViewModel :ObservableRecipient
    {
        
        public ICommand AddBrandCommand { get; set; }
      
        public ICommand DeleteBrandCommand { get; set; }
    
        public ICommand UpdateBrandCommand { get; set; }

       
        public RestCollection<Brand> Brands { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
    
        private Brand selectedBrand;
        public Brand SelectedBrand
        {
            get { return selectedBrand; }
            set
            {
                SetProperty(ref selectedBrand, value);
                (DeleteBrandCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateBrandCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public BrandWindowViewModel()
        {
            if (!IsInDesignMode)
            {
               
                Brands = new RestCollection<Brand>("http://localhost:35445/", "Brand");
               
                AddBrandCommand = new RelayCommand(() =>
                {
                    Brands.Add(new Brand()
                    {
                        Name = selectedBrand.Name
                    });
                });
                DeleteBrandCommand = new RelayCommand(() =>
                {
                    Brands.Delete(SelectedBrand.brandId);
                },
                () =>
                {
                    return SelectedBrand != null;
                });
                UpdateBrandCommand = new RelayCommand(() =>
                {
                    Brands.Update(selectedBrand);
                },
                () =>
                {
                    return SelectedBrand != null;
                });
                selectedBrand= new Brand();
            }
        }
    }
}

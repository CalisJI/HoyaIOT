using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HOYA_IOT.ViewModel
{
    public class MainViewModel:BaseViewModel
    {
        #region ICommand
        public ICommand Loaded { get; set; }
        public ICommand Unload { get; set; }
        public ICommand Home { get; set; }

        #region Page Command
        public ICommand Simulator_Page { get; set; }
        public ICommand Information_Page { get; set; }
        public ICommand Settings_Page { get; set; }
        public ICommand Processoverview_Page { get; set; }
        public ICommand PackingDataView_Page { get; set; }

        #endregion


        #endregion
        #region Model
        private BaseViewModel _model;

        public BaseViewModel SelectedViewModel
        {
            get => _model;
            set => SetProperty(ref _model, value, nameof(SelectedViewModel));
        }
        private string _tiltle;

        public string Title
        {
            get => _tiltle;
            set => SetProperty(ref _tiltle, value, nameof(Title));
        }

        #endregion
        #region Variable
        public MainScreen_ViewModel MainScreen_ViewModel = MainScreen_ViewModel.INS_MainScreenViewModel;
        public Simulator_ViewModel Simulator_ViewModel = Simulator_ViewModel.INS_Simulator_ViewModel;
        public ProcessOverView_ViewModel ProcessOverView_ViewModel = ProcessOverView_ViewModel.INS_ProcessOverView_ViewModel;
        public PackingData_ViewModel PackingData_ViewModel = PackingData_ViewModel.INS_PackingData_ViewModel;
        public Settings_ViewModel Settings_ViewModel = Settings_ViewModel.INS_Settings_ViewModel;
        public static MainViewModel main;
        #endregion
        public MainViewModel() 
        {
            main = this;
            Processoverview_Page = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                main.Title = "Process OverView";
                main.SelectedViewModel = ProcessOverView_ViewModel;
            });

            Simulator_Page = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                main.Title = "Monitor";
                main.SelectedViewModel = Simulator_ViewModel;
            });
            Loaded = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                main.Title = "Home";
                main.SelectedViewModel = MainScreen_ViewModel;
            });
            Unload = new RelayCommand<object>((p) => { return true; }, (p) =>
            {

            });
            Home = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                main.Title = "Home";
                main.SelectedViewModel = MainScreen_ViewModel;
            });
            Settings_Page = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                main.Title = "Settings";
                main.SelectedViewModel = Settings_ViewModel;
            });
            PackingDataView_Page = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                main.Title = "Packing Form";
                main.SelectedViewModel = PackingData_ViewModel;
            });

        }
    }
}

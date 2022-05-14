using MaterialDesignThemes.Wpf;
using MyToDo.Common;
using MyToDo.Shared.Dtos;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyToDo.ViewModels.Dialog
{
    public class ExitViewModel : BindableBase, IDialogHostAware  
    {
        public ExitViewModel()
        {
            CancelCommand = new DelegateCommand(Cancel);
            ConfirmCommand = new DelegateCommand(Confirm);
        }
        private void Cancel() 
        {
            if(DialogHost.IsDialogOpen(DialogHostName))
                 DialogHost.Close(DialogHostName);
        }
        private void Confirm()
        {
            if (DialogHost.IsDialogOpen(DialogHostName))
            {
                if (Mychoice.Choice == true)
                    Application.Current.Shutdown();
                else if(Mychoice.Choice == false)
                {
                    DialogHost.Close(DialogHostName);
                    Application.Current.MainWindow.Hide();
                }
            }
        }

        //mychoice是判斷我選擇哪一種關閉方式
        private ChoicesDto mychoice;

        public ChoicesDto Mychoice
        {
            get { return mychoice; }
            set { mychoice = value; RaisePropertyChanged(); }
        }

        public string DialogHostName { get ; set; }
        public DelegateCommand CancelCommand { get ; set ; }
        public DelegateCommand ConfirmCommand { get; set; }
        public void OnDialogOpend(IDialogParameters parameters)
        {
            Mychoice = new ChoicesDto();
        }
    }
}

using MyToDo.Common;
using MyToDo.Common.Models;
using MyToDo.Extensions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Services.Dialogs;

namespace MyToDo.ViewModels
{
    public class MainViewModel :BindableBase, IConfigureService
    {
        public string Username;
        //IRegionManager是prism自带的接口
        public MainViewModel(IDialogHostService dialog, IRegionManager regionManager, IContainerProvider containerProvider) 
        {
            //CreateMenuBar();
            MenuBars = new ObservableCollection<MenuBar>();

            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
            //放到初始化函數中
            //CreateMenuBar();
            ExitCommand = new DelegateCommand(ShowExit);

            GoBackCommand = new DelegateCommand(() =>
            {
                if (journal!=null && journal.CanGoBack)
                    journal.GoBack();

            });
            GoForwardCommand = new DelegateCommand(() =>
            {
                if (journal != null && journal.CanGoForward)
                    journal.GoForward();
            });
            this.regionManager = regionManager;
            this.dialog = dialog;
            this.containerProvider = containerProvider;
        }


        private void Navigate(MenuBar obj)
        {
            if (obj == null || string.IsNullOrWhiteSpace(obj.NameSpace))
                return;

            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(obj.NameSpace, back =>
            {
                journal = back.Context.NavigationService.Journal;
            });
        }

         void ShowExit()
        {
            dialog.ShowDialog("ExitView", null);
        }

        //驅動整個導航功能
        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }
        private readonly IRegionManager regionManager;
        private IRegionNavigationJournal journal;
        private readonly IDialogHostService dialog;

        public DelegateCommand ExitCommand { get; private set; }
        public DelegateCommand GoBackCommand { get; private set; }
        public DelegateCommand GoForwardCommand { get; private set; }

        public ObservableCollection<MenuBar> menuBars;

        public ObservableCollection<MenuBar> MenuBars
        {
            get { return menuBars; }
            set { menuBars = value; RaisePropertyChanged();}
        }

        private readonly IContainerProvider containerProvider;

        void CreateMenuBar()
        {
            MenuBars.Add(new MenuBar() { Icon = "Home", Title = "首頁", NameSpace = "IndexView"});
            MenuBars.Add(new MenuBar() { Icon = "Account", Title = "用户", NameSpace = "UserDataTestView" });
            MenuBars.Add(new MenuBar() { Icon = "Cog", Title = "設置", NameSpace = "SettingView"});
            
        }

        public void Configure()
        {
            CreateMenuBar();
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate("IndexView");
        }
    }
}

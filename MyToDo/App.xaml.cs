using DryIoc;
using MyToDo.Common;
using MyToDo.Service;
using MyToDo.ViewModels;
using MyToDo.ViewModels.Dialog;
using MyToDo.ViewModels.TestViewModels;
using MyToDo.Views;
using MyToDo.Views.Dialog;
using MyToDo.Views.TestViews;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using Hardcodet.Wpf.TaskbarNotification;
using MyToDo.Extensions;
using MyToDo.Service.TestService;

namespace MyToDo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
            
        }

        private TaskbarIcon _taskbar;

        protected override void OnInitialized()
        {
            //var Service = App.Current.MainWindow.DataContext as IConfigureService;
            //if (Service != null)
            //{
            //    Service.Configure();
            //}
            //base.OnInitialized();
            //WindowsTaskbarIcon.Open();

            _taskbar = (TaskbarIcon)FindResource("Taskbar");
            var dialog = Container.Resolve<IDialogService>();
            
            dialog.ShowDialog("LoginView", callback =>
            {
                if (callback.Result != ButtonResult.OK)
                {
                    Application.Current.Shutdown();
                    return;
                }
                else if(callback.Result == ButtonResult.OK) { 
                    var service = App.Current.MainWindow.DataContext as IConfigureService;
                    if (service != null)
                        service.Configure();
                    base.OnInitialized();
                }
            });




        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.GetContainer()
                .Register<HttpRestClient>(made: Parameters.Of.Type<string>(serviceKey: "webUrl"));

            containerRegistry.GetContainer().RegisterInstance(@"http://127.0.0.1:3000/", serviceKey: "webUrl");

            containerRegistry.Register<ILoginService,LoginService>();
            containerRegistry.Register<ITestLoginService, TestLoginService>();
            containerRegistry.Register<IDialogHostService, DialogHostService>();

            containerRegistry.RegisterDialog<LoginView, LoginViewModel>();
            containerRegistry.RegisterForNavigation<ExitView, ExitViewModel>();
            containerRegistry.RegisterForNavigation<AddMouseUser, AddMouseUserModel>();

            
            containerRegistry.RegisterForNavigation<SysSettingView, SysSettingViewModel>();
            containerRegistry.RegisterForNavigation<AboutUsView, SysSettingViewModel>();

            containerRegistry.RegisterForNavigation<IndexView, IndexViewModel>();
            containerRegistry.RegisterForNavigation<UserDataView, UserDataViewModel>();
            containerRegistry.RegisterForNavigation<SettingView, SettingViewModel>();
            containerRegistry.RegisterForNavigation<UserDataTestView, UserDataTestViewModel>();
        }
    }
}

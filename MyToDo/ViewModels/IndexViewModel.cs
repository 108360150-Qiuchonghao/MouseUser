using MyToDo.Common;
using MyToDo.Common.Models;
using MyToDo.Extensions;
using MyToDo.Shared.Dtos;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MyToDo.ViewModels
{
    public class IndexViewModel : NavigationViewModel
    {
        private int i = 0;
        private readonly IRegionManager regionManager;
        public IndexViewModel(IContainerProvider provider, IDialogHostService dialog) : base(provider)
        {
            UpdateLoading(true);
            TaskBars = new ObservableCollection<TaskBar>();
            MouseUsers = new ObservableCollection<MouseUserDto>();
            timer.Tick += new EventHandler(Timer_Tick);
            //timer.Interval = TimeSpan.FromSeconds(1); //设置刷新的间隔时间
            timer.Start();

            this.regionManager = provider.Resolve<IRegionManager>();
            this.dialog = dialog;
            NavigateCommand = new DelegateCommand<TaskBar>(Navigate);
            ShowAddCommand = new DelegateCommand(ShowAdd);

            CreateTaskBars();
            UpdateLoading(false);
        }
        
        public DelegateCommand<TaskBar> NavigateCommand { get; private set; }
        public DelegateCommand ShowAddCommand { get; private set; }
        private readonly IDialogHostService dialog;

        private ObservableCollection<TaskBar> taskBars;
        public ObservableCollection<TaskBar> TaskBars
        {
            get{ return taskBars; }
            set { taskBars = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<MouseUserDto> mouseusers;
        public ObservableCollection<MouseUserDto> MouseUsers
        {
            get { return mouseusers; }
            set { mouseusers = value; RaisePropertyChanged(); }
        }

        DispatcherTimer timer = new DispatcherTimer();
        long _start;
         void Timer_Tick(object sender, EventArgs e)
        {
            i++;
            Title = $"您好，{AppSession.UserName}，現在是{DateTime.Now.GetDateTimeFormats('f')[0].ToString()}，測試{i}";
            
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged(); }
        }

        //添加新滑鼠用戶
        void ShowAdd()
        {
            dialog.ShowDialog("AddMouseUser", null);
        }
        private void Navigate(TaskBar obj)
        {
            if(string.IsNullOrWhiteSpace(obj.Target)) return;

            NavigationParameters param = new NavigationParameters();
            ToName.Name = obj.Title;
            if (MouseUsers.Count != 0)
            {
                int index = 0;
                foreach (MouseUserDto mouseUserDto in MouseUsers)
                {
                    if (mouseUserDto.User_ID == ToName.Name)
                        ToName.index = index;
                    else
                        index++;
                }
            }
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(obj.Target, param);
            aggregator.SendMessage("成功跳轉");
        }
        private string Userstatus;
        private string color;
        void CreateTaskBars() 
        {
            GetUsers();
            foreach (MouseUserDto mouseUser in MouseUsers)
            {
                if (mouseUser.Status == true)
                {
                    Userstatus = "在線";
                    color = "#FF607D8B";
                }

                else
                {
                    Userstatus = "離線";
                    color = "#FFFE526B";
                }
                TaskBars.Add(new TaskBar() { Icon = "ChartLineVariant", Title = mouseUser.User_ID, Content = Userstatus, Color = color, Target = "UserDataTestView" });
            }
            //TaskBars.Add(new TaskBar() { Icon = "ChartLineVariant" ,Title = "Allen", Content = "心率異常", Color = "#FFFE526B", Target = "UserDataTestView" }); 
            //TaskBars.Add(new TaskBar() { Icon = "ChartLineVariant", Title = "阿翔", Content = "生理體征正常", Color = "#FF607D8B", Target = "UserDataTestView" }); 
            //TaskBars.Add(new TaskBar() { Icon = "ChartLineVariant", Title = "宇倫", Content = "生理體征正常", Color = "#FF607D8B", Target = "UserDataTestView" }); 
            //TaskBars.Add(new TaskBar() { Icon = "ChartLineVariant", Title = "展毅", Content = "生理體征正常", Color = "#FF607D8B", Target = "UserDataTestView" }); 
        }



        private async void GetUsers() 
        {
            //1.從API接口得到所有屬於這個admin的mouseuser
            //var GetUsersResult = new List<MouseUserDto>();
            MouseUsers.Add(new MouseUserDto { Mouse_ID = "1", User_ID = "Allen", Status = true});
            MouseUsers.Add(new MouseUserDto { Mouse_ID = "2", User_ID = "阿翔", Status = false});
            MouseUsers.Add(new MouseUserDto { Mouse_ID = "3", User_ID = "宇倫", Status = false});
            MouseUsers.Add(new MouseUserDto { Mouse_ID = "4", User_ID = "展毅", Status = false});
            //2.不斷維護這個list
            //

        }

    }
}

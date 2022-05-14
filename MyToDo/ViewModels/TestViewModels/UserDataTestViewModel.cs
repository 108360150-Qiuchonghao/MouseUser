using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using MyToDo.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using Prism.Mvvm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Prism.Commands;
using MyToDo.Shared.Dtos;
using MyToDo.Common;
using Prism.Regions;
using Prism.Ioc;
using LiveCharts;
using MyToDo.Common.TestData;
using System.Windows;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System.Windows.Media;

namespace MyToDo.ViewModels.TestViewModels
{
    public class UserDataTestViewModel : NavigationViewModel
    {
        public UserDataTestViewModel(IContainerProvider provider) : base(provider)
        {
            TimeBarIndex = 0;
            NameIndex = 0;
            TaskBars = new ObservableCollection<TaskBar>();
            TimeBars = new ObservableCollection<TimeBar>();
            NameBars = new ObservableCollection<MouseUserDto>();
            Fakedates1 = new List<List<TimeBar>>();
            CreateTimeBars();
            CreateTaskBars();
            CreateNameBars();
            CreateFakeDates();
            CreateFakechartData();

            NameSelectedItem = NameBars.FirstOrDefault();
            TimeSelectedItem = TimeBars.FirstOrDefault();
            //右侧弹窗的指令
            modifycommand = new DelegateCommand(Modify);
            ModifyTrue = new DelegateCommand(modifytrue);
            Modifycancel = new DelegateCommand(modifycancel);

            NameListselect = new DelegateCommand(namelistselect);
            Timelistselect = new DelegateCommand(timelistselect);

            //圖表初始化
            ZoomingMode = ZoomingOptions.X;
            XFormatter = val => new DateTime((long)val).ToString("dd MMM");
            YFormatter = val => val.ToString("C");
            //new圖表假數據

            HRData = new ChartValues<double> { 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160, 80, 81, 83, 90, 100, 160 };

            Dt_TickAsync();
            
        }
        //重寫導航事件
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            FindName();
            FindDate();
            
        }

        private int nameindex;

        /// <summary>
        /// 下拉列表选中状态值
        /// </summary>
        public int NameIndex
        {
            get { return nameindex; }
            set { nameindex = value; RaisePropertyChanged(); }
        }

        //寻找对应的那个人
        private void FindName()
        {
            if (NameBars.Count != 0) { 
                int index = 0;
                foreach (MouseUserDto mouseUserDto in NameBars)
                {
                    if (mouseUserDto.User_ID == ToName.Name)
                        NameIndex = index;
                    else
                        index++;
                }
            }
        }

        #region SelectedItem
        private MouseUserDto nameselectedItem;

        /// <summary>
        /// 
        /// </summary>
        public MouseUserDto NameSelectedItem
        {
            get { return nameselectedItem; }
            set { nameselectedItem = value; RaisePropertyChanged(); }
        }

        private TimeBar timeselectedItem;

        /// <summary>
        /// 
        /// </summary>
        public TimeBar TimeSelectedItem
        {
            get { return timeselectedItem; }
            set { timeselectedItem = value; RaisePropertyChanged(); }
        }

        #endregion
        //寻找对应人的时间
        private void FindDate()
        {
            TimeBars.Clear();
            if (NameBars.Count != 0)
            {
                int index = 0;
                foreach (MouseUserDto mouseUserDto in NameBars)
                {
                    if (mouseUserDto.User_ID == ToName.Name)
                        if (Fakedates1[index].Count != 0)
                            TimeBars.AddRange(Fakedates1[index]);
                        else
                        {
                            TimeBars.Add(new TimeBar { Date = "無數據"});
                        }
                    else
                        index++;
                }
            }
            TimeBarIndex = 0;
        }

        private int timebarindex;

        /// <summary>
        /// 下拉列表选中状态值
        /// </summary>
        public int TimeBarIndex
        {
            get { return timebarindex; }
            set { timebarindex = value; RaisePropertyChanged(); }
        }

        static HttpClient client = new HttpClient();

        //按下修改按钮后的右侧弹窗是否开启参数
        private bool isRightDrawerOpen;

        public bool IsRightDrawerOpen
        {
            get { return isRightDrawerOpen; }
            set { isRightDrawerOpen = value; RaisePropertyChanged(); }
        }

        #region 修改用户信息按钮的command
        private void Modify() 
        {
            IsRightDrawerOpen = true;
        }
        private void modifytrue()
        {
            IsRightDrawerOpen = false;
        }

        private void modifycancel()
        {
            IsRightDrawerOpen = false;
        }

        //修改用户信息按钮的command start
        public DelegateCommand modifycommand { get;  private set;}
        public DelegateCommand ModifyTrue { get; private set; }
        public DelegateCommand Modifycancel { get; private set; }
        //修改用户信息按钮的command end
        #endregion



        #region 名字和日期combobox的command
        private void namelistselect() 
        {
            ToName.Name = NameSelectedItem.User_ID;
            FindDate();
        }

        public DelegateCommand NameListselect{ get; private set; }


        private void timelistselect()
        {
            
        }

        public DelegateCommand Timelistselect { get; private set; }


        #endregion

        public ISeries[] Series { get; set; }
        public LiveCharts.Wpf.Axis[] XAxes1 { get; set; }

        private async void Dt_TickAsync( )
        {
            string AllDate = await GetAPIAsync("http://localhost:3000/api/history/2");


            List<History> histories = JsonConvert.DeserializeObject<List<History>>(AllDate);
            //String sResult = "API Result on api/article" + Environment.NewLine + "Time" + ans.time + Environment.NewLine + "temp" + ans.temp
            //    + Environment.NewLine + "HR" + ans.SPO2 + Environment.NewLine + "mouse_id" + ans.u_mouse_id;
            //Data = sResult;
            //lsDate = ConfirmDate(histories);
            //Data = history.time.ToString("yyyy-MM-dd HH:mm:ss"); 
        }

        public List<string> ConfirmDate(List<History> histories) 
        {
            DateTime tempDate = histories[0].time;
            List<string> backDate = new List<string>();
            foreach (History history in histories)
            {
                backDate.Add(history.time.ToString("yyyy年MM月dd日"));
            }
            return backDate;
        }

        //自定义去重函数



        public class History
        {
            public DateTime time { set; get; }
            public int temp { set; get; }
            public int HR { set; get; }
            public int SPO2 { set; get; }
            public int u_mouse_id { set; get; }
        }

        static async Task<string> GetAPIAsync(string path)
        {
            string project = null;
            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)

            {
                project = await response.Content.ReadAsStringAsync();
            }

            return project;

        }

        private ObservableCollection<TimeBar> timeBars;

        public ObservableCollection<TimeBar> TimeBars
        {
            get { return timeBars; }
            set { timeBars = value; RaisePropertyChanged(); }
        }

        //新建一个List，存放所有的日期，按照mouseid或者用户名寻找。


        //要和combobox绑定的class
        private ObservableCollection<TaskBar> taskBars;

        public ObservableCollection<TaskBar> TaskBars
        {
            get { return taskBars; }
            set { taskBars = value; RaisePropertyChanged(); }
        }


        private ObservableCollection<MouseUserDto> namebars;

        public ObservableCollection<MouseUserDto> NameBars
        {
            get { return namebars; }
            set { namebars = value; RaisePropertyChanged(); }
        }

        

        void CreateNameBars() 
        {
            GetUsers();
            //NameBars.Add(new MouseUserDto{User_ID = "Allen" });  
            //NameBars.Add(new MouseUserDto{User_ID = "阿翔" });  
            //NameBars.Add(new MouseUserDto{User_ID = "宇倫" });  
            //NameBars.Add(new MouseUserDto{User_ID = "展毅" });  
        }

        void CreateTimeBars()
        {
            TimeBars.Add(new TimeBar() { Date = "2022年3月17日", Time = "" });
            TimeBars.Add(new TimeBar() { Date = "2022年3月16日", Time = "" });
            TimeBars.Add(new TimeBar() { Date = "2022年3月15日", Time = "" });
        }

        void CreateTaskBars()
        {
            TaskBars.Add(new TaskBar() { Icon = "CardsHeart", Title = "心率", Content = "70bpm", Color = "#FFD6D6D6", Target = "" });
            TaskBars.Add(new TaskBar() { Icon = "LiquidSpot", Title = "血氧濃度", Content = "98%", Color = "#FFD6D6D6", Target = "" });
            TaskBars.Add(new TaskBar() { Icon = "Thermometer", Title = "體溫", Content = "37℃", Color = "#FFD6D6D6", Target = "" });
        }

        //从APi接口得到所有关于每个人的Date
        private void GetMembers() {
        
        }

        


        private  void GetUsers()
        {
            //1.從API接口得到所有屬於這個admin的mouseuser
            //var GetUsersResult = new List<MouseUserDto>();
            NameBars.Add(new MouseUserDto { Mouse_ID = "1", User_ID = "Allen", Status = true });
            NameBars.Add(new MouseUserDto { Mouse_ID = "2", User_ID = "阿翔", Status = false });
            NameBars.Add(new MouseUserDto { Mouse_ID = "3", User_ID = "宇倫", Status = false });
            NameBars.Add(new MouseUserDto { Mouse_ID = "4", User_ID = "展毅", Status = false });
            //2.不斷維護這個list
            //
        }

        private async void GetUser_Date()
        {
            
            //var GetUser_Date_Result = List<HistoryDto> 
           
        }

        #region livecharts圖表

        public SeriesCollection SeriesCollection { get; set; }
        public Func<double, string> XFormatter { get; set; }
        public Func<double, string> YFormatter { get; set; }

        #region zoommode

        private ZoomingOptions zoomingmode;

        public ZoomingOptions ZoomingMode
        {
            get { return zoomingmode; }
            set { zoomingmode = value; RaisePropertyChanged(); }
        }

        private void ToogleZoomingMode(object sender, RoutedEventArgs e)
        {
            switch (ZoomingMode)
            {
                case ZoomingOptions.None:
                    ZoomingMode = ZoomingOptions.X;
                    break;
                case ZoomingOptions.X:
                    ZoomingMode = ZoomingOptions.Y;
                    break;
                case ZoomingOptions.Y:
                    ZoomingMode = ZoomingOptions.Xy;
                    break;
                case ZoomingOptions.Xy:
                    ZoomingMode = ZoomingOptions.None;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        #endregion
        private ChartValues<DateTimePoint> GetData()
        {
            var r = new Random();
            var trend = 100;
            var values = new ChartValues<DateTimePoint>();

            for (var i = 0; i < 100; i++)
            {
                var seed = r.NextDouble();
                if (seed > .8) trend += seed > .9 ? 50 : -50;
                values.Add(new DateTimePoint(DateTime.Now.AddDays(i), trend + r.Next(0, 10)));
            }

            return values;
        }

        //還原圖表的按鈕
        private void ResetZoomOnClick(object sender, RoutedEventArgs e)
        {
            //Use the axis MinValue/MaxValue properties to specify the values to display.
            //use double.Nan to clear it.

            //X.MinValue = double.NaN;
            //X.MaxValue = double.NaN;
            //Y.MinValue = double.NaN;
            //Y.MaxValue = double.NaN;
        }
        #endregion

        #region fake data region
        private List<List<TimeBar>> fakedates1;

        public List<List<TimeBar>> Fakedates1
        {
            get { return fakedates1; }
            set { fakedates1 = value; RaisePropertyChanged(); }
        }

        private void CreateFakeDates()
        {
            Fakedates1.Add(new List<TimeBar>());
            Fakedates1.Add(new List<TimeBar>());
            Fakedates1.Add(new List<TimeBar>());
            Fakedates1.Add(new List<TimeBar>());
            Fakedates1[0].Add(new TimeBar() { Date = "2022年3月17日", Time = "" });
            Fakedates1[0].Add(new TimeBar() { Date = "2022年3月18日", Time = "" });
            Fakedates1[0].Add(new TimeBar() { Date = "2022年3月19日", Time = "" });

            Fakedates1[1].Add(new TimeBar() { Date = "2022年3月20日", Time = "" });
            Fakedates1[1].Add(new TimeBar() { Date = "2022年3月21日", Time = "" });
            Fakedates1[1].Add(new TimeBar() { Date = "2022年3月22日", Time = "" });

            Fakedates1[2].Add(new TimeBar() { Date = "2022年3月23日", Time = "" });
            Fakedates1[2].Add(new TimeBar() { Date = "2022年3月24日", Time = "" });



        }


        #region 圖表假數據
        
        //1.线条显示数值: DataLabels="True"
        //2.线条是否弯曲: LineSmoothness="0" 或 "1" 
        //3.线条的颜色: Stroke="Red"  //设置线条的颜色为红色
        //4.线条下方颜色: Fill="Pink" //线条的下方颜色
        //5.线条的每个点: PointGeometrySize="20" //设置数据点大小
        //6.显示数据字体颜色: Foreground="Red" 
        //7.数据点的颜色: PointForeground="#FF6347"
        //8.线条虚线: StrokeDashArray="5" //数值愈大间隔愈大, 如下绿色虚线


        public ChartValues<double> HRData { get; set; }

        private void CreateFakechartData() 
        {
            var gradientBrush = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(0, 1)
            };
            gradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(33, 148, 241), 0));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Transparent, 1));

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Values = GetData(),
                    Fill = gradientBrush,
                    StrokeThickness = 1,
                    PointGeometrySize = 0
                }
            };
        }
        #endregion


        #endregion
    }




}

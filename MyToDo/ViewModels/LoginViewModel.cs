using MyToDo.Common;
using MyToDo.Extensions;
using MyToDo.Service;
using MyToDo.Service.TestService;
using MyToDo.Shared.Dtos;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyToDo.ViewModels
{
    public class LoginViewModel : BindableBase, IDialogAware
    {


        // private readonly IEventAggregator aggregator;
        //ILoginService loginService, IEventAggregator aggregator
        public LoginViewModel(IEventAggregator aggregator, ITestLoginService loginService)
        {
            UserDto = new ResgiterUserDto();
            ExecuteCommand = new DelegateCommand<string>(Execute);
            this.loginService = loginService;
            this.aggregator = aggregator;
        }

        private readonly ITestLoginService loginService;
        private readonly IEventAggregator aggregator;
        public string Title { get; set; }

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            LoginOut();
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            
        }

        public DelegateCommand<string> ExecuteCommand { get; private set; }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string account;

        public string Account
        {
            get { return account; }
            set { account = value; }
        }


        public void Execute(string arg)
        {
            switch (arg)
            {
                case "Login":
                    Login();
                    break;
                case "LoginOut":
                    LoginOut();
                    break;
                case "Go":
                    SelectIndex = 1;
                    break;
                case "Return":
                    SelectIndex = 0;
                    break;
                case "Register":
                    Resgiter();
                    break;
            }
        }

        private async void Resgiter()
        {
            if (string.IsNullOrWhiteSpace(UserDto.Account) ||
                string.IsNullOrWhiteSpace(UserDto.UserName) ||
                string.IsNullOrWhiteSpace(UserDto.PassWord) ||
                string.IsNullOrWhiteSpace(UserDto.NewPassWord))
            {
                aggregator.SendMessage("请输入完整的注册信息！", "Login");
                return;
            }

            if (UserDto.PassWord != UserDto.NewPassWord)
            {
                aggregator.SendMessage("密码不一致,请重新输入！", "Login");
                return;
            }

            var resgiterResult = await loginService.Resgiter(new Shared.Dtos.UserDto()
            {
                Account = UserDto.Account,
                UserName = UserDto.UserName,
                PassWord = UserDto.PassWord
                
            });

            if (resgiterResult != null && resgiterResult.Status)
            {
                //aggregator.SendMessage("注册成功", "Login");
                //注册成功,返回登录页页面
                SelectIndex = 0;
            }
            else { }
            //aggregator.SendMessage(resgiterResult.Message, "Login");
        }

        private int selectIndex;

        public int SelectIndex
        {
            get { return selectIndex; }
            set { selectIndex = value; RaisePropertyChanged(); }
        }

        private ResgiterUserDto userDto;

        public ResgiterUserDto UserDto
        {
            get { return userDto; }
            set { userDto = value; RaisePropertyChanged(); }
        }

        async void Login()
        {
            if (string.IsNullOrWhiteSpace(Account) || string.IsNullOrWhiteSpace(Password))
            {
                return;
            }
                //去api抓賬號密碼
                var loginResult = await loginService.Login(new Shared.Dtos.AdminDto()
                {
                    account = Account,
                    password = Password
                });

                if (loginResult != null && loginResult.Message == "Login Successfully")
                {
                     aggregator.SendMessage("登錄成功", "Login");
                    
                    AppSession.UserName = Account;
                    RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
                }
                else
                {
                    aggregator.SendMessage("賬號密碼錯誤", "Login");
                }
        }

        void LoginOut()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.No));
        }
    }
}

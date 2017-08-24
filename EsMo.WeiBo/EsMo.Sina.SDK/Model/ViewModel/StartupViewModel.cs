using EsMo.Sina.Model.Person;
using EsMo.Sina.SDK.Resource;
using EsMo.Sina.SDK.Service;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EsMo.Sina.SDK.Model
{
    public class StartupViewModel : BaseViewModel
    {
        IAccountService accountService;
        internal const string LoginUrl = "LoginUrl";
        string loginUrl;
        public StartupViewModel(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        bool isLoggingIn=false;

        public bool IsLoggingIn
        {
            get
            {
                return isLoggingIn;
            }

            private set
            {
                this.RaiseAndSetIfChanged(ref isLoggingIn, value, () => this.IsLoggingIn);
            }
        }
        string statusText;
        public string StatusText
        {
            get
            {
                return statusText;
            }
            private set
            {
                this.RaiseAndSetIfChanged(ref statusText, value, () => this.StatusText);
            }
        }
        string profileUrl;
        public string ProfileUrl
        {
            get
            {
                return profileUrl;
            }
            private set
            {
                this.RaiseAndSetIfChanged(ref profileUrl, value, () => this.ProfileUrl);
            }
        }
        public Stream UnknownProfile
        {
            get { return this.GetApplication().ResourceCache.Get(AssetsHelper.login_user_unknown.ToAssetsImage()); }
        }
        protected override void InitFromBundle(IMvxBundle parameters)
        {
            base.InitFromBundle(parameters);
            loginUrl = parameters.Data[LoginUrl];
        }
        public ICommand StartupCommand
        {
            get { return new MvxAsyncCommand(Startup); }
        }

        async Task Startup()
        {
            this.IsLoggingIn = true;
            this.StatusText = AppResources.Loading + " " + AppResources.User;
            Account account = await this.accountService.LoginWithToken(loginUrl);
            Debug.WriteLine("Login account");
            await Task.Delay(1000);
            if (account != null)
            {
                this.GetApplication().Account = account;
                await this.accountService.InitialUserShow(account);
                Debug.WriteLine("Get AccountShow");
                
                this.StatusText = AppResources.Loading + " " + account.Show.ScreenName;
                this.ProfileUrl = account.Show.ProfileImageUrl;
                await Task.Delay(2000);
                await this.accountService.InitialAccountInfo(account);
                Debug.WriteLine("Initial Account");
                this.ShowViewModel<MenuViewModel>();
                this.ShowViewModel<MainViewModel>();
            }
            this.IsLoggingIn = false;
        }
    }
}

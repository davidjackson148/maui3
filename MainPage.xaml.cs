
using Onsidaca.Mobile;
using Onsidaca.Mobile.Models;
using Onsidaca.Mobile.Services;

namespace Onsidaca.MAU;

public partial class MainPage : ContentPage
{
	private readonly ConnectionService _connectionService;
    //private readonly DataService _dataService;
    public MainPage(ConnectionService connectionService)//, DataService dataService)
	{
		_connectionService = connectionService;
        //_dataService = dataService;

        InitializeComponent();

//removed
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
    private async void btnLogin_Clicked(object sender, EventArgs e)
	{
        string sEmail = txtEmail.Text;
        string sPassword = txtPassword.Text;

        actMain.IsVisible = true;

        JsonApiResult result = await _connectionService.SignIn(sEmail, sPassword);

        if (result.Result == "fail")
        {
            await DisplayAlert("Login", result.Message, "OK");
        }
        else if (result.Result == "success")
        {
            //result.
            // Data = email/username
            // message = secure token
            // Result = password/message

            result.Result = sPassword;

            Database.LoginToken = result.Message;

            UserInfo user = new UserInfo { UserName = result.Data, Password = result.Result, Token = result.Message };

            await Database.DeleteUserInfoAsync(user.UserName);

            await Database.SaveUserInfoAsync(user);

            //await DisplayAlert("Login", $"Token: {result.Message}", "OK");

            //await Navigation.PushAsync(new Pages.StartPage(result), true);
            await Shell.Current.GoToAsync(nameof(Pages.StartPage), true, new Dictionary<string, object>
            {
                { "LoginData", result }
            });
        }

        actMain.IsRunning = false;
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
	{
        Environment.Exit(0);
	}

    private async void btnTest_Clicked(object sender, EventArgs e)
    {
        UserInfo info = await Database.GetFirstUserInfoAsync();

        await DisplayAlert(info.UserName, FileSystem.AppDataDirectory, "OK");

        await Shell.Current.GoToAsync(nameof(Pages.StartPage), true);
        // /data/user/0/com.companyname.onsidaca.mau/files
    }
}


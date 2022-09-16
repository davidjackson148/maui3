using Onsidaca.Mobile;
using Onsidaca.Mobile.Models;
using Onsidaca.Mobile.Services;
using Syncfusion.Maui.Core.Hosting;
namespace Onsidaca.MAU.Pages;

[QueryProperty(nameof(GetLoginData), "LoginData")]
public partial class StartPage : ContentPage
{
    private readonly ConnectionService _connectionService;
    private readonly DataService _dataService;
    private JsonApiResult _loginData;
    public JsonApiResult GetLoginData { set { _loginData = value; }  }

    public StartPage(ConnectionService connectionService, DataService dataService)
	{
		InitializeComponent();

        AddMenuItems();

        _connectionService = connectionService;
        _dataService = dataService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await DisplayAlert("Token", Database.LoginToken, "OK");
    }

    private void AddMenuItems()
    {
        //string[] menuItems = { "Sync", "Weather", "Location", "Barcode", "Database" };
        string[] menuItems = { "Sync Data", "Day View", "Week View", "Month View", "Agenda View" };

        foreach (string menuItem in menuItems)
        {
            ToolbarItem item = new ToolbarItem
            {
                Text = menuItem,
                //IconImageSource = ImageSource.FromFile("example_icon.png"),
                Order = ToolbarItemOrder.Secondary,
                Priority = 0
            };

            item.Clicked += Item_Clicked;

            // "this" refers to a Page object
            this.ToolbarItems.Add(item);
        }
    }
    private async void calSchedule_DoubleTapped(object sender, Syncfusion.Maui.Scheduler.SchedulerDoubleTappedEventArgs e)
	{
        if (e.Appointments != null)
            //await Navigation.PushAsync(new Pages.ClaimsPage(e.Date), true);
            await DisplayAlert("Onsidaca Mobile", $"Go to Claim Appointment {e.Date}", "OK");
        else
            await DisplayAlert("Onsidaca Mobile", $"There are no appointments on {e.Date?.ToString("dd-MMM-yyyy")}", "OK");

    }

    private void Item_Clicked(object sender, EventArgs e)
    {
        ToolbarItem t = (ToolbarItem)sender;

        if (t.Text == "Sync Data")
        {
            SynchroniseClaims();
        }
        else
        {
            switch (t.Text)
            {
                case "Day View":
                    calSchedule.View = Syncfusion.Maui.Scheduler.SchedulerView.Day;
                    break;
                case "Week View":
                    calSchedule.View = Syncfusion.Maui.Scheduler.SchedulerView.Week;
                    break;
                case "Month View":
                    calSchedule.View = Syncfusion.Maui.Scheduler.SchedulerView.Month;
                    break;
                case "Agenda View":
                    calSchedule.View = Syncfusion.Maui.Scheduler.SchedulerView.Agenda;
                    break;
            }
            //Type pageType = Type.GetType($"Onsidaca.Mobile.Pages.{t.Text}Page");

            ////var page = new NavigationPage(Activator.CreateInstance(pageType) as Page);
            //var page = Activator.CreateInstance(pageType) as Page;

            //await Navigation.PushAsync(page, true);
        }
    }

    private void SynchroniseClaims()
    {
        //pgBar.IsVisible = true;
        //pgBar.Progress = 0;

        //string secureToken = _result.Message;

        ////clear out the database
        //_dataService.DeleteAllClaims();

        //JsonApiResult dataResult = await _connectionService.GetMyAssignedClaimsMobile(secureToken);

        //if (dataResult.Data.Count > 0)
        //{
        //    pgBar.SegmentCount = dataResult.Data.Count;
        //    pgBar.Minimum = 0;
        //    pgBar.Maximum = dataResult.Data.Count;

        //    foreach (string claim in dataResult.Data)
        //    {
        //        JsonApiResult claimResult = await _connectionService.GetMyAssignedClaim(claim, secureToken);
        //        string saveResult = await _dataService.SaveMyAssignedClaim(claimResult);

        //        if (saveResult != "success")
        //            await DisplayAlert("Onsidaca Mobile", $"Sync Error: {saveResult}", "OK");

        //        pgBar.Progress += 1;
        //    }
        //}

        //await ShowAllClaims();

        //pgBar.IsVisible = false;
    }

    //private async Task<int> ShowAllClaims()
    //{
    //    //calSchedule.DataSource = await _dataService.GetDisplaySchedulesAsync();

    //    return 0;
    //}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Toolbar", "Clicked", "Exit");
    }
}
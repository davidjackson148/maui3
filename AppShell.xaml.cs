namespace Onsidaca.MAU;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(Pages.StartPage), typeof(Pages.StartPage));
	}
}

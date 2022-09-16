using Onsidaca.Mobile;

namespace Onsidaca.MAU;

public partial class App : Application
{
    public App()
	{
		InitializeComponent();

        string path = Path.Combine(FileSystem.AppDataDirectory, "onsidaca.db3");

        _ = Database.NewDatabase(path);

        MainPage = new AppShell();
	}
}

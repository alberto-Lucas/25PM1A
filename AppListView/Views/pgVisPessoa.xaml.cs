namespace AppListView.Views;

public partial class pgVisPessoa : ContentPage
{
	public pgVisPessoa()
	{
		InitializeComponent();
	}

    private async void btnVoltar_Clicked(object sender, EventArgs e)
    {
		await Application.Current.MainPage.
			Navigation.PopAsync();
    }
}
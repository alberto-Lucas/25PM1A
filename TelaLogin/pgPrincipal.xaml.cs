namespace TelaLogin;

public partial class pgPrincipal : ContentPage
{
	public pgPrincipal()
	{
		InitializeComponent();
	}

    private void btnVoltar_Clicked(object sender, EventArgs e)
    {
		Application.Current.MainPage.
			Navigation.PopAsync();
    }
}
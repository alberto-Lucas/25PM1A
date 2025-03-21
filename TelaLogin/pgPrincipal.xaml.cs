namespace TelaLogin;

public partial class pgPrincipal : ContentPage
{
	public pgPrincipal()
	{
		InitializeComponent();

		//Vamos recuperar o usuario
		//q esta na singleton
		var usuarioLogado = UsuarioLogado.Instancia;
        txtUsuarioLogado.Text = usuarioLogado.Login;


    }

    private void btnVoltar_Clicked(object sender, EventArgs e)
    {
		Application.Current.MainPage.
			Navigation.PopAsync();
    }
}
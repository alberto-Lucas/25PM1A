namespace TelaLogin;

public partial class pgPrincipal : ContentPage
{
	public pgPrincipal()
	{
		InitializeComponent();

		//Vamos recuperar o usuario
		//q esta na singleton
		var usuarioLogado = UsuarioLogado.Instancia;

		txtNome.Text  = "Nome: "  + usuarioLogado.Nome;
		txtLogin.Text = "Login: " + usuarioLogado.Login;
		txtSenha.Text = "Senha: " + usuarioLogado.Senha;
		txtEmail.Text = "Email: " + usuarioLogado.Email;
		txtIdade.Text = "Idade: " + usuarioLogado.Idade;
		imgPerfil.Source = 
			usuarioLogado.DiretorioImagem;


    }

    private void btnVoltar_Clicked(object sender, EventArgs e)
    {
		Application.Current.MainPage.
			Navigation.PopAsync();
    }
}
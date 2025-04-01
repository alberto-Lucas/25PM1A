namespace TelaLogin;

public partial class pgRegistro : ContentPage
{
	public pgRegistro()
	{
		InitializeComponent();
	}

    private void btnSalvar_Clicked(object sender, EventArgs e)
    {
		//Variavel para referenciar 
		//a instancia da classe singleton

		var usuarioLogado = UsuarioLogado.Instancia;

		usuarioLogado.Nome = txtNome.Text;
		usuarioLogado.Login = txtLogin.Text;
		usuarioLogado.Senha = txtSenha.Text;
		usuarioLogado.Email = txtEmail.Text;
		usuarioLogado.Idade = txtIdade.Text;

		//Recupero o diretorio da imagem
		//e salvo na classe singleton
		//Ex: c:/imagens/aula - Windows
		//Ex: gaeria/whatsappImagem - Android
		usuarioLogado.DiretorioImagem = 
			DirImagem;

		DisplayAlert("Informa��o",
					"Cadastro realizado com sucesso",
					"OK");

        //Application o proprio projeto
        //Current tela em execu��o no momento
        //MainPage � a tela aberta para o usuario
        //Navigation � navega��o em si 
        //A��o ->
		//PopAsync() - Voltar Pagina anterior
		//PushAsync() - Avan�ar para proxima paxina
        Application.Current.MainPage.
			Navigation.PopAsync();
    }

	string DirImagem;
    private async void btnAddImagem_Clicked(object sender, EventArgs e)
    {
		//Primeira coisa
		//precisamos de uma variavel 
		//global para armazenar o 
		//diretorio da imagem
		//parace acessar no 
		//botao salvar

		//Criar uma variavel
		//q vai receber a imagem selecionada
		var imagemSelecionada =
			await 
			MediaPicker.PickPhotoAsync();
		//valido se realmente
		//uma imagem foi selecionada
		if(imagemSelecionada != null)
		{
			DirImagem = 
				imagemSelecionada.FullPath;
			imgAvatar.Source = DirImagem;
		}
    }
}
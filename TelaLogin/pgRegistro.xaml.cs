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

		DisplayAlert("Informação",
					"Cadastro realizado com sucesso",
					"OK");

        //Application o proprio projeto
        //Current tela em execução no momento
        //MainPage é a tela aberta para o usuario
        //Navigation é navegação em si 
        //Ação ->
		//PopAsync() - Voltar Pagina anterior
		//PushAsync() - Avançar para proxima paxina
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
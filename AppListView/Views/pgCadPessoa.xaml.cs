using AppListView.Models;
using AppListView.Controllers;

namespace AppListView.Views;

public partial class pgCadPessoa : ContentPage
{
    //Importar
    //using AppListView.Models;
    //using AppListView.Controllers;

    //Criar a intancia para a
    //classe PessoaController
    private PessoaController pessoaController;
	public pgCadPessoa()
	{
		InitializeComponent();

        //Instenciar a controller
        pessoaController = 
            new PessoaController();
	}

    private async void btnVoltar_Clicked(object sender, EventArgs e)
    {
        //Tela sera aberta em modo asincrono
        //portando o fechamento precisa ser
        //asincrono
        await Application.Current.MainPage.
            Navigation.PopAsync();
    }

    private void btnAdicionar_Clicked(object sender, EventArgs e)
    {
        //Recuperar os dados que o usuario
        //informou
        string nome = txtNome.Text;
        string idade = txtIdade.Text;

        //Validar os registro
        if(string.IsNullOrEmpty(nome) ||
            string.IsNullOrEmpty(idade))
        {
            //Se um dos dois estiver vazio
            //ja abortamos a rotina
            DisplayAlert(
                "Atençao",
                "Preencha os campos corretamente.",
                "OK");
            //Abortar a rotina
            return;
        }

        //Iremos criar e popular o objeto pessoa
        Pessoa pessoa = new Pessoa();
        pessoa.Nome = nome;
        pessoa.Idade = idade;

        //Realizar a inserção no banco de dados
        if(pessoaController.Insert(pessoa))
        {
            //Notificamos que deu tudo certo
            DisplayAlert(
                "Informação",
                "Registro salvo com sucesso.",
                "OK");
            txtNome.Text = "";
            txtIdade.Text = "";
        }
        else
        {
            DisplayAlert(
                "Erro",
                "Falha ao salvar o registro no " +
                "banco de dados",
                "OK");
        }
    }
}
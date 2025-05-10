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

    }
}
using AppListView.Models;

namespace AppListView.Views;

public partial class pgVisPessoa : ContentPage
{
	//Ira transitar o cadastro selecionedo
	//via paramtro da tela, pois o cadastro
	//ja foi carregado na listView
	//assim econimizamos uma consulta no BD
	//Para isso iremos adicionar o parametro
	//Pessoa no construtor da tela
	public pgVisPessoa(Pessoa pessoa)
	{
		//Nesse momento ja temos o cadastro
		//aqui dentro da tela
		//precisamo apenas exibir
		InitializeComponent();
		ExibirDados(pessoa);
	}

	private void ExibirDados(Pessoa pessoa)
	{
		//Mapemaneto do objeto
		//com os campos em tela
		lblId.Text = pessoa.Id.ToString();
		lblNome.Text = pessoa.Nome;
		lblIdade.Text = pessoa.Idade;
	}

    private async void btnVoltar_Clicked(object sender, EventArgs e)
    {
		await Application.Current.MainPage.
			Navigation.PopAsync();
    }
}
using AppListView.Controllers;
using AppListView.Models;
using AppListView.Views;

namespace AppListView
{
    public partial class MainPage : ContentPage
    {
        #region Passo a Passo
        //Passo passo para MVC
        //-----------------------------------
        //Primeiro passo
        //Instalar as bibliotecas do SQLite
        //e gerenciamento de arquivo 
        //Instalação pacote NuGet
        //sqlite-net-pcl (icone da pena)
        //pclext.filestorage (icone do susshi)
        //-----------------------------------
        //Segundo passo
        //Criar a pasta Models
        //Iremos criar a classe Pessoa
        //para o nosso objeto Pessoa
        //-----------------------------------
        //Terceiro passo
        //Criar a pasta Services
        //Onde iremos aramazenar a conexão
        //com o banco de dados
        //Iremos criar a classe DatabaseService
        //Quarto passo
        //Criar a pasta Controllers
        //Onde iremos armazenar a manipulação 
        //dos dados no BD
        //Insert, Update, Delete e Select
        //Como precisamos criar com base no objeto
        //criaremos a classe PessoaController
        //-----------------------------------
        //Quinto passo
        //Criar a pasta Views
        //Onde iremos armazenar as telas
        //que serão exibidas ao usuario
        //Portanto iremos criar uma de cadastro
        //e manteremos a ListView na MainPage
        //-----------------------------------
        #endregion

        //Importar as camdas
        //using AppListView.Controllers;
        //using AppListView.Models;
        //using AppListView.Views;

        //Criar a instancia da classe pessoaController
        private PessoaController pessoaController;
        public MainPage()
        {
            InitializeComponent();
            //Instanciar a classe e atribuir a variavel
            pessoaController = new PessoaController();

            AtualizarListView();
        }

        //Método para atualizar a ListView
        private void AtualizarListView()
        {
            lsvLista.ItemsSource =
                pessoaController.GetAll();
        }

        private async void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            //Precisamo do modo Async, para aguardar
            //a finalização do cadastro
            await Application.Current.MainPage.Navigation.
                PushAsync(new pgCadPessoa());
            //Após finalizar o cadastro, atualizamos a tela
            AtualizarListView();

        }

        private void btnAtualizar_Clicked(object sender, EventArgs e)
        {
            AtualizarListView();
        }

        private void tapVisualizar_Tapped(object sender, TappedEventArgs e)
        {
            //Reconhecer se o gesto é do Tipo Tapped
            //O parametro e possui todos os toques da tela
            //portanto precisamos extrair o tapped de e
            TappedEventArgs tapped = (TappedEventArgs)e;

            //Precisamos validar se o registro selecionado
            //é realmente do tipo pessoa
            //Se for extraimos o objeto da ListView
            if(tapped.Parameter is Pessoa registro)
            {
                //Chamar a tela de visualização
                //onde iremos passar o registro extraido
                //via parametro
                Application.Current.MainPage.Navigation.
                    PushAsync(new pgVisPessoa(registro));
            }
        }

        private async void tapExcluir_Tapped(object sender, TappedEventArgs e)
        {
            //Seguir a mesma ideia da rotina de visualizar
            //Onde precisamos realizar a identificação
            //do gesto tapped
            //E extrair o objeto do registro selecionado

            TappedEventArgs tapped = (TappedEventArgs)e;
            if(tapped.Parameter is Pessoa registro)
            {
                //Iremos usar um diplay alert para confirmar 
                //a exclusão do registro 
                //pelo fato do disply ficar aperto até a tomada
                //de decisão, é preciso chama-lo de maneira async
                bool decisao =
                    await DisplayAlert(
                            "Confirmação",
                            "Deseja realmente excluir o registro?",
                            "Sim", "Não");

                if(decisao)
                {
                    //Iremos chamar a rotina Delete da camada
                    //controller e atualizar a ListView
                    pessoaController.Delete(registro);
                    AtualizarListView();
                }
            }
        }
    }
}

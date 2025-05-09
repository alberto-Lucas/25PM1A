using System.Collections.ObjectModel;

namespace AppListView
{
    public partial class MainPage : ContentPage
    {
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





        //Criar uma classe Pessoa
        //que sera o nosso objeto Pessoa
        public class Pessoa
        {
            public string Nome { get; set; }
            public string Idade { get; set; }
        }

        //Criar uma coleção de obejto
        //Bassicamente cada registro é um objeto
        //Reunimos todos os registro em uma 
        //coleção
        //Tipo Coleção é usado para atualizar
        //automaticamente a ListView

        //Para isso precisamos importar a biblioteca
        //using System.Collections.ObjectModel;
        ObservableCollection<Pessoa> pessoas =
            new ObservableCollection<Pessoa>();

        public MainPage()
        {
            InitializeComponent();

            //Vincular a coleção com a LIstView
            lsvLista.ItemsSource = pessoas;

            //Adicionar um registro default
            //apenas para teste
            pessoas.Add(
                    new Pessoa
                    {
                        Nome = "Lucas",
                        Idade = "00"
                    }
                );
        }

        private void btnAdicionar_Clicked(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string idade = txtIdade.Text;

            //Valida simples se o campo ta preenchido
            if(string.IsNullOrEmpty(nome) || 
                string.IsNullOrEmpty(idade))
            {
                DisplayAlert("Atenção",
                    "Preencha os campos corretamente.", "OK");
                return; //para a excução do botão
            }

            //Se chegou até aqui, é pq esta tudo certo
            //pode adicionar a lista

            pessoas.Add(
                    new Pessoa
                    {
                        Nome = nome,
                        Idade = idade
                    }
                );

            //Limpar os campos
            txtNome.Text = "";
            txtIdade.Text = "";
        }
    }
}

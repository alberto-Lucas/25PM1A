using System.Collections.ObjectModel;

namespace AppListView
{
    public partial class MainPage : ContentPage
    {
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

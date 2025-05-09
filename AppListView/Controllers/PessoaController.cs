using SQLite;
using AppListView.Services;
using AppListView.Models;

namespace AppListView.Controllers
{
    //Importar
    //using SQLite;
    //using AppListView.Services;
    //using AppListView.Models;
    public class PessoaController
    {
        //Criar a instancia com a classe
        //DatabaseService
        private DatabaseService databaseService;

        //Criar a instancia para armazenar
        //a conexão do BD
        private SQLiteConnection connection;

        //Criar o método construtor
        public PessoaController()
        {
            //Instanciar a databaseService
            databaseService =
                new DatabaseService();

            //Recuperar a conexão do BD
            connection =
                databaseService.GetConexao();

            //Mapear o objeto Pessoa
            //para criacao/atualizacao da tabela
            //no bd
            connection.CreateTable<Pessoa>();
        }

        //Criação dos métodos de manipulção
        //Insert, Update, Delete e Select
        public bool Insert(Pessoa value)
        {
            //o Insert retorna o numero de 
            //linhas afetadas
            //COmo iremos inserir apenas um registro
            //por vez, esperar a quantidade de linhas
            //afetadas seja, 1
            //Se retornar 1, o registro foi inserido
            //Se retornar 0, o registro não foi inserido
            return connection.Insert(value) > 0;
        }
    }
}

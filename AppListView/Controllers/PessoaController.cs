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

        public bool Update(Pessoa value)
        {
            //seguir a mesma ideia do Insert
            return connection.Update(value) > 0;
        }

        public bool Delete(Pessoa value)
        {
            return connection.Delete(value) > 0;
        }

        //Rotina de consulta

        //Consultar para retornoar todos os dados
        public List<Pessoa> GetAll()
        {
            //Retornar todos registro da tabela
            //em um lista do tipo Pessoa
            //Semelhante ao comando
            //SELECT * FROM Pessoa
            return
                connection.Table<Pessoa>().ToList();
        }

        //Consultar por ID
        public Pessoa GetById(int value)
        {
            //Utilizar o recurso Find
            //Vai consultar todos
            //os registro e identificar
            //o id pela chave primaria
            //Ou seja olha apenas para a
            //chave primaria
            return 
                connection.Find<Pessoa>(value);
        }

        //Consulta filtrando pelo Nome
        public List<Pessoa> GetByNome(string value)
        {
            //Retornar uma lista de registros
            //de acordoc om o filtro aplicado
            //Onde ira validar se o registro
            //contem o valor desejado
            //semelhante ao comando Like

            //o seja é o dataTable
            //=> é o lambida
            //imputa um dado implicitamente
            return
                connection.Table<Pessoa>().
                Where(x => x.Nome.Contains(value)).
                ToList();
        }


    }
}

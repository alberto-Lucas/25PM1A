using SQLite;

namespace AppListView.Models
{
    //Importar a bibliote do SQLite
    //using SQLite;

    //Deixar a classe publica
    public class Pessoa
    {
        //Este objeto sera usado de base
        //para criação da tabela no BD
        //Ou seja a tabela é criada com base 
        //no objeto
        //se o objeto for alterado, a tabela
        //será atualizada

        //Configurar o atributo ID
        //como chave primaria e auto incremento
        //da tabela no BD
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Idade { get; set; }
        //Adicioanr a propriedade para salvar
        //o diretorio da imagem
        public string DirImagem { get; set; }
    }
}

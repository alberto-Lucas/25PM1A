using POO_CRUD.Models;
using POO_CRUD.Services;
using System.Collections.Generic;
using RepoDb;
using RepoDb.Attributes;
using System.Data.SqlClient;
using System.Linq;

namespace POO_CRUD.Controllers
{
    public class ClienteController
    {
        SqlConnection conexao;
        DatabaseService databaseService;

        public ClienteController()
        {
            databaseService = new DatabaseService();
            conexao = databaseService.GetConnection();            
        }

        public bool Insert(Cliente value)
        {
            var c = conexao.Insert(value);
            return true;
        }

        public List<Cliente> GetAll()
        {
            return conexao.QueryAll<Cliente>().ToList();
        }
    }
}

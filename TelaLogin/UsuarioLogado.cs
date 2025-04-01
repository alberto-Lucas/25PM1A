using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelaLogin
{
    //Classe singleton
    //Parar armazenar o usuario logado
    public sealed class UsuarioLogado
    {
        //Variavel quer vai apontar na memoria
        static UsuarioLogado _instancia;

        //Metodo para retorno da Instancia
        public static UsuarioLogado Instancia
        {
            //Retorno o apontamento da memoria
            get
            {
                //Se não existir a instancia
                //criar um novo apontamento
                //se ja exitir retorna ela mesma
                //?? serve para validar se a
                //varaivel é null
                return _instancia ??
                    (_instancia = new UsuarioLogado());
            }
        }
        //Construtor da classe
        public UsuarioLogado() { }

        //Criar os campos da classe
        //Ou seja o atributos

        //prop tab tab
        //Atributo para armazenar o login
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Idade { get; set; }
        public string DiretorioImagem { get; set; }
    }
}

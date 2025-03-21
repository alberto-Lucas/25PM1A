﻿namespace TelaLogin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ckbSenha_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            MostrarSenha();
        }

        private void tapSenha_Tapped(object sender, TappedEventArgs e)
        {
            //Alterar o status do checkbox
            ckbSenha.IsChecked =
                !ckbSenha.IsChecked;
            MostrarSenha();
        }

        void MostrarSenha()
        {
            txtSenha.IsPassword = 
                !ckbSenha.IsChecked;
        }

        private void btnEntrar_Clicked(object sender, EventArgs e)
        {
            //Validar usuario e senha
            if (txtUsuario.Text == "admin"
                && txtSenha.Text == "admin")
            {
                /*DisplayAlert("Informação!",
                             "Acesso permitido",
                             "OK");*/
                //Vamos armazenar o usuario logado
                //na classe singleton

                //Criando variavel para acessar
                //a classe singleton
                var usuarioLogado = UsuarioLogado.Instancia;
                usuarioLogado.Login = txtUsuario.Text;

                //Chamar a tela Principal
                Application.Current.MainPage.
                    Navigation.PushAsync(
                    new pgPrincipal());
            }
            else
                DisplayAlert("Atenção!",
                    "Usuário ou Senha inválido",
                    "OK");
        }

        private void lblRegistrar_Tapped(object sender, TappedEventArgs e)
        {

        }
    }
}

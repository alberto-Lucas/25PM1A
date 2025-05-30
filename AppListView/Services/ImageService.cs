﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListView.Services
{
    //Usaremos o recurso de classe static
    //pois classes não precisam ser 
    //instanciadas, iremos acessar os seus
    //métodos e funções diretamente
    public static class ImageService
    {
        //Funação de seleção de imagem
        //Iremo chama a seleção de imagem
        //do dispositivo e iremos retornar
        //o diretorio dessa imagem
        //a selação de imagem precisa 
        //ser asincrono para não travar
        //a excução do aplicativo
        public static async 
            Task<string> SelecionarImagem()
        {
            string diretorio = "";

            //Método de seleção de imagem
            var imagemSelecionada =
                await MediaPicker.PickPhotoAsync();

            //Validar se realmente foi selecionado
            if(imagemSelecionada != null)
            {
                //recupero o diretorio da imagem
                diretorio = imagemSelecionada.FullPath;
            }

            return diretorio;
        }

        //Função que ira copiar a imagem
        //para dentro da raiz do aplicativo
        //retornamos o diretorio da nova imagem
        public static string 
            CopiarImagem(string sDirOriginal)
        {
            string DiretorioDestino = "";
            //Precisamos gerar o diretorio para
            //salvar as imagens que ficara na 
            //instalação do app
            //para isso precisamos recuperar
            //o caminho da instalação
            //AppContext.BaseDirectory =
            //local de instalação do app
            var novoDiretorio =
                Path.Combine(
                    AppContext.BaseDirectory, "Imagens");

            //Verificar a existencia do novo diretorio
            //se nao existir o criamos
            if(!Directory.Exists(novoDiretorio))
            {
                Directory.CreateDirectory(novoDiretorio);
            }

            //Montar o diretorio de destino da nova imagem
            //ou seja a imagem ira para a pasta que criamos
            //anteriormente
            //Imagem original chama img.png
            //q fica no c:/
            //ou seja c:/img.png
            //A nova pasta ser o D:/
            //entao irei criar o diretorio
            //d:/img.png

            DiretorioDestino =
                Path.Combine(novoDiretorio,
                    Path.GetFileName(sDirOriginal));

            //Agora sim, iremos copiar a imagem
            //portanto iremos duplicar a imagem
            //original e salvar a copia
            //no Diretorio de Destino
            //e retornamos o diretorio da copia
            //para que o arquivo seja subistituido
            //caso ja exista = overwrite: true
            File.Copy(sDirOriginal, 
                        DiretorioDestino,
                            overwrite: true);

            return DiretorioDestino;
        }
    }
}

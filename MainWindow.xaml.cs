using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JogoDaMemoriaa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //var corDaVitoria = new ImageBrush();
            //corDaVitoria.ImageSource = new BitmapImage(new Uri("/cordavitoria.png", UriKind.Relative));
        }

        //Variáveis que armazenam se os pares do jogo foram encontrados ou não
        bool primeiroParEncontrado = false;
        bool segundoParEncontrado = false;
        bool terceiroParEncontrado = false;
        bool quartoParEncontrado = false;

        //Variáveis que armazenam se cada um dos botões foram ou não clicados
        bool clicarCartaUm = false;
        bool clicarCartaDois = false;
        bool clicarCartaTres = false;
        bool clicarCartaQuatro = false;
        bool clicarCartaCinco = false;
        bool clicarCartaSeis = false;
        bool clicarCartaSete = false;
        bool clicarCartaOito = false;

        //Variável que armazena se a contagem do delay foi iniciada ou não
        bool iniciouContagem = false;

        //Variáveis que armazenam o valor total de jogadas feita pelo jogador e o total de pares errados encontrados pelo jogador
        int totalDeJogadas = 0;
        int contaErros = 0;

        List<int> posicoes = new List<int> { 1, 1, 2, 2, 3, 3, 4, 4};
        
        //Variaveis que vai armazenar as tasks para o timer
        Task tasks;
        CancellationToken cancellationToken;
        CancellationTokenSource tokenSorce;


        //Parte do delay:
        //Método que faz a contagem do tempo
        private void InicializaTaskContagem()
        {
            //Cria o objeto para o token a ser parametrizado na task
            tokenSorce = new CancellationTokenSource();
            cancellationToken = tokenSorce.Token;
            tasks = IniciaTimer(tokenSorce.Token);
        }

        //Tarefa do delay que vai ser iniciada
        private async Task IniciaTimer(CancellationToken token)
        {
            iniciouContagem = true;
            //Loop para fazer a contagem do tempo
            while (true)
            {
                //Verificar se houve um cancelamento da tarefa e 
                cancellationToken.ThrowIfCancellationRequested();
                if (cancellationToken.IsCancellationRequested)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                }

                //Esperando 1 segundo para continuar
                await Task.Delay(3000);
            }
        }

        //Instanciando o camando dos botões
        //Método do botão para reiniciar o jogo
        private void IniciarNovoJogo(object sender, RoutedEventArgs e)
        {
            EmbaralharCartas();

            imgPrimeiraImagemA.Visibility = Visibility.Hidden;
            imgPrimeiraImagemB.Visibility = Visibility.Hidden;
            imgSegundaImagemA.Visibility = Visibility.Hidden;
            imgSegundaImagemB.Visibility = Visibility.Hidden;
            imgTerceiraImagemA.Visibility = Visibility.Hidden;
            imgTerceiraImagemB.Visibility = Visibility.Hidden;
            imgQuartaImagemA.Visibility = Visibility.Hidden;
            imgQuartaImagemB.Visibility = Visibility.Hidden;

            contaErros = 0;
            txtNumeroTotalDeErros.Text = $"{(contaErros)}";
        }

        //Método que diz o que a lógica deve fazer ao clicar na Imagem Um
        private void ClicarCartaUm(object sender, MouseButtonEventArgs e)
        {
            clicarCartaUm = true;
            imgPrimeiraImagemA.Visibility = Visibility.Visible; 
                if (ClicouEmDuasCartas() == true)
                {
                    if (AcertouOPar() == true)
                    {
                        imgPrimeiraImagemA.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        InicializaTaskContagem();
                        imgPrimeiraImagemA.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    imgPrimeiraImagemA.Visibility = Visibility.Visible;
                }
        }

        //Método que diz o que a lógica deve fazer ao clicar na Imagem Dois
        private void ClicarCartaDois(object sender, MouseButtonEventArgs e)
        {
            clicarCartaDois = true;
            imgSegundaImagemA.Visibility = Visibility.Visible;

            if (ClicouEmDuasCartas() == true)
            {
                if (AcertouOPar() == true)
                {
                    imgSegundaImagemA.Visibility = Visibility.Visible;
                }
                else
                {
                    InicializaTaskContagem();
                    imgSegundaImagemA.Visibility = Visibility.Hidden;
                }

            }
            else
            {
                imgSegundaImagemA.Visibility = Visibility.Visible;
            }
        }

        //Método que diz o que a lógica deve fazer ao clicar na Imagem Três
        private void ClicarCartaTres(object sender, MouseButtonEventArgs e)
        {
            clicarCartaTres = true;
            imgTerceiraImagemA.Visibility = Visibility.Visible;

            if (ClicouEmDuasCartas() == true)
            {
                if (AcertouOPar() == true)
                {
                    imgTerceiraImagemA.Visibility = Visibility.Visible;
                }
                else
                {
                    InicializaTaskContagem();
                    imgTerceiraImagemA.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                imgTerceiraImagemA.Visibility = Visibility.Visible;
            }
        }

        //Método que diz o que a lógica deve fazer ao clicar na Imagem Quatro
        private void ClicarCartaQuatro(object sender, MouseButtonEventArgs e)
        {
            clicarCartaQuatro = true;
            imgQuartaImagemA.Visibility = Visibility.Visible;

            if (ClicouEmDuasCartas() == true)
            {
                if (AcertouOPar() == true)
                {
                    imgQuartaImagemA.Visibility = Visibility.Visible;
                }
                else
                {

                    InicializaTaskContagem();
                    imgQuartaImagemA.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                imgQuartaImagemA.Visibility = Visibility.Visible;
            }
        }

        //Método que diz o que a lógica deve fazer ao clicar na Imagem Cinco
        private void ClicarCartaCinco(object sender, MouseButtonEventArgs e)
        {
            clicarCartaCinco = true;
            imgPrimeiraImagemB.Visibility = Visibility.Visible;

            if (ClicouEmDuasCartas() == true)
            {
                if (AcertouOPar() == true)
                {
                    imgPrimeiraImagemB.Visibility = Visibility.Visible;
                }
                else
                {

                    InicializaTaskContagem();
                    imgPrimeiraImagemB.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                imgPrimeiraImagemB.Visibility = Visibility.Visible;
            }
        }

        //Método que diz o que a lógica deve fazer ao clicar na Imagem Seis
        private void ClicarCartaSeis(object sender, MouseButtonEventArgs e)
        {
            clicarCartaSeis = true;
            imgSegundaImagemB.Visibility = Visibility.Visible;

            if (ClicouEmDuasCartas() == true)
            {
                if (AcertouOPar() == true)
                {
                    imgSegundaImagemB.Visibility = Visibility.Visible;
                }
                else
                {
                    InicializaTaskContagem();
                    imgSegundaImagemB.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                imgSegundaImagemB.Visibility = Visibility.Visible;
            }
        }

        //Método que diz o que a lógica deve fazer ao clicar na Imagem Sete
        private void ClicarCartaSete(object sender, MouseButtonEventArgs e)
        {
            clicarCartaSete = true;
            imgTerceiraImagemB.Visibility = Visibility.Visible;

            if (ClicouEmDuasCartas() == true)
            {
                if (AcertouOPar() == true)
                {
                    imgTerceiraImagemB.Visibility = Visibility.Visible;
                }
                else
                {
                    InicializaTaskContagem();
                    imgTerceiraImagemB.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                imgTerceiraImagemB.Visibility = Visibility.Visible;
            }
        }

        //Método que diz o que a lógica deve fazer ao clicar na Imagem Oito
        private void ClicarCartaOito(object sender, MouseButtonEventArgs e)
        {
            clicarCartaOito = true;
            imgQuartaImagemB.Visibility = Visibility.Visible;

            if (ClicouEmDuasCartas() == true)
            {
                if (AcertouOPar() == true)
                {
                    imgQuartaImagemB.Visibility = Visibility.Visible;
                }
                else
                {
                    InicializaTaskContagem();
                    imgQuartaImagemB.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                imgQuartaImagemB.Visibility = Visibility.Visible;
            }
        }






        //Método para embaralhar as cartas no início do jogo
        private void EmbaralharCartas()
        {
            Random aleatorizarPosicoes = new Random();
            int posicoes = aleatorizarPosicoes.Next();
        }

        //Método que diz se o jogador acertou ou não o par selecionado
        private bool AcertouOPar()
        {
            if (clicarCartaUm == true)
            {
                if (clicarCartaCinco == true)
                {
                    primeiroParEncontrado = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (clicarCartaDois == true)
            {
                if (clicarCartaSeis == true)
                {
                    segundoParEncontrado = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (clicarCartaTres == true)
            {
                if (clicarCartaSete == true)
                {
                    terceiroParEncontrado = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (clicarCartaQuatro == true)
            {
                if (clicarCartaOito == true)
                {
                    quartoParEncontrado = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //Método que atualiza na tela o total de erros cometidos pelo jogador
        private void MudarOTotalDeErrosNaTela()
        {
            if (AcertouOPar() != true)
            {
                txtNumeroTotalDeErros.Text = $"{(contaErros++)}";
            }
            else
            {
                txtNumeroTotalDeErros.Text = $"{(contaErros)}";
            }
        }

        //Método para dizer quando o jogador ganhou o jogo
        private void JogoGanho(bool ganhouOJogo)
        {
            if (primeiroParEncontrado == true && segundoParEncontrado == true && terceiroParEncontrado == true && quartoParEncontrado == true)
            {
                TelaFinal frmTelaFinal = new TelaFinal();
                frmTelaFinal.Show();
                Close();
                ganhouOJogo = true;
            }
            else
            {
                ganhouOJogo = false;
            }
        }
        //Método para verificar se o jogador clicou em duas cartas
        private bool ClicouEmDuasCartas()
        {
            if (clicarCartaUm == true)
            {
                if (clicarCartaDois == true || clicarCartaTres == true || clicarCartaQuatro == true || clicarCartaCinco == true || clicarCartaSeis == true || clicarCartaSete == true || clicarCartaOito == true)
                {
                    return true;
                }
            }
            else if (clicarCartaDois == true)
            {
                if (clicarCartaUm == true || clicarCartaTres == true || clicarCartaQuatro == true || clicarCartaCinco == true || clicarCartaSeis == true || clicarCartaSete == true || clicarCartaOito == true)
                {
                    return true;
                }
            }
            else if (clicarCartaTres == true)
            {
                if (clicarCartaDois == true || clicarCartaUm == true || clicarCartaQuatro == true || clicarCartaCinco == true || clicarCartaSeis == true || clicarCartaSete == true || clicarCartaOito == true)
                {
                    return true;
                }
            }
            else if (clicarCartaQuatro == true)
            {
                if (clicarCartaDois == true || clicarCartaTres == true || clicarCartaUm == true || clicarCartaCinco == true || clicarCartaSeis == true || clicarCartaSete == true || clicarCartaOito == true)
                {
                    return true;
                }
            }
            else if (clicarCartaCinco == true)
            {
                if (clicarCartaDois == true || clicarCartaTres == true || clicarCartaQuatro == true || clicarCartaUm == true || clicarCartaSeis == true || clicarCartaSete == true || clicarCartaOito == true)
                {
                    return true;
                }
            }
            else if (clicarCartaSeis == true)
            {
                if (clicarCartaDois == true || clicarCartaTres == true || clicarCartaQuatro == true || clicarCartaCinco == true || clicarCartaUm == true || clicarCartaSete == true || clicarCartaOito == true)
                {
                    return true;
                }
            }
            else if (clicarCartaSete == true)
            {
                if (clicarCartaDois == true || clicarCartaTres == true || clicarCartaQuatro == true || clicarCartaCinco == true || clicarCartaUm == true || clicarCartaUm == true || clicarCartaOito == true)
                {
                    return true;
                }
            }
            else if (clicarCartaOito == true)
            {
                if (clicarCartaDois == true || clicarCartaTres == true || clicarCartaQuatro == true || clicarCartaCinco == true || clicarCartaUm == true || clicarCartaSete == true || clicarCartaUm == true)
                {
                    return true;
                }
            }
            else
            {
                return false;
            }


            return false;
        }

        //Método para atualizar o total de jogadas que o jogador fez
        private void ContaOTotalDeJogadas()
        {
            if(clicarCartaUm == true)
            {
                totalDeJogadas++;
            }
            else if(clicarCartaDois == true)
            {
                totalDeJogadas++;
            }
            else if (clicarCartaTres == true)
            {
                totalDeJogadas++;
            }
            else if (clicarCartaQuatro == true)
            {
                totalDeJogadas++;
            }
            else if (clicarCartaCinco == true)
            {
                totalDeJogadas++;
            }
            else if (clicarCartaSeis == true)
            {
                totalDeJogadas++;
            }
            else if (clicarCartaSete == true)
            {
                totalDeJogadas++;
            }
            else if (clicarCartaOito == true)
            {
                totalDeJogadas++;
            }
            else
            {
                totalDeJogadas = totalDeJogadas + 0;
            }
        }
    }
}


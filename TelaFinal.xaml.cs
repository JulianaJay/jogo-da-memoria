using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System MainWindow.xaml.cs;

namespace JogoDaMemoriaa
{
    /// <summary>
    /// Lógica interna para TelaFinal.xaml
    /// </summary>
    public partial class TelaFinal : Window
    {
        public TelaFinal()
        {
            InitializeComponent();
        }

        //Variável que armazena o valor total de jogadas feita pelo jogador
        int totalDeJogadas = 0; //tecnicamente vindo do código da tela principal
        //Variável que armazena o total de pares errados encontrados pelo jogador
        int contaErros = 0; //tecnicamente vindo do código da tela principal
        //Variável que armazena o valor do aproveitamento do jogador na partida
        int porcentagemDeAproveitamentoDoJogo = 0;

        //Método do botão para reiniciar o jogo
        private void RecomecarJogo(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        //Método para mostrar na tela qual foi o aproveitamento do jogador no jogo
        private void AproveitamentoDoJogo()
        {
            txtAproveitamentoDoJogador.Text = $"{(porcentagemDeAproveitamentoDoJogo)}";
        }

        //Método para calcular qual foi o aproveitamento do jogador no jogo
        private void CalcularAproveitamento()
        {
            porcentagemDeAproveitamentoDoJogo = (contaErros / totalDeJogadas) * 100;
        }
       
    }
}

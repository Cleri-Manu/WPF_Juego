using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TrabajoWPF {
    /// <summary>
    /// Interaction logic for AuxWindow.xaml
    /// </summary>
    public partial class AuxWindow : Window {
        ObservableCollection<Game> savedGames;
        Game currentGame;
        public AuxWindow( ObservableCollection<Game> savedGames, Game currentGame) {
            InitializeComponent();
            this.savedGames = savedGames;
            G_auxWindow.ItemsSource = currentGame.CardsDeck;
            this.currentGame = currentGame;
            C_Save.ItemsSource = this.savedGames;
            this.Focusable = true;
            this.Topmost = false;
        }

        public void Change(ObservableCollection<Game> savedGames,Game currentGame) {
            this.savedGames = savedGames;
            G_auxWindow.ItemsSource = currentGame.CardsDeck;
            this.currentGame = currentGame;
            if (currentGame.Difficulty.Equals("Dificultad: Facil")) {
                S_Diff.Value = 0;
            } else if(currentGame.Difficulty.Equals("Dificultad: Normal")) {
                S_Diff.Value = 1;
            } else if(currentGame.Difficulty.Equals("Dificultad: Dificil")) {
                S_Diff.Value = 2;
            }
            C_Save.ItemsSource = this.savedGames;
            C_Show.IsChecked = currentGame.ShowCards;
        }



        //Con la siguiente función se evita que al cerrar la ventana auxiliar se borren todos sus datos (se oculta la ventana en vez de borrarla)
        protected override void OnClosing(CancelEventArgs e) {
            e.Cancel = true;
            this.Hide();
        }

        private void C_Show_Checked(object sender, RoutedEventArgs e) {
            if (currentGame == null)
                return;;
                currentGame.ShowCards = (bool)C_Show.IsChecked;
        }

        private void S_Diff_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            if (currentGame == null)
                return;;
            currentGame.Difficulty = S_Diff.Value.ToString();
            L_Diff.Content = (currentGame.Difficulty);
        }

        private void B_Save_Click(object sender, RoutedEventArgs e) {
            foreach(Game g in savedGames) {
                if(g.Name.Equals(T_Save.Text)) {
                    MessageBoxResult result = MessageBox.Show("Ya existe una partida guardada con ese nombre ¿Desea sobreescribirla?", "Atención", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes) {
                        savedGames.Remove(g);
                        currentGame.Name = T_Save.Text;
                        savedGames.Add(new Game(currentGame));
                        return;;
                    } else {
                        return;;
                    }
                }
            }
            currentGame.Name = T_Save.Text;
            savedGames.Add(new Game(currentGame));

        }

        private void C_Save_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if((C_Save.SelectedItem as Game) != null) {
                Game g = (C_Save.SelectedItem as Game);
                currentGame.Name = g.Name;
                currentGame.Difficulty = g.Difficulty;
                currentGame.CardsDeck = g.CardsDeck;
                currentGame.Dealer = new Dealer(g.Dealer);
                currentGame.Points = 0;
                currentGame.Points = g.Points;
                currentGame.ShowCards = g.ShowCards;
            }
        }
    }
}

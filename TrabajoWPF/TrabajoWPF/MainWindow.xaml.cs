using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace TrabajoWPF {
    public partial class MainWindow : Window {
        private AuxWindow auxWindow;
        int clickCount;
        public List<Storyboard> myImgStoryBoards;
        public List<Storyboard> marginIncreaseStoryBoards;
        public List<Storyboard> marginDecreaseStoryBoards;
        Storyboard pointsIncrease;
        Storyboard pointsDecrease;
        List<Image> cardsView;
        Game currentGame;
        ObservableCollection<Game> savedGames;
        Card lastCard;

        public MainWindow() {
            InitializeComponent();
            myImgStoryBoards = new List<Storyboard>();
            marginIncreaseStoryBoards = new List<Storyboard>();
            marginDecreaseStoryBoards = new List<Storyboard>();
            L_Points.MouseEnter += MouseOverCustom;
            L_Points.MouseLeave += MouseOutCustom;
            savedGames = new ObservableCollection<Game>();
            clickCount = 0;
            currentGame = new Game();
            auxWindow = new AuxWindow(savedGames, currentGame);
            cardsView = new List<Image>();
            this.DataContext = this;
            this.Focusable = true;
            this.Topmost = false;

        }


        private void B_Conf_Click(object sender, RoutedEventArgs e) {
            if (auxWindow == null) {
                auxWindow = new AuxWindow(savedGames, currentGame);
                auxWindow.Owner = this;
            }
            auxWindow.Owner = this;
            auxWindow.DataContext = this;
            auxWindow.Show();
        }

        public void EmptyDeckAndClearGrid() {
            ClearGrid();
            currentGame.Dealer = new Dealer();
            myImgStoryBoards = new List<Storyboard>();
            marginIncreaseStoryBoards = new List<Storyboard>();
            marginDecreaseStoryBoards = new List<Storyboard>();
            lastCard = null;
        }

        public void ClearGrid() {
            foreach (Image t in cardsView) {
                MainGrid.Children.Remove(t);
            }
            cardsView = new List<Image>();
            myImgStoryBoards = new List<Storyboard>();
            marginIncreaseStoryBoards = new List<Storyboard>();
            marginDecreaseStoryBoards = new List<Storyboard>();
        }

        private void B_New_Click(object sender, RoutedEventArgs e) {
            EmptyDeckAndClearGrid();
            currentGame = new Game();
            currentGame.PropertyChanged += PropertyChanged;
            currentGame.CardsDeck = currentGame.Dealer.DealCards(MainGrid.ActualHeight, MainGrid.ActualWidth, currentGame);
            auxWindow.Change(savedGames,currentGame);
        }

        private void MouseUpCustom(object sender, RoutedEventArgs e) {
            if (clickCount == 0) {
                ++clickCount;
                marginDecreaseStoryBoards[cardsView.IndexOf((sender as Image))].Begin();
                marginIncreaseStoryBoards[cardsView.IndexOf((sender as Image))].Begin();
                if(!currentGame.ShowCards) {
                    myImgStoryBoards[cardsView.IndexOf((sender as Image))].Begin();
                }

                if (lastCard == null) {                                  //Si no hay ultima carta pon la actual como ultima carta
                    foreach (Card c in currentGame.CardsDeck) {
                        if ((sender as Image).Name.Equals(c.Name)) {
                            lastCard = new Card(c);
                        }
                    }
                }
                //Si hay ultima carta
                foreach (Card c in currentGame.CardsDeck) {                                      //Para cada carta
                    if (c.Name.Equals((sender as Image).Name)) {                                 //Saca la carta con el mismo nombre que su vista
                        if (lastCard.ImgPath.Equals(c.ImgPath) && lastCard.ID != c.ID) {         //Si esta y la carta anterior tienen la misma imagen y diferente ID son una pareja correcta
                                    
                            currentGame.Points += 50;
                            MainGrid.Children.Remove(sender as Image);
                            Image tempImg1 = new Image();
                            Image tempImg2 = new Image();
                            foreach (Object o in MainGrid.Children) {
                                if(o is Image) {
                                    if((o as Image).Name.Equals(lastCard.Name)) {
                                        tempImg1 = (o as Image);
                                    } else if((o as Image).Name.Equals(c.Name)) {
                                        tempImg2 = (o as Image);
                                    }
                                }
                            }
                            MainGrid.Children.Remove(tempImg1);
                            MainGrid.Children.Remove(tempImg2);

                            marginDecreaseStoryBoards.RemoveAt(cardsView.IndexOf(cardsView.Find(img => img.Name.Equals(c.Name))));
                            marginIncreaseStoryBoards.RemoveAt(cardsView.IndexOf(cardsView.Find(img => img.Name.Equals(c.Name))));
                            myImgStoryBoards.RemoveAt(cardsView.IndexOf(cardsView.Find(img => img.Name.Equals(c.Name))));
                            cardsView.RemoveAll(img => img.Name.Equals(c.Name));

                            marginIncreaseStoryBoards.RemoveAt(cardsView.IndexOf(cardsView.Find(img => img.Name.Equals(lastCard.Name))));
                            marginDecreaseStoryBoards.RemoveAt(cardsView.IndexOf(cardsView.Find(img => img.Name.Equals(lastCard.Name))));
                            myImgStoryBoards.RemoveAt(cardsView.IndexOf(cardsView.Find(img => img.Name.Equals(lastCard.Name))));
                            cardsView.RemoveAll(img => img.Name.Equals(lastCard.Name));

                            Card tempC = new Card(); ;
                            foreach(Card c2 in currentGame.CardsDeck) {
                                if (c2.Name.Equals(lastCard.Name))
                                    tempC = c2;
                            }
                            currentGame.CardsDeck.Remove(tempC);
                            currentGame.CardsDeck.Remove(c);
                            if (currentGame.ShowCards)
                                clickCount--;
                            if(currentGame.CardsDeck.Count == 0)
                                NewTable();
                            return;;

                        } else {
                            lastCard = new Card(c);
                            currentGame.Points -= 5;
                        }
                    }
                }
            }
            if (currentGame.ShowCards)
                clickCount--;
        }
        
        private void MouseOverCustom(object sender, RoutedEventArgs e) {
            if(sender is Label) {
                if(pointsIncrease == null) {
                    pointsIncrease = new Storyboard();

                    DoubleAnimation fontSizeAnimation1 = new DoubleAnimation();
                    fontSizeAnimation1.BeginTime = TimeSpan.FromMilliseconds(0);
                    fontSizeAnimation1.Duration = TimeSpan.FromMilliseconds(180);
                    fontSizeAnimation1.From = L_Points.FontSize;
                    fontSizeAnimation1.To = L_Points.FontSize*1.25;
                    Storyboard.SetTarget(fontSizeAnimation1, L_Points);
                    Storyboard.SetTargetProperty(fontSizeAnimation1, new PropertyPath("(Label.FontSize)"));
                    pointsIncrease.Children.Add(fontSizeAnimation1);

                    ColorAnimation fontColorAnimation1 = new ColorAnimation();
                    fontColorAnimation1.BeginTime = TimeSpan.FromMilliseconds(0);
                    fontColorAnimation1.Duration = TimeSpan.FromMilliseconds(180);
                    fontColorAnimation1.To = (Color)ColorConverter.ConvertFromString("#05EE72"); ;
                    Storyboard.SetTarget(fontColorAnimation1, L_Points);
                    Storyboard.SetTargetProperty(fontColorAnimation1, new PropertyPath("(Label.Foreground).(SolidColorBrush.Color)"));
                    pointsIncrease.Children.Add(fontColorAnimation1);
                }
                pointsIncrease.Begin();
            } else {
                marginIncreaseStoryBoards[cardsView.IndexOf((sender as Image))].Begin();
            }
        }

        private void MouseOutCustom(object sender, RoutedEventArgs e) {
            if (sender is Label) {
                if (pointsDecrease == null) {
                    pointsDecrease = new Storyboard();
                    DoubleAnimation fontSizeAnimation2 = new DoubleAnimation();
                    fontSizeAnimation2.BeginTime = TimeSpan.FromMilliseconds(0);
                    fontSizeAnimation2.Duration = TimeSpan.FromMilliseconds(180);
                    fontSizeAnimation2.From = L_Points.FontSize;
                    fontSizeAnimation2.To = L_Points.FontSize/1.25;
                    Storyboard.SetTarget(fontSizeAnimation2, L_Points);
                    Storyboard.SetTargetProperty(fontSizeAnimation2, new PropertyPath("(Label.FontSize)"));
                    pointsDecrease.Children.Add(fontSizeAnimation2);

                    ColorAnimation fontColorAnimation2 = new ColorAnimation();
                    fontColorAnimation2.BeginTime = TimeSpan.FromMilliseconds(0);
                    fontColorAnimation2.Duration = TimeSpan.FromMilliseconds(180);
                    fontColorAnimation2.To = (Color)ColorConverter.ConvertFromString("#04be5b"); ;
                    Storyboard.SetTarget(fontColorAnimation2, L_Points);
                    Storyboard.SetTargetProperty(fontColorAnimation2, new PropertyPath("(Label.Foreground).(SolidColorBrush.Color)"));
                    pointsDecrease.Children.Add(fontColorAnimation2);
                }
                pointsDecrease.Begin();
            } else {
                if(cardsView.IndexOf((sender as Image)) > 0 && cardsView.IndexOf((sender as Image)) < marginDecreaseStoryBoards.Count)
                    marginDecreaseStoryBoards[cardsView.IndexOf((sender as Image))].Begin();
            }         
        }

        private void ResetClickCount(object sender, EventArgs e) {
            clickCount--;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e) {
            if (currentGame.Dealer.CardsDeck.Count > 0) {
                currentGame.Dealer.AssignSize(MainGrid.ActualHeight, MainGrid.ActualWidth, currentGame);
                B_New_Click(sender, e);
            }
        }

        void PropertyChanged(object sender, PropertyChangedEventArgs e) {
            if(sender is Game) {
                switch (e.PropertyName) {
                    case "Difficulty":
                        NewTable();
                        break;
                    case "ShowCards":
                        FlipCards();
                        break;
                    case "PointsString":
                        IncreasePoints();
                        break;
                    case "CardsDeck":
                        FlipCards();
                        break;
                    case "Dealer":
                        myImgStoryBoards = new List<Storyboard>();
                        marginIncreaseStoryBoards = new List<Storyboard>();
                        marginDecreaseStoryBoards = new List<Storyboard>();
                        FlipCards();
                        auxWindow.Change(savedGames, currentGame);
                        break;
                }
            }
        }

        public void IncreasePoints() {
            L_Points.Content = currentGame.PointsString;
            MouseOverCustom(L_Points, null);
            MouseOutCustom(L_Points, null);
        }

        private void FlipCards() {
            ClearGrid();
            IncreasePoints();
            if (currentGame.ShowCards) {
                foreach (Card c in currentGame.CardsDeck) {
                    Image temp = new Image();
                    temp.Source = new BitmapImage(new Uri(c.ImgPath, UriKind.Relative));
                    temp.Name = c.Name;
                    Grid.SetRow(temp, c.Row);
                    Grid.SetColumn(temp, c.Column);
                    Grid.SetColumnSpan(temp, c.ColumnSpan);
                    Grid.SetRowSpan(temp, c.RowSpan);
                    temp.MaxHeight = c.MaxHeight;
                    temp.MaxWidth = c.MaxWidth;

                    temp.Margin = new Thickness(c.Margin);
                    temp.Opacity = 0.8;
                    temp.MouseUp += MouseUpCustom;
                    temp.MouseEnter += MouseOverCustom;
                    temp.MouseLeave += MouseOutCustom;


                    ThicknessAnimation marginAnimation1 = new ThicknessAnimation();
                    marginAnimation1.BeginTime = TimeSpan.FromMilliseconds(0);
                    marginAnimation1.Duration = TimeSpan.FromMilliseconds(180);
                    marginAnimation1.From = new Thickness(c.Margin);
                    marginAnimation1.To = new Thickness(c.Margin / 10);
                    Storyboard.SetTarget(marginAnimation1, temp);
                    Storyboard.SetTargetProperty(marginAnimation1, new PropertyPath("(Image.Margin)"));

                    DoubleAnimation opacityAnimation1 = new DoubleAnimation();
                    opacityAnimation1.BeginTime = TimeSpan.FromMilliseconds(0);
                    opacityAnimation1.Duration = TimeSpan.FromMilliseconds(180);
                    opacityAnimation1.From = 0.8;
                    opacityAnimation1.To = 1;
                    Storyboard.SetTarget(opacityAnimation1, temp);
                    Storyboard.SetTargetProperty(opacityAnimation1, new PropertyPath("(Image.Opacity)"));

                    DoubleAnimation opacityAnimation2 = new DoubleAnimation();
                    opacityAnimation2.BeginTime = TimeSpan.FromMilliseconds(0);
                    opacityAnimation2.Duration = TimeSpan.FromMilliseconds(180);
                    opacityAnimation2.From = 1;
                    opacityAnimation2.To = 0.8;
                    Storyboard.SetTarget(opacityAnimation2, temp);
                    Storyboard.SetTargetProperty(opacityAnimation2, new PropertyPath("(Image.Opacity)"));

                    ThicknessAnimation marginAnimation2 = new ThicknessAnimation();
                    marginAnimation2.BeginTime = TimeSpan.FromMilliseconds(0);
                    marginAnimation2.Duration = TimeSpan.FromMilliseconds(180);
                    marginAnimation2.From = new Thickness(c.Margin / 10);
                    marginAnimation2.To = new Thickness(c.Margin);
                    Storyboard.SetTarget(marginAnimation2, temp);
                    Storyboard.SetTargetProperty(marginAnimation2, new PropertyPath("(Image.Margin)"));


                    ObjectAnimationUsingKeyFrames animation = new ObjectAnimationUsingKeyFrames();
                    animation.BeginTime = TimeSpan.FromMilliseconds(0);
                    Storyboard.SetTarget(animation, temp);
                    Storyboard.SetTargetProperty(animation, new PropertyPath("(Image.Source)"));
                    DiscreteObjectKeyFrame keyFrame = new DiscreteObjectKeyFrame(BitmapFrame.Create(new Uri(c.ImgPath, UriKind.Relative)), TimeSpan.FromMilliseconds(0));
                    DiscreteObjectKeyFrame keyFrame2 = new DiscreteObjectKeyFrame(BitmapFrame.Create(new Uri(Card.MarkPath1, UriKind.Relative)), TimeSpan.FromMilliseconds(900));
                    animation.KeyFrames.Add(keyFrame);
                    animation.KeyFrames.Add(keyFrame2);
                    Storyboard stemp = new Storyboard();

                    stemp.Children.Add(animation);
                    stemp.Completed += ResetClickCount;
                    myImgStoryBoards.Add(stemp);

                    stemp = new Storyboard();
                    stemp.Children.Add(marginAnimation1);
                    stemp.Children.Add(opacityAnimation1);
                    marginIncreaseStoryBoards.Add(stemp);

                    stemp = new Storyboard();
                    stemp.Children.Add(marginAnimation2);
                    stemp.Children.Add(opacityAnimation2);
                    marginDecreaseStoryBoards.Add(stemp);


                    MainGrid.Children.Add(temp);
                    cardsView.Add(temp);
                }
            } else {
                foreach (Card c in currentGame.CardsDeck) {
                    Image temp = new Image();
                    temp.Source = new BitmapImage(new Uri(Card.MarkPath0, UriKind.Relative));
                    temp.Name = c.Name;
                    Grid.SetRow(temp, c.Row);
                    Grid.SetColumn(temp, c.Column);
                    Grid.SetColumnSpan(temp, c.ColumnSpan);
                    Grid.SetRowSpan(temp, c.RowSpan);
                    temp.MaxHeight = c.MaxHeight;
                    temp.MaxWidth = c.MaxWidth;

                    temp.Margin = new Thickness(c.Margin);
                    temp.Opacity = 0.8;
                    temp.MouseUp += MouseUpCustom;
                    temp.MouseEnter += MouseOverCustom;
                    temp.MouseLeave += MouseOutCustom;


                    ThicknessAnimation marginAnimation1 = new ThicknessAnimation();
                    marginAnimation1.BeginTime = TimeSpan.FromMilliseconds(0);
                    marginAnimation1.Duration = TimeSpan.FromMilliseconds(180);
                    marginAnimation1.From = new Thickness(c.Margin);
                    marginAnimation1.To = new Thickness(c.Margin / 10);
                    Storyboard.SetTarget(marginAnimation1, temp);
                    Storyboard.SetTargetProperty(marginAnimation1, new PropertyPath("(Image.Margin)"));

                    DoubleAnimation opacityAnimation1 = new DoubleAnimation();
                    opacityAnimation1.BeginTime = TimeSpan.FromMilliseconds(0);
                    opacityAnimation1.Duration = TimeSpan.FromMilliseconds(180);
                    opacityAnimation1.From = 0.8;
                    opacityAnimation1.To = 1;
                    Storyboard.SetTarget(opacityAnimation1, temp);
                    Storyboard.SetTargetProperty(opacityAnimation1, new PropertyPath("(Image.Opacity)"));

                    DoubleAnimation opacityAnimation2 = new DoubleAnimation();
                    opacityAnimation2.BeginTime = TimeSpan.FromMilliseconds(0);
                    opacityAnimation2.Duration = TimeSpan.FromMilliseconds(180);
                    opacityAnimation2.From = 1;
                    opacityAnimation2.To = 0.8;
                    Storyboard.SetTarget(opacityAnimation2, temp);
                    Storyboard.SetTargetProperty(opacityAnimation2, new PropertyPath("(Image.Opacity)"));

                    ThicknessAnimation marginAnimation2 = new ThicknessAnimation();
                    marginAnimation2.BeginTime = TimeSpan.FromMilliseconds(0);
                    marginAnimation2.Duration = TimeSpan.FromMilliseconds(180);
                    marginAnimation2.From = new Thickness(c.Margin / 10);
                    marginAnimation2.To = new Thickness(c.Margin);
                    Storyboard.SetTarget(marginAnimation2, temp);
                    Storyboard.SetTargetProperty(marginAnimation2, new PropertyPath("(Image.Margin)"));


                    ObjectAnimationUsingKeyFrames animation = new ObjectAnimationUsingKeyFrames();
                    animation.BeginTime = TimeSpan.FromMilliseconds(0);
                    Storyboard.SetTarget(animation, temp);
                    Storyboard.SetTargetProperty(animation, new PropertyPath("(Image.Source)"));
                    DiscreteObjectKeyFrame keyFrame = new DiscreteObjectKeyFrame(BitmapFrame.Create(new Uri(c.ImgPath, UriKind.Relative)), TimeSpan.FromMilliseconds(0));
                    DiscreteObjectKeyFrame keyFrame2 = new DiscreteObjectKeyFrame(BitmapFrame.Create(new Uri(Card.MarkPath1, UriKind.Relative)), TimeSpan.FromMilliseconds(900));
                    animation.KeyFrames.Add(keyFrame);
                    animation.KeyFrames.Add(keyFrame2);
                    Storyboard stemp = new Storyboard();

                    stemp.Children.Add(animation);
                    stemp.Completed += ResetClickCount;
                    myImgStoryBoards.Add(stemp);

                    stemp = new Storyboard();
                    stemp.Children.Add(marginAnimation1);
                    stemp.Children.Add(opacityAnimation1);
                    marginIncreaseStoryBoards.Add(stemp);

                    stemp = new Storyboard();
                    stemp.Children.Add(marginAnimation2);
                    stemp.Children.Add(opacityAnimation2);
                    marginDecreaseStoryBoards.Add(stemp);


                    MainGrid.Children.Add(temp);
                    cardsView.Add(temp);
                }
            }
        }

        private void NewTable() {
            EmptyDeckAndClearGrid();
            currentGame.CardsDeck = currentGame.Dealer.DealCards(MainGrid.ActualHeight, MainGrid.ActualWidth, currentGame);
            auxWindow.Change(savedGames, currentGame);
            FlipCards();
        }
    }
}

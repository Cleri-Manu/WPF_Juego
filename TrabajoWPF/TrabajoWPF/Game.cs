using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoWPF {
    public class Game : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName) {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private ObservableCollection<Card> _CardsDeck;
        public ObservableCollection<Card> CardsDeck {
            get { return _CardsDeck; }
            set {
                if (this._CardsDeck != value) {
                    this._CardsDeck = value;
                    this.NotifyPropertyChanged("CardsDeck");
                }
            }
        }

        private Dealer _Dealer;
        public Dealer Dealer {
            get { return _Dealer; }
            set {
                if (this._Dealer != value) {
                    this._Dealer = value;
                    this.NotifyPropertyChanged("Dealer");
                }
            }
        }


        private int _Points;
        public int Points {
            get { return _Points; }
            set {
                if (value > 0) {
                    if (this._Points != value) {
                        this._Points = value;
                        this.NotifyPropertyChanged("Points");
                        this.PointsString = "Puntos: " + Points.ToString();
                    }
                }
            }
        }

        private string _PointsString;
        public string PointsString {
            get { return _PointsString; }
            set {
                if (this._PointsString != value) {
                    this._PointsString = value;
                    this.NotifyPropertyChanged("PointsString");
                }
            }
        }

        private string _Name;
        public string Name {
            get { return _Name; }
            set {
                if (value.Equals("") || value.Equals(" ") || value.Equals("  ") || value.Equals("   ")) {
                    this._Name = "Game #" + Path.GetRandomFileName().Substring(0,4);
                    this.NotifyPropertyChanged("Name");
                } else {
                    if (this._Name != value) {
                        this._Name = value;
                        this.NotifyPropertyChanged("Name");
                    }
                }
            }
        }

        private bool _ShowCards;
        public bool ShowCards {
            get { return _ShowCards; }
            set {
                if (value == true || value == false) {
                    if (this._ShowCards != value) {
                        this._ShowCards = value;
                        this.NotifyPropertyChanged("ShowCards");
                    }
                }
            }
        }

        private string _Difficulty;
        public string Difficulty {
            get { return _Difficulty; }
            set {
                if (value.Equals("") || value.Equals(" ") || value.Equals("  ") || value.Equals("   ") || (value.Length == 0)) {
                        this._Difficulty = "Dificultad: Facil";
                        this.NotifyPropertyChanged("Difficulty");
                } else {
                    if(value.Equals("0")) { 
                        this._Difficulty = "Dificultad: Facil";
                        this.NotifyPropertyChanged("Difficulty");
                    } else if (value.Equals("1")) {
                        this._Difficulty = "Dificultad: Normal";
                        this.NotifyPropertyChanged("Difficulty");
                    } else if (value.Equals("2")) {
                        this._Difficulty = "Dificultad: Dificil";
                        this.NotifyPropertyChanged("Difficulty");
                    } else {
                        if (this._Difficulty != value) {
                            this._Difficulty = value;
                            this.NotifyPropertyChanged("Difficulty");
                        }
                    }
                }
            }
        }

        public Game() {
            this.Name = "";
            this.CardsDeck = new ObservableCollection<Card>();
            this.Points = 0;
            this.ShowCards = false;
            this.Difficulty = "Dificultad: Facil";
            this.PointsString = "Puntos: " + Points.ToString();
            Dealer = new Dealer();
        }
        public Game(Game game) {
            this.Name = game.Name;
            this.CardsDeck = new ObservableCollection<Card>(game.CardsDeck);
            this.Points = game.Points;
            this.ShowCards = game.ShowCards;
            this.Difficulty = game.Difficulty;
            this.PointsString = "Puntos: " + Points.ToString();
            this.Dealer = new Dealer(game.Dealer);
        }
        public Game(string name, ObservableCollection<Card> cardsDeck, int points, bool showCards, string dificultad) {
            this.Name = name;
            this.CardsDeck = cardsDeck;
            this.Points = points;
            this.ShowCards = showCards;
            this.Difficulty = dificultad;
            this.PointsString = "Puntos: " + Points.ToString();
        }
    }
}

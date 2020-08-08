using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoWPF {
    public class Dealer : INotifyPropertyChanged {
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

        private const int CardsRow = 8; //Numero de cartas por fila 
        private const int GridRows = 24;//Numero de filas que hay

        private int _NumOfCards;
        public int NumOfCards {
            get { return this._NumOfCards; }
            set {
                if (value > 0) {
                    if (this._NumOfCards != value) {
                        this._NumOfCards = value;
                        this.NotifyPropertyChanged("NumOfCards");
                    }
                }
            }
        }

        private int _NumOfRows;
        public int NumOfRows {
            get { return this._NumOfRows; }
            set {
                if (value > 0) {
                    if (this._NumOfRows != value) {
                        this._NumOfRows = value;
                        this.NotifyPropertyChanged("NumOfRows");
                    }
                }
            }
        }

        public Dealer() {
            CardsDeck = new ObservableCollection<Card>();
            NumOfCards = 24;
            NumOfRows = NumOfCards / CardsRow;
        }

        public Dealer(Dealer dealer) {
            CardsDeck = new ObservableCollection<Card>(dealer.CardsDeck);
            NumOfCards = dealer.NumOfCards;
            NumOfRows = NumOfCards / CardsRow;
        }

        public ObservableCollection<Card> DealCards(double gridHeight, double gridWidth, Game currentGame) {
            string cardName = "a";

            if (currentGame.Difficulty.Equals("Dificultad: Facil")) {
                NumOfCards = 24;
                NumOfRows = NumOfCards / CardsRow;
            } else if (currentGame.Difficulty.Equals("Dificultad: Normal")) {
                NumOfCards = 32;
                NumOfRows = NumOfCards / CardsRow;
            } else if (currentGame.Difficulty.Equals("Dificultad: Dificil")) {
                NumOfCards = 48;
                NumOfRows = NumOfCards / CardsRow;
            }

            for (int i = 0; i < NumOfCards; i++) {
                Card c = new Card(cardName);
                cardName += "a";
                CardsDeck.Add(c);
            }
            
            
            this.AssignNameAndImgPath();
            this.AssignPosition(gridHeight,gridWidth);

            return this.CardsDeck;
        }



        public void AssignNameAndImgPath() {
            Random rnd = new Random();
            List<int> tempImg = new List<int>();
            List<int> tempID = new List<int>();
            for (int i = 0; i < 24; i++) { tempImg.Add(i + 1); }
            for (int i = 0; i < NumOfCards; i++) { tempID.Add(i); }
            List<int> imgNames = tempImg.OrderBy(x => rnd.Next()).ToList();
            List<int> cardIDs = tempID.OrderBy(x => rnd.Next()).ToList();

            int card = 0;
            for (int j = 0; j<2; j++) {
                for (int i = 0; i < NumOfCards / 2; i++) {
                    CardsDeck[tempID[card]].ID = j;
                    CardsDeck[tempID[card]].ImgPath = "Cards/"+ imgNames[i] +".png";
                    card++;
                }
            }
            
        }

        public void AssignPosition(double gridHeight, double gridWidth) {
            Random rnd = new Random();
            int card = 0;
            int k = 0;                                  //En la fila k
            List<int> tempID = new List<int>();
            for (int i = 0; i < NumOfCards; i++) { tempID.Add(i); }
            List<int> cardIDs = tempID.OrderBy(x => rnd.Next()).ToList();
            List<string> colsRows = new List<string>();


            for (int j = 0; j < NumOfRows; j++) {       //Por cada fila de cartas que habrá
                for (int i = 0; i < CardsRow; i++) {    //Asigna 8 cartas en sus posiciones
                    if(NumOfCards == 48) {
                        CardsDeck[tempID[card]].Margin = 15;
                    } else if(NumOfCards == 32) {
                        CardsDeck[tempID[card]].Margin = 20;
                    } else {
                        CardsDeck[tempID[card]].Margin = 45;

                    }
                        
                    CardsDeck[tempID[card]].MaxHeight =  gridHeight / NumOfRows - ((gridHeight / NumOfRows) / 6);
                    CardsDeck[tempID[card]].MaxWidth = gridWidth / 8 - ((gridWidth / 8) / 6);
                    CardsDeck[tempID[card]].Row = k;
                    //CardsDeck[tempID[card]].Column = i;
                    colsRows.Add(i.ToString() + "-" + k.ToString());
                    CardsDeck[tempID[card]].RowSpan = (GridRows / NumOfRows);
                    CardsDeck[tempID[card]].ColumnSpan = 2;
                    card++;
                }
                k += (GridRows / NumOfRows);            //Pasa a la siguiente fila del grid
            }

            colsRows = colsRows.OrderBy(x => rnd.Next()).ToList();
            int cr;
            for (int i = 0; i < CardsDeck.Count; i++) {
                Int32.TryParse(colsRows[i].Substring(0, colsRows[i].IndexOf("-")), out cr);
                CardsDeck[i].Column = cr;
                Int32.TryParse(colsRows[i].Substring(colsRows[i].IndexOf("-")+1), out cr);
                CardsDeck[i].Row = cr;
            }
        }

        public void AssignSize(double gridHeight, double gridWidth, Game currentGame) {

            if (currentGame.Difficulty.Equals("Dificultad: Facil")) {
                NumOfCards = 24;
            } else if (currentGame.Difficulty.Equals("Dificultad: Normal")) {
                NumOfCards = 32;
            } else if (currentGame.Difficulty.Equals("Dificultad: Dificil")) {
                NumOfCards = 48;
            }

            int card = 0;
            for (int j = 0; j < NumOfRows; j++) {       //Por cada fila de cartas que habrá
                for (int i = 0; i < CardsRow; i++) {    //Asigna 8 cartas en sus posiciones
                    CardsDeck[card].MaxHeight = gridHeight / NumOfRows - ((gridHeight / NumOfRows) / 6);
                    CardsDeck[card].MaxWidth = gridWidth / 8 - ((gridWidth / 8) / 6);
                    card++;
                }
            }
        }
    }
}

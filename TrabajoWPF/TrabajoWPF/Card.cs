using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace TrabajoWPF {
    public class Card : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName) {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public const string MarkPath0 = "/TrabajoWPF;component/Cards/mark.png"; 
        public const string MarkPath1 = "Cards/mark.png";

        private string _Name;
        public string Name {
            get { return this._Name; }
            set {
                if (this._Name != value) {
                    this._Name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }

        private int _ID;
        public int ID {
            get { return this._ID; }
            set {
                if((value == 0) || (value == 1)) {
                    if (this._ID != value) {
                        this._ID = value;
                        this.NotifyPropertyChanged("ID");
                    }
                } else {
                    this._ID = -1;
                }
            }
        }

        private string _ImgPath;
        public string ImgPath {
            get { return this._ImgPath; }
            set {
                if (this._ImgPath != value) {
                    this._ImgPath = value;
                    this.NotifyPropertyChanged("ImgPath");
                }
            }
        }

        private int _Column;
        public int Column {
            get { return this._Column; }
            set {
                if (this._Column != value) {
                    this._Column = value;
                    this.NotifyPropertyChanged("Column");
                }
            }
        }

        private int _Row;
        public int Row {
            get { return this._Row; }
            set {
                if (this._Row != value) {
                    this._Row = value;
                    this.NotifyPropertyChanged("Row");
                }
            }
        }

        private int _ColumnSpan;
        public int ColumnSpan {
            get { return this._ColumnSpan; }
            set {
                if (this._ColumnSpan != value) {
                    this._ColumnSpan = value;
                    this.NotifyPropertyChanged("ColumnSpan");
                }
            }
        }

        private int _RowSpan;
        public int RowSpan {
            get { return this._RowSpan; }
            set {
                if (this._RowSpan != value) {
                    this._RowSpan = value;
                    this.NotifyPropertyChanged("RowSpan");
                }
            }
        }

        private int _Margin;
        public int Margin {
            get { return this._Margin; }
            set {
                if (value > 0) {
                    if (this._Margin != value) {
                        this._Margin = value;
                        this.NotifyPropertyChanged("Margin");
                    }
                }
            }
        }

        private double _MaxWidth;
        public double MaxWidth {
            get { return this._MaxWidth; }
            set {
                if (value > 0) {
                    if (this._MaxWidth != value) {
                        this._MaxWidth = value;
                        this.NotifyPropertyChanged("MaxWidth");
                    }
                }
            }
        }

        private double _MaxHeight;
        public double MaxHeight {
            get { return this._MaxHeight; }
            set {
                if (value > 0) {
                    if (this._MaxHeight != value) {
                        this._MaxHeight = value;
                        this.NotifyPropertyChanged("MaxHeight");
                    }
                }
            }
        }

        private int _Speed;
        public int Speed {
            get { return this._Speed; }
            set {
                if (value > 0) {
                    if (this._Speed != value) {
                        this._Speed = value;
                        this.NotifyPropertyChanged("Speed");
                    }
                }
            }
        }

        public Card() { }

        public Card(Card c) {
            this.Name = c.Name;
            this.ID = c.ID;
            this.ImgPath = c.ImgPath;
            this.Column = c.Column;
            this.Row = c.Row;
            this.Margin = c.Margin;
            this.MaxWidth = c.MaxWidth;
            this.MaxHeight = c.MaxHeight;
            this.Speed = c.Speed; //ms
        }

        public Card(string name) {
            this.Name = name;
            this.Speed = 800; //ms
        }

        public Card(string name, int id) {
            this.Name = name;
            this.ID = id;
            this.Speed = 800; //ms
        }

        public Card(string name, int id, string imgPath, int column, int row, int margin) {
            this.Name = name;
            this.ID = id;
            this.ImgPath = imgPath;
            this.Column = column;
            this.Row = row;
            this.Margin = margin;
            this.Speed = 800; //ms
        }

        public Card(string imgPath, int column, int row, int margin, int mWidth, int mHeight) {
            this.ImgPath = imgPath;
            this.Column = column;
            this.Row = row;
            this.Margin = margin;
            this.MaxWidth = mWidth;
            this.MaxHeight = mHeight;
            this.Speed = 800; //ms
        }

        public Card(string name, int id, string imgPath, int column, int row, int margin, int mWidth, int mHeight) {
            this.Name = name;
            this.ID = id;
            this.ImgPath = imgPath;
            this.Column = column;
            this.Row = row;
            this.Margin = margin;
            this.MaxWidth = mWidth;
            this.MaxHeight = mHeight;
            this.Speed = 800; //ms
        }

    }
}

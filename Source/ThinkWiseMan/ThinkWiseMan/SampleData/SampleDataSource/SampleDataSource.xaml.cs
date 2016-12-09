﻿//      *********    DO NOT MODIFY THIS FILE     *********
//      This file is regenerated by a design tool. Making
//      changes to this file can cause errors.
namespace Blend.SampleData.SampleDataSource
{
    using System; 
    using System.ComponentModel;

// To significantly reduce the sample data footprint in your production application, you can set
// the DISABLE_SAMPLE_DATA conditional compilation constant and disable sample data at runtime.
#if DISABLE_SAMPLE_DATA
    internal class SampleDataSource { }
#else

    public class SampleDataSource : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public SampleDataSource()
        {
            try
            {
                Uri resourceUri = new Uri("ms-appx:/SampleData/SampleDataSource/SampleDataSource.xaml", UriKind.RelativeOrAbsolute);
                Windows.UI.Xaml.Application.LoadComponent(this, resourceUri);
            }
            catch
            {
            }
        }

        private WiseIdeaModel _WiseIdeaModel = new WiseIdeaModel();

        public WiseIdeaModel WiseIdeaModel
        {
            get
            {
                return this._WiseIdeaModel;
            }
        }
    }

    public class WiseIdeaModelItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string _Content = string.Empty;

        public string Content
        {
            get
            {
                return this._Content;
            }

            set
            {
                if (this._Content != value)
                {
                    this._Content = value;
                    this.OnPropertyChanged("Content");
                }
            }
        }

        private string _Author = string.Empty;

        public string Author
        {
            get
            {
                return this._Author;
            }

            set
            {
                if (this._Author != value)
                {
                    this._Author = value;
                    this.OnPropertyChanged("Author");
                }
            }
        }

        private string _DateText = string.Empty;

        public string DateText
        {
            get
            {
                return this._DateText;
            }

            set
            {
                if (this._DateText != value)
                {
                    this._DateText = value;
                    this.OnPropertyChanged("DateText");
                }
            }
        }

        private double _Day = 0;

        public double Day
        {
            get
            {
                return this._Day;
            }

            set
            {
                if (this._Day != value)
                {
                    this._Day = value;
                    this.OnPropertyChanged("Day");
                }
            }
        }

        private double _Month = 0;

        public double Month
        {
            get
            {
                return this._Month;
            }

            set
            {
                if (this._Month != value)
                {
                    this._Month = value;
                    this.OnPropertyChanged("Month");
                }
            }
        }

        private bool _IsFavorite = false;

        public bool IsFavorite
        {
            get
            {
                return this._IsFavorite;
            }

            set
            {
                if (this._IsFavorite != value)
                {
                    this._IsFavorite = value;
                    this.OnPropertyChanged("IsFavorite");
                }
            }
        }

        private bool _Selected = false;

        public bool Selected
        {
            get
            {
                return this._Selected;
            }

            set
            {
                if (this._Selected != value)
                {
                    this._Selected = value;
                    this.OnPropertyChanged("Selected");
                }
            }
        }

        private string _Id = string.Empty;

        public string Id
        {
            get
            {
                return this._Id;
            }

            set
            {
                if (this._Id != value)
                {
                    this._Id = value;
                    this.OnPropertyChanged("Id");
                }
            }
        }
    }

    public class WiseIdeaModel : System.Collections.ObjectModel.ObservableCollection<WiseIdeaModelItem>
    { 
    }
#endif
}

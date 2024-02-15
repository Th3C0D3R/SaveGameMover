using System;
using System.ComponentModel;

namespace SaveGameMoverData
{
    public class Profile : INotifyPropertyChanged
    {
        #region Private
        private string locPath = "";
        private string remPath = "";
        private string name = "";
        private Guid guid = Guid.Empty;
        #endregion

        #region Public
        public string LocalPath
        {
            get { return locPath; }
            set
            {
                if (value != locPath)
                {
                    locPath = value;
                    OnPropertyChanged(nameof(LocalPath));
                }
            }
        }
        public string RemotePath
        {
            get { return remPath; }
            set
            {
                if (value != remPath)
                {
                    remPath = value;
                    OnPropertyChanged(nameof(RemotePath));
                }
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public Guid Guid
        {
            get { return guid; }
            set
            {
                if (value != guid)
                {
                    guid = value;
                    OnPropertyChanged(nameof(Guid));
                }
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        public override string ToString()
        {
            return Name;
        }
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    }
}

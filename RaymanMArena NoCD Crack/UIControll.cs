using System;
using System.ComponentModel;

namespace RaymanMArena_NoCD_Crack
{
    class UIControll : INotifyPropertyChanged
    {
        public static UIControll GetNewController()
        {
            return new UIControll();
        }

        private string _fileName;
        private bool _ready = false;
        private string _crackLabel = "CrackIt!";
        private bool _backup = true;

        public string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                _fileName = value;
                NotifyPropertyChanged("FileName");
            }
        }

        public bool ReadyToCrack
        {
            get
            {
                return _ready;
            }
            set
            {
                _ready = value;
                NotifyPropertyChanged("ReadyToCrack");
            }
        }

        public string CrackButtonLabel
        {
            get
            {
                return _crackLabel;
            }
            set
            {
                _crackLabel = value;
                NotifyPropertyChanged("CrackButtonLabel");
            }
        }

        public bool CreateBackup
        {
            get
            {
                return _backup;
            }
            set
            {
                _backup = value;
                NotifyPropertyChanged("CreateBackup");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using CommandHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommandTester
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ICommand _buttonClickedCommand;

        public MainWindowViewModel()
        {
            Message = "Hallo!";
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }



        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                //Hiermit informieren wir die Oberfläche, dass sich die Property "Message" 
                //geändert hat. Damit wird diese Property neu gebunden und der zugewiesene
                //Wert erscheint.
                //PropertyChanged(this, new PropertyChangedEventArgs("Message")); //-> Direkter Aufruf
                NotifyPropertyChanged();  //-> Komfortabler
            }
        }


        public ICommand ButtonClickedCommand
        {

            get
            {
                if (_buttonClickedCommand == null)
                    _buttonClickedCommand = new RelayCommand(s => CommandMethod());
                return _buttonClickedCommand;
            }

        }

        private void CommandMethod()
        {
            Message = "Button wurde geklickt!";

        }
    }
}

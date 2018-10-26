using System.Runtime.Serialization;


namespace OASU_RPO.Configuration {
    [DataContract]
    public class Exchange : ConfProperty {

        private string _Username = "";
        private string _Password = "";
        private string _ServerName = "cas.crimeanpost.ru";
        private string _Domain = "crimeanpost.ru";
        private string _SenderName = "robomaster@russianpost.ru";
        private string _MessageRegex = "File (?<FILE>\\d{8}\\.\\d{2}F) loaded by AMP system";


        [DataMember]
        public string Username {
            get {
                return _Username;
            }
            set {
                string old = _Username;
                _Username = value;
                SingletonEvent.OnPropertyChanged(value, old);
            }
        }

        [DataMember]
        public string Password {
            get {
                return _Password;
            }
            set {
                string old = _Password;
                _Password = value;
                SingletonEvent.OnPropertyChanged(value, old);
            }
        }

        [DataMember]
        public string ServerName {
            get {
                return _ServerName;
            }
            set {
                string old = _ServerName;
                _ServerName = value;
                SingletonEvent.OnPropertyChanged(value, old);
            }
        }

        [DataMember]
        public string Domain {
            get {
                return _Domain;
            }
            set {
                string old = _Domain;
                _Domain = value;
                SingletonEvent.OnPropertyChanged(value, old);
            }
        }

        [DataMember]
        public string SenderName {
            get {
                return _SenderName;
            }
            set {
                string old = _SenderName;
                _SenderName = value;
                SingletonEvent.OnPropertyChanged(value, old);
            }
        }

        [DataMember]
        public string MessageRegex {
            get {
                return _MessageRegex;
            }
            set {
                string old = _MessageRegex;
                _MessageRegex = value;
                SingletonEvent.OnPropertyChanged(value, old);
            }
        }

        public SingletonEvent SingletonEvent {
            get {
                return SingletonEvent.Instance;
            }
        }

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context) {
            Username = (string.IsNullOrWhiteSpace(Username)) ? "" : Username;
            Password = (string.IsNullOrWhiteSpace(Password)) ? "" : Password;
            ServerName = (string.IsNullOrWhiteSpace(ServerName)) ? "cas.crimeanpost.ru" : ServerName;
            Domain = (string.IsNullOrWhiteSpace(Domain)) ? "crimeanpost.ru" : Domain;
            SenderName = (string.IsNullOrWhiteSpace(SenderName)) ? "robomaster@russianpost.ru" : SenderName;
            MessageRegex = (string.IsNullOrWhiteSpace(MessageRegex)) ? "File (?<FILE>\\d{8}\\.\\d{2}F) loaded by AMP system" : MessageRegex;
        }
    }
}

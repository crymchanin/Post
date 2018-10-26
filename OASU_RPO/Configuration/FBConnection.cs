using System.Runtime.Serialization;


namespace OASU_RPO.Configuration {
    [DataContract]
    public class FBConnection : ConfProperty {

        private string _Username = "";
        private string _Password ="";
        private string _Database = "C:\\Program Files\\RussianPost\\PostUnit\\db\\POSTDATA.IB";
        private string _Datasource = "localhost";
        private bool _Pooling;
        private int _ConnectionLifetime = 60;
        private string _Charset = "WIN1251";


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
        public string Database {
            get {
                return _Database;
            }
            set {
                string old = _Database;
                _Database = value;
                SingletonEvent.OnPropertyChanged(value, old);
            }
        }

        [DataMember]
        public string Datasource {
            get {
                return _Datasource;
            }
            set {
                string old = _Datasource;
                _Datasource = value;
                SingletonEvent.OnPropertyChanged(value, old);
            }
        }

        [DataMember]
        public bool Pooling {
            get {
                return _Pooling;
            }
            set {
                bool old = _Pooling;
                _Pooling = value;
                SingletonEvent.OnPropertyChanged(value, old);
            }
        }

        [DataMember]
        public int ConnectionLifetime {
            get {
                return _ConnectionLifetime;
            }
            set {
                int old = _ConnectionLifetime;
                _ConnectionLifetime = value;
                SingletonEvent.OnPropertyChanged(value, old);
            }
        }

        [DataMember]
        public string Charset {
            get {
                return _Charset;
            }
            set {
                string old = _Charset;
                _Charset = value;
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
            Database = (string.IsNullOrWhiteSpace(Database)) ? "C:\\Program Files\\RussianPost\\PostUnit\\db\\POSTDATA.IB" : Database;
            Datasource = (string.IsNullOrWhiteSpace(Datasource)) ? "localhost" : Datasource;
            ConnectionLifetime = (ConnectionLifetime == 0) ? 60 : ConnectionLifetime;
            Charset = (string.IsNullOrWhiteSpace(Charset)) ? "WIN1251" : Charset;
        }
    }
}

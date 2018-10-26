using System.Runtime.Serialization;


namespace OASU_RPO.Configuration {
    [DataContract]
    public class Config : ConfProperty {

        private Global _Global;
        private FBConnection _FBConnection;
        private Exchange _Exchange;
        private Admin _Admin;


        [DataMember]
        public Global Global {
            get {
                return _Global;
            }
            set {
                Global old = _Global;
                _Global = value;
                SingletonEvent.OnPropertyChanged(value, old);
            }
        }

        [DataMember]
        public FBConnection FBConnection {
            get {
                return _FBConnection;
            }
            set {
                FBConnection old = _FBConnection;
                _FBConnection = value;
                SingletonEvent.OnPropertyChanged(value, old);
            }
        }

        [DataMember]
        public Exchange Exchange {
            get {
                return _Exchange;
            }
            set {
                Exchange old = _Exchange;
                _Exchange = value;
                SingletonEvent.OnPropertyChanged(value, old);
            }
        }

        [DataMember]
        public Admin Admin {
            get {
                return _Admin;
            }
            set {
                Admin old = _Admin;
                _Admin = value;
                SingletonEvent.OnPropertyChanged(value, old);
            }
        }

        public SingletonEvent SingletonEvent {
            get {
                return SingletonEvent.Instance;
            }
        }

        public Config() {
            Global = new Global();
            FBConnection = new FBConnection();
            Exchange = new Exchange();
            Admin = new Admin();
        }

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context) {
            Global = (Global == null) ? new Global() : Global;
            FBConnection = (FBConnection == null) ? new FBConnection() : FBConnection;
            Exchange = (Exchange == null) ? new Exchange() : Exchange;
            Admin = (Admin == null) ? new Admin() : Admin;
        }
    }
}

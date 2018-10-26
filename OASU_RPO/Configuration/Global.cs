using System.Runtime.Serialization;


namespace OASU_RPO.Configuration {
    [DataContract]
    public class Global : ConfProperty {

        private int _ShedulerInterval = 600000;
        private int _SearchDaysCount = 30;
        private bool _SoundNotifications;
        private int _NotifyWindowOpacity = 90;
        private bool _EnableAutorun;
        private bool _RunMinimized;
        private bool _CheckUpdates;
        private string _UpdatesServerName = "localhost";


        [DataMember]
        public int ShedulerInterval {
            get {
                return _ShedulerInterval;
            }
            set {
                int old = _ShedulerInterval;
                _ShedulerInterval = value;
                SingletonEvent.OnPropertyChanged(value, old);
            }
        }

        [DataMember]
        public int SearchDaysCount {
            get {
                return _SearchDaysCount;
            }
            set {
                int old = _SearchDaysCount;
                _SearchDaysCount = value;
                SingletonEvent.OnPropertyChanged(value, old);
            }
        }

        [DataMember]
        public bool SoundNotifications {
            get {
                return _SoundNotifications;
            }
            set {
                bool old = _SoundNotifications;
                _SoundNotifications = value;
                SingletonEvent.OnPropertyChanged(value, old);
            }
        }

        [DataMember]
        public int NotifyWindowOpacity {
            get {
                return _NotifyWindowOpacity;
            }
            set {
                int old = _NotifyWindowOpacity;
                _NotifyWindowOpacity = value;
                SingletonEvent.OnPropertyChanged(value, old);
            }
        }

        [DataMember]
        public bool EnableAutorun {
            get {
                return _EnableAutorun;
            }
            set {
                bool old = _EnableAutorun;
                _EnableAutorun = value;
                SingletonEvent.OnPropertyChanged(value, old);
            }
        }

        [DataMember]
        public bool RunMinimized {
            get {
                return _RunMinimized;
            }
            set {
                bool old = _RunMinimized;
                _RunMinimized = value;
                SingletonEvent.OnPropertyChanged(value, old);
            }
        }

        [DataMember]
        public bool CheckUpdates {
            get {
                return _CheckUpdates;
            }
            set {
                bool old = _CheckUpdates;
                _CheckUpdates = value;
                SingletonEvent.OnPropertyChanged(value, old);
            }
        }

        [DataMember]
        public string UpdatesServerName {
            get {
                return _UpdatesServerName;
            }
            set {
                string old = _UpdatesServerName;
                _UpdatesServerName = value;
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
            ShedulerInterval = (ShedulerInterval == 0) ? 600000 : ShedulerInterval;
            SearchDaysCount = (SearchDaysCount == 0) ? 30 : SearchDaysCount;
            NotifyWindowOpacity = (NotifyWindowOpacity == 0) ? 90 : NotifyWindowOpacity;
            UpdatesServerName = (string.IsNullOrWhiteSpace(UpdatesServerName)) ? "localhost" : UpdatesServerName;
        }
    }
}

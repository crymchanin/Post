using System;
using System.Runtime.Serialization;


namespace OASU_RPO.Configuration {
    [DataContract]
    public class Admin : ConfProperty {

        private string _RootName;
        private string _RootPassword;


        [DataMember]
        public string RootName {
            get {
                return _RootName;
            }
            set {
                string old = _RootName;
                _RootName = value;
                SingletonEvent.OnPropertyChanged(value, old);
            }
        }

        [DataMember]
        public string RootPassword {
            get {
                return _RootPassword;
            }
            set {
                string old = _RootPassword;
                _RootPassword = value;
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
            if (string.IsNullOrWhiteSpace(RootName) || string.IsNullOrWhiteSpace(RootPassword)) {
                throw new Exception("Логин или пароль администратора не задан");
            }
        }
    }
}

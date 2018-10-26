using System.Runtime.CompilerServices;


namespace OASU_RPO.Configuration {

    /// <summary>
    /// Представляет метод, обрабатывающий событие PropertyChanged для объектов конфигурации
    /// </summary>
    /// <param name="newValue"></param>
    /// <param name="oldValue"></param>
    /// <param name="propertyName"></param>
    public delegate void ChangeEventHandler(object newValue, object oldValue, string propertyName);

    /// <summary>
    /// Синглтон события PropertyChanged
    /// </summary>
    public sealed class SingletonEvent {
        private static SingletonEvent _Instance = null;
        private static readonly object padlock = new object();

        public event ChangeEventHandler PropertyChangedEvent;

        private SingletonEvent() { }

        public static SingletonEvent Instance {
            get {
                lock (padlock) {
                    if (_Instance == null) {
                        _Instance = new SingletonEvent();
                    }

                    return _Instance;
                }
            }
        }

        public void OnPropertyChanged(object newValue, object oldValue, [CallerMemberName]string propertyName = "") {
            ChangeEventHandler ev = PropertyChangedEvent;

            ev?.Invoke(newValue, oldValue, propertyName);
        }
    }

    /// <summary>
    /// Предоставляет событие PropertyChanged для всех объектов конфигурации
    /// </summary>
    public interface ConfProperty {

        SingletonEvent SingletonEvent { get; }
    }
}

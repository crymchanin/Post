using System.Runtime.Serialization;


namespace OASU_RPO.Updates {
    [DataContract]
    public class ResponseObject {
        [DataMember]
        public bool success { get; set; }
        [DataMember]
        public string result { get; set; }
    }
}

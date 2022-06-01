using System;
using System.Collections.Generic;

namespace MGM.MVP.StorageTable.Entities
{
    public class Entity
    {
        private readonly Dictionary<string, object> _properties = new Dictionary<string, object>();

        public string StationName { get; set; }

        public string Etag { get; set; }

        public string ObservationDate { get; set; }

        public string ObservationTime { get; set; }

        public DateTimeOffset? Timestamp { get; set; }

        public object this[string name]
        {
            get => (ContainsProperty(name)) ? _properties[name] : null;
            set => _properties[name] = value;
        }

        public Dictionary<string, object> KeyValuePairs => _properties;

        public ICollection<string> PropertyNames => _properties.Keys;

        public int PropertyCount => _properties.Count;

        public bool ContainsProperty(string name) => _properties.ContainsKey(name);
    }
}

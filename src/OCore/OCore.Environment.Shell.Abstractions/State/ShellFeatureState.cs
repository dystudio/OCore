﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using OCore.Entities;

namespace OCore.Environment.Shell.State
{
    /// <summary>
    /// Reprensents the state if a feature in a tenant.
    /// </summary>
    public class ShellFeatureState : IEntity
    {
        //public JObject Properties { get; set; } = new JObject();
        public string Id { get; set; }
        public State InstallState { get; set; }
        public State EnableState { get; set; }

        [JsonIgnore]
        public bool IsInstalled { get { return InstallState == State.Up; } }
        [JsonIgnore]
        public bool IsEnabled { get { return EnableState == State.Up; } }
        [JsonIgnore]
        public bool IsDisabled { get { return EnableState == State.Down || EnableState == State.Undefined; } }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum State
        {
            Undefined,
            Rising,
            Up,
            Falling,
            Down,
        }
    }
}

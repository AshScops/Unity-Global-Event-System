using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace event_system
{
    public abstract class EventBase
    {
        public string Name { get; private set; }
        public bool Enable { get; private set; }

        public EventBase() { }
        public EventBase(string name)
        {
            Name = name;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public virtual void SetEnable(bool enable, bool includeChildren = true)
        {
            Enable = enable;
        }

        public virtual EventBase Find(string name)
        {
            return Name == name ? this : null;
        }

        public abstract void OnUpdate();

    }

}

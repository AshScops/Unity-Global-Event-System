using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace event_system
{
    public class EventManager : Singleton<EventManager>
    {
        private GroupEvent m_root = new GroupEvent("Root");

        private T Create<T>(string name, string parentName) where T : EventBase, new()
        {
            GroupEvent group = m_root.Find(parentName) as GroupEvent;
            if (name is null || group is null) return null;

            var e = new T();
            e.SetName(name);
            group.AddEvent(e);
            return e;
        }

        public SingleEvent CreateSingleEvent(string name, string parentName = "Root")
        {
            return Create<SingleEvent>(name, parentName);
        }

        public GroupEvent CreateGroupEvent(string name, string parentName = "Root")
        {
            return Create<GroupEvent>(name, parentName);
        }

        public void Enable(string name, bool enable, bool includeChildren = true)
        {
            var target = m_root.Find(name);
            if (target == null) return;
            target.SetEnable(enable, includeChildren);
        }

        public void OnUpdate()
        {
            m_root?.OnUpdate();
        }

    }

}

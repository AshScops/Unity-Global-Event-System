using System.Collections.Generic;
using UnityEngine;

namespace event_system
{
    /// <summary>
    /// 它本身不带Func和Action，仅存储一系列SingleEvent
    /// </summary>
    public class GroupEvent : EventBase
    {
        private List<EventBase> m_children;

        public GroupEvent() { }
        public GroupEvent(string name) : base(name) { }

        public void AddEvent(EventBase e)
        {
            if (e == null) return;
            m_children ??= new List<EventBase>();
            m_children.Add(e);
            Debug.Log("Add " + e.Name + " to " + this.Name + " done.");
        }

        public bool RemoveEvent(EventBase e)
        {
            return m_children != null && m_children.Remove(e);
        }

        public override void SetEnable(bool enable, bool includeChildren = true)
        {
            base.SetEnable(enable);
            if (!includeChildren || m_children == null) return;
            foreach (var child in m_children)
            {
                child.SetEnable(enable);
            }
        }

        public override EventBase Find(string name)
        {
            if (name == null) return null;
            if (this.Name == name) return this;
            if (m_children == null) return null;
            foreach (var child in m_children)
            {
                if (child.Find(name) != null)
                    return child;
            }
            return null;
        }

        public override void OnUpdate()
        {
            Debug.Log(this.Name + m_children);
            if(! this.Enable || m_children == null) return;

            foreach (var child in m_children)
            {
                child.OnUpdate();
            }
        }
    }

}

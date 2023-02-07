using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace event_system
{
    public class SingleEvent : EventBase
    {
        public SingleEvent() { }
        public SingleEvent(string name) : base(name) { }

        private Func<bool> m_condition;
        private Action m_action;

        public void SetCondition(Func<bool> condition)
        {
            m_condition += condition;
        }

        public void RemoveCondition(Func<bool> condition)
        {
            m_condition -= condition;
        }

        public void Subscribe(Action action)
        {
            m_action += action;
        }

        public void Unsubscribe(Action action)
        {
            m_action -= action;
        }

        public override void OnUpdate()
        {
            if (!this.Enable) return;
            if(m_condition != null && m_condition())
            {
                m_action();
                Debug.Log("m_action execute");
            }
        }
    }

}

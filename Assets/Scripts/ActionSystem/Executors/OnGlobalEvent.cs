using UnityEngine;

namespace RomanDoliba.ActionSystem
{
    public class OnGlobalEvent : ExecutorBase
    {
        [SerializeField] private string _eventName;

        private void Awake()
        {
            GlobalEventSender.OnEvent += ExecuteEvent;
        }

        protected void ExecuteEvent(string eventName)
        {
            if (eventName == _eventName)
            {
                Execute();
            }
        }   
    }
}

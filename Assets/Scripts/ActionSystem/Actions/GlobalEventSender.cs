using System;
using UnityEngine;

namespace RomanDoliba.ActionSystem
{
    public class GlobalEventSender : ActionBase
    {
        public static Action<string> OnEvent;
        [SerializeField] private string _eventName;
        public static void FireEvent(string eventName)
        {
            OnEvent?.Invoke(eventName);
        }
        public override void Execute(object data = null)
        {
            FireEvent(_eventName);
        }
    }
}

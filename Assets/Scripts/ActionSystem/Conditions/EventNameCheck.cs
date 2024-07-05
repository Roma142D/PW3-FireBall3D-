using UnityEngine;

namespace RomanDoliba.ActionSystem
{
    public class EventNameCheck : ConditionBase
    {
        [SerializeField] string _eventName;

        public override bool Check(object data = null)
        {
            if (data.ToString() == _eventName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

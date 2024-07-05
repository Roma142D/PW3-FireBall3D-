using System.Data.Common;
using UnityEngine;

namespace RomanDoliba.ActionSystem
{
    public class SetUnsetActive : ActionBase
    {
        [SerializeField] private GameObject _objectToSetActive;

        public override void Execute(object data = null)
        {
            if (!_objectToSetActive.activeSelf)
            {
                _objectToSetActive.SetActive(true);
            }
            else
            {
                _objectToSetActive.SetActive(false);
            }
        }
    }
}

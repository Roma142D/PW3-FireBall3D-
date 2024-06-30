using UnityEngine;

namespace RomanDoliba.ActionSystem
{
    public class Destroy : ActionBase
    {
        [SerializeField] private GameObject _objectToDestroy;
        [SerializeField] private float _delayToDestroy;

        public override void Execute(object data = null)
        {
            Destroy(_objectToDestroy, _delayToDestroy);
        }
    }  
}

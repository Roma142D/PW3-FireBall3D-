using RomanDoliba.ActionSystem;
using UnityEngine;

namespace RomanDoliba.Core
{
    public class TreasureControler : MonoBehaviour
    {
        [SerializeField] private int _treasureHealth;
        [SerializeField] private string _onTreasureHitEventName;
        [SerializeField] private GameObject _treasure;

        private void Awake()
        {
            GlobalEventSender.OnEvent += OnTreasureTakeHit;
        }

        private void OnTreasureTakeHit(string eventName)
        {
            if (eventName == _onTreasureHitEventName)
            {
                _treasureHealth -= 1;
                if (_treasureHealth <= 0)
                {
                    Destroy(_treasure);
                }
            }
        }
    }
}

using RomanDoliba.ActionSystem;
using TMPro;
using UnityEngine;

namespace RomanDoliba.Core
{
    public class TreasureControler : MonoBehaviour
    {
        [SerializeField] private int _treasureHealth;
        [SerializeField] private string _onTreasureHitEventName;
        [SerializeField] private GameObject _treasure;
        [SerializeField] private TextMeshPro _treasureUI;

        private void Awake()
        {
            GlobalEventSender.OnEvent += OnTreasureTakeHit;
            _treasureUI.SetText($"{_treasureHealth}");
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
                _treasureUI.SetText($"{_treasureHealth}");
            }
        }
    }
}

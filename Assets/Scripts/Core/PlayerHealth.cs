using System;
using RomanDoliba.ActionSystem;
using TMPro;
using UnityEngine;

namespace RomanDoliba.Core
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int _playerHealth;
        [SerializeField] private string _onHitEventName;
        [SerializeField] private TextMeshProUGUI _healthBar;
        [SerializeField] private GameObject _cannon;
                
        private void Awake()
        {
            GlobalEventSender.OnEvent += OnTakeHit;
            _healthBar.SetText($"Helth:{_playerHealth}");
        }

        private void OnTakeHit(string eventName)
        {
            if (eventName == _onHitEventName)
            {
                _playerHealth -= 1;
                _healthBar.SetText($"Helth:{_playerHealth}");
                if (_playerHealth <= 0)
                {
                   Destroy(_cannon, 1f);
                }
            }
        }
    }
}

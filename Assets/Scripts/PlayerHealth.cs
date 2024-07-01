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
                    Time.timeScale = 0;
                }
            }
        }
    }
}

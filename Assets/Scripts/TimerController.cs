using System;
using RomanDoliba.ActionSystem;
using TMPro;
using UnityEngine;

namespace RomanDoliba.Core
{
    public class TimerController : MonoBehaviour
    {
        [SerializeField] private float _oneStarResult;
        [SerializeField] private float _twoStarResult;        
        [SerializeField] private float _threeStarResult;
        [SerializeField] private TextMeshProUGUI _timerUI;
        [SerializeField] private GameObject _cannon;
        private float _curentTime;

        private void Awake()
        {
            _timerUI.SetText(_oneStarResult.ToString());
            _curentTime = _oneStarResult;
        }
        private void Update()
        {
            Countdown();

            if (_curentTime < 0)
            {
                Destroy(_cannon, 1f);
            }
        }

        private void Countdown()
        {
            _curentTime -= Time.deltaTime;
            _timerUI.SetText(Math.Round(_curentTime).ToString());
        }
    }
}

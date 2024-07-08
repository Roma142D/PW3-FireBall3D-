using System;
using RomanDoliba.ActionSystem;
using TMPro;
using UnityEngine;

namespace RomanDoliba.Core
{
    public class TimerController : MonoBehaviour
    {
        [SerializeField] public TimeOnStarsResult _timeOnStarsResult;
        [SerializeField] private TextMeshProUGUI _timerUI;
        [SerializeField] private GameObject _cannon;
        private float _curentTime;

        public float CurentTime => _curentTime; 
        private void Awake()
        {
            _timerUI.SetText(_timeOnStarsResult.OneStarResult.ToString());
            _curentTime = _timeOnStarsResult.OneStarResult;
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

        [System.Serializable]
        public struct TimeOnStarsResult
        {
            public float OneStarResult;
            public float TwoStarResult;        
            public float ThreeStarResult;
        }
    }
}

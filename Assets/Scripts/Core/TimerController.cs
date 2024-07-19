using System;
using TMPro;
using UnityEngine;

namespace RomanDoliba.Core
{
    public class TimerController : MonoBehaviour 
    {
        public static TimerController Instance{get; private set;}
        [SerializeField] public TimeOnStarsResult _timeOnStarsResult;
        [SerializeField] private TextMeshProUGUI _timerUI;
        [SerializeField] private GameObject _cannon;
        private float _curentTime;

        public float CurentTime => _curentTime; 
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);   
            }
            
            _timerUI.SetText(Instance.OneStarResult().ToString());
            _curentTime = Instance.OneStarResult();
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

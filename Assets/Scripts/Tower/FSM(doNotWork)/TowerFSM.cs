using RomanDoliba.Core;
using TMPro;
using UnityEngine;

namespace RomanDoliba.Tower
{
    public class TowerFSM : MonoBehaviour
    {
        public enum State {LowSpeed, HighSpeed, Counterwrap}
        private State _currentState;
        public State CurrentState
        {
            get => _currentState;
            set
            {
                _currentState = value;
                _text.text = _currentState.ToString();
            }
        }
        [SerializeField] private TowerSectionsPooling _tower;
        [SerializeField] private TowerData _towerData;
        [SerializeField] private TextMeshProUGUI _text;
        private TowerSectionBase[] _towerSections;
        
        private void Start()
        {
            StateLowSpeed();
            _towerSections = _tower.GetComponentsInChildren<TowerSectionBase>();
        }

        public void StateLowSpeed()
        {
            CurrentState = State.LowSpeed;
            foreach (var towerSection in _towerSections)
            {
                towerSection.RotationSpeed = new Vector2(_towerData.RotationLowSpeed.x, _towerData.RotationLowSpeed.y);
            }
            
        }
        public void StateHighSpeed()
        {
            CurrentState = State.HighSpeed;
            foreach (var towerSection in _towerSections)
            {
                towerSection.RotationSpeed = new Vector2(_towerData.RotationHighSpeed.x, _towerData.RotationHighSpeed.y);
            }
        }
        public void StateCounterwrap()
        {
            CurrentState = State.Counterwrap;
            foreach (var towerSection in _towerSections)
            {
                    if (towerSection.Counterwrap == true)
                {
                    towerSection.Counterwrap = false;
                }
                else
                {
                    towerSection.Counterwrap = true;
                }
            }
            
        }

        private void Update()
        {
            ExecuteCurrentState();
        }
        public void ExecuteCurrentState()
        {
            if (_currentState == State.LowSpeed)
            {
                if (TimerController.Instance.CurentTime < TimerController.Instance.TwoStarResult())
                {
                    StateHighSpeed();
                }
                else if (_tower.TowerSectionsCount > 5)
                {
                    StateCounterwrap();
                }
            }
            if (_currentState == State.HighSpeed)
            {
                if (TimerController.Instance.CurentTime < TimerController.Instance.ThreeStarResult())
                {
                    StateCounterwrap();
                }
                else if (_tower.TowerSectionsCount > 10)
                {
                    StateLowSpeed();
                }
            }
        }

        [System.Serializable]
        public struct TowerData
        {
            public Vector2 RotationLowSpeed;
            public Vector2 RotationHighSpeed;
        }
    }
}

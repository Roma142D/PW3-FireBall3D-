using RomanDoliba.Core;
using TMPro;
using UnityEngine;

namespace RomanDoliba.Tower
{
    public class TowerSectionFSM : MonoBehaviour
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
        private TowerSectionBase _towerSection;
        
        private void Start()
        {
            StateLowSpeed();
        }

        public void StateLowSpeed()
        {
            CurrentState = State.LowSpeed;
            
            _towerSection.RotationSpeed = new Vector2(_towerData.RotationLowSpeed.x, _towerData.RotationLowSpeed.y);
            
        }
        public void StateHighSpeed()
        {
            CurrentState = State.HighSpeed;
            
            _towerSection.RotationSpeed = new Vector2(_towerData.RotationHighSpeed.x, _towerData.RotationHighSpeed.y);
        }
        public void StateCounterwrap()
        {
            CurrentState = State.Counterwrap;
            
                if (_towerSection.Counterwrap == true)
            {
                _towerSection.Counterwrap = false;
            }
            else
            {
                _towerSection.Counterwrap = true;
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

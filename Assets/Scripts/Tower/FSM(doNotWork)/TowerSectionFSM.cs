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
            }
        }
        
        [SerializeField] private TowerData _towerData;
        private TowerGenerator _tower;
        private Vector2 _currentRotationSpeed;
        private bool _currentRotationDirection;
        
        private void Start()
        {
            StateLowSpeed();
            _tower = gameObject.GetComponentInParent<TowerGenerator>();
            _currentRotationDirection = _towerData.Counterwrap;
            _currentRotationSpeed = _towerData.RotationLowSpeed;
        }

        public void StateLowSpeed()
        {
            CurrentState = State.LowSpeed;
            _currentRotationSpeed = _towerData.RotationLowSpeed;          
        }
        public void StateHighSpeed()
        {
            CurrentState = State.HighSpeed;
            _currentRotationSpeed = _towerData.RotationHighSpeed;
            Rotate(_currentRotationSpeed, _currentRotationDirection, _towerData.Shield);
        }
        public void StateCounterwrap()
        {
            CurrentState = State.Counterwrap;
                        
            if (_currentRotationDirection == true)
                {
                    _currentRotationDirection = false;
                }
                else
                {
                    _currentRotationDirection = true;
                }
            Rotate(_currentRotationSpeed, _currentRotationDirection, _towerData.Shield);
            
        }

        private void Update()
        {
            ExecuteCurrentState();
            Rotate(_currentRotationSpeed, _currentRotationDirection, _towerData.Shield);
        }
        public void ExecuteCurrentState()
        {
            if (_currentState == State.LowSpeed)
            {
                if (TimerController.Instance.CurentTime < TimerController.Instance.TwoStarResult())
                {
                    StateHighSpeed();
                }
                
                else if (_tower._towerSections.Count < 5)
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
                
                else if (_tower._towerSections.Count < 10)
                {
                    StateLowSpeed();
                }
                
            }
        }
        public void Rotate(Vector2 rotationSpeed, bool counterwrap, Transform objectToRotate)
        {
            var randomSpeed = Random.Range(rotationSpeed.x, rotationSpeed.y);
            
            if (counterwrap == false)
            {
                objectToRotate.Rotate(new Vector3(0, -randomSpeed * Time.deltaTime, 0));
            }
            else
            {
                objectToRotate.Rotate(new Vector3(0, randomSpeed * Time.deltaTime, 0));
            }
        }
        private void OnDisable()
        {
            _tower._towerSections.RemoveAt(0);
        }

        [System.Serializable]
        public struct TowerData
        {
            public Vector2 RotationLowSpeed;
            public Vector2 RotationHighSpeed;
            public bool Counterwrap;
            public Transform Shield;

        }
    }
}

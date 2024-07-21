using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RomanDoliba.Tower
{
    public class TowerSectionBase : MonoBehaviour
    {
        [SerializeField] public ShieldController _shieldController;
        [SerializeField] private Vector2 _rotationSpeeds;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private bool _counterwrap;
        private int _randomRotatinDirection;

        public Vector2 RotationSpeed
        {
            get => _rotationSpeeds;
            set
            {
                _rotationSpeeds = value;
            }
        }
        public float RotationSpeedSteady
        {
            get => _rotationSpeed;
            set
            {
                _rotationSpeed = value;
            }
        }
        public bool Counterwrap
        {
            get => _counterwrap;
            set
            {
                _counterwrap = value;
            }
        }
        private void Awake()
        {
            _randomRotatinDirection = Random.Range(0, 2);
        }
        private void Update()
        {
            var rotationSpeeds = new Vector2(_rotationSpeeds.x, _rotationSpeeds.y);
            var counterwrap = _counterwrap;
            _shieldController.Rotate(rotationSpeeds, counterwrap, _randomRotatinDirection, _shieldController.transform);
            //_shieldController.Rotate(_rotationSpeed, _counterwrap);
        }     
    }
}

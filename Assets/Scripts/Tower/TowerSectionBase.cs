using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RomanDoliba.Tower
{
    public class TowerSectionBase : MonoBehaviour
    {
        [SerializeField] public ShieldController _shieldController;
        [SerializeField] public Transform _shield;
        [SerializeField] private Vector2 _rotationSpeeds;
        [SerializeField] private bool _counterwrap;
        
        public Vector2 RotationSpeed
        {
            get => _rotationSpeeds;
            set
            {
                _rotationSpeeds = value;
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
        
        private void Update()
        {
            var rotationSpeeds = new Vector2(_rotationSpeeds.x, _rotationSpeeds.y);
            var counterwrap = _counterwrap;
            _shieldController.Rotate(rotationSpeeds, counterwrap, _shield);
        }     
    }
}

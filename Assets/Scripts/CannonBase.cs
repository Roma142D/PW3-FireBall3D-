using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RomanDoliba.Core
{
    public class CannonBase : MonoBehaviour
    {
        [SerializeField] private CannonballBase _cannonball;
        [SerializeField] private Transform _target;
        [SerializeField] private Button _shootButton;
        [SerializeField] private Transform _spawnPoint;
        
        private void Awake()
        {
            _shootButton.onClick.AddListener(Shoot);
            _cannonball._spawnPoint = _spawnPoint;
        }
        
        private void Shoot()
        {
            _cannonball.Shoot(_target.position);
        }
    }
}

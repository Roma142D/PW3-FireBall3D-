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
        [SerializeField] private float _delayBetweenShoots;
        [SerializeField] private Button _shootButton;
        [SerializeField] private Transform _spawnPoint;
        private float _timeAfterShoot;

        private void Awake()
        {
            _shootButton.onClick.AddListener(Shoot);
            _cannonball._spawnPoint = _spawnPoint;
        }
        private void Update()
        {

        }

        private void Shoot()
        {
            _cannonball.Shoot(_target.position);
        }
        //private bool IsCanShoot()
        //{
        //    var canShoot = false;
        //    _delayBetweenShoots -= Time.deltaTime;
        //}
    }
}

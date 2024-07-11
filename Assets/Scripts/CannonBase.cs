using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RomanDoliba.Core
{
    public class CannonBase : MonoBehaviour
    {
        [SerializeField] private Rigidbody _cannonballPrefab;
        [SerializeField] private Transform _target;
        [SerializeField] private Button _shootButton;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private float _speed;
        [SerializeField] private float _shootInterval;       
        private Coroutine _shootIntervalRoutine;
        
        private void Awake()
        {
            _shootButton.onClick.AddListener(Shoot);
        }
        
        private void Shoot()
        {
            if (_shootIntervalRoutine == null)
            {
                ShootCannonball(_target.position);
            }
        }
        public void ShootCannonball(Vector3 target)
        {
            var cannonballInstance = Instantiate(_cannonballPrefab, _spawnPoint.position, Quaternion.identity);
            cannonballInstance.AddForce(_speed * target * -1, ForceMode.Impulse);

            _shootIntervalRoutine = StartCoroutine(ShootIntervalRoutine(ClearRoutine));
        }

        private IEnumerator ShootIntervalRoutine(System.Action callback)
        {
            Debug.Log("CoroutineStart");
            if (_shootButton.isActiveAndEnabled)
            {
                Debug.Log("ButtonPresed");
                yield return new WaitForSeconds(_shootInterval);
            }
            callback?.Invoke();
        }

        private void ClearRoutine()
        {
            Debug.Log("ClearRoutine");
            _shootIntervalRoutine = null;
        }
       
    }
}

using System.Collections;
using System.Collections.Generic;
using RomanDoliba.ActionSystem;
using UnityEngine;
using UnityEngine.UI;

namespace RomanDoliba.Core
{
    public class CannonShotPool : MonoBehaviour
    {
        [SerializeField] private Rigidbody _cannonBallPrefab;
        [SerializeField] private Transform _target;
        [SerializeField] private Button _shootButton;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private float _speed;
        [SerializeField] private float _shootInterval;       
        private Coroutine _shootIntervalRoutine;
        private Queue<Rigidbody> _instancedCannonBalls = new Queue<Rigidbody>();

        private void Awake()
        {
            CheckTime();
            _shootButton.onClick.AddListener(Shoot);
        }

        private void Shoot()
        {
            if (_shootIntervalRoutine == null)
            {
                ShootCannonball(_target.position);
            }
        }
        private void ShootCannonball(Vector3 target)
        {
            if (_instancedCannonBalls.Count > 5)
            {
                var cannonballInstance = _instancedCannonBalls.Dequeue();
                cannonballInstance.velocity = Vector3.zero;
                cannonballInstance.transform.position = _spawnPoint.position;
                var executors = cannonballInstance.GetComponents<ExecutorBase>();
                if (executors != null)
                {
                    foreach (var executor in executors)
                    {
                        executor.ResetExecutor();
                    }
                }
                cannonballInstance.gameObject.SetActive(true);
                cannonballInstance.AddForce(_speed * target * -1, ForceMode.Impulse);

                _instancedCannonBalls.Enqueue(cannonballInstance);
                _shootIntervalRoutine = StartCoroutine(ShootIntervalRoutine(ClearRoutine));
            }
            else
            {
                var cannonballInstance = Instantiate(_cannonBallPrefab, _spawnPoint.position, Quaternion.identity);
                cannonballInstance.AddForce(_speed * target * -1, ForceMode.Impulse);
                _instancedCannonBalls.Enqueue(cannonballInstance);

                _shootIntervalRoutine = StartCoroutine(ShootIntervalRoutine(ClearRoutine));
            }
        }

        private IEnumerator ShootIntervalRoutine(System.Action callback)
        {
            if (_shootButton.isActiveAndEnabled)
            {
                yield return new WaitForSeconds(_shootInterval);
            }
            callback?.Invoke();
        }
         private void ClearRoutine()
        {
            _shootIntervalRoutine = null;
        }

        private void CheckTime()
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
        }
    }
}

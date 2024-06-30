using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RomanDoliba.Core
{
    public class CannonballBase : MonoBehaviour
    {
        [SerializeField] private Rigidbody _cannonballPrefab;
        [SerializeField] public Transform _spawnPoint;
        [SerializeField] private float _speed;
                
        public void Shoot(Vector3 target)
        {
            var cannonballInstance = Instantiate(_cannonballPrefab, _spawnPoint.position, Quaternion.identity);
            cannonballInstance.AddForce(_speed * target * -1, ForceMode.Impulse);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

namespace RomanDoliba.Tower
{
    public class TowerSectionsPooling : MonoBehaviour
    {
        [SerializeField] private TowerSectionBase _towerSection;
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private int _maxPoolSize;
        [SerializeField] private Button button;
        private Vector3 _currentSpawnPoint;
        private ObjectPool<TowerSectionBase> _towerSectionsPool;

        private void Awake()
        {
            _currentSpawnPoint = _spawnPosition.GetPosition();
            StartCoroutine(BuildTower());
        }
        public ObjectPool<TowerSectionBase> TowerSectionsPool
        {
            get
            {
                if (_towerSectionsPool == null)
                {
                    _towerSectionsPool = new ObjectPool<TowerSectionBase>(BuildSection, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, 10, _maxPoolSize);
                }
                return _towerSectionsPool;
            }

        }
        private IEnumerator BuildTower()
        {
            while (TowerSectionsPool.CountAll <= 15)
            {
                var towerSection = TowerSectionsPool.Get();
                _currentSpawnPoint = towerSection.GetPosition();

                Debug.Log(_towerSectionsPool.CountAll);
                yield return new WaitForSeconds(0.5f);
            }
        }
        
        private TowerSectionBase BuildSection()
        {
            var newSection = Instantiate(_towerSection, GetNextSpawnPoint(_currentSpawnPoint), Quaternion.identity, this.transform);
            
            newSection.gameObject.AddComponent<ReturnToPool>();
            newSection.GetComponent<ReturnToPool>()._towerSectionsPool = TowerSectionsPool;

            return newSection;
        }
        private Vector3 GetNextSpawnPoint(Vector3 spawnedSectionPosition)
        {
            var nextSpawnPosition = new Vector3(_spawnPosition.position.x,
            spawnedSectionPosition.y + _towerSection.transform.localScale.y,
            _spawnPosition.position.z);

            return nextSpawnPosition;
        }

        private void OnReturnedToPool(TowerSectionBase towerSection)
        {
            towerSection.gameObject.SetActive(false);
        }
        private void OnTakeFromPool(TowerSectionBase towerSection)
        {
            towerSection.gameObject.SetActive(true);
        }
        private void OnDestroyPoolObject(TowerSectionBase towerSection)
        {
            Destroy(towerSection.gameObject);
        }
    }
}

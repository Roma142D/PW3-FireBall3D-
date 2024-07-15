using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace RomanDoliba.Tower
{
    public class TowerGenerator : MonoBehaviour
    {
        [SerializeField] private TowerSectionBase[] _towerSectionsPrefabs;
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private int _sectionsAmount;
        private List<TowerSectionBase> _towerSections;
        private Vector3 _currentSpawnPoint;
        
        private void Awake()
        {
            _towerSections = new List<TowerSectionBase>();
            _currentSpawnPoint = _spawnPosition.GetPosition();
            BuildTower();
        }
        private void BuildTower()
        {
            for (int i = 0; i < _sectionsAmount; i++)
            {
                var spawnedSection = BuildSection();
                _towerSections.Add(spawnedSection);
                _currentSpawnPoint = spawnedSection.GetPosition();
            }
        }

        private TowerSectionBase BuildSection()
        {
            var newSection = Instantiate(_towerSectionsPrefabs[Random.Range(0, _towerSectionsPrefabs.Length)],
            GetNextSpawnPoint(_currentSpawnPoint), Quaternion.identity, this.transform);

            return newSection;
        }
        private Vector3 GetNextSpawnPoint(Vector3 spawnedSectionPosition)
        {
            var nextSpawnPosition = new Vector3(_spawnPosition.position.x,
            spawnedSectionPosition.y + _towerSectionsPrefabs[0].transform.localScale.y,
            _spawnPosition.position.z);

            return nextSpawnPosition;
        }
    }
}

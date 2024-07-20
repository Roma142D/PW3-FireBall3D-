using UnityEngine;
using UnityEngine.Pool;

namespace RomanDoliba.Tower
{
    [RequireComponent(typeof(TowerSectionBase))]
    public class ReturnToPool : MonoBehaviour
    {
        public TowerSectionBase _towerSection;
        public IObjectPool<TowerSectionBase> _towerSectionsPool;

        public void Start()
        {
            _towerSection = GetComponent<TowerSectionBase>();
        }
        public void OnDisable()
        {
            _towerSectionsPool.Release(_towerSection);
        }
    }
}

using UnityEngine;

namespace RomanDoliba.Tower
{
    public class ShieldController : MonoBehaviour
    {
        [SerializeField] Vector2 _rotationSpeed;
        [SerializeField] bool _counterwrap;

        private void FixedUpdate()
        {
            Rotate();
        }
        private void Rotate()
        {
            var randomSpeed = Random.Range(_rotationSpeed.x, _rotationSpeed.y);
            if (_counterwrap)
            {
                transform.Rotate(new Vector3(0, randomSpeed * Time.deltaTime * -1, 0));
            }
            else
            {
                transform.Rotate(new Vector3(0, randomSpeed * Time.deltaTime, 0));
            }
        }
    }
}

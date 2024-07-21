using UnityEngine;

namespace RomanDoliba.Tower
{
    public class ShieldController : MonoBehaviour
    {
        public void Rotate(Vector2 rotationSpeed, bool counterwrap, int randomRotatinDirection, Transform objectToRotate)
        {
            var randomSpeed = Random.Range(rotationSpeed.x, rotationSpeed.y);
            if (randomRotatinDirection == 0 && counterwrap == false)
            {
                objectToRotate.Rotate(new Vector3(0, randomSpeed * Time.deltaTime * -1, 0));
            }
            else
            {
                objectToRotate.Rotate(new Vector3(0, randomSpeed * Time.deltaTime, 0));
            }
        }
        public void Rotate(float rotationSpeed, bool counterwrap)
        {
            if (counterwrap == true)
            {
                transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime * -1, 0));
            }
            else
            {
                transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
            }
        }
    }
}

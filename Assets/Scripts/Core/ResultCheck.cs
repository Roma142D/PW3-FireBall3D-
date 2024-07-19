using UnityEngine;

namespace RomanDoliba.Core
{
    public class ResultCheck : MonoBehaviour
    {
        [SerializeField] private GameObject[] _starsImages;
        private float _curentResult;
        private int _starsToActivate;
        private TimerController _timerController;

        private void OnEnable()
        {
            _timerController = TimerController.Instance;
            CheckTimeResult(_timerController.CurentTime);
            ActivateStarsImages();
        }

        private void CheckTimeResult(float curentTime)
        {
            _curentResult = _timerController.OneStarResult() - _timerController.CurentTime;

            if (_curentResult <= _timerController.ThreeStarResult())
            {
                _starsToActivate = 3;
            }
            else if (_curentResult <= _timerController.TwoStarResult() && _curentResult > _timerController.ThreeStarResult())
            {
                _starsToActivate = 2;
            }
            else
            {
                _starsToActivate = 1;
            }
        }
        private void ActivateStarsImages()
        {
            for (int i = 0; i < _starsToActivate; i++)
            {
                _starsImages[i].SetActive(true);
            }
        }
    }
}

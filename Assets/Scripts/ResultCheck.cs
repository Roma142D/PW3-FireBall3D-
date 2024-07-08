using UnityEngine;

namespace RomanDoliba.Core
{
    public class ResultCheck : MonoBehaviour
    {
        [SerializeField] private TimerController _timerController;
        [SerializeField] private GameObject[] _starsImages;
        private float _curentResult;
        private int _starsToActivate;

        private void OnEnable()
        {
            CheckTimeResult(_timerController.CurentTime);
            ActivateStarsImages();
        }

        private void CheckTimeResult(float curentTime)
        {
            _curentResult = _timerController._timeOnStarsResult.OneStarResult - _timerController.CurentTime;

            if (_curentResult <= _timerController._timeOnStarsResult.ThreeStarResult)
            {
                _starsToActivate = 3;
                //return;
            }
            else if (_curentResult <= _timerController._timeOnStarsResult.TwoStarResult && _curentResult > _timerController._timeOnStarsResult.ThreeStarResult)
            {
                _starsToActivate = 2;
                //return;
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

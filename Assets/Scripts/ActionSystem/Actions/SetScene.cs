using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RomanDoliba.ActionSystem
{
    public class SetScene : ActionBase
    {
        [SerializeField] private int _sceneIndex;

        public override void Execute(object data = null)
        {
            SceneManager.LoadScene(_sceneIndex);
        }
    }
}

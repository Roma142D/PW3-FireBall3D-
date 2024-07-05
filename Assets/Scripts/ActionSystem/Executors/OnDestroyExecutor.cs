using UnityEngine;

namespace RomanDoliba.ActionSystem
{
    public class OnDestroyExecutor : ExecutorBase
    {
        private void OnDestroy()
        {
            Execute();
        }
    }
}

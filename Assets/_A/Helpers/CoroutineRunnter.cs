using System.Collections;
using UnityEngine;

public class CoroutineRunner : MonoBehaviour
{
    #region Singleton
    public static CoroutineRunner Instance;
    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    #endregion

    public IEnumerator RunCoroutine(IEnumerator coroutine)
    {
        if(coroutine != null) StartCoroutine(coroutine);
        return coroutine;
    }

    public void KillRoutine(IEnumerator coroutine)
    {
        if(coroutine != null) StopCoroutine(coroutine);
    }
}
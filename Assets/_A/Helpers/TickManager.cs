using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class TickManager : MonoBehaviour
{
    #region Singleton
    public static TickManager Instance;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    #endregion

    private List<ITickable> _tickables = new();

    public void RegisterTickable(ITickable tickable) => _tickables.Add(tickable);
    public void UnregisterTickable(ITickable tickable) => _tickables.Remove(tickable);

    void Update()
    {
        if(_tickables == null) return;
        foreach (ITickable tickable in _tickables) tickable.Tick();
    }
}
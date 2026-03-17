using System;
using UnityEngine;

public class AnxietyDetection: ITickable
{
    GameObject _playerObj;
    float _detectionRadius;
    LayerMask _detectionLayerMask;

    Collider[] _detectedNpcs = new Collider[20];
    int _detectedNpcsCount;
    public int NumberOfDetectedNpcs => _detectedNpcsCount;

    public void Initialize(AnxietyDetectionData data)
    {
        _playerObj = data.PlayerObj;
        _detectionRadius = data.DetectionRadius;
        _detectionLayerMask = data.DetectionLayerMask;

        TickManager.Instance.RegisterTickable(this);
    }
    public void DetectNpcs()
    {
        int detectedNpcCount = Physics.OverlapSphereNonAlloc(_playerObj.transform.position, _detectionRadius, _detectedNpcs,_detectionLayerMask);

        if(detectedNpcCount != _detectedNpcsCount)
        {
            _detectedNpcsCount = detectedNpcCount;
            Debug.Log($"Detected {detectedNpcCount} NPCs");
        }
    }

    public void Tick()
    {
        DetectNpcs();
    }
}

[Serializable]
public struct AnxietyDetectionData
{
    public GameObject PlayerObj;
    public float DetectionRadius;
    public LayerMask DetectionLayerMask;

}
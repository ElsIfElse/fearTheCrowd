using System;
using Unity.VisualScripting;
using UnityEngine;

public class AnxietyDetection: ITickable
{
    GameObject _playerObj;
    float _detectionRadius;
    LayerMask _detectionLayerMask;

    Collider[] _detectedNpcs = new Collider[20];
    int _detectedNpcsCount;
    public int NumberOfDetectedNpcs => _detectedNpcsCount;

    float _bumperTimeCooldown;
    float _bumperTimer;
    public bool _isBumperActive = true;

    public void Initialize(AnxietyDetectionData data)
    {
        _playerObj = data.PlayerObj;
        _detectionRadius = data.DetectionRadius;
        _detectionLayerMask = data.DetectionLayerMask;
        _bumperTimeCooldown = data.BumperTimeCooldown;
        _bumperTimer = _bumperTimeCooldown;

        TickManager.Instance.RegisterTickable(this);
    }
    public void DetectNpcs()
    {
        int detectedNpcCount = Physics.OverlapSphereNonAlloc(_playerObj.transform.position, _detectionRadius, _detectedNpcs,_detectionLayerMask);

        if(detectedNpcCount != _detectedNpcsCount)
        {
            _detectedNpcsCount = detectedNpcCount;
        }
    }

    public void Tick()
    {
        DetectNpcs();
        BumperTimer();
    }

    void BumperTimer()
    {
        if(_isBumperActive) return;
        _bumperTimer -= Time.deltaTime;

        if(_bumperTimer <= 0)
        {
            _isBumperActive = true;
            _bumperTimer = _bumperTimeCooldown;
        }
    }

    public bool TryBump(Collider other)
    {
        if(!other.CompareTag("NPC")) 
            return false;

        if(!_isBumperActive) 
            return false;

        _isBumperActive = false;
        return true;
    }
}

[Serializable]
public struct AnxietyDetectionData
{
    public GameObject PlayerObj;
    public float DetectionRadius;
    public LayerMask DetectionLayerMask;

    public float BumperTimeCooldown;
    public float BumpAnxietyGain;

}
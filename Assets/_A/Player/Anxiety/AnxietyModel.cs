using System;
using UnityEngine;

public class AnxietyModel : ITickable
{
    float _maxAnxiety;
    float _currentAnxiety;
    float _anxietyGainRatePerSecond;
    float _anxietyRemovingRate;
    int _currentNpcCount;

    AnxietyDetection _anxietyDetection;
    AnxietyMeterView _anxietyMeterView;

    public void Initialize(AnxietyModelData data)
    {
        _maxAnxiety = data.MaxAnxiety;
        _currentAnxiety = data.CurrentAnxiety;
        _anxietyGainRatePerSecond = data.AnxietyGainRatePerSecond;
        _anxietyRemovingRate = data.AnxietyRemovingRate;
        _anxietyDetection = data.AnxietyDetection;
        _anxietyMeterView = data.AnxietyMeterView;

        TickManager.Instance.RegisterTickable(this);
    }
    public void AddAnxiety()
    {
        _currentAnxiety = Mathf.Clamp(
            _currentAnxiety + _anxietyGainRatePerSecond * _currentNpcCount * Time.deltaTime,
            0, _maxAnxiety
        );
        
        UpdateAnxietyMeter();
    }

    public void AddAnxiety_Amount(float amount)
    {
        _currentAnxiety = Mathf.Clamp(
            _currentAnxiety + amount,
            0, _maxAnxiety
        );
        
        UpdateAnxietyMeter();
    }


    public void RemoveAnxiety()
    {
        
    }

    public void UpdateAnxietyMeter()
    {
        _anxietyMeterView.SetMeterBar(_currentAnxiety, _maxAnxiety);
    }

    public void Tick()
    {
        AnxietyGainTick();
    }

    void AnxietyGainTick()
    {
        int latestNpcCount = _anxietyDetection.NumberOfDetectedNpcs;

        if (latestNpcCount == 0) return;
        _currentNpcCount = latestNpcCount;

        AddAnxiety();
    }
}

[Serializable]
public struct AnxietyModelData
{
    public float MaxAnxiety;
    public float CurrentAnxiety;
    public float AnxietyGainRatePerSecond;
    public float AnxietyRemovingRate;

    public AnxietyDetection AnxietyDetection;
    public AnxietyMeterView AnxietyMeterView;
}
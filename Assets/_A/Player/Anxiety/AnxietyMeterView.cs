using System;
using UnityEngine.UI;

public class AnxietyMeterView
{
    Image _meterBar;

    public void SetMeterBar(float currentAnxiety, float maxAnxiety)
    {
        _meterBar.fillAmount = currentAnxiety / maxAnxiety;
    }

    public void Initialize(AnxietyMeterViewData data)
    {
        _meterBar = data.MeterBar;
    }
}

[Serializable]
public struct AnxietyMeterViewData
{
    public Image MeterBar;
}
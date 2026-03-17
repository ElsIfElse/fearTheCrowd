using System;

public class AnxietyHandler
{
    AnxietyDetection _anxietyDetection;
    AnxietyDetectionData _anxietyDetectionData;

    public void InitializeHandler(AnxietyHandlerData data)
    {
        _anxietyDetectionData = data.AnxietyDetectionData;

        Initialize_AnxietyDetection();
    }

    void Initialize_AnxietyDetection()
    {
        _anxietyDetection = new();
        _anxietyDetection.Initialize(_anxietyDetectionData);
    }
}

[Serializable]
public struct AnxietyHandlerData
{
    public AnxietyDetectionData AnxietyDetectionData;
}
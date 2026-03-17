using System;

public class AnxietyHandler
{
    AnxietyHandlerData _data;

    AnxietyDetection _anxietyDetection;
    AnxietyModel _anxietyModel;
    AnxietyMeterView _anxietyMeterView;
    void CreateSubHandlers()
    {
        _anxietyDetection = new AnxietyDetection();
        _anxietyModel = new AnxietyModel();
        _anxietyMeterView = new AnxietyMeterView();
    }
    void InitializeSubhandlers()
    {
        _anxietyDetection.Initialize(_data.AnxietyDetectionData);

        _data.AnxietyModelData.AnxietyDetection = _anxietyDetection;
        _data.AnxietyModelData.AnxietyMeterView = _anxietyMeterView;
        _anxietyModel.Initialize(_data.AnxietyModelData);
        
        _anxietyMeterView.Initialize(_data.AnxietyMeterViewData);
    }
    public void InitializeHandler(AnxietyHandlerData data)
    {
        _data = data;

        CreateSubHandlers();
        InitializeSubhandlers();
    }
}

[Serializable]
public struct AnxietyHandlerData
{
    public AnxietyDetectionData AnxietyDetectionData;
    public AnxietyModelData AnxietyModelData;
    public AnxietyMeterViewData AnxietyMeterViewData;
}
using System;

public class AnxietyHandler
{
    AnxietyHandlerData _data;

    AnxietyDetection _anxietyDetection;
    AnxietyModel _anxietyModel;
    AnxietyMeterView _anxietyMeterView;
    public void InitializeHandler(AnxietyHandlerData data)
    {
        _data = data;

        CreateSubHandlers();
        PrepareDataStructs();
        InitializeSubhandlers();
    }
    void CreateSubHandlers()
    {
        _anxietyDetection = new AnxietyDetection();
        _anxietyModel = new AnxietyModel();
        _anxietyMeterView = new AnxietyMeterView();
    }
    void InitializeSubhandlers()
    {
        _anxietyDetection.Initialize(_data.AnxietyDetectionData);
        _anxietyModel.Initialize(_data.AnxietyModelData);
        _anxietyMeterView.Initialize(_data.AnxietyMeterViewData);
    }

    void PrepareDataStructs()
    {
        _data.AnxietyModelData.AnxietyDetection = _anxietyDetection;
        _data.AnxietyModelData.AnxietyMeterView = _anxietyMeterView;
    }
}

[Serializable]
public struct AnxietyHandlerData
{
    public AnxietyDetectionData AnxietyDetectionData;
    public AnxietyModelData AnxietyModelData;
    public AnxietyMeterViewData AnxietyMeterViewData;
}
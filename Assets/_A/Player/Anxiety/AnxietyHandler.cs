using System;

public class AnxietyHandler
{
    AnxietyHandlerData _data;

    public AnxietyDetection AnxietyDetection;
    public AnxietyModel AnxietyModel;
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
        AnxietyDetection = new AnxietyDetection();
        AnxietyModel = new AnxietyModel();
        _anxietyMeterView = new AnxietyMeterView();
    }
    void InitializeSubhandlers()
    {
        AnxietyDetection.Initialize(_data.AnxietyDetectionData);
        AnxietyModel.Initialize(_data.AnxietyModelData);
        _anxietyMeterView.Initialize(_data.AnxietyMeterViewData);
    }

    void PrepareDataStructs()
    {
        _data.AnxietyModelData.AnxietyDetection = AnxietyDetection;
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
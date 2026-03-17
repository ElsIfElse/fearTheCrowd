using System.Collections.Generic;

public class NpcsStateHandler
{
    Dictionary<NpcStateType, NpcState> _stateDictionary = new();
    NpcState _currentState;

    public void InitializeStateHandler(NpcStateHandlerData data)
    {
        CreateStateDictionary();
        InitializeStates(data.NpcStateData);
    }

    void CreateStateDictionary()
    {
        _stateDictionary[NpcStateType.Idle] = new NpcState_StayIdleAtLocation();
        _stateDictionary[NpcStateType.GoToRandomLocation] = new NpcState_GoToRandomLocation();
    }

    public void ChangeState(NpcStateType newState)
    {
        
    }

    void InitializeStates(NpcStateData data)
    {
        data.NpcStateHandler = this;
        foreach (KeyValuePair<NpcStateType,NpcState> pair in _stateDictionary) pair.Value.InitializeState(data);
    }
}

public struct NpcStateHandlerData
{
    public NpcStateData NpcStateData;
}
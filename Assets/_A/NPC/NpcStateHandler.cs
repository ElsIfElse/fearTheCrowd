using System;
using System.Collections.Generic;
using UnityEngine.AI;

public class NpcsStateHandler
{
    Dictionary<NpcStateType, NpcState> _stateDictionary = new();
    NpcState _currentState;
    NpcController _npcController;

    public void InitializeStateHandler(NpcStateHandlerData data)
    {
        _npcController = data.NpcController;

        CreateStateDictionary();
        InitializeStates(data.NpcStateData);

        ChangeState(NpcStateType.GoToRandomLocation);
    }

    void CreateStateDictionary()
    {
        _stateDictionary[NpcStateType.Idle] = new NpcState_StayIdleAtLocation();
        _stateDictionary[NpcStateType.GoToRandomLocation] = new NpcState_GoToRandomLocation();
    }
 
    public void ChangeState(NpcStateType newState)
    {
        _currentState?.OnExit();
        _currentState = _stateDictionary[newState];
        _npcController.StartCoroutine(_currentState.OnEnter());
    }

    void InitializeStates(NpcStateData data)
    {
        data.NpcStateHandler = this;
        foreach (KeyValuePair<NpcStateType,NpcState> pair in _stateDictionary) pair.Value.InitializeState(data);
    }
}

[Serializable]
public struct NpcStateHandlerData
{
    public NpcStateData NpcStateData;
    public NpcController NpcController;
}
using System;
using System.Collections;

public abstract class NpcState
{
    protected NpcsStateHandler _npcsStateHandler;
    public abstract IEnumerator OnEnter();
    public abstract void OnExit();
    public abstract void Tick();

    public abstract void InitializeState(NpcStateData data);
}

public struct NpcStateData
{
    public NpcsStateHandler NpcStateHandler;
}
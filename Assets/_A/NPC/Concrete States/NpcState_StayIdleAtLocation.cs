using System.Collections;
using UnityEngine;

public class NpcState_StayIdleAtLocation : NpcState
{
    public override void InitializeState(NpcStateData data)
    {
        base.InitializeState(data);
    }

    public override IEnumerator OnEnter()
    {
        yield return new WaitForSeconds(Random.Range(10, 20)); 
        _npcsStateHandler.ChangeState(NpcStateType.GoToRandomLocation);
    }

    public override void OnExit()
    {
        
    }

    public override void Tick()
    {
        
    }

    IEnumerator StayIdleFor(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
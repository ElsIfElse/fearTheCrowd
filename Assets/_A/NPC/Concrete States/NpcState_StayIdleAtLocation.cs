using System.Collections;
using UnityEngine;

public class NpcState_StayIdleAtLocation : NpcState
{
    public override void InitializeState(NpcStateData data)
    {

    }

    public override IEnumerator OnEnter()
    {
       yield return null; 
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
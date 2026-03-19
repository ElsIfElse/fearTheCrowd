using System.Collections;

public class NpcState_WalkToSeller : NpcState
{
    public override void InitializeState(NpcStateData data)
    {
        base.InitializeState(data);
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
}
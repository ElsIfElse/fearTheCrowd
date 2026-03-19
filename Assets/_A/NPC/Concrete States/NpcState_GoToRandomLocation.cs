using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NpcState_GoToRandomLocation : NpcState
{
    public override void InitializeState(NpcStateData data)
    {
        base.InitializeState(data);
    }

    public override IEnumerator OnEnter()
    {
        Vector3 targetLocation = _npcAgent.transform.position;
        NavMeshHit hit;

    if (NavMesh.SamplePosition(RandomLocation(), out hit, 5f, NavMesh.AllAreas))
    {
        targetLocation = hit.position;
    }

        Debug.Log($"Target location: {targetLocation}");
        _npcAgent.SetDestination(targetLocation);

        yield return null;
        yield return new WaitUntil(() => _npcAgent.pathPending == false);
        yield return new WaitUntil(() => _npcAgent.remainingDistance <= _npcAgent.stoppingDistance);

        _npcsStateHandler.ChangeState(NpcStateType.Idle);
    }

    Vector3 RandomLocation()
    {
        float halfX = _ground.transform.localScale.x *10 /2;
        float halfZ = _ground.transform.localScale.z *10 /2;

        return new Vector3(Random.Range(-halfX, halfX), _npcAgent.transform.position.y, Random.Range(halfZ, -halfZ));
    }

    public override void OnExit()
    {
        _npcAgent.ResetPath();
    }

    public override void Tick()
    {
        
    }
}
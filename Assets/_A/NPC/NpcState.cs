using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms.GameCenter;

public abstract class NpcState
{
    public NpcsStateHandler _npcsStateHandler;
    public NavMeshAgent _npcAgent;
    public GameObject _ground;

    public abstract IEnumerator OnEnter();
    public abstract void OnExit();
    public abstract void Tick();

    public virtual void InitializeState(NpcStateData data)
    {
        _npcsStateHandler = data.NpcStateHandler;
        _npcAgent = data.NpcAgent;
        _ground = data.Ground;
    }
}

[Serializable]
public struct NpcStateData
{
    public NpcsStateHandler NpcStateHandler;
    public NavMeshAgent NpcAgent;
    public GameObject Ground;
}
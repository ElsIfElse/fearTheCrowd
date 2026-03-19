using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    NpcsStateHandler _npcStateHandler;
    public NpcStateHandlerData NpcStateHandlerData;

    void Start()
    {
        InitializeController();
    }

    void InitializeController()
    {
        CreateSubHandlers();
        InitializeSubhandlers();
    }

    void CreateSubHandlers()
    {
        _npcStateHandler = new();
    }

    void InitializeSubhandlers()
    {
        NpcStateHandlerData.NpcController = this;
        _npcStateHandler.InitializeStateHandler(NpcStateHandlerData);
    }
}
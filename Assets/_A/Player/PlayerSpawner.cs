using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    #region Singleton
    public static PlayerSpawner Instance;
    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }
    #endregion

    public Transform spawnPoint;
    public GameObject playerPrefab;
    GameObject _runtimePlayerPrefab;

    // Temporary Game initializer method
    public void SpawnPlayer()
    {
        if(_runtimePlayerPrefab != null) return;
        _runtimePlayerPrefab = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        GameObject cameraHolderObj = _runtimePlayerPrefab.transform.Find("CameraHolder").gameObject;

        PlayerManager.Instance.InitializeManager(_runtimePlayerPrefab);
        CameraManager.Instance.SetPlayerObjToCameraToFollow(cameraHolderObj);
        GroceryItemManager.Instance.CreateNewGroceryTaskList(3);
    }

    public void DespawnPlayer()
    {
        if(_runtimePlayerPrefab == null) return;
        Destroy(_runtimePlayerPrefab);
    }

    void OnGUI()
    {
        if(GUI.Button(new Rect(0, 100, 150, 30), "Spawn Player")) SpawnPlayer();
    }
}
using UnityEngine;

public class PlayerOnTriggerDetection : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        PlayerManager.Instance.BumperDetection(other);
    }
}
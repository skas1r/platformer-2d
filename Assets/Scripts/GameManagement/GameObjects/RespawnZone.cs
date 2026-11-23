using UnityEngine;

public class RespawnZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        RespawnObject respawnObject = other.GetComponent<RespawnObject>();
        respawnObject?.Respawn();
    }
}

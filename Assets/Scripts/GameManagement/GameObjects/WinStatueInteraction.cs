using UnityEngine;

public class WinStatueInteraction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindFirstObjectByType<WinScreenManager>()?.ShowScreen();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindFirstObjectByType<WinScreenManager>()?.HideScreen();
        }
    }
}

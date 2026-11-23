using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class StatueInteraction : MonoBehaviour
{
    [SerializeField] private AudioClip teleportSound;
    private AudioSource audioSource;
    private bool isPlayerInRange;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Statue collider triggered");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Statue indicated player");
            isPlayerInRange = true;
            PlayerController player = other.GetComponentInChildren<PlayerController>();
            player?.SetCurrentStatue(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Statue exit collider");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited Statue zone");
            isPlayerInRange = false;
            PlayerController player = other.GetComponentInChildren<PlayerController>();
            player?.SetCurrentStatue(null);
        }
    }

    public void Interact()
    {
        Debug.Log("Statue interacted");
        if (isPlayerInRange)
        {
            audioSource.PlayOneShot(teleportSound);
            FindFirstObjectByType<SceneTransitionManager>()?.TransitionToNextScene();
        }
    }
}

using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MovementSounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] footstepClips;
    [SerializeField] private AudioClip jumpClip;
    private int currentStepIndex;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayFootstepSound()
    {
        if (footstepClips == null || footstepClips.Length == 0) return;

        audioSource.PlayOneShot(footstepClips[currentStepIndex], 0.1f);
        currentStepIndex = (currentStepIndex + 1) % footstepClips.Length;
    }

    public void PlayJumpSound()
    {
        if (jumpClip == null) return;
        audioSource.PlayOneShot(jumpClip);
    }
}
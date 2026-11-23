using System;
using UnityEngine;

public class RespawnObject : MonoBehaviour
{
    [SerializeField] private GameObject disappearEffect;
    private Vector3 startPosition;
    private Rigidbody2D rb;

    void Start()
    {
        startPosition = transform.position;
        rb = transform.GetComponent<Rigidbody2D>();
    }

    public void Respawn()
    {
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }

        PlayDissapearEffect();
        transform.position = startPosition;
        PlayDissapearEffect();
    }

    private void PlayDissapearEffect()
    {
        if(disappearEffect != null)
        {
            Instantiate(disappearEffect, transform.position, Quaternion.identity);
        }
    }
}

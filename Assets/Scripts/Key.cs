using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    AudioManager audioManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Panggil metode CollectKey pada pemain
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
                audioManager.PlaySFX(audioManager.collectKey);
                player.CollectKey();
                // Hancurkan GameObject kunci setelah dikumpulkan
                Destroy(gameObject);
            }
        }
    }
}

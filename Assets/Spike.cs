using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HealthManager healthManager = other.GetComponent<HealthManager>();

            if (healthManager != null)
            {
                healthManager.DecreaseHearts(); // Panggil DecreaseHearts() pada HealthManager pemain
            }
        }
    }
}

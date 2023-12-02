using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    AudioManager audioManager;
    public KeyInfo keyInfo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            // Ganti dengan kode yang mengambil referensi ke pemain dan mengambil jumlah kunci yang dimilikinya
            PlayerController player = collision.GetComponent<PlayerController>();

            if (player != null && player.GetKeyCount() >= 3)
            {
                audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
                audioManager.PlaySFX(audioManager.doorWin);
                UnlockNewLevel();
                SceneController.Instance.NextLevel();
            }
            else
            {
                // Tampilkan pesan atau lakukan sesuatu jika pemain tidak memiliki 3 kunci
                keyInfo.ShowNotification();
            }
        }

        void UnlockNewLevel ()
        {
            if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
            {
                PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
                PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
                PlayerPrefs.Save();
            }
        }
    }
}

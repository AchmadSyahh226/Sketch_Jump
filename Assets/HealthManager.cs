using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class HealthManager : MonoBehaviour
{
    public int maxHearts = 3; // Jumlah hati maksimum
    private int currentHearts; // Jumlah hati saat ini
    public Image[] heartImages; // Array referensi gambar hati
    public Sprite fullHeart; // Sprite untuk hati penuh
    public Sprite emptyHeart; // Sprite untuk hati kosong
    public GoMenu goMenuScript;

    private void Start()
    {
        currentHearts = maxHearts; // Mengatur jumlah hati awal sesuai dengan maksimum
        UpdateHeartsUI(); // Memperbarui tampilan gambar hati pada awal permainan
    }

    public void DecreaseHearts()
    {
        currentHearts--; // Mengurangi hati saat pemain menyentuh "Spike"
        UpdateHeartsUI(); // Memperbarui tampilan gambar hati

        if (currentHearts <= 0)
        {
            // Jika hati habis, tampilkan goMenu
            goMenuScript.Pause();
        }
    }

    private void UpdateHeartsUI()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < currentHearts)
            {
                heartImages[i].sprite = fullHeart; // Mengatur gambar hati menjadi penuh
            }
            else
            {
                heartImages[i].sprite = emptyHeart; // Mengatur gambar hati menjadi kosong
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            DecreaseHearts(); // Panggil DecreaseHearts() saat pemain menyentuh objek "Spike"
        }
    }
}

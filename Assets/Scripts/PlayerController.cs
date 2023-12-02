using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int keyCount = 0;

    // Fungsi ini dipanggil saat pemain mengumpulkan kunci
    public void CollectKey()
    {
        keyCount++;
    }

    // Fungsi ini digunakan untuk mendapatkan jumlah kunci yang dimiliki pemain
    public int GetKeyCount()
    {
        return keyCount;
    }

    // Anda juga dapat menambahkan fungsi-fungsi lain yang relevan dengan pemain di sini
}

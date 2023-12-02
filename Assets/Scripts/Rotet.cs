using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotet : MonoBehaviour
{
    public float kecepatanRotasi = 45.0f; // Kecepatan rotasi objek (per detik)
    private float rotasi = 0.0f; // Penyimpanan rotasi objek
    private bool objekDisentuh = false; // Menandai apakah objek sudah disentuh

    private void Update()
    {
        if (!objekDisentuh)
        {
            // Menghitung rotasi berdasarkan waktu
            rotasi += kecepatanRotasi * Time.deltaTime;

            // Mengatur rotasi objek
            transform.rotation = Quaternion.Euler(0, 0, rotasi);

            // Mengubah arah rotasi saat mencapai putaran penuh (360 derajat)
            if (rotasi >= 360)
            {
                rotasi = 0; // Kembali ke 0 derajat
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            objekDisentuh = true; // Menandai bahwa objek telah disentuh oleh pemain
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false; // Menonaktifkan renderer objek
            }
            // Anda juga dapat menggunakan perintah berikut untuk menghapus objek:
            // Destroy(gameObject);
        }
    }
}

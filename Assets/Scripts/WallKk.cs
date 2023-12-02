using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallKk : MonoBehaviour
{
    public float moveSpeed = 2f; // Kecepatan pergerakan
    public float moveDistance = 2f; // Jarak pergerakan ke kiri
    private Vector3 originalPosition; // Posisi awal
    private bool isMovingLeft = true; // Apakah sedang bergerak ke kiri
    private Tilemap tilemap; // Referensi ke Tilemap jika diperlukan

    private void Start()
    {
        originalPosition = transform.position; // Simpan posisi awal
        tilemap = GetComponent<Tilemap>(); // Dapatkan komponen Tilemap jika diperlukan
    }

    private void Update()
    {
        if (isMovingLeft)
        {
            // Gerakan ke kiri
            Vector3 newPosition = transform.position + Vector3.left * moveSpeed * Time.deltaTime;

            // Periksa apakah tile yang baru akan berada di dalam Tilemap
            if (IsTileWithinTilemap(newPosition))
            {
                transform.position = newPosition;
            }
            else
            {
                isMovingLeft = false;
            }
        }
        else
        {
            // Gerakan ke kanan
            Vector3 newPosition = transform.position + Vector3.right * moveSpeed * Time.deltaTime;

            // Periksa apakah tile yang baru akan berada di dalam Tilemap
            if (IsTileWithinTilemap(newPosition))
            {
                transform.position = newPosition;
            }
            else
            {
                isMovingLeft = true;
            }
        }
    }

    // Fungsi untuk memeriksa apakah tile berada dalam Tilemap
    private bool IsTileWithinTilemap(Vector3 position)
    {
        if (tilemap == null)
        {
            return true; // Jika tidak ada komponen Tilemap, izinkan pergerakan
        }

        // Ubah posisi dunia menjadi posisi tile dalam Tilemap
        Vector3Int tilePosition = tilemap.WorldToCell(position);

        // Periksa apakah tile ada dalam Tilemap
        return tilemap.HasTile(tilePosition);
    }
}

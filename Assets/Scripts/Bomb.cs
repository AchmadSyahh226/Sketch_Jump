using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDownMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Kecepatan pergerakan bomb
    public float moveDistance = 2f; // Jarak pergerakan ke atas
    private Vector3 originalPosition; // Posisi awal
    private bool isMovingUp = true; // Apakah sedang bergerak ke atas

    private void Start()
    {
        originalPosition = transform.position; // Simpan posisi awal
    }

    private void Update()
    {
        if (isMovingUp)
        {
            // Gerakan ke atas
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

            // Periksa apakah sudah mencapai jarak ke atas
            if (transform.position.y >= originalPosition.y + moveDistance)
            {
                isMovingUp = false;
            }
        }
        else
        {
            // Gerakan ke bawah
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

            // Periksa apakah sudah kembali ke posisi awal
            if (transform.position.y <= originalPosition.y)
            {
                isMovingUp = true;
            }
        }
    }
}

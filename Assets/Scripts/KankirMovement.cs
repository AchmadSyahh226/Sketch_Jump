using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KankirMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Kecepatan pergerakan
    public float moveDistance = 2f; // Jarak pergerakan ke kiri
    private Vector3 originalPosition; // Posisi awal
    private bool isMovingLeft = true; // Apakah sedang bergerak ke kiri

    private void Start()
    {
        originalPosition = transform.position; // Simpan posisi awal
    }

    private void Update()
    {
        if (isMovingLeft)
        {
            // Gerakan ke kiri
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

            // Periksa apakah sudah mencapai jarak ke kiri
            if (transform.position.x <= originalPosition.x - moveDistance)
            {
                isMovingLeft = false;
            }
        }
        else
        {
            // Gerakan ke kanan
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

            // Periksa apakah sudah kembali ke posisi awal
            if (transform.position.x >= originalPosition.x)
            {
                isMovingLeft = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Import namespace untuk SceneManager

public class playerMovement : MonoBehaviour
{
    Rigidbody2D Rb;
    public float ms;
    public float jf;
    public float rotationSpeed; // Kecepatan rotasi
    private bool hasJumped = false; // Menandai apakah pemain telah melompat

    // Simpan posisi awal pemain
    private Vector3 startingPosition;

    // Script Inisialisasi Audio/SFX
    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        // Simpan posisi awal pemain saat awal game
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxisRaw("Horizontal");
        Rb.velocity = new Vector2(ms * horiz, Rb.velocity.y);

        // Rotasi objek saat bergerak ke kanan atau ke kiri
        if (horiz > 0)
        {
            Rb.angularVelocity = -rotationSpeed; // Putar searah jarum jam saat bergerak ke kanan
        }
        else if (horiz < 0)
        {
            Rb.angularVelocity = rotationSpeed; // Putar berlawanan arah jarum jam saat bergerak ke kiri
        }
        else
        {
            Rb.angularVelocity = 0; // Berhenti berputar jika tidak bergerak
        }

        // Cek apakah pemain dapat melompat
        if (Input.GetButtonDown("Jump") && !hasJumped)
        {
            Rb.AddForce(new Vector2(0, jf));
            audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
            audioManager.PlaySFX(audioManager.bounce);
            hasJumped = true; // Menandai bahwa pemain telah melompat
        }
    }

    // Method ini akan dipanggil saat pemain menyentuh objek lain
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            hasJumped = false; // Reset status lompatan saat pemain menyentuh tanah
        }
        else if (collision.gameObject.CompareTag("Spike"))
        {
            // Jika pemain menyentuh objek dengan tag "Spike," kembalikan pemain ke posisi awal
            audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
            audioManager.PlaySFX(audioManager.death);
            
        }
    }
}

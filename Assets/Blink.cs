using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Blink : MonoBehaviour
{
    // Tetapkan waktu kedipan (dalam detik)
    public float blinkDuration = 0.5f;

    private SpriteRenderer playerSprite;
    private bool isBlinking = false;
    private Color originalColor;

    private void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        originalColor = playerSprite.color;
    }

    private void Update()
    {
        if (isBlinking)
        {
            BlinkPlayer();
        }
    }

    public void StartBlinking()
    {
        isBlinking = true;
        StartCoroutine(StopBlinking());
    }

    private void BlinkPlayer()
    {
        float lerpTime = Mathf.PingPong(Time.time, blinkDuration) / blinkDuration;
        Color lerpedColor = Color.Lerp(originalColor, Color.clear, lerpTime);
        playerSprite.color = lerpedColor;
    }

    private IEnumerator StopBlinking()
    {
        yield return new WaitForSeconds(blinkDuration);
        isBlinking = false;
        playerSprite.color = originalColor;
    }

    // ... (sisa skrip pemain Anda)
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyInfo : MonoBehaviour
{
    [SerializeField] GameObject keyInfo;

    public float displayDuration = 1.5f;

    public void ShowNotification()
    {
        keyInfo.SetActive(true);
        Invoke("HideNotification", displayDuration);
    }

    public void HideNotification()
    {
        keyInfo.SetActive(false);
    }
}

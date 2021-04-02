using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFX : MonoBehaviour
{

    private AudioSource clickSound;

    private void Start()
    {
        try
        {
            clickSound = gameObject.GetComponent<AudioSource>();
        }
        catch
        {
            Debug.Log("Couldn't find AudioSource componenet");
        }
    }

    public void ButtonClick()
    {
        clickSound.Play();
    }
}

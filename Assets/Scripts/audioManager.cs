using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{

    public AudioSource AudioSource;


    public static audioManager am;

    public void Awake()
    {
        am = this;
    }

    public void ReproducirSonidosFx(AudioClip _elsonidito)
    {
        AudioSource.PlayOneShot(_elsonidito);
    }
}


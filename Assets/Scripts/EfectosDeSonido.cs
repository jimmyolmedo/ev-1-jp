using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectosDeSonido : MonoBehaviour
{
    public AudioSource audioSource;


    public void ReproducirSonidoAleatoreo(LibreriaDeSonidos _libreria)
    {
        audioSource.PlayOneShot(_libreria.clip);
    }
}

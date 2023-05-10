using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiarEstado : MonoBehaviour
{
    public Transform root;
    public Transform posReal;

    public GameObject parent;

    public AudioSource audioSource;

    public AudioClip caminarClip;
    public AudioClip golpeClip;
    public AudioClip muerteClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiarEstado()
    {
        gameObject.GetComponentInParent<arañaNormal>().caminando = true;
    }

    public void cambiarPosicion()
    {
        posReal.position = new Vector2(root.position.x, posReal.position.y);
    }

    public void atacado()
    {
        gameObject.GetComponentInParent<arañaNormal>().Daño();
    }


   public void Destruir()
    {
        Debug.Log("destruiste un enemigo!!");
        Destroy(parent.gameObject);
    }


    public void audioCaminar()
    {
        audioSource.clip = caminarClip;
        audioSource.Play();
    }


    public void audioGolpe()
    {
        audioSource.clip = golpeClip;
        audioSource.Play();
    }

    public void audioMuerte()
    {
        audioSource.clip = muerteClip;
        audioSource.Play();
    }

}

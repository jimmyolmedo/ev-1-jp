using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemReparar : MonoBehaviour
{

    public int reparacion = 50;
    public AudioClip sonidoReparar;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().hacha.hpHacha.valor += reparacion;
            audioManager.am.ReproducirSonidosFx(sonidoReparar);
            Destroy(gameObject);


        }  
    }
}

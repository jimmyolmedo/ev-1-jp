using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacha : MonoBehaviour
{

    public IntVariable hpHacha;
    public IntVariable dañoHacha;
    public IntVariable gastoPorGolpe;
    public IntVariable lvlHacha;

    public Sprite hachaNormal, hachaRota;
    public SpriteRenderer spr;
    public AudioClip sonidoHachaRota;
    public AudioSource audioSource;


    public void Golpeo()
    {
        hpHacha.valor -= gastoPorGolpe.valor;       // resta vida al hacha por cada golpe
        CheckHachaHP();                     
    }

    void CheckHachaHP()
    {
       // si le queda Hp muestra el sprite de hacha normal, sino, muestra el de hacha rota
        if(hpHacha.valor < 1)
        {
            audioSource.PlayOneShot(sonidoHachaRota);
            spr.sprite = hachaRota;
        }
        else
        {
            spr.sprite = hachaNormal;
        }
    }
}

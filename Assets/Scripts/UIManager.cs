using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public float vidaPlayer;
    public float velocidad;
    public float da�o;
    public float dinero;

    public GameObject player;
    public GameObject hacha;

    public TextMeshProUGUI hpTxt, da�oTxt, velocidadTxt, dineroTxt;

    private void Update()
    {

        Variables();

        hpTxt.text = "HP: " + vidaPlayer.ToString();
        da�oTxt.text = "Da�o: " + da�o.ToString();
        velocidadTxt.text = "velocidad: " + velocidad.ToString();
        dineroTxt.text = dinero.ToString();

    }


    public void Variables()
    {
        vidaPlayer = player.gameObject.GetComponent<Player>().vidaActual;

        velocidad = player.gameObject.GetComponent<Player>().velocidadMovimiento;

        da�o = hacha.gameObject.GetComponent<Hacha>().da�oHacha;

        dinero = GameManager.gm.dinero;
    }

}

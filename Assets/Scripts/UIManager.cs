using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public float vidaPlayer;
    public float velocidad;
    public float daño;
    public float dinero;

    public GameObject player;
    public GameObject hacha;

    public TextMeshProUGUI hpTxt, dañoTxt, velocidadTxt, dineroTxt;

    private void Update()
    {

        Variables();

        hpTxt.text = "HP: " + vidaPlayer.ToString();
        dañoTxt.text = "Daño: " + daño.ToString();
        velocidadTxt.text = "velocidad: " + velocidad.ToString();
        dineroTxt.text = dinero.ToString();

    }


    public void Variables()
    {
        vidaPlayer = player.gameObject.GetComponent<Player>().vidaActual;

        velocidad = player.gameObject.GetComponent<Player>().velocidadMovimiento;

        daño = hacha.gameObject.GetComponent<Hacha>().dañoHacha;

        dinero = GameManager.gm.dinero;
    }

}

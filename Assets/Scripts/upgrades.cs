using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class upgrades : MonoBehaviour
{

    public float dineroCompra;
    public int aumentoCosto;

    public UnityEvent compra;
    public UnityEvent noCompra;

    public GameObject player;

    public float aumentoVel;
    public int costovel;

    public float aumentoDamage;
    public int costoDamage;

    public float aumentoVida;
    public int costoVida;

    public bool comprando;
    public bool hp;
    public bool damage;
    public bool vel;
    public bool reparar;

    public TMP_Text textCosto;

    public int costoReparar;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarTextos();


        dineroCompra = GameManager.gm.dinero;
        if (comprando)
        {
            compra.Invoke();
        }
        else
        {
            noCompra.Invoke();
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("Player"))
       {
           comprando = true;
       }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        comprando = false;
    }


    public void aumentarSpeed()
    { 
        if (Input.GetButtonDown("Fire1"))
        {
            for(int i = 0; i < 1; i++)
            {
                if (dineroCompra >= costovel)
                {
                    GameManager.gm.GastarDinero(costovel);
                    player.gameObject.GetComponent<Player>().AumentarVelocidad(aumentoVel);
                    costovel = costovel + aumentoCosto;
                }
            }
        }
    }

    public void AumentarAtaque()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            for (int i = 0; i < 1; i++)
            {
                if (dineroCompra >= costoDamage)
                {
                    GameManager.gm.GastarDinero(costoDamage);
                    player.gameObject.GetComponent<Player>().hacha.AumentarDamage(aumentoDamage);
                    costoDamage = costoDamage + aumentoCosto;
                }
            }
        }

    }

    public void AumentarVida()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            for (int i = 0; i < 1; i++)
            {
                if (dineroCompra >= costoVida)
                {
                    GameManager.gm.GastarDinero(costoVida);
                    player.gameObject.GetComponent<Player>().AumentarHp(aumentoVida);
                    costoVida = costoVida + aumentoCosto;
                }
            }
        }
    }

    public void AvanzarOleada()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameManager.gm.contEnemy = 15;
        }
    }


    public void ActualizarTextos()
    {
        if(hp == true)
        {
            textCosto.text = "-" + costoVida.ToString();
        }
         if(vel == true)
        {
            textCosto.text = "-" + costovel.ToString();
        }
         if(damage == true)
        {
            textCosto.text = "-" + costoDamage.ToString();
        }
         if(reparar == true)
        {
            textCosto.text = "-" + costoReparar.ToString();
        }
    }


    public void ReparacionArbol()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            for (int i = 0; i < 1; i++)
            {
                if (dineroCompra >= costoReparar)
                {
                    GameManager.gm.GastarDinero(costoReparar);
                    player.gameObject.GetComponent<Player>().repararArbol = true;
                    costoReparar = costoReparar + aumentoCosto;
                }
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class upgrades : MonoBehaviour
{

    public float dineroCompra;
    public float aumentoCosto;

    public UnityEvent compra;

    public GameObject player;

    public float aumentoVel;
    public float costovel;

    public float aumentoDamage;
    public float costoDamage;

    public float aumentoVida;
    public float costoVida;

    public bool comprando;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dineroCompra = GameManager.gm.dinero;
        if (comprando)
        {
            compra.Invoke();
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

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class upgrades : MonoBehaviour
{

    public UnityEvent compra;

    public GameObject player;

    public float aumentoVel;
    public float costovel;

    public float aumentoDamage;
    public float costoDamage;

    public float aumentoVida;
    public float costoVida;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            compra.Invoke();
        }
    }


    public void aumentarSpeed()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            player.gameObject.GetComponent<Player>().AumentarVelocidad(aumentoVel);
        }
    }

    public void AumentarAtaque()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            player.gameObject.GetComponent<Player>().hacha.AumentarDamage(aumentoDamage);
        }

    }

    public void AumentarVida()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            player.gameObject.GetComponent<Player>().AumentarHp(aumentoVida);
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

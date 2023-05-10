using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;
using TMPro;
using UnityEngine.UI;

public class Arbol : MonoBehaviour
{
    public float hpActual;
    public float hpMax;
    public UnityEvent onHit, onDead, onCaida;
    public Animator animator;
    public TextMeshPro textoDaño;
    public TextMeshPro textoReparar;
    public int dropValue;

    public AudioClip sonidoCaida;
    public AudioClip sonidoHojas; 
    public AudioSource audioSource;

    public bool ocupado;
    public bool muerto;

    public Transform lugarSpawn;

    public GameObject enemyActual;

    public GameObject player;

    public GameObject canvas;

    public float damage;

    public float oleadaActual;

    public float timerDamage;

    public float timeDamage;

    public Slider barraVida;

    public GameObject simbolo;

    public GameObject SimboloDe;

    public GameObject SimboloIz;

    public bool enRango;

    


    public void Start()
    {
        hpActual = hpMax;

        barraVida.maxValue = hpMax;

        audioSource = GetComponent<AudioSource>(); 
        animator = GetComponent<Animator>();
        timerDamage = timeDamage;
    }

    void Caida()
    {
        //GameManager.gm.AgregarMadera(dropValue);


        onCaida.Invoke();                           // este evento se manda a llamar desde la animación de caida
    }

    private void Update()
    {

        if(enRango == true)
        {
            ExclamarArbol();
        }
        if(enRango == false)
        {
            ExclamarCamara();
        }


        if(muerto == false)
        {
            oleadaActual = GameManager.gm.numOleada;

            barraVida.value = hpActual;

            if (ocupado)
            {
                animator.Play("agitarHojas");
                PasiveDamage();
            }
        }
        /*
        oleadaActual = GameManager.gm.numOleada;

        barraVida.value = hpActual;

        if (ocupado)
        {
            animator.Play("agitarHojas");
            PasiveDamage();
        }
         */


        if (hpActual < 1)             
        {
            if(muerto == false)
            {
                if (ocupado)
                {
                    GameObject.Find("SPAWNERS").gameObject.GetComponent<spawnEnemy>().BajarSpawn();
                    GameManager.gm.contEnemy++;
                }
                GameManager.gm.arbolesMuertos++;
                Muere();
                muerto = true;
            }
        }
    }





    public void RecibirDaño(int _daño)
    {

        MostrarTextoDaño(_daño);

        hpActual -= _daño;            //restar daño
        if (hpActual < 1)             // si no tengo hp ejecutar Muere sino ejecutar Hit
        {
            Muere();           
        } 
        else
        {
            Hit();
        } 
    }

    void Hit()
    {
        onHit.Invoke();                             // por cada golpe se ejecuta este evento
    }

    void Muere()
    {
        onDead.Invoke();                            // cuando se queda sin hp se ejecuta este evento
        ocupado = false;
        simbolo.SetActive(false);
        SimboloDe.SetActive(false);
        SimboloIz.SetActive(false);
    }



    void MostrarTextoDaño(float cantidad)
    {
        textoDaño.gameObject.SetActive(false);      // apagar texto para que se resetee la animación
        textoDaño.text = "- " + cantidad.ToString();       // actualizar la cantidad de daño en el texto
        textoDaño.gameObject.SetActive(true);       // prender el texto para que muestre cuanto se le quito
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("hacha"))
        {

           if(ocupado == true)
           {
                CrearEnemy();
                GameObject.Find("SPAWNERS").gameObject.GetComponent<spawnEnemy>().BajarSpawn();
                animator.Play("Shake");
                simbolo.SetActive(false);
                SimboloDe.SetActive(false);
                SimboloIz.SetActive(false);
            }
            
            
            //int daño = collision.GetComponent<Hacha>().dañoHacha.valor;     //obtiene el daño del hacha
            //collision.GetComponent<Hacha>().Golpeo();                       // ejecuta la funcion Golpeo dentro del hacha
            // RecibirDaño(daño);                                              // Aplica daño al arbol
        }

        if (collision.CompareTag("Player"))
        {
            enRango = true;
        }
       
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canvas.SetActive(true);
            if(collision.gameObject.GetComponent<Player>().repararArbol == true)
            {
                textoReparar.gameObject.SetActive(true);

                if (Input.GetButtonDown("Fire1"))
                {
                    collision.gameObject.GetComponent<Player>().repararArbol = false;
                    recuperar();
                }
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canvas.SetActive(false);
        textoReparar.gameObject.SetActive(false);
        if (collision.CompareTag("Player"))
        {
            enRango = false;
        }
    }


    public void CrearEnemy()
    {
        Instantiate(enemyActual, lugarSpawn.position, Quaternion.Euler(0, 0, 0));
        ocupado = false;
    }

    public void PasiveDamage()
    {
        timerDamage -= Time.deltaTime;

        if (timerDamage <= 0)
        {
            hpActual = hpActual - damage;
            MostrarTextoDaño(damage);
            timerDamage = timeDamage;
        }
    }



    void SonidoCaida()
    {
        audioSource.PlayOneShot(sonidoCaida);
    }

    public void AumentarDamage()
    {
        //timeDamage = timeDamage - 3;
        damage = damage + 3;
    }

    public void recuperar()
    {
        hpActual = hpMax;
        textoReparar.gameObject.SetActive(false);
    }


    public void ocupar()
    {
        ocupado = true;
    }


    public void ExclamarArbol()
    {
        if(ocupado == true)
        {
            simbolo.SetActive(true);
            SimboloDe.SetActive(false);
            SimboloIz.SetActive(false);
        }
        else
        {
            simbolo.SetActive(false);
        }
    }

    public void ExclamarCamara()
    {
        float playerPos = player.gameObject.transform.position.x;


        if (ocupado == true)
        {
            if (playerPos > transform.position.x)
            {
                SimboloDe.SetActive(true);
            }
            else if(playerPos < transform.position.x)
            {
                SimboloIz.SetActive(true);
            }
        }
        /*else
        {
            SimboloDe.SetActive(false);
            SimboloIz.SetActive(false);
        }*/
    }


    public void CalcularPosision()
    {

    }


    public void SonidoAgitarHojas()
    {
        audioSource.clip = sonidoHojas;
        audioSource.Play();
    }


}

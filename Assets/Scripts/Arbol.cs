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
    public TextMeshPro textoDa�o;
    public TextMeshPro textoReparar;
    public int dropValue;

    public AudioClip sonidoCaida;
    public AudioSource audioSource;

    public bool ocupado;
    public bool muerto;

    public Transform lugarSpawn;

    public GameObject enemyActual;

    public GameObject canvas;

    public float damage;

    public float oleadaActual;

    public float timerDamage;

    public float timeDamage;

    public Slider barraVida;


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


        onCaida.Invoke();                           // este evento se manda a llamar desde la animaci�n de caida
    }

    private void Update()
    {

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
                }
                GameManager.gm.arbolesMuertos++;
                Muere();
                muerto = true;
            }
        }
    }





    public void RecibirDa�o(int _da�o)
    {

        MostrarTextoDa�o(_da�o);

        hpActual -= _da�o;            //restar da�o
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
    }



    void MostrarTextoDa�o(float cantidad)
    {
        textoDa�o.gameObject.SetActive(false);      // apagar texto para que se resetee la animaci�n
        textoDa�o.text = "- " + cantidad.ToString();       // actualizar la cantidad de da�o en el texto
        textoDa�o.gameObject.SetActive(true);       // prender el texto para que muestre cuanto se le quito
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
            }
            
            
            //int da�o = collision.GetComponent<Hacha>().da�oHacha.valor;     //obtiene el da�o del hacha
            //collision.GetComponent<Hacha>().Golpeo();                       // ejecuta la funcion Golpeo dentro del hacha
            // RecibirDa�o(da�o);                                              // Aplica da�o al arbol
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
            MostrarTextoDa�o(damage);
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

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;
using TMPro;

public class Arbol : MonoBehaviour
{
    public int hp;
    public UnityEvent onHit, onDead, onCaida;
    public Animator animator;
    public TextMeshPro textoDaño;
    public int dropValue;

    public bool ocupado;
    public Transform lugarSpawn;
    public GameObject enemyActual;
    public int damage;
    public float timerDamage;
    public float timeDamage;



    public void Start()
    {
        animator = GetComponent<Animator>();
        timerDamage = timeDamage;
    }



    private void Update()
    {
        if (ocupado)
        {
            animator.Play("agitarHojas");
            PasiveDamage();
        }
        else
        {
            animator.Play("New State");
        }
    }





    public void RecibirDaño(int _daño)
    {

        MostrarTextoDaño(_daño);

        hp -= _daño;            //restar daño
        if (hp < 1)             // si no tengo hp ejecutar Muere sino ejecutar Hit
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

    void Caida()
    {
        GameManager.gm.agregarMadera(dropValue);


        onCaida.Invoke();                           // este evento se manda a llamar desde la animación de caida
    }

    void MostrarTextoDaño(int cantidad)
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
            }
            
            
            //int daño = collision.GetComponent<Hacha>().dañoHacha.valor;     //obtiene el daño del hacha
            //collision.GetComponent<Hacha>().Golpeo();                       // ejecuta la funcion Golpeo dentro del hacha
            // RecibirDaño(daño);                                              // Aplica daño al arbol
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
            hp = hp - damage;
            MostrarTextoDaño(damage);
            timerDamage = timeDamage;
        }
    }

}

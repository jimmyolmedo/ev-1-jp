using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class arañaNormal : MonoBehaviour
{

    public float nivel;
    public float vida;

    public UnityEvent caer;
    public UnityEvent muerte;


    public float speed;
    public float empuje;
    public float damage;
    public float damagePlayer;

    public Vector3 escala;

    public GameObject player;
    public Transform playerPos;
    public Transform root;
    public Animator animator;
    public Rigidbody2D rb;
    public BoxCollider2D bc;

    public bool caminando = true;
    public bool callendo = true;
    public bool puedoAtacar = true;
    public bool muerto;
    public bool normal;
    public bool rapida;
    public bool blindada;

    public int cantDinero;

    public TextMeshPro textDinero;


    public AudioSource audioSource;

    public AudioClip golpeClip;
    public AudioClip caminarClip;
    public AudioClip muerteClip;

    // Start is called before the first frame update
    void Start()
    {

        AumentoNivel();
        SumarEnemy();


        player = GameObject.Find("leñador");               //busca al leñador para llenar la variable player
        playerPos = player.transform;                      //toma la posicion del player                   
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        Caer();

       
    }

    // Update is called once per frame
    void Update()
    {

        Girar();

        if (callendo == false)
        {
            Muerte();
            Movement();
        }

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(callendo == false)
        {
            if(muerto == false)
            {
                if (collision.gameObject.CompareTag("hacha"))
                {
                    damagePlayer = collision.gameObject.GetComponent<Hacha>().dañoHacha;
                    Golpe();
                    Empujar(player.transform.position.x);                          //activa la funcion Empujar y toma la posicion de x del hacha
                }
                if (collision.gameObject.CompareTag("Player"))
                {
                    if (puedoAtacar == true)
                    {
                        animator.Play("atacar");
                    }
                }
                if (collision.gameObject.CompareTag("suelo"))
                {
                    caer.Invoke();

                }

            }
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (callendo == true)
        {
            if (collision.gameObject.CompareTag("suelo"))
            {
                callendo = false;
                rb.gravityScale = 0;
                animator.Play("caminar");
                caer.Invoke();
            }
        }
    }

    public void Muerte()
    {
        if(vida <= 0)
        {
            if(muerto == false)
            {
                muerte.Invoke();
                caminando = false;
                puedoAtacar = false;
                animator.Play("muerte");
                GameManager.gm.contEnemy++;
                drop();
                RestarEnemy();
                muerto = true;
            }
        }
    }

    public void Movement()
    {

       if (caminando == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerPos.position.x, transform.position.y), speed * Time.deltaTime);
        }
    }

    public void Golpe()
    {
        caminando = false;
        animator.Play("hurt");
        // empujar a la araña
    }

    public void Daño()
    {
        vida = vida - damagePlayer;
    }

    public void Caer()
    {
        animator.Play("caer");
    }

    void Empujar(float hachaPosX)
    {
        if(transform.position.x > hachaPosX)
        {
            print("empujar hacia la derecha");
            rb.AddForce(Vector2.right * empuje , ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(Vector2.left * empuje, ForceMode2D.Impulse);
        }


        Invoke("DetenerEmpuje", 0.25f);

    }

    void DetenerEmpuje()
    {
        rb.velocity = Vector2.zero;
    }


    void Girar()
    {
        escala = transform.localScale;
        float direccion;
        direccion = transform.position.x - player.transform.position.x;
        if(direccion >= 0)
        {
            escala.x = 1;
            transform.localScale = escala;
        }
        else
        {
            escala.x = -1;
            transform.localScale = escala;
        }
    }


    public void AumentoNivel()
    {
        nivel = GameManager.gm.numOleada;
        if(nivel != 1)
        {
            speed = speed + nivel;

            damage = damage + nivel;

            vida = vida + nivel;
        }
    }

    public void drop()
    {
        int cantidad = Random.Range(1, cantDinero);

        GameManager.gm.AgregarDinero(cantidad);

        textDinero.gameObject.SetActive(false);      // apagar texto para que se resetee la animación
        textDinero.text = "+ " + cantidad.ToString();       // actualizar la cantidad de daño en el texto
        Debug.Log("pa casa platita");
        textDinero.gameObject.SetActive(true);       // prender el texto para que muestre cuanto se le quito

    }

    public void SumarEnemy()
    {
        if (normal)
        {
            GameManager.gm.normal++;
        }
        else if (rapida)
        {
            GameManager.gm.rapida++;
        }
        else if (blindada)
        {
            GameManager.gm.blindada++;
        }
    }


    public void RestarEnemy()
    {
        if (normal)
        {
            GameManager.gm.normal--;
        }
        else if (rapida)
        {
            GameManager.gm.rapida--;
        }
        else if (blindada)
        {
            GameManager.gm.blindada--;
        }
    }

    public void audioCaminar()
    {
        audioSource.clip = caminarClip;
        audioSource.Play();
    }


    public void audioGolpe()
    {
        audioSource.clip = golpeClip;
        audioSource.Play();
    }

    public void audioMuerte()
    {
        audioSource.clip = muerteClip;
        audioSource.Play();
    }


    public void destruir()
    {
        Destroy(gameObject);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arañaNormal : MonoBehaviour
{
    
    public int vida;
    public float speed;
    public float empuje;

    public Vector3 escala;

    public GameObject player;
    public Transform playerPos;
    public Transform root;
    public Animator animator;
    public Rigidbody2D rb;
    public BoxCollider2D bc;

    public bool caminando = true;
    public bool callendo = true;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("leñador");               //busca al leñador para llenar la variable player
        playerPos = player.transform;                      //toma la posicion del player                   
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

        caer();

       
    }

    // Update is called once per frame
    void Update()
    {

        Girar();

        if (callendo == false)
        {
            muerte();
            movement();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(callendo == false)
        {
            if (collision.gameObject.CompareTag("hacha"))
            {
                Golpe();
                Empujar(collision.transform.position.x);                          //activa la funcion Empujar y toma la posicion de x del hacha
            }
            if (collision.gameObject.CompareTag("Player"))
            {
                animator.Play("atacar");
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
            }
        }
    }

    public void muerte()
    {
        if(vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void movement()
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

    public void daño()
    {
        vida--;
    }

    public void caer()
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

}

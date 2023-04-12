using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arañaNormal : MonoBehaviour
{

    public int vida;
    public float speed;
    public float empuje;

    public GameObject player;
    public Transform playerPos;
    public Transform root;
    public Animator animator;
    public Rigidbody2D rb;

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
        if (callendo == false)
        {
            muerte();
            movement();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(callendo == true)
        {
            if (collision.gameObject.CompareTag("suelo"))
            {
                callendo = false;
                rb.gravityScale = 0;
                animator.Play("caminar");
            }
        }


        if(callendo == false)
        {
            if (collision.gameObject.CompareTag("hacha"))
            {
                golpe();
            }
            if (collision.gameObject.CompareTag("Player"))
            {
                animator.Play("atacar");
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
       if(caminando == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerPos.position.x, transform.position.y), speed * Time.deltaTime);
        }
    }

    public void golpe()
    {
        caminando = false;
        animator.Play("hurt");
    }

    public void daño()
    {
        vida--;
    }

    public void caer()
    {
        animator.Play("caer");
    }

}

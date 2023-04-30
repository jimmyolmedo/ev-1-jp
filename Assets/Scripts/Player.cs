using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Hacha hacha;                 // referencia al Hacha
    public Animator animator;           // referencia al animator
    
    public bool movimiento;             // activar o desactivar el movimiento
    public bool golpear;                // activar o desactivar el golpe del hacha

    public float velocidadMovimiento;
    public float empuje;
    public float damageEnemy;

    float inputX;

    public float vidaActual;
    public float vidaMax;

    public bool mirarDerecha;

    public Vector3 Escala;

    public Rigidbody2D rb;

    public bool repararArbol;           //se activara al comprar la reparacion del arbol


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        vidaActual = vidaMax;
    }


    private void Update()
    {

        if(vidaActual > vidaMax)
        {
            vidaActual = vidaMax;
        }

        Morir();

        if (movimiento)
            Mover();

        if(golpear)
            Golpear();

        AnimatorParameters();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ataqueEnemigo"))
        {
            damageEnemy = collision.gameObject.GetComponentInParent<arañaNormal>().damage;
            Debug.Log("golpeado!!");
            Empujar(collision.transform.position.x);
        }
    }




    void Golpear()
    {
        if(Input.GetButtonDown("Jump"))
        {
            StartCoroutine(BloquearMovimientoDuranteAnimacion());   //el player no se puede mover cuando esta golpeando

            if (hacha.hpHacha.valor > 1)                            // si el hacha tiene HP puede golpear, sino, reproduce la animacion de hacha rota
                animator.Play("Golpear");
            else
                animator.Play("HachaRota");
        }
    }

    void Mover()
    {
        inputX = Input.GetAxisRaw("Horizontal");                // obtiene e valor del axis horizontal 

        if(inputX !=0)
        {
            transform.Translate(Vector3.right * inputX * velocidadMovimiento * Time.deltaTime);
            Flip();
        }

    }

    void Flip()
    {
        transform.localScale = inputX > 0? Vector3.one : new Vector3(-1,1,1); //gira al personaje en la dirección donde se está moviendo
    }

    void AnimatorParameters()
    {
        animator.SetFloat("inputX", Mathf.Abs(inputX));     // alimenta el parametro de INputX del animator
    }

    IEnumerator BloquearMovimientoDuranteAnimacion()
    {
        movimiento = false;         // bloquea el movimiento del personaje

        while(!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))  // espera hasta que la animación llegue al Idle para seguir con la corutina
        {
            yield return null;
        }

        movimiento = true;          // desbloquea el movimiento del personaje
    }



    void Empujar(float hachaPosX)
    {
        if (transform.position.x > hachaPosX)
        {
            print("empujar hacia la derecha");
            rb.AddForce(Vector2.right * empuje, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(Vector2.left * empuje, ForceMode2D.Impulse);
        }

        animator.Play("leñadorHurt");
        Invoke("DetenerEmpuje", 0.30f);

    }

    void DetenerEmpuje()
    {
        rb.velocity = Vector2.zero;
    }

    public void AumentarVelocidad(float _cantidad)
    {
        velocidadMovimiento = velocidadMovimiento + _cantidad;
    }


    public void AumentarHp(float _cantidad)
    {
        if(vidaActual < vidaMax)
        {
            vidaActual = vidaActual + _cantidad;
        }
    }


    public void RecibirDamage()
    {
        vidaActual = vidaActual - damageEnemy;
    }


    public void Morir()
    {
        if(vidaActual <= 0)
        {
            GameManager.gm.EliminarEnemys();
            animator.Play("muerte");
        }
    }

}

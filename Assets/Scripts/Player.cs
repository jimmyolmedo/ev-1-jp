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

    float inputX;




    private void Update()
    {
        if(movimiento)
            Mover();

        if(golpear)
            Golpear();

        AnimatorParameters();
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






}

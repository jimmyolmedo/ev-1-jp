using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reparar : MonoBehaviour
{
    public int reparacion = 50;

    private void OnTriggerEnter2D(Collider2D elOtroCollision)
    {
        if(elOtroCollision.CompareTag("Player"))
        {
            elOtroCollision.gameObject.GetComponent<Player>().hacha.hpHacha.valor += reparacion;

            Destroy(gameObject);
        }
    }
}

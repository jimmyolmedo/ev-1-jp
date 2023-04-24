using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent onGameStart, onGameOver, onGameRestart;
    public static GameManager gm;

    public GameObject[] arboles;

    public IntVariable madera;

    public int numOleada = 1;

    public int contEnemy;

    public GameObject spawner;
    public GameObject looby;

    private void Awake()
    {
        gm = this;
    }

    private void Update()
    {
        if(contEnemy >= 10)
        {
            numOleada++;

            if(numOleada % 2 != 0)
            {
                spawner.gameObject.GetComponent<spawnEnemy>().aumentarSpawn();
            }

            AumentarDamageArbol();

            contEnemy = 0;
        }

        if(numOleada % 2 == 0)
        {
            spawner.SetActive(false);
            looby.SetActive(true);
        }
        else
        {
            spawner.SetActive(true);
            looby.SetActive(false);
        }
    }



    public void OnGameStart()
    {
        onGameStart.Invoke();
    }


    public void OnGameOver()
    {
        onGameOver.Invoke();
    }

    public void OnGameRestart()
    {
        onGameRestart.Invoke();
    }

    public void AgregarMadera(int _cantidad)
    {
        madera.valor += _cantidad;
    }

    public void AumentarDamageArbol()
    {
        for(int i = 0; i < arboles.Length; i++)
        {
            arboles[i].gameObject.GetComponent<Arbol>().AumentarDamage();
        }
    }

}

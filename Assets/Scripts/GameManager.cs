using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent onGameStart, onGameOver, onGameRestart;
    public static GameManager gm;

    public IntVariable madera;

    public int numOleada = 1;

    public int contEnemy;

    public GameObject spawner;

    private void Awake()
    {
        gm = this;
    }

    private void Update()
    {
        if(contEnemy >= 10)
        {
            numOleada++;

            spawner.gameObject.GetComponent<spawnEnemy>().aumentarSpawn();
            contEnemy = 0;
        }

        if(numOleada % 2 == 0)
        {
            spawner.SetActive(false);
        }
        else
        {
            spawner.SetActive(true);
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
}

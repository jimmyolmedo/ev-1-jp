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

    private void Awake()
    {
        gm = this;
    }

    private void Update()
    {
        if(contEnemy >= 15)
        {
            numOleada++;
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

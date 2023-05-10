using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    public UnityEvent onGameStart, onGameOver, onGameRestart;
    public static GameManager gm;

    public GameObject[] arboles;

    public UnityEvent perdida;

    public int dinero;

    public float numOleada = 1;

    public int contEnemy;
    public int arbolesMuertos;

    public GameObject spawner;
    public GameObject looby;

    public int normal;
    public int rapida;
    public int blindada;
    public TextMeshPro textDinero;

    private void Awake()
    {
        gm = this;
    }

    private void Update()
    {


        if(arbolesMuertos >= arboles.Length)
        {
            perdida.Invoke();
        }

        if(contEnemy >= 10)
        {
            numOleada++;

            if(numOleada % 2 != 0)
            {
                spawner.gameObject.GetComponent<spawnEnemy>().aumentarSpawn();
                AumentarDamageArbol();
            }

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

    public void AgregarDinero(int _cantidad)
    {
        dinero = dinero + _cantidad;

    }


    public void ActivarTextoDinero(int _cantidad)
    {
        textDinero.gameObject.SetActive(false);      // apagar texto para que se resetee la animación
        textDinero.text = "+ " + _cantidad.ToString();       // actualizar la cantidad de daño en el texto
        Debug.Log("pa casa platita");
        textDinero.gameObject.SetActive(true);
    }

    public void AumentarDamageArbol()
    {
        for(int i = 0; i < arboles.Length; i++)
        {
            arboles[i].gameObject.GetComponent<Arbol>().AumentarDamage();
        }
    }

    public void GastarDinero(int _cantidad)
    {
        dinero = dinero - _cantidad;
    }


    public void EliminarEnemys()
    {
        for(int i = 0; i < normal; i++)
        {
            GameObject.Find("arañaParent(Clone)").gameObject.GetComponent<arañaNormal>().destruir();
        }
        for (int i = 0; i < rapida; i++)
        {
            GameObject.Find("aranaRapida parent(Clone)").gameObject.GetComponent<arañaNormal>().destruir();
        }
        for (int i = 0; i < blindada; i++)
        {
            GameObject.Find("arañaBlindadaParent(Clone)").gameObject.GetComponent<arañaNormal>().destruir();
        }

    }


}

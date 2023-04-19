using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{

    public int oleada;
    public int spawnMax;

    public GameObject[] enemys;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    public Transform[] spawn;

    public float tiempoSpawn;
    public float timerSpawn;


    // Start is called before the first frame update
    void Start()
    {
        timerSpawn = tiempoSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        timerSpawn -= Time.deltaTime;

        if (spawnMax <= 3)
        {
            if(timerSpawn <= 0)
            {
                Spawnear();
            }
        }
    }

    public void Spawnear()
    {
        int randomT = Random.Range(0, spawn.Length);
        int randomG = Random.Range(0, enemys.Length);
        int numero = 0;

         if (numero == 0)
         {
            if (spawn[randomT].gameObject.GetComponent<Arbol>().ocupado == false)
            {
               //Instantiate(enemys[randomG], spawn[randomT].position, Quaternion.Euler(0, 0, 0));
                spawn[randomT].gameObject.GetComponent<Arbol>().ocupado = true;
                spawnMax++;
                timerSpawn = tiempoSpawn;
                numero++;
            }
            else
            {
                randomT = Random.Range(0, spawn.Length);
            }
         }
    }

    public void BajarSpawn()
    {
        spawnMax--;
    }

}

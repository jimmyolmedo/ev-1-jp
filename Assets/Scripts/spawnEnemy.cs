using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{

    public float oleada;
    public int spawnMax;
    public int arbolCaidos;
    public int spawnPorOleada = 15;
    public float tiempoMenos = 1;

    public GameObject[] enemys;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    public Transform[] spawn;

    public float tiempoSpawn;
    public float timerSpawn;

    public bool puedeSpawnear = true;


    // Start is called before the first frame update
    void Start()
    {
        timerSpawn = tiempoSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        timerSpawn -= Time.deltaTime;

        DetenerSpawn();

        if(puedeSpawnear == true)
        {
            if (spawnMax < 3)
            {
                if (timerSpawn <= 0)
                {
                    NivelOleada();
                }

            }
        }

    }

    public void Spawnear()
    {

        enemys = new GameObject[] { enemy1 };

        int randomT = Random.Range(0, spawn.Length);
        int randomG = Random.Range(0, enemys.Length);


        if (spawn[randomT].gameObject.GetComponent<Arbol>().ocupado == false && spawn[randomT].gameObject.GetComponent<Arbol>().muerto == false)
        {
            //Instantiate(enemys[randomG], spawn[randomT].position, Quaternion.Euler(0, 0, 0));

            spawn[randomT].gameObject.GetComponent<Arbol>().enemyActual = enemys[randomG];

            spawn[randomT].gameObject.GetComponent<Arbol>().ocupado = true;
                spawnMax++;
                timerSpawn = tiempoSpawn;
                arbolCaidos++;

                
            }
            else
            {
                randomT = Random.Range(0, spawn.Length);
            }
         
    }

    public void SpawnearLv2()
    {

        enemys = new GameObject[] { enemy1, enemy2 };

        int randomT = Random.Range(0, spawn.Length);
        int randomG = Random.Range(0, enemys.Length);


        if (spawn[randomT].gameObject.GetComponent<Arbol>().ocupado == false && spawn[randomT].gameObject.GetComponent<Arbol>().muerto == false)
        {
            //Instantiate(enemys[randomG], spawn[randomT].position, Quaternion.Euler(0, 0, 0));

            spawn[randomT].gameObject.GetComponent<Arbol>().enemyActual = enemys[randomG];

            spawn[randomT].gameObject.GetComponent<Arbol>().ocupado = true;
            spawnMax++;
            timerSpawn = tiempoSpawn;
            arbolCaidos++;


        }
        else
        {
            randomT = Random.Range(0, spawn.Length);
        }
    }



    public void SpawnearLv3()
    {

        enemys = new GameObject[] { enemy1, enemy2, enemy3 };

        int randomT = Random.Range(0, spawn.Length);
        int randomG = Random.Range(0, enemys.Length);

        //pregunto si el arbol no esta ocupado ni muerto, ejecutar el spawn
        if (spawn[randomT].gameObject.GetComponent<Arbol>().ocupado == false && spawn[randomT].gameObject.GetComponent<Arbol>().muerto == false)
        {
            //Instantiate(enemys[randomG], spawn[randomT].position, Quaternion.Euler(0, 0, 0));

            spawn[randomT].gameObject.GetComponent<Arbol>().enemyActual = enemys[randomG];

            spawn[randomT].gameObject.GetComponent<Arbol>().ocupado = true;
            spawnMax++;
            timerSpawn = tiempoSpawn;
            arbolCaidos++;


        }
        else
        {
            randomT = Random.Range(0, spawn.Length);
        }
    }



    public void BajarSpawn()
    {
        spawnMax--;
    }

    public void DetenerSpawn()
    {
        if(arbolCaidos >= 10)
        {
            if(puedeSpawnear == true)
            {
                tiempoMenos++;
                puedeSpawnear = false;
                arbolCaidos = 0;
            }
        }
    }


    public void aumentarSpawn()
    {
        oleada = GameManager.gm.numOleada;

        if(oleada != 1)
        {
            tiempoSpawn = tiempoSpawn - tiempoMenos;
            timerSpawn = tiempoSpawn;
            puedeSpawnear = true;
        }
    }


    public void NivelOleada()
    {
        if(spawnPorOleada > 0)
        {
            if (oleada < 3)
            {
                Spawnear();
            }
            else if (oleada < 6)
            {
                SpawnearLv2();
            }
            else
            {
                SpawnearLv3();
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{

    public int oleada;

    public GameObject[] enemys;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    public Transform[] spawn;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnear()
    {
        int randomT = Random.Range(0, spawn.Length);
        int randomG = Random.Range(0, enemys.Length);
        Instantiate(enemys[randomG], spawn[randomT].position, Quaternion.Euler(0, 90, 0));
    }
}

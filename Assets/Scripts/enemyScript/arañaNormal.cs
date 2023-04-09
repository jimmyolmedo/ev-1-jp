using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arañaNormal : MonoBehaviour
{

    public int vida;
    public float speed;

    public GameObject player;

    public Transform playerPos;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("leñador");               //busca al leñador para llenar la variable player
        playerPos = player.transform;                      //toma la posicion del player                   
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        muerte();
        movement();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("hacha"))
        {
            vida--;
        }
    }

    public void muerte()
    {
        if(vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerPos.position.x, transform.position.y), speed * Time.deltaTime);
    }

}

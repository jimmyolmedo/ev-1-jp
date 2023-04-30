using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Activaciones : MonoBehaviour
{
    public UnityEvent presionarTecla;
    public UnityEvent entrarTrigger;
    public KeyCode tecla;
    public string escena;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(tecla))
        {
            presionarTecla.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            entrarTrigger.Invoke();
        }
    }



    public void cambiarescena()
    {
        SceneManager.LoadScene(escena);
    }

}

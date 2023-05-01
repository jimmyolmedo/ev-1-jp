using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectarPeligro : MonoBehaviour
{

    public GameObject[] arboles;
    public GameObject exclamacionDe;
    public GameObject exclamacionIz;

    public bool enArea;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enArea == false)
        {
            for(int i = 0; i < arboles.Length; i++)
            {
                arboles[i].gameObject.GetComponent<Arbol>().ExclamarCamara();
            }
        }
        if(enArea == true)
        {

            exclamacionDe.SetActive(false);
            exclamacionIz.SetActive(false);

            for (int i = 0; i < arboles.Length; i++)
            {
                arboles[i].gameObject.GetComponent<Arbol>().ExclamarArbol();
            }
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("arbol"))
        {
            enArea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        enArea = false;
    }







    public void EncenderDe()
    {
        exclamacionDe.SetActive(true);
    }

    public void EncenderIz()
    {
        exclamacionIz.SetActive(true);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiarEstado : MonoBehaviour
{
    public Transform root;
    public Transform posReal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiarEstado()
    {
        gameObject.GetComponentInParent<arañaNormal>().caminando = true;
    }

    public void cambiarPosicion()
    {
        posReal.position = new Vector2(root.position.x, posReal.position.y);
    }

    public void atacado()
    {
        gameObject.GetComponentInParent<arañaNormal>().daño();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiarEstado : MonoBehaviour
{
    public Transform root;
    public Transform posReal;

    public GameObject parent;
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
        gameObject.GetComponentInParent<ara�aNormal>().caminando = true;
    }

    public void cambiarPosicion()
    {
        posReal.position = new Vector2(root.position.x, posReal.position.y);
    }

    public void atacado()
    {
        gameObject.GetComponentInParent<ara�aNormal>().Da�o();
    }


   public void Destruir()
    {
        Debug.Log("destruiste un enemigo!!");
        Destroy(parent.gameObject);
    }

}

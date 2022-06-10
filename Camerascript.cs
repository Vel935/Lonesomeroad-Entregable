using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerascript : MonoBehaviour
{

    public GameObject Mago;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;  // en cada frame se coge la posicion de la camara 
        position.x = Mago.transform.position.x;  // se copia la posicion del mago 
        transform.position = position;
    }
}

using UnityEngine;
using System.Collections;

public class ControlBola : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Eliminamos el objeto si se sale de la pantalla
        if (transform.position.y > 10 || transform.position.y < -5)
        {
            Destroy(gameObject);
        }


       
    }
}

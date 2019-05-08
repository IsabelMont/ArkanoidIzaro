using UnityEngine;
using System.Collections;

public class ControlBarrera : MonoBehaviour
{

    // Velocidad a la que se desplaza la barrera (medido en u/s)
    private float velocidad = 20f;

    // LE BAJO LA FUERZA A LA BOLA QUE SI NO VA A TODA HOSTIA
    // Fuerza de lanzamiento de la bola
    //private float fuerza = 0.5f;
    private float fuerza = 0.2f;

    // Acceso al prefab de la bola
    public Rigidbody2D bola;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
         // CREO LA BOLA:              
         // Instanciamos el objeto partiendo del prefab
         Rigidbody2D bolita = (Rigidbody2D)Instantiate(bola, transform.position, transform.rotation);
        

        // Calculamos la anchura visible de la cámara en pantalla
        float distanciaHorizontal = Camera.main.orthographicSize * Screen.width / Screen.height;

        // Calculamos el límite izquierdo y el derecho de la pantalla
        float limiteIzq = -1.0f * distanciaHorizontal;
        float limiteDer = 1.0f * distanciaHorizontal;

        // Tecla: Izquierda
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            // Nos movemos a la izquierda hasta llegar al límite para entrar por el otro lado
            if (transform.position.x > limiteIzq)
            {
                transform.Translate(Vector2.left * velocidad * Time.deltaTime);
            }
            else
            {
                transform.position = new Vector2(limiteDer, transform.position.y);
            }
        }

        // Tecla: Derecha
        if (Input.GetKey(KeyCode.RightArrow))
        {

            // Nos movemos a la derecha hasta llegar al límite para entrar por el otro lado
            if (transform.position.x < limiteDer)
            {
                transform.Translate(Vector2.right * velocidad * Time.deltaTime);
            }
            else
            {
                transform.position = new Vector2(limiteIzq, transform.position.y);
            }
        }

        // Bola
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // CONTROLO QUE SOLO HAYA EN PANTALLA UNA BOLA
            if bolita 
            disparar(bolita);
        }
    }

    void disparar(Rigidbody2D bola)
    {
        // Hacemos copias del prefab de la bola y las lanzamos
        //Rigidbody2D d = (Rigidbody2D)Instantiate(bola, transform.position, transform.rotation);

        // Desactivar la gravedad para este objeto, si no, ¡se cae!
        bola.gravityScale = 0;

        // Posición de partida, en la punta de la barrera
        bola.transform.Translate(Vector2.up * 0.7f);

        // Lanzarlo
        bola.AddForce(Vector2.up * fuerza, ForceMode2D.Impulse);
    }


}

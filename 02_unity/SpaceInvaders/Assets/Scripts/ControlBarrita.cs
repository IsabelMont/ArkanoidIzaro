using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControlBarrita : MonoBehaviour
{
    // Conexión al marcador, para poder actualizarlo
    private GameObject marcador;

    // Por defecto, 100 puntos por cada barrita
    private int puntos = 100;

    // Objeto para reproducir la explosión de una barrita
    private GameObject efectoExplosion;

    // Use this for initialization
    void Start()
    {
        // Localizamos el objeto que contiene el marcador
        marcador = GameObject.Find("Marcador");

        // Objeto para reproducir la explosión de una barrita
        efectoExplosion = GameObject.Find("EfectoExplosion");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // Detectar la colisión entre la barrita y otros elementos

        // Necesitamos saber contra qué hemos chocado
        if (coll.gameObject.tag == "Bola")
        {

            // Sonido de explosión
            GetComponent<AudioSource>().Play();

            // Sumar la puntuación al marcador
            marcador.GetComponent<ControlMarcador>().puntos += puntos;

            // NO QUIERO DESTRUIR LA BOLA, ASÍ QUE LA DEJO SIN DESTROY
            // La bola desaparece (cuidado, si tiene eventos no se ejecutan)
            //Destroy(coll.gameObject);

            // La barrita desaparece (no hace falta retraso para la explosión, está en otro objeto)
            efectoExplosion.GetComponent<AudioSource>().Play();
            Destroy(gameObject);

            

        }
        else if (coll.gameObject.tag == "Barra")
        {
            SceneManager.LoadScene("Nivel1");
        }
    }
}

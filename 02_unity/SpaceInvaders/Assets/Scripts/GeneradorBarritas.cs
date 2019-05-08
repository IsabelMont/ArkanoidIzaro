using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GeneradorBarritas : MonoBehaviour
{

    // Publicamos la variable para conectarla desde el editor
    public Rigidbody2D prefabBarritaRoja;

    // Referencia para guardar una matriz de objetos
    private Rigidbody2D[,] barritas;

    // Tamaño de las barritas
    private const int FILAS = 4;
    private const int COLUMNAS = 7;

    // Enumeración para expresar el sentido del movimiento
    //private enum direccion { IZQ, DER };

    // Rumbo que lleva el pack de las barritas
    //private direccion rumbo = direccion.DER;

    // Posición vertical de las barritas (lo iremos restando de la .y de cada barrita)
    private float altura = 0.5f;

    // Límites de la pantalla
    private float limiteIzq;
    private float limiteDer;

    // Velocidad a la que se desplazan los aliens (medido en u/s)
    //private float velocidad = 5f;

    // Use this for initialization
    void Start()
    {
        // Rejilla de 4x7 barritas
        generarBarritas(FILAS, COLUMNAS, 1.5f, 1.0f);

        // Calculamos la anchura visible de la cámara en pantalla
        float distanciaHorizontal = Camera.main.orthographicSize * Screen.width / Screen.height;

        // Calculamos el límite izquierdo y el derecho de la pantalla (añadimos una unidad a cada lado como margen)
        limiteIzq = -1.0f * distanciaHorizontal + 1;
        limiteDer = 1.0f * distanciaHorizontal - 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Contador para saber si hemos terminado
        int numBarritas = 0;

        // Variable para saber si al menos una barrita ha llegado al borde
        //bool limiteAlcanzado = false;

        // Recorremos las barritas
        for (int i = 0; i < FILAS; i++)
        {
            for (int j = 0; j < COLUMNAS; j++)
            {

                // Comprobamos que haya objeto, para cuando nos empiecen a disparar
                if (barritas[i, j] != null)
                {

                    // Una barrita más
                    numBarritas += 1;

                    // ¿Vamos a izquierda o derecha?
                    //if (rumbo == direccion.DER)
                    //{

                        // Nos movemos a la derecha (todos las barritas que queden)
                        //barritas[i, j].transform.Translate(Vector2.right * velocidad * Time.deltaTime);

                        // Comprobamos si hemos tocado el borde
                        //if (barritas[i, j].transform.position.x > limiteDer)
                        //{
                           // limiteAlcanzado = true;
                        //}
                    }
                    else
                    {

                        // Nos movemos a la derecha (todos las barritas que queden)
                        //barritas[i, j].transform.Translate(Vector2.left * velocidad * Time.deltaTime);

                        // Comprobamos si hemos tocado el borde
                        //if (barritas[i, j].transform.position.x < limiteIzq)
                        //{
                           // limiteAlcanzado = true;
                        //}
                    }
                //}
            }
        }

        // Si no quedan barritas, hemos terminado
        if (numBarritas == 0)
        {
            SceneManager.LoadScene("Nivel1");
        }

        // Si al menos una barrita ha tocado el borde, todo el pack cambia de rumbo
       // if (limiteAlcanzado == true)
       // {
            //for (int i = 0; i < FILAS; i++)
           // {
               // for (int j = 0; j < COLUMNAS; j++)
               // {

                    // Comprobamos que haya objeto, para cuando nos empiecen a disparar
                  //  if (barritas[i, j] != null)
                   // {
                    //    barritas[i, j].transform.Translate(Vector2.down * altura);
                   // }
               // }
           // }


            //if (rumbo == direccion.DER)
            //{
               // rumbo = direccion.IZQ;
            //}
            //else
            //{
                //rumbo = direccion.DER;
            //}
        //}
    }

    void generarBarritas(int filas, int columnas, float espacioH, float espacioV, float escala = 1.0f)
    {
        /* Creamos una rejilla de barritas a partir del punto de origen
		 * 
		 * Ejemplo (2,5):
		 *   A A A A A
		 *   A A O A A
		 */

        // Calculamos el punto de origen de la rejilla
        Vector2 origen = new Vector2(transform.position.x - (columnas / 2.0f) * espacioH + (espacioH / 2), transform.position.y);

        // Instanciamos el array de referencias
        barritas = new Rigidbody2D[filas, columnas];

        // Fabricamos una barrita en cada posición del array
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {

                // Posición de cada barrita
                Vector2 posicion = new Vector2(origen.x + (espacioH * j), origen.y + (espacioV * i));

                // Instanciamos el objeto partiendo del prefab
                Rigidbody2D barrita = (Rigidbody2D)Instantiate(prefabBarritaRoja, posicion, transform.rotation);

                // Guardamos la barrita en el array
                barritas[i, j] = barrita;

                // Escala opcional, por defecto 1.0f (sin escala)
                // Nota: El prefab original ya está escalado a 0.2f
                barrita.transform.localScale = new Vector2(1f * escala, 1f * escala);
            }
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breathe : MonoBehaviour
{
    public AudioSource Respiracion; // Referencia al AudioSource
    private bool puedeReproducir = true; // Controla si se puede reproducir el sonido

    void Update()
    {
        // Si puedeReproducir es true, reproduce el sonido y desactiva la posibilidad de reproducirlo de nuevo
        if (puedeReproducir)
        {
            Respiracion.Play(); // Reproduce el sonido
            puedeReproducir = false; // Desactiva la reproducción del sonido
            StartCoroutine(ReiniciarRespiracion()); // Inicia la corutina para el intervalo de 30 segundos
        }
    }

    // Corutina que espera 30 segundos antes de permitir que el sonido se reproduzca de nuevo
    private IEnumerator ReiniciarRespiracion()
    {
        yield return new WaitForSeconds(30); // Espera 30 segundos
        puedeReproducir = true; // Permite que el sonido se reproduzca nuevamente
    }
}

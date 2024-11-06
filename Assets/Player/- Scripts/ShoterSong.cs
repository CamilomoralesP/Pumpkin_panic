using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoterSong : MonoBehaviour
{
    public AudioSource Sonido; // Referencia al AudioSource
    private int contadorSonido = 0; // Contador de reproducciones
    private bool puedeReproducir = true; // Controla si se puede reproducir el sonido
   
    

    void Update()
    {
        // Reproduce el sonido solo si puedeReproducir es true y el botón "Fire1" se ha presionado
        if (Input.GetButtonDown("Fire1") && puedeReproducir)
        {
            Sonido.Play(); // Reproduce el sonido
            contadorSonido++; // Incrementa el contador de sonidos

            // Si el contador llega a 15, se desactiva la reproducción y se inicia la corutina de reinicio
            if (contadorSonido >= 16)
            {
               
                puedeReproducir = false; // Desactiva la capacidad de reproducir sonido
                StartCoroutine(ReiniciarSonido()); // Inicia la corutina de reinicio
             
            }
        }
    }

    // Corutina que espera 6 segundos antes de reiniciar el contador y activar el sonido
    private IEnumerator ReiniciarSonido()
    {
        yield return new WaitForSeconds(8); // Espera 6 segundos
        contadorSonido = 0; // Reinicia el contador de sonidos
        puedeReproducir = true; // Permite reproducir el sonido de nuevo
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    public int saludMaxima = 5; // Número máximo de velas
    private int saludActual;
    public Image[] velas; // Imágenes de las velas en la UI

    void Start()
    {
        saludActual = saludMaxima; // Inicializa la salud a la máxima
        ActualizarSalud();
    }

    public void RecivirDaño()
    {
        if (saludActual > 0)
        {
            saludActual--;
            ActualizarSalud();

            // Si solo queda una vela, recargar todas las velas
            if (saludActual == 1)
            {
                RechargeHealth();
            }
        }
    }

    private void ActualizarSalud()
    {
        // Actualiza la visibilidad de las velas
        for (int i = 0; i < saludMaxima; i++)
        {
            velas[i].enabled = i < saludActual;
        }
    }

    private void RechargeHealth()
    {
        saludActual = saludMaxima; // Restaura la salud al máximo
        ActualizarSalud(); // Actualiza la visualización de las velas
    }

    // Método que puedes llamar cuando el enemigo ataque
    // public void EnemyAttack()
    // {
    //     RecibirDaño(); // Suponiendo que el enemigo hace 1 punto de daño
    // }

    
}

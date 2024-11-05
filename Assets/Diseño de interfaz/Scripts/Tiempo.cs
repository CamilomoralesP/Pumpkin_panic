using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tiempo : MonoBehaviour
{
    public TextMeshProUGUI textoTimer;
    
    public Button botonReinicio;
    //public TextMeshProUGUI gameOverText;
    public Image fondoGameOver;
    private float tiempoRestante;
    //public Button restartButton;
    public bool juegoEstaActivo;
    //private float tiempoRestante;


    // Start is called before the first frame update
    void Start()
    {
        tiempoRestante = 60;
        //gameOverText.gameObject.SetActive(false);
        fondoGameOver.gameObject.SetActive(false);
    }


     // Update is called once per frame
    private void Update()
    {
        tiempoRestante -= Time.deltaTime;
        textoTimer.SetText("Timer: " + Mathf.Round(tiempoRestante));
        if (tiempoRestante <0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        fondoGameOver.gameObject.SetActive(true);
        //gameOverText.gameObject.SetActive(true);
        textoTimer.SetText("Game Over");
        Time.timeScale = 0; // Pausamos el juego
        
        botonReinicio.gameObject.SetActive(true);
        juegoEstaActivo = false;
    }


   
    public void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

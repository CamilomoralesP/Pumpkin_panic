using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambiarEscena : MonoBehaviour
{
    public void PasarOtraPantalla(string InterfaceMilena)
    {
        SceneManager.LoadScene("InterfaceMilena");
    }
    
}

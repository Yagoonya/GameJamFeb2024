using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

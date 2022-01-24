using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsMenu : MonoBehaviour
{
    public void StartGames()
    {
        SceneManager.LoadScene("GameScene");
    }
}

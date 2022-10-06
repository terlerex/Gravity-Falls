using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public GameObject _OptionsMenu;
    public GameObject MainMenu;
    public AudioSource OnClick;

    public static MenuButton instance;
    
    //Singleton
    private void Awake() {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
    
    
    public void Start()
    
    {
        _OptionsMenu.SetActive(false);
    }

    public void ActiveOptionsMenu()
    { 
        OnClick.Play();
       _OptionsMenu.SetActive(true); 
       MainMenu.SetActive(false);
    }

    public void BackFromOptionsToMenu()
    {
        OptionsMenu.instance.SaveSystem();
        OnClick.Play();
        _OptionsMenu.SetActive(false); 
        MainMenu.SetActive(true);
    }
    
    public void StartGames()
    {
        OnClick.Play();
        StartCoroutine(FakeLoading());
    }

    IEnumerator FakeLoading()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGames()
    {
        Application.Quit();
    }
}

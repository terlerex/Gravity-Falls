using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject PausesMenu;
    public GameObject OptionMenu;
    public bool PauseMenuIsActive;
    public AudioSource OnClick;
    public static PauseMenu instance;
    
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;  
        }
    }

    private void Start()
    {
        OptionMenu.SetActive(false);
        PauseMenuIsActive = false;
        PausesMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !PauseMenuIsActive)
        {
            _PauseMenu();
        }
    }

    void _PauseMenu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        PauseMenuIsActive = true;
        PausesMenu.SetActive(true);
    }
    
    public void ExitPauseMenu()
    {
        OnClick.Play();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PauseMenuIsActive = false;
        Time.timeScale = 1;
        PausesMenu.SetActive(false);
    }

    public void ExitGames()
    {
        OnClick.Play();
        Application.Quit();
    }

    public void OptionMenuActive()
    {
        OnClick.Play();
        
        OptionsMenu.instance.selectedVolumeView = PlayerPrefs.GetInt("currentSound");
        OptionsMenu.instance.selectedResolutions = PlayerPrefs.GetInt("currentResolution");
        
        PausesMenu.SetActive(false);
        OptionMenu.SetActive(true);
    }

    public void ExitOptionMenu()
    {
        OnClick.Play();
        PausesMenu.SetActive(true);
        OptionMenu.SetActive(false);
    }
}

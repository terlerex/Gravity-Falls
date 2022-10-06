using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerAndScore : MonoBehaviour
{
    [Header("Timer")] 
    private float currentTime;
    public Text FinalTimerText;
    private bool timerActive;
    public GameObject FinalButtons;
    private GameObject target;
    private Camera _camera;
    public AudioSource FinalButtonsClic;

    private void Start()
    {
        FinalButtons.SetActive(false);
        FinalTimerText.enabled = false;
        currentTime = 0;
        StartTimer();
        _camera = Camera.main;
    }
    
    

    private void Update()
    {
        if(timerActive)
            currentTime = currentTime += Time.deltaTime;

        currentTime = Mathf.Clamp(currentTime, 0f, Mathf.Infinity);
        FinalTimerText.text = string.Format(" Vous avez terminé ce niveaux en " + Environment.NewLine + "{0:00.00}" + " Secondes", currentTime);    
        

        if (Input.GetKeyDown(KeyCode.P))
        {
            StopTimer();
        }
        
        if(Input.GetKeyDown(KeyCode.E))
            Interact();

    }
    

    void StartTimer()
    {
        timerActive = true;
    }
    
    void StopTimer()
    {
        FinalButtonsClic.Play();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        FinalButtons.SetActive(true);
        FinalTimerText.enabled = true;
        timerActive = false;
    }
    
    private void Interact()
    {
        RaycastHit hit;
        if (target == null)
        {
            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, 20))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                if(hit.transform.CompareTag("Button"))
                {
                    if(hit.transform.name == "FinalButton")
                    {
                        StopTimer();
                    }
                    
                }
            }
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
        StartTimer();
    }
    
    public void NextLevel()
    {
        SceneManager.LoadScene("GameScene2");
        Time.timeScale = 1;
        StartTimer();
    }
    
}

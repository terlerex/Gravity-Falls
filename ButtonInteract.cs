using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteract : MonoBehaviour
{
    [Header("Button to active teleport")] 
    private bool isPressed;
    [SerializeField] private Text pressedText;
    [SerializeField] private GameObject teleporter;
    [SerializeField] private GameObject teleporter1;
    private GameObject target;
    private Camera _camera;
    public AudioSource ButtonPress;

    private void Start()
    {
        teleporter.SetActive(false);
        teleporter1.SetActive(false);
        pressedText.enabled = false;
        _camera = Camera.main;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
            Interact();
    }


    private void Interact()
    {
        RaycastHit hit;
        if (target == null)
        {
            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, 20))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, 
                    Color.yellow);
                if(hit.transform.CompareTag("Button") && !isPressed)
                {
                    if(hit.transform.name == "FirstButton")
                    {
                        ButtonPress.Play();
                        teleporter.SetActive(true);
                        teleporter1.SetActive(true);
                        StartCoroutine(ButtonPressed());
                    }
                    
                }
            }
        }
    }

    
    IEnumerator ButtonPressed()
    {
        isPressed = true;
        pressedText.enabled = true;
        yield return new WaitForSeconds(3);
        pressedText.enabled = false;
    }
    
}

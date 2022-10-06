using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform firstTeleporter;
    [SerializeField] private Transform secondTeleporter;
    public KeyCode _teleporterKeyCode = KeyCode.F;
    private bool isTeleport;
    [SerializeField] private GameObject Player;
    public static bool isInTheTeleport;
    public AudioSource TeleportSound;
    
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            isInTheTeleport = true;

            if(gameObject.name == "Teleporter" && !isTeleport && Input.GetKey(_teleporterKeyCode))
            {
                isTeleport = true;
                StartCoroutine(CIsTeleport());
            }
            
            if(gameObject.name == "Teleporter1" && !isTeleport && Input.GetKey(_teleporterKeyCode))
            {
                isTeleport = true;
                StartCoroutine(CIsTeleport1());
            }
        }
    }

    IEnumerator CIsTeleport()
    {
        TeleportSound.Play();
        yield return new WaitForSeconds(1.8f);
        Player.transform.position = secondTeleporter.transform.position;
        isTeleport = false;
    }
    
    IEnumerator CIsTeleport1()
    {
        TeleportSound.Play();
        yield return new WaitForSeconds(1.8f);
        Player.transform.position = firstTeleporter.transform.position;
        isTeleport = false;
    }
    
    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            isInTheTeleport = false;
        }
    }
}

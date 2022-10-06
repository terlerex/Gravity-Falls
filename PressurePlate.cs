using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    
    [Header("Main")]
    private bool _isPressed;
    
    
    [Header("Green Cube")]
    [SerializeField] private GameObject greenCube;
    [SerializeField] private Transform greenCubeSpawnPoint;
    public static bool _isSpawning;
    public static bool _firstCubePose;
    public static bool _secondeCubePose;
    public static bool _AllGreenCubePose;

    [Header("Action")] 
    [SerializeField] private GameObject _YellowDoor;
    [SerializeField] private GameObject _FinalGlass;

    
    public static bool _YellowCubePose;
    public static bool _GreenCubePose;
    public static bool _BlueCubePose;
    public static bool _AllCubePose;
    
    [Header("Blue Cube")]
    [SerializeField] private GameObject glass;


    private void Start()
    {
        _AllGreenCubePose = false;
        _firstCubePose = false;
        _secondeCubePose = false;
        _isSpawning = false;
        glass.SetActive(true);
        _FinalGlass.SetActive(true);

    }


    private void Update()
    {
        //Green cube and second green cube are online ? 
        if (_firstCubePose && _secondeCubePose)
        {
            Debug.Log("Les deux cubes sont poser");
            _AllGreenCubePose = true;
        }
        else
        {
            _AllGreenCubePose = false;
        }
        
        if (_YellowCubePose && _GreenCubePose && _BlueCubePose)
        {
            Debug.Log("tout les cubes sont poser");
            _AllCubePose = true;
        }
        else
        {
            _AllCubePose = false;
        }
        
        if (_AllCubePose)
            _FinalGlass.SetActive(false);
        

        //Si tout les cubes vert sont poser
        if (_AllGreenCubePose)
            _YellowDoor.SetActive(false);
        else
            _YellowDoor.SetActive(true);
    }

    private void OnTriggerStay(Collider col)
    {
        
        //Check if Yellow cube is online
        if (col.name == "YellowCube")
        {
            if (gameObject.name == "YellowPlate")
            {
                Debug.Log("YellowCube à était poser");
                _YellowCubePose = true;
            }
            else
                _YellowCubePose = false;
        }
        //Green cube
        if (col.name == "GreenCube")
        {
            if (gameObject.name == "GreenPlate")
            {
                Debug.Log("GreenCube à était poser");
                _GreenCubePose = true;
            }
            else
                _GreenCubePose = false;
        }
        //Blue cube
        if (col.name == "BlueCube")
        {
            if (gameObject.name == "BluePlate")
            {
                Debug.Log("BlueCube à était poser");
                _BlueCubePose = true;
            }
            else
                _BlueCubePose = false;
        }
        
       
        if (col.name == "GreenCube")
        {
                if (gameObject.name == "GreenPlateToOpen" || gameObject.name == "GreenPlateToOpen2")
                {
                    Debug.Log("GreenCube à était poser");
                    _firstCubePose = true;
                }
        }
        
        if (col.name == "GreenCubeSecond(Clone)")
        {
            if (gameObject.name == "GreenPlateToOpen" || gameObject.name == "GreenPlateToOpen2")
            {
                Debug.Log("GreenCubeSecond(Clone) à était poser");
                _secondeCubePose = true;
            }
        }
        
        //Faire apparaitre le deuxième cube vert
            if (col.name == "GreenCube" && !_isSpawning)
            {
                if(gameObject.name == "GreenPlateToOpen")
                Instantiate(greenCube, greenCubeSpawnPoint.position, Quaternion.identity);
                _isSpawning = true;
            }
            
            //Déverouiller le cube vert
            else if(col.name == "BlueCube")
            {
                if(gameObject.name == "PressurePlateBlueToGreen")
                glass.SetActive(false);
                _isPressed = true;
            }
    }

    private void OnTriggerExit(Collider col)
    {
        
        if (col.name == "GreenCube")
        {
            if (gameObject.name == "GreenPlateToOpen" || gameObject.name == "GreenPlateToOpen2")
            {
                _firstCubePose = false;
            }
        }
        if (col.name == "GreenCubeSecond(Clone)")
        {
            if (gameObject.name == "GreenPlateToOpen" || gameObject.name == "GreenPlateToOpen2")
            {
                _secondeCubePose = false;
            }
        }
        
            
            //Regarder si ont enleve le cube bleu
            if(col.name == "BlueCube")
            {
                if(gameObject.name == "PressurePlateBlueToGreen")
                {
                    glass.SetActive(true);
                    _isPressed = false;
                }
            }
    }
}

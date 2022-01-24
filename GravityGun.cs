using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    public Transform floatPoint;
    [SerializeField ]private float launchSpeed;
    [SerializeField] private float weaponRange = 12f;
    private GameObject target;
    private Rigidbody _rigidbody;
    private Camera _camera;
    private bool isAttracting;
    private bool isLaunching;
    private bool _rigidbodyFreezeRotation;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            isAttracting = true;
        else if(Input.GetButtonUp("Fire1"))
            isAttracting = false;

        if (isAttracting)
        {
            if (Input.GetButtonDown("Fire2"))
                _rigidbodyFreezeRotation = true;
        }
        
    }

    private void FixedUpdate()
    {
        if(isAttracting)
            Attract();
        else if(!isAttracting)
            Release();

        if (isLaunching)
            Throw();

    }


    private void Attract()
    {
        RaycastHit hit;
        if (target == null)
        {
            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, weaponRange))
            {
                if(hit.transform.CompareTag("CanGrab"))
                {
                    target = hit.transform.gameObject;
                    _rigidbody = target.GetComponent<Rigidbody>();
                    target.transform.position = Vector3.MoveTowards(target.transform.position, floatPoint.position, 0.3f);
                    _rigidbody.useGravity = false;
                }
            }
        }
        else
        {
            target.transform.position = Vector3.MoveTowards(target.transform.position, floatPoint.position, 0.3f);
        }
    }

    private void Release()
    {
        if (target != null)
        {
            _rigidbody.useGravity = true;
            target = null;
        }
    }

    private void Throw()
    {
        if (_rigidbody != null)
        {
            _rigidbody.useGravity = true;
            _rigidbody.AddForce(floatPoint.transform.forward * launchSpeed, ForceMode.Impulse);
            target = null;
            isLaunching = false;
        }
    }

}

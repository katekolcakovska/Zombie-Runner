using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    
    [SerializeField] CinemachineVirtualCamera fpsCamera;
    [SerializeField] float zoomedOutFieldOfView = 40f;
    [SerializeField] float zoomedInFieldOfView = 20f;
    [SerializeField] float zoomedOutMouseSensitivity = 2f;
    [SerializeField] float zoomedInMouseSensitivity = .5f;
    

    FirstPersonController firstPersonController;

    bool zoomedInToggle = false;

    void OnDisable()
    {
        ZoomOut();
    }
    void Start()
    {
        firstPersonController = GetComponentInParent<FirstPersonController>();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(zoomedInToggle == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    void ZoomIn()
    {
        zoomedInToggle = true;
        fpsCamera.m_Lens.FieldOfView = zoomedInFieldOfView;
        firstPersonController.RotationSpeed = zoomedInMouseSensitivity;
    }

    void ZoomOut()
    {
        zoomedInToggle = false;
        fpsCamera.m_Lens.FieldOfView = zoomedOutFieldOfView;
        firstPersonController.RotationSpeed = zoomedOutMouseSensitivity;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomOut = 60f;
    [SerializeField] float zoomIn = 20f;
    [SerializeField] float lowMouseSensativity = .5f;
    [SerializeField] float hightMouseSensativity = 2f;

    RigidbodyFirstPersonController fpsController;
    // Start is called before the first frame update
    void Start()
    {
        fpsController = FindObjectOfType<RigidbodyFirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            fpsCamera.fieldOfView = zoomIn;
            fpsController.mouseLook.XSensitivity = lowMouseSensativity;
            fpsController.mouseLook.YSensitivity = lowMouseSensativity;
        }
        if (Input.GetMouseButtonUp(1))
        {
            fpsCamera.fieldOfView = zoomOut;
            fpsController.mouseLook.XSensitivity = hightMouseSensativity;
            fpsController.mouseLook.YSensitivity = hightMouseSensativity;
        }
    }
}

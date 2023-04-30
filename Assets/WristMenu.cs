using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using System.Threading.Tasks;



public class WristMenu : MonoBehaviour
{
    public GameObject wristUI;
    public bool activeWristUI = true;
    public GameObject objectToSpawn;
    public GameObject previewObject;

    void Start()
    {
        DisplayWristUI();
    }

    public void MenuPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
            DisplayWristUI();
    }

    public void DisplayWristUI()
    {
        if (activeWristUI)
        {
            wristUI.SetActive(false);
            activeWristUI = false;
        }
        else if (!activeWristUI)
        {
            wristUI.SetActive(true);
            activeWristUI = true;
        }
    }

public void SpawnObject()
{
    // Get a reference to the VR controller's transform
    Transform controllerTransform = GetComponent<Transform>();

    // Set up a raycast to detect the ground below the controller
    RaycastHit hit;
    if (Physics.Raycast(controllerTransform.position, Vector3.down, out hit))
    {
        // Spawn the object at the position of the surface below the controller
        Instantiate(objectToSpawn, hit.point, Quaternion.identity);
    }
}
}   
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SpawnObjectOnKeyPress : MonoBehaviour
{
    public GameObject objectToSpawn;
    public XRController controller;
    public InputHelpers.Button buttonToPress;

    private bool isPressed = false;

    private void Update()
    {
        if (controller.inputDevice.IsPressed(buttonToPress, out bool isPressedNow) && !isPressed && isPressedNow)
        {
            SpawnObject();
        }

        isPressed = isPressedNow;
    }

    private void SpawnObject()
    {
        GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, transform.rotation);
        spawnedObject.SetActive(true);
    }
}
using UnityEngine;

public class LampToggle : MonoBehaviour
{
    // Reference to the child GameObject named "Lamp"
    private GameObject lampChild;

    // Variable to track the lamp's state
    private bool isLampOn = false;

    void Start()
    {
        // Find the child GameObject named "Lamp"
        lampChild = transform.Find("Lamp").gameObject;

        // Initialize the lamp's state
        UpdateLampState();
    }

    void Update()
    {
        // Check if the "Q" key is pressed
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Toggle the lamp's state
            isLampOn = !isLampOn;

            // Update the Lamp GameObject's state
            UpdateLampState();
        }
    }

    // Method to update the Lamp's active state
    private void UpdateLampState()
    {
        if (lampChild != null)
        {
            // Set the Lamp GameObject's active state based on isLampOn
            lampChild.SetActive(isLampOn);

            // Log the current state of the lamp
            Debug.Log("Lamp state: " + (isLampOn ? "On" : "Off"));
        }
        else
        {
            // Log if the child Lamp GameObject is not found
            Debug.LogWarning("Lamp child GameObject not found!");
        }
    }
}

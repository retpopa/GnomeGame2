using UnityEngine;

public class RainEffectToggle : MonoBehaviour
{
    // Reference to the child GameObject named "rain"
    private GameObject rainChild;

    // Variable to track the rain effect's state
    private bool isRainActive = false;

    void Start()
    {
        // Find the child GameObject named "rain"
        rainChild = transform.Find("rain").gameObject;

        // Initialize the rain's state
        UpdateRainState();
    }

    void Update()
    {
        // Check if the "R" key is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Toggle the rain's state
            isRainActive = !isRainActive;

            // Update the rain GameObject's state
            UpdateRainState();
        }
    }

    // Method to update the rain's active state
    private void UpdateRainState()
    {
        if (rainChild != null)
        {
            // Set the rain GameObject's active state based on isRainActive
            rainChild.SetActive(isRainActive);

            // Log the current state of the rain effect
            Debug.Log("Rain state: " + (isRainActive ? "On" : "Off"));
        }
        else
        {
            // Log if the child rain GameObject is not found
            Debug.LogWarning("Rain child GameObject not found!");
        }
    }
}

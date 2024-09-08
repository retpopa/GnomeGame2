using UnityEngine.UI;
using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{

    private Image imageComponent;
    public TextMeshProUGUI textComponent; // Reference to the TextMeshProUGUI component
    public string[] lines;                // Array of lines to display
    public float textSpeed;               // Speed at which text appears
    private int index;                    // Current line index

    // Start is called before the first frame update
    public void Start()
    {
        imageComponent = GetComponent<Image>();
        imageComponent.enabled = false;
        textComponent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            if (textComponent.text == lines[index])
            {
                NextLine(); // Correct method call with parentheses
            }
            else
            {
                StopAllCoroutines();           // Correct method call with parentheses
                textComponent.text = lines[index]; // Display the full line instantly
            }
        }
    }

    // Starts the dialogue sequence
    void StartDialogue()
    {
        index = 0;                // Reset index
        StartCoroutine(TypeLine()); // Start typing the first line
    }

    // Coroutine to display text one character at a time
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;                // Append character to the text component
            yield return new WaitForSeconds(textSpeed); // Wait for the defined speed before adding the next character
        }
    }
    // Called from outside when a new dialogue is started
    public void CreateDialogue(string[] strings)
    {
        imageComponent.enabled = true;
        textComponent.enabled = true;
        lines = strings;
        textComponent.text = string.Empty; // Initialize text as empty
        StartDialogue();                   // Begin the dialogue sequence
    }

    // Proceeds to the next line in the dialogue
    void NextLine()
    {
        if (index < lines.Length - 1) // Corrected length access
        {
            index++;                  // Move to the next line
            textComponent.text = string.Empty; // Clear the text component
            StartCoroutine(TypeLine());        // Correct coroutine start with parentheses
        }
        else
        {
            imageComponent.enabled = false; // Corrected SetActive method call
            textComponent.enabled = false;
        }
    }
}

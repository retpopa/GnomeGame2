using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    private DialogueUnique dialogueUnique;
    private Dialogue dialogue;
    private Animator animator;
    private void Awake()
    {
      //Transform child = transform.GetChild(0);
      //Animator animatorChild = child.GetComponent<Animator>();
    }

    public void Interact()
    {
      Transform child = transform.GetChild(0);
      Animator animatorChild = child.GetComponent<Animator>();
        // Attempt to get the DialogueUnique component

        dialogueUnique = GetComponent<DialogueUnique>();
        if (dialogueUnique == null)
        {
            Debug.LogError("DialogueUnique component not found on the NPC!");
            return;
        }

        // Attempt to find the DialogueBox GameObject
        GameObject dialogueBox = GameObject.Find("DialogueBox");
        if (dialogueBox == null)
        {
            Debug.LogError("DialogueBox GameObject not found in the scene!");
            return;
        }

        // Attempt to get the Dialogue component from DialogueBox
        dialogue = dialogueBox.GetComponent<Dialogue>();
        if (dialogue == null)
        {
            Debug.LogError("Dialogue component not found on DialogueBox!");
            return;
        }

        // Retrieve the NPC dialogue lines and trigger the dialogue
        string[] npcLines = dialogueUnique.lineNPC;
        Debug.Log("NPC dialogue: " + string.Join(", ", npcLines)); // Logs all dialogue lines
        if (animatorChild!=null) animatorChild.SetTrigger("Talk");
        dialogue.CreateDialogue(npcLines);
        if (animatorChild!=null) animatorChild.SetTrigger("Idle");
    }
}
//DialogueBox
//DialogueBox

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
  public void Update() {
  if(Input.GetKeyDown(KeyCode.E)){
    Debug.Log("E");
      float interactRange = 4f;
      Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
      foreach (Collider collider in colliderArray){
        Debug.Log("Object");
        if (collider.TryGetComponent(out NPCInteractable npcInteractable)){
          Debug.Log("NPC");
          npcInteractable.Interact();
        }
      }
    }
  }
}

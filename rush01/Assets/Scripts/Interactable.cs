using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 1f;
    bool isFocus = false;
    bool hasInteracted = false;
    Transform player;
    public Transform interactionTransform;

    public virtual void Interact()
    {
        // This method is meant to be overwritten
        Debug.Log("INTERACT WITH " + transform.name);
    }

    void Start()
    {

    }

    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            // float distance = Vector3.Distance(player.position, transform.position);
            float distance = Vector3.Distance(player.position, interactionTransform.position); // interaction point from the object
            if (distance <= radius)
            {
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
        Interact();
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }


    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
        {
            // for ItemPickup
            interactionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
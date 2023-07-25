using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    float st = 0;
    internal float interval = 3;
    internal bool canInteract = true;
    internal string interactionTag = "Player";

    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (!canInteract) return;
        if (other.tag == interactionTag)
        {
            StartInteractWithPlayer(other.GetComponent<PlayerTrigger>());
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (!canInteract) return;
        if (other.tag == interactionTag)
        {
            ExitInteractWithPlayer(other.GetComponent<PlayerTrigger>());
        }
    }
    
    // !!!!!!!!!!!!!!
    //Kaldigi sure boyunca burasi da aktif oluyor
    void OnTriggerStay2D(Collider2D other)
    {
        /*if (!canInteract) return;
        if (other.tag == interactionTag)
        {
            InteractWithPlayer(other.GetComponent<Player>());
        }*/
    }
    
    void StartInteractWithPlayer(PlayerTrigger player)
    {
        DoAction(player);
    }

    void ExitInteractWithPlayer(PlayerTrigger player)
    {
        //InteractionExit(player);
    }

    void InteractWithPlayer(PlayerTrigger player)
    {
        st += Time.deltaTime;
        if (st > interval)
        {
            ResetProgress();
            DoAction(player);
        }
    }
    //virtuallarin hepsini implemente ediyor
    internal virtual void ResetProgress()
    {
        st = 0;
    }
    internal virtual void InteractionExit(PlayerTrigger player)
    {
        throw new System.NotImplementedException();
    }
    internal virtual void DoAction(PlayerTrigger player)
    {
        throw new System.NotImplementedException();
    }
    internal void StopInteract()
    {
        canInteract = false;
    }
    internal void StartInteract()
    {
        canInteract = true;
    }
}

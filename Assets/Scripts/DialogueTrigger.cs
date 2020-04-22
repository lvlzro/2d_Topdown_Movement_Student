using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    [SerializeField] bool interactReady;
    [SerializeField] bool isTalking;
    [SerializeField] GameObject interactPopUp;
    private void Start()
    {
        interactPopUp.SetActive(false);
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }   
    public void continueDialogue()
    {
        FindObjectOfType<DialogueManager>().displayNextSentence();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactPopUp.SetActive(true);
        interactReady = true;
        Debug.Log("entered");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        interactPopUp.SetActive(false);
        interactReady = false;
        isTalking = false;
    }
    private void Update()
    {
        if (interactReady && Input.GetKeyDown(KeyCode.Space) || interactReady && Input.GetKeyDown(KeyCode.Return))
        {
            if (!isTalking) { 
            TriggerDialogue();
            interactPopUp.SetActive(false);
                isTalking = true;
            }
            else
            {
            continueDialogue();
            }
        }
    }
}

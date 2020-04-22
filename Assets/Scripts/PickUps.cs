using UnityEngine;

public class PickUps : MonoBehaviour
{
    bool itemReady;
    public Dialogue dialogue;
    [SerializeField] bool interactReady;
    [SerializeField] bool isTalking;
    [SerializeField] GameObject interactPopUp;
    private void Start()
    {
        interactPopUp.SetActive(false);
        itemReady = true;
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
        if ( itemReady && interactReady && Input.GetKeyDown(KeyCode.Space) || itemReady && interactReady && Input.GetKeyDown(KeyCode.Return))
        {
            if (!isTalking)
            {
                TriggerDialogue();
                interactPopUp.SetActive(false);
                isTalking = true;
                itemReady = false;
                gameObject.SetActive(false);
                itemManager.miscCount += 1;

            }
            else
            {
                continueDialogue();
            }
        }
    }
}

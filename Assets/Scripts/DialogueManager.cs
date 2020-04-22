using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private PlayerMovement playerMoving;
    private GameObject player;

    public GameObject dialogueUI;
    public Text dialogueBox;
    private void Start()
    {
        sentences = new Queue<string>();
        dialogueUI.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        playerMoving = player.GetComponent<PlayerMovement>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting Conversation");
        sentences.Clear();
        dialogueUI.SetActive(true);
        playerMoving.enabled = false;
        foreach (string sentence in dialogue.senctences)
        {
            sentences.Enqueue(sentence);
        }
        displayNextSentence();
    }
    public void displayNextSentence()
    {
        if (sentences.Count == 0)
        {
            endDigalogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(typeSentence(sentence));
    }
    private IEnumerator typeSentence(string sentence)
    {
        dialogueBox.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueBox.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void endDigalogue()
    {
        dialogueUI.SetActive(false);
        playerMoving.enabled = true;
        Debug.Log("end of digalogue");
    }
}

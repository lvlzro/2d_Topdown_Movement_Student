using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Text dialogBox;
    public GameObject dialogPanel;
    public GameObject interactPopUp;
    public string[] lines;



    private float typingSpeed = 0.05f;
    private int index;
    private bool isTalking;

    private PlayerMovement playerMoving;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMoving = player.GetComponent<PlayerMovement>();
    }
    private IEnumerator type()
    {
        foreach (char letter in lines[index].ToCharArray())
        {
            dialogBox.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
      
    private void NextLine()
    {
        if (dialogBox.text != lines[index])
        {
            dialogBox.text = lines[index];
            StopAllCoroutines();
        }
        else if (index < lines.Length - 1)
        {
            index++;
            dialogBox.text = "";
            StopAllCoroutines();
        }
        else if (index == lines.Length - 1)
        {
            dialogBox.text = "";
            interactPopUp.SetActive(false);
            dialogPanel.SetActive(false);
            isTalking = false;
            playerMoving.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("entered");
        interactPopUp.SetActive(true);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isTalking)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.KeypadEnter))
            {
                interactPopUp.SetActive(false);
                dialogPanel.SetActive(true);
                StartCoroutine(type());

                playerMoving.enabled = false;

                isTalking = true;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.KeypadEnter))
            {
                NextLine();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        interactPopUp.SetActive(false);
    }
}

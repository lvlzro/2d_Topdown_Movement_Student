using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Text dialogBox;
    public GameObject dialogPanel;
    public GameObject buttom;
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

    public void NextLine()
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
            //have to restart the coroutine for the new line
            StartCoroutine(type());

        }
        else if (index == lines.Length - 1)
        {
            dialogBox.text = "";
            interactPopUp.SetActive(false);
            dialogPanel.SetActive(false);
            buttom.SetActive(false);
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
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                interactPopUp.SetActive(false);
                dialogPanel.SetActive(true);
                buttom.SetActive(true);
                StartCoroutine(type());
                isTalking = true;
                playerMoving.enabled = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("next line");
                NextLine();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        interactPopUp.SetActive(false);
    }
}

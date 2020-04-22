using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartQuest : MonoBehaviour
{
    public GameObject items;
    bool interactReady;
    void Awake()
    {
        items.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactReady = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        interactReady = false;
    }
    private void Update()
    {
         if (interactReady && Input.GetKeyDown(KeyCode.Space) || interactReady && Input.GetKeyDown(KeyCode.Return))
        {
            items.SetActive(true);
        }   
    }
}

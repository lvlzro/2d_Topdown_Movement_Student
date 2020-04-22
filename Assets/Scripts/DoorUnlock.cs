using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    public GameObject objectState1;
    public GameObject objectState2;


    private void Awake()
    {
        objectState1.SetActive(true);
        objectState2.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (itemManager.keyCount == 1)
        {
            Destroy(objectState1);
            objectState2.SetActive(true);
        }
        
    }
}

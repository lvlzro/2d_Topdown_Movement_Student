using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    bool itemReady;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        itemReady = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        itemReady = true;
    }
    private void Update()
    {
        if (itemReady && Input.GetKeyDown(KeyCode.Space) || itemReady && Input.GetKeyDown(KeyCode.Return))
        {
            if(itemManager.gemCount != 1)
            {
            itemManager.gemCount += 1;
            }
            itemReady = false;
        }
    }

}

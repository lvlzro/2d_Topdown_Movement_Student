using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public GameObject gameOver;


    private void Awake()
    {
        gameOver.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameOver.SetActive(true);
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}

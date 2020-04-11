using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public Camera cam;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = cam.transform.position - player.transform.position;
    }
    private void LateUpdate()
    {
        cam.transform.position = player.transform.position + offset;
    }
}

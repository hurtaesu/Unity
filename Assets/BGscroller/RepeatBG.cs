using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBG : MonoBehaviour
{
    Movement movement;
    Controller controller;
    private float offset;
    public float repeatSpeed;

    private MeshRenderer meshRenderer;
    private Vector2 cam;


    // Start is called before the first frame update
    void Start()
    {
        movement = GameObject.Find("Player").GetComponent<Movement>();
        controller = GameObject.Find("Player").GetComponent<Controller>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        cam = GameObject.Find("Main Camera").transform.position;
        if (controller.x != 0)
        {
            offset += controller.x * repeatSpeed;
            meshRenderer.material.mainTextureOffset = new Vector2(offset, 0);
        }
        transform.position = new Vector3(cam.x, cam.y, 5);
    }
}
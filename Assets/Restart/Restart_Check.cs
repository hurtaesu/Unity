using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart_Check : MonoBehaviour
{
    public bool gameover;
    
    void Start()
    {

    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if(gameover && Input.GetKeyDown(KeyCode.R))
        {
            GameObject.Find("Player").GetComponent<Transform>().position = new Vector3(0, 2, 0);
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gameover = true;
        }    
    }
}

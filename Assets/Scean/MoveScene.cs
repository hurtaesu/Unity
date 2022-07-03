using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("∏  ¿Ãµø");
        SceneManager.LoadScene("Stage 1");
    }

    public void MoveToGame()
    {
        SceneManager.LoadScene("Lobby");
    }
}

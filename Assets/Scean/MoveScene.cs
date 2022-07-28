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
        collision.gameObject.GetComponent<Transform>().position = new Vector3(0, 1, 0);
        Debug.Log("∏  ¿Ãµø");
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            SceneManager.LoadScene(Random.Range(5, 7));
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            SceneManager.LoadScene(Random.Range(6, 7));
        }
        else if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            SceneManager.LoadScene(Random.Range(4, 5));
        }
        else if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            SceneManager.LoadScene(Random.Range(4, 6));
        }
        else
        {
            SceneManager.LoadScene(Random.Range(4, 7));
        }


    }


    public void MoveToGame()
    {
        SceneManager.LoadScene("Creat_Player");
    }
}

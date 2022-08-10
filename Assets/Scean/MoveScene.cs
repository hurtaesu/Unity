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
        //수정예정
        collision.gameObject.GetComponent<Transform>().position = new Vector3(0, 1, 0);
        Debug.Log("맵 이동");
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            SceneManager.LoadScene(Random.Range(5, 8));
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            SceneManager.LoadScene(Random.Range(6, 8));
        }
        else if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            SceneManager.LoadScene(Random.Range(4, 6));
        }
        else if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            SceneManager.LoadScene(Random.Range(4, 7));
        }
        else
        {
            SceneManager.LoadScene(Random.Range(4, 9));
        }
    }


    public void MoveToGame()
    {
        SceneManager.LoadScene("Creat_Player");
    }
}

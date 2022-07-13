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
        SceneManager.LoadScene(Random.Range(3,7));
    }

    public void MoveToGame()
    {
        SceneManager.LoadScene("Creat_Player");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    Animator animator;
    Restart_Check check;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        check = GameObject.Find("Wall").GetComponent<Restart_Check>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    [System.Obsolete]
    public void Restart_(bool gameover)
    {
        if (gameover == true)
        {
            Debug.Log("¶³¾îÁü");
            animator.SetBool("isgameover", true);
        }

        if (gameover && Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("rÅ° ´©¸§");
            GameObject.Find("Player").GetComponent<Transform>().position = new Vector3(0, 2, 0);
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}

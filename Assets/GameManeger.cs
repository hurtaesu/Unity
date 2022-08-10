using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    RepeatBG repeatBG;
    Restart restartCheck;
    Restart_Check check;
    void Start()
    {
       repeatBG = GameObject.Find("Back").GetComponent<RepeatBG>();
       restartCheck = GameObject.Find("GameOver Canvas").GetComponent<Restart>();
       check = GameObject.Find("Wall").GetComponent<Restart_Check>();
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        repeatBG.ScrollBG();
        restartCheck.Restart_(gameover: check.gameover); //나중에 고쳐야함
    }
}

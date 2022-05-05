using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{
    public float speed;
    private Vector3 movedirection;

    public void Setup(Vector3 direction)
    {
        movedirection = direction;
    }
    private void Update()
    {
        if (movedirection == new Vector3(0, 0, 0))
        {
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }
        else
        {
            transform.position += movedirection * speed * Time.deltaTime;
        }
    }
}

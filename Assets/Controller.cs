using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Movement movement;
    [SerializeField]
    private GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement.jump();
        }
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical"); 
        movement.Move(x);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
           GameObject clone = Instantiate(bullet,transform.position,Quaternion.identity);
            clone.GetComponent<bulletMovement>().Setup(new Vector3(x, 0, 0));
        }
    }
}

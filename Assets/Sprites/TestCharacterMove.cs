using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCharacterMove : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    //public InputMaster input;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        //input = new InputMaster();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector2 position = rigidbody2d.position;
        position.x += 3f * horizontal * Time.deltaTime;
        position.y += 3f * vertical * Time.deltaTime;
        
        transform.position = position;
        rigidbody2d.MovePosition(position);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KolobokMove : MonoBehaviour
{
    Rigidbody2D kolobok;
    void Start()
    {
        kolobok = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0)
        {
            var pos = transform.position;
            pos += Vector3.right * horizontal * Time.deltaTime * 75;
            kolobok.MovePosition(pos);
        }

        if (vertical != 0)
        {
            var position = transform.position;
            position += Vector3.up * vertical * Time.deltaTime * 75;
            kolobok.MovePosition(position);
        }
    }
}

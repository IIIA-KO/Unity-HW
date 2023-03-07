using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Vorog : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {
        var Pozition = col.GetComponent<PlayerController>().getRespawnPosition();
        col.transform.position = Pozition.position;
    }
}
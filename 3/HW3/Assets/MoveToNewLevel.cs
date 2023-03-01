using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNewLevel : MonoBehaviour
{
    public int level = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CharacterMovement>() != null)
        {
            SceneManager.LoadScene(level);
        }
    }
}

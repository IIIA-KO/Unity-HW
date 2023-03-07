using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNewLevel : MonoBehaviour
{
    public int level = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>() != null)
        {
            StartCoroutine(LoadDelay());
        }
    }

    private IEnumerator LoadDelay()
    {
        yield return new WaitForSeconds(1.2f);
        TransitionNextLevel();
    }

    private void TransitionNextLevel()
    {
        SceneManager.LoadScene(level);
    }
}

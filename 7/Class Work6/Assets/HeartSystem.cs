using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{

    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite EmptyHeart;


    private void Update()
    {

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < numOfHearts)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = EmptyHeart;
            }


        }
    }

    public void DamagePlayer()
    {
        if (numOfHearts == 0)
        {
            SceneManager.LoadScene(0);
        }
        this.numOfHearts--;
    }
}
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {

        if (otherCollider.GetComponent<PlayerController>() != null)
        {
            otherCollider.gameObject.GetComponent<HeartSystem>().DamagePlayer();
        }

        var transformPosition = otherCollider.GetComponent<PlayerController>().getRespawnPosition();
        otherCollider.transform.position = transformPosition.position;
    }
}
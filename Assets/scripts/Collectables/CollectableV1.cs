using UnityEngine;

public class CollectableV1 : MonoBehaviour
{
    public int scoreValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreV1.instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
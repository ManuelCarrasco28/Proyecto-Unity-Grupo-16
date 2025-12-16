using UnityEngine;

public class pointsystem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddPoint();
            }

            Destroy(other.gameObject);
        }
    }
}

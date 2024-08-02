using UnityEngine;

public class HealthCollectible : MonoBehaviour{
    [SerializeField] private float healthValue;
    [SerializeField] private AudioClip pickUpSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
            SoundManager.instance.PlaySound(pickUpSound);
        }
    }
}
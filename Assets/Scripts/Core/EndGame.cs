using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame: MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Finish();
        }
    }

    private void Finish()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

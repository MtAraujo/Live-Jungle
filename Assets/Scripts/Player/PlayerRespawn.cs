using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpoint;
    private Transform currentCheckpoint;
    private Vector3 initialPosition;
    private Health playerHealth;
    private UIManager uiManager;

    private void Awake(){
        playerHealth = GetComponent<Health>();
        uiManager = FindObjectOfType<UIManager>();
        initialPosition = transform.position;  
        
    }

    public void checkRespawn(){

        if(currentCheckpoint == null){
            uiManager.GameOver();
            return;
        }
        playerHealth.Respawn();

        if (currentCheckpoint != null){
            transform.position = currentCheckpoint.position;
        }
        else{
            transform.position = initialPosition;
        }

        Camera.main.GetComponent<CameraController>().MoveToNewRoom(transform);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Checkpoint")){
            currentCheckpoint = collision.transform;
            SoundManager.instance.PlaySound(checkpoint);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("Active");
        }
    }
}


using UnityEngine;

public class CameraController : MonoBehaviour{
    [SerializeField] private Transform player;
    [SerializeField] private float cameraSpeed;

    [SerializeField] private float aheadDistance;

    private float lookAhead;

    private void Update(){
        if (player != null)
        {
            Vector3 targetPosition = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * cameraSpeed);
            lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
        }
    }

    public void MoveToNewRoom(Transform newTarget){
        player = newTarget;
        Vector3 newPosition = newTarget.position;
        newPosition.z = transform.position.z; 
        transform.position = newPosition;
    }
}


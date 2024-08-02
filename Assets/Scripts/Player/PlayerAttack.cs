using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] shots;
    [SerializeField] private AudioClip shotSound;

    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake(){
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.E) && cooldownTimer > attackCooldown && playerMovement.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack(){
        SoundManager.instance.PlaySound(shotSound);
        anim.SetTrigger("Attack");
        cooldownTimer = 0;

        shots[FindShots()].transform.position = firePoint.position;
        shots[FindShots()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    private int FindShots(){
        for (int i = 0; i < shots.Length; i++)
        {
            if (!shots[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
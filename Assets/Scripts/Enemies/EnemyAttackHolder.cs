using UnityEngine;

public class EnemyAttackHolder : MonoBehaviour{
    [SerializeField] private Transform enemy;

    private void Update()
    {
        transform.localScale = enemy.localScale;
    }
}
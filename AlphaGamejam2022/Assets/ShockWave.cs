using UnityEngine;

public class ShockWave : MonoBehaviour
{
    [SerializeField] private int damage;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}

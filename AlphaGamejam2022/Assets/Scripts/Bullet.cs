using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    public Vector3 direction;


    private void Start()
    {
        Invoke(nameof(DestroyBullet), 3);
    }

    void Update()
    {
        rb.velocity = direction * speed;
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            col.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}

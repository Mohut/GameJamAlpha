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
            col.GetComponent<Enemy>().TakeDamage(damage * GameObject.Find("Player").GetComponent<WeaponController>().damageMuliplicator);
            
            if(GameObject.Find("NextWeaponManager").GetComponent<NextWeaponManager>().nextWeapon == Weapon.Gun)
            {
                GameObject.Find("Player").GetComponent<WeaponController>().IncreaseDamage();
            }
            else
            {
                GameObject.Find("Player").GetComponent<WeaponController>().DecreaseDamage();
            }
            
            GameObject.Find("NextWeaponManager").GetComponent<NextWeaponManager>().NextWeapon();
            DestroyBullet();
        }
    }
}

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
        
        if(GameObject.Find("NextWeaponManager").GetComponent<NextWeaponManager>().nextWeapon == Weapon.ShockWave)
        {
            GameObject.Find("Player").GetComponent<WeaponController>().IncreaseDamage();
        }
        else
        {
            GameObject.Find("Player").GetComponent<WeaponController>().DecreaseDamage();
        }
    }
}

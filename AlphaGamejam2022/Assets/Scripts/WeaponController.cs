using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
public enum Weapon {Gun, ShockWave}
public class WeaponController : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject shockWave;
    private Weapon currentWeapon = Weapon.ShockWave;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ChangeWeapon();
        }
        
        if(Input.GetMouseButtonDown(0))
        {
            switch (currentWeapon)
            {
                case Weapon.Gun:
                    ShootBullet();
                    break;
                case Weapon.ShockWave:
                    ShockWave();
                    break;
            }
        }
    }
    private void ChangeWeapon()
    {
        if (currentWeapon == Weapon.Gun)
            currentWeapon = Weapon.ShockWave;

        if (currentWeapon == Weapon.ShockWave)
            currentWeapon = Weapon.Gun;
    }

    private void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().direction =  (camera.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
    }

    private void ShockWave()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Co_ShockWave());
        }
    }

    System.Collections.IEnumerator Co_ShockWave()
    {
        shockWave.transform.position = transform.position;
        shockWave.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        shockWave.SetActive(false);
    }
}

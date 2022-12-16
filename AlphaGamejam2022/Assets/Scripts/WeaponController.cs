using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum Weapon {Gun, ShockWave}
public class WeaponController : MonoBehaviour
{
    [Header("Player stats")]
    [SerializeField] private float heat = 100;
    [SerializeField] private float headReductionRate;

    [SerializeField] private Slider heatBar;
    [SerializeField] private TextMeshProUGUI weaponText;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject shockWave;
    
    private Camera camera;
    private Weapon currentWeapon = Weapon.ShockWave;
    public bool inFireRange = true;

    private void Start()
    {
        camera = Camera.main;
        SetWeaponText();
    }

    void Update()
    {
        heatBar.value = heat / 100;
        UpdateHeat();
        
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
        {
            currentWeapon = Weapon.ShockWave;
            SetWeaponText();
            return;
        }
        
        if (currentWeapon == Weapon.ShockWave)
        {
            currentWeapon = Weapon.Gun;
            SetWeaponText();
            return;
        }
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

    private void SetWeaponText()
    {
        switch (currentWeapon)
        {
            case Weapon.Gun:
                weaponText.text = "Gun";
                break;
            case Weapon.ShockWave:
                weaponText.text = "ShockWave";
                break;
        }
    }

    private void UpdateHeat()
    {
        if (inFireRange)
            return;

        heat -= headReductionRate * Time.deltaTime;
        heatBar.value = heat / 100;
    }

    System.Collections.IEnumerator Co_ShockWave()
    {
        shockWave.transform.position = transform.position;
        shockWave.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        shockWave.SetActive(false);
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum Weapon {Gun = 0, ShockWave = 1}
public class WeaponController : MonoBehaviour
{
    [Header("Player stats")]
    [SerializeField] private float heat = 100;
    [SerializeField] private float headReductionRate;
    public int damageMuliplicator = 1;

    [SerializeField] private SpriteRenderer image;
    private Color red = Color.red;
    private Color white = Color.white;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Slider heatBar;
    [SerializeField] private TextMeshProUGUI weaponText;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject shockWave;
    
    private Camera camera;
    public Weapon currentWeapon = Weapon.ShockWave;
    public bool inFireRange = true;

    private void Start()
    {
        Time.timeScale = 1;
        camera = Camera.main;
        SetWeaponText();
    }

    void Update()
    {
        heatBar.value = heat / 100;
        UpdateHeat();
        
        if (Input.GetKeyDown(KeyCode.Space))
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
        
        if(Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
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
                weaponText.text = "Current Weapon: Gun";
                break;
            case Weapon.ShockWave:
                weaponText.text = "Current Weapon: ShockWave";
                break;
        }
    }

    private void UpdateHeat()
    {
        if (inFireRange == false)
            heat -= headReductionRate * Time.deltaTime;

        if (inFireRange && heat < 100)
            heat += headReductionRate * Time.deltaTime * 2;
        
        heatBar.value = heat / 100;

        if (heat <= 0)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void IncreaseDamage()
    {
        if (damageMuliplicator < 3)
        {
            damageMuliplicator++;
            image.color = Color.Lerp(white, red, damageMuliplicator/3f);
        }
    }

    public void DecreaseDamage()
    {
        damageMuliplicator = 1;
        image.color = Color.Lerp(white, red, 0);
    }

    public void ReduceHeat(int heatToReduce)
    {
        heat -= heatToReduce;
    }

    System.Collections.IEnumerator Co_ShockWave()
    {
        shockWave.transform.position = transform.position;
        shockWave.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        shockWave.SetActive(false);
    }
}

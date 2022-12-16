using TMPro;
using UnityEngine;

public class NextWeaponManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nextWeaponText;
    [SerializeField] public Weapon nextWeapon = Weapon.Gun;
    void Start()
    {
        NextWeapon();
    }

    [ContextMenu("test")]
    public void NextWeapon()
    {
        nextWeapon = (Weapon)Random.Range(0, 2);

        switch (nextWeapon)
        {
            case Weapon.Gun:
                nextWeaponText.text = "Gun";
                break;
            case Weapon.ShockWave:
                nextWeaponText.text = "Shockwave";
                break;
        }
    }
}

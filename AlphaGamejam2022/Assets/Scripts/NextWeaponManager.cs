using TMPro;
using UnityEngine;

public class NextWeaponManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nextWeaponText;
    [SerializeField] private Weapon nextWeapon = Weapon.Gun;
    void Start()
    {
        NextWeapon();
    }

    [ContextMenu("test")]
    private void NextWeapon()
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

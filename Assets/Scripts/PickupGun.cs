using UnityEngine;

public class PickupGun : MonoBehaviour
{
    [SerializeField] private Pistol currentWeapon;
    [SerializeField] private Pistol weapon1;
    [SerializeField] private Pistol weapon2;
    [SerializeField] private Pistol weapon3;
    [SerializeField] private GameObject gunHolder;
    [SerializeField] private bool fPressed; // for testing
    [SerializeField] private bool gPressed; // for testing
    [SerializeField] private bool hPressed; // for testing
    [SerializeField] private LITGPlayerManager playerManager;



    public void OnWeapon1()
    {
        if (currentWeapon != null) currentWeapon = null;
        fPressed = true;
        ShootIdleAnim();
        currentWeapon = weapon1;
        PlaceWeapon();
        Debug.Log("weapon1 called");
    }

    public void OnWeapon2()
    {
        if (currentWeapon != null) currentWeapon = null;
        gPressed = true;
        ShootIdleAnim();
        currentWeapon = weapon2;
        PlaceWeapon();
        Debug.Log("weapon2 called");
    }

    public void OnWeapon3()
    {
        if (currentWeapon != null) currentWeapon = null;
        hPressed = true;
        ShootIdleAnim();
        currentWeapon = weapon3;
        PlaceWeapon();
        Debug.Log("weapon3 called");
    }

    public void OnFire()
    {
        Debug.Log("Fire called");

        if (currentWeapon != null && currentWeapon.BulletsAmount() > 0)
        {
            currentWeapon.FireBullet();
            playerManager.StartPlayerAnimation(null, "shooting");
        }
    }

    public void OnDropWeapon()
    {
        Debug.Log("Drop weapon called");
        playerManager.StopPlayerAnimation("shootIdle");
        if(currentWeapon != null) currentWeapon.transform.parent = null;
        currentWeapon.SetInitialValues();
        currentWeapon = null;
    }

    public void PlaceWeapon()
    {
        currentWeapon.transform.SetParent(gunHolder.transform);
        currentWeapon.transform.localPosition = gunHolder.transform.localPosition + new Vector3(-0.1f, 0.07f, 0);
        currentWeapon.transform.localRotation = Quaternion.Euler(0, 90, 0);
    }

    private void ShootIdleAnim()
    {
        playerManager.StartPlayerAnimation("shootIdle", null);
    }
}

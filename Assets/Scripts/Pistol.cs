using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField] private PistolData pistolData;
    [SerializeField] private Transform bullet;
    [SerializeField] private int bulletsAmount;
    [SerializeField] private Transform firePos;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private bool isGravityEnabled;
    [SerializeField] private bool isKinematicEnabled;

    private void Start()
    {
        pistolData.initialPos = transform.position;
        pistolData.initialRot = transform.rotation;
        bullet = pistolData.bulletPrefab;
        bulletsAmount = pistolData.bulletsAmount;
        bulletSpeed = pistolData.bulletSpeed;
        isGravityEnabled = pistolData.isGravityEnabled;
        isKinematicEnabled = pistolData.isKinematicEnabled;
    }

    public void SetInitialValues()
    {
        transform.position = pistolData.initialPos;
        transform.rotation = pistolData.initialRot;
    }

    public void FireBullet()
    {
        if (bulletsAmount <= 0) return;

        var newBullet = Instantiate(bullet, firePos.position, Quaternion.identity);
        var bulletRb = newBullet.GetComponent<Rigidbody>();
        bulletRb.useGravity = isGravityEnabled;
        bulletRb.isKinematic = isKinematicEnabled;

        if (isGravityEnabled && !isKinematicEnabled)
        {
            bulletRb.AddForce(firePos.forward * bulletSpeed, ForceMode.Impulse);
        }

        else if (isKinematicEnabled)
        {
            bulletRb.MovePosition(Vector3.forward * bulletSpeed);
        }
        
        bulletsAmount--;
    }

    public int BulletsAmount() => bulletsAmount;
}

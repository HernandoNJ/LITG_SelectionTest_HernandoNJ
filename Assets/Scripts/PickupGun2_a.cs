using UnityEngine;

public class PickupGun2_a : MonoBehaviour
{
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject weapon;
    [SerializeField] private Vector3 weaponInitialPos;
    [SerializeField] private GameObject weaponCube;
    [SerializeField] private GameObject gunHolder;
    [SerializeField] private bool fPressed;
    [SerializeField] private LITGPlayerManager playerManager;

    private void Update()
    {
        RaycastHit hitInfo;
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.transform.CompareTag("Weapon"))
            {
                Debug.Log("weapon found");

                weaponCube = hitInfo.transform.Find("Cube").gameObject;
                if (weaponCube != null) weaponCube.SetActive(true);

                if (fPressed)
                {
                    weapon = hitInfo.transform.gameObject;
                    weaponInitialPos = weapon.transform.position;
                    ShootIdleAnim();
                    weapon.gameObject.transform.parent = gunHolder.transform;
                    weapon.gameObject.transform.localPosition = new Vector3(0, 0.05f, 0);
                    weapon.gameObject.transform.localRotation = Quaternion.Euler(0, 90, 0);
                    weapon.GetComponent<Rigidbody>().isKinematic = false;
                    weapon.GetComponent<Collider>().enabled = false;

                    weaponCube.SetActive(false);
                }
                else
                {
                    weapon.GetComponent<Rigidbody>().isKinematic = true;
                    weapon.GetComponent<Collider>().enabled = true;
                    weapon.transform.position = weaponInitialPos;
                    weapon.transform.parent = null;

                    weapon = null;

                    //weapon.transform.parent = null;
                    //weaponCube.SetActive(false);
                }
            }
        }
    }

    public void OnSelect()
    {
        fPressed = true;
        Debug.Log("on select called");
    }

    public void OnDeselect()
    {
        fPressed = false;
        Debug.Log("on deselect called");
        playerManager.StopPlayerAnimation("shootIdle");
    }

    public void OnFire()
    {
        Debug.Log("Fire called");
        playerManager.StartPlayerAnimation(null, "shooting");
    }

    private void ShootIdleAnim()
    {
        playerManager.StartPlayerAnimation("shootIdle", null);
    }
}

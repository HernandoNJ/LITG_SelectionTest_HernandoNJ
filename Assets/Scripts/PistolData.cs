using UnityEngine;

[CreateAssetMenu(fileName = "PistolData", menuName = "ScriptableObjects/PistolData")]
public class PistolData : ScriptableObject
{
    public Vector3 initialPos;
    public Vector3 bulletPos;
    public Quaternion initialRot;
    public Transform bulletPrefab;
    public float bulletSpeed;
    public int bulletsAmount;
    public bool isGravityEnabled;
    public bool isKinematicEnabled;
}

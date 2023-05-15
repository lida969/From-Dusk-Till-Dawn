using UnityEngine;
using UnityEngine.XR;
using System.Collections;
using System.Collections.Generic;

public class Shooting : MonoBehaviour
{
    

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed;
    public float bulletLifetime = 2f;

    private bool triggerPressed = false;
    private float timer = 0f;
   



    void Update()
    {
        var device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out var triggerValue) && triggerValue && !triggerPressed)
        {
            triggerPressed = true;
            ShootBullet();
        }
        else if (!triggerValue)
        {
            triggerPressed = false;
        }

        var device1 = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);

        if (device1.TryGetFeatureValue(CommonUsages.triggerButton, out var triggerValue1) && triggerValue && !triggerPressed)
        {
            triggerPressed = true;
            ShootBullet();
        }
        else if (!triggerValue1)
        {
            triggerPressed = false;
        }
    }

 

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = bulletSpawn.forward * bulletSpeed;
        Destroy(bullet, bulletLifetime);
    }
}
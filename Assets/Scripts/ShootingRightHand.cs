using UnityEngine.XR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShootingRightHand : MonoBehaviour
{
    public GameObject bullet;
    public float shootForce, upwardForce;
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;

    int bulletsLeft, bulletsShot;
    public Rigidbody playerRb;
    public float recoilForce;
    bool readyToShoot, reloading;
    public Transform attackPoint;
    public GameObject muzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;
    public bool allowInvoke = true;
    private bool triggerPressed = false;
    private bool t;

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();
        if (ammunitionDisplay != null)
            ammunitionDisplay.SetText(bulletsLeft / bulletsPerTap + " / " + magazineSize / bulletsPerTap);
    }
    private void MyInput()
    {
        var device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        if (readyToShoot && !reloading && bulletsLeft <= 0) Reload();

        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out var triggerValue) && triggerValue && !triggerPressed && readyToShoot && !reloading && bulletsLeft > 0)
        {
            triggerPressed = true;
            bulletsShot = 0;

            Shoot();
        }
        else if (!triggerValue)
        {
            triggerPressed = false;
        }

    }

    private void Shoot()
    {

        readyToShoot = false;

        Ray ray = new Ray(attackPoint.position, -attackPoint.forward);
        
        RaycastHit hit;


        //check if ray hits something
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75); 
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        GameObject currentBullet = Instantiate(bullet, attackPoint);  

        if (muzzleFlash != null)
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot++;

        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
            playerRb.AddForce(-directionWithoutSpread.normalized * recoilForce, ForceMode.Impulse);
        }

        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }
    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime); 
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}

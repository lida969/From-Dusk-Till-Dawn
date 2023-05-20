using UnityEngine.XR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShootingLeftHand : MonoBehaviour
{
    //bullet 
    public GameObject bullet;

    //bullet force
    public float shootForce, upwardForce;

    //Gun stats
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;

    int bulletsLeft, bulletsShot;

    //Recoil
    public Rigidbody playerRb;
    public float recoilForce;

    //bools
    bool readyToShoot, reloading;

    //Reference
    //public Camera fpsCam;
    public Transform attackPoint;

    //Graphics
    public GameObject muzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;

    //bug fixing :D
    public bool allowInvoke = true;
    private bool triggerPressed = false;
    private bool t;

    private void Awake()
    {
        //make sure magazine is full
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();

        //Set ammo display, if it exists :D
        if (ammunitionDisplay != null)
            ammunitionDisplay.SetText(bulletsLeft / bulletsPerTap + " / " + magazineSize / bulletsPerTap);
    }
    virtual protected void MyInput()
    {
        var device = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);

        if (readyToShoot && !reloading && bulletsLeft <= 0) Reload();

        //Shooting
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

    virtual protected void Shoot()
    {
        readyToShoot = false;

        //Find the exact hit position using a raycast
        Ray ray = new Ray(attackPoint.position, -attackPoint.forward);
        //Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //Just a ray through the middle of your current view
        RaycastHit hit;

        //check if ray hits something
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75); //Just a point far away from the player

        //Calculate direction from attackPoint to targetPoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //Instantiate bullet/projectile
        GameObject currentBullet = Instantiate(bullet, attackPoint); //store instantiated bullet in currentBullet

        //Add forces to bullet
        //currentBullet.GetComponent<Rigidbody>().AddForce(currentBullet.transform.forward * shootForce, ForceMode.VelocityChange);
        //currentBullet.GetComponent<Rigidbody>().AddForce(attackPoint.up * upwardForce, ForceMode.Impulse);

        //Instantiate muzzle flash, if you have one
        if (muzzleFlash != null)
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot++;

        //Invoke resetShot function (if not already invoked), with your timeBetweenShooting
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;

            //Add recoil to player (should only be called once)
            playerRb.AddForce(-directionWithoutSpread.normalized * recoilForce, ForceMode.Impulse);
        }

        //if more than one bulletsPerTap make sure to repeat shoot function
        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }
    private void ResetShot()
    {
        //Allow shooting and invoking again
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime); //Invoke ReloadFinished function with your reloadTime as delay
    }
    private void ReloadFinished()
    {
        //Fill magazine
        bulletsLeft = magazineSize;
        reloading = false;
    }
}

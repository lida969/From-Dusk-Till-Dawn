using UnityEngine;
using UnityEngine.XR;
using TMPro;
using System.Diagnostics;
using System;

public class GunSystem : MonoBehaviour
{
    //Gun stats
    public int damage;
    public float timeBetweenShooting, range, timeBetweenShots;
    public int bulletsPerTap;
    int bulletsLeft, bulletsShot;

    //bools 
    //bool shooting, readyToShoot;
    bool triggerPressed=false;

    //Reference
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    //Graphics
    public GameObject muzzleFlash, bulletHoleGraphic;
    public TextMeshProUGUI text;

    private void Awake()
    {
        
        //readyToShoot = true;
    }
    private void Update()
    {
        MyInput();

        
       
    }
    private void MyInput()
    {
        var device = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out var triggerValue) && triggerValue && !triggerPressed)
        {
            triggerPressed = true;
            //какой-то метод, который нужно
            bulletsShot = bulletsPerTap;
            Shoot();
        }
        else if (!triggerValue)
        {
            triggerPressed = false;
        }
        

        
    }
    private void Shoot()
    {
        //readyToShoot = false;

        Vector3 direction = attackPoint.forward;

        //RayCast
        if (Physics.Raycast(attackPoint.position, direction, out rayHit, range, whatIsEnemy))
        {
           
            //if (rayHit.collider.CompareTag("Enemy"))
                //rayHit.collider.GetComponent<EnemyHealth>().AddDamage(damage);
        }



        //Graphics
        Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot--;

        if (bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Polybrush;

public class Strzelanie : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public Animation animation;
    public int ammoCount =30;
    public int ammoInMagazine =30;
    public TextMeshProUGUI magazine, totalAmmo;
    private double lastTime = 0;
    public float shootInterval =0.3f;
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)&& Time.timeAsDouble-lastTime > shootInterval && ammoInMagazine >0)
        {
            ammoInMagazine--;
            magazine.text = ammoInMagazine + "/30";
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            lastTime = Time.timeAsDouble;
            //animation.Play("Shoot");
        }

        if (Input.GetKeyDown(KeyCode.R) && ammoCount + ammoInMagazine > 0)
        {
            animation.Play("Reload");
            ammoCount += ammoInMagazine;
            ammoInMagazine = Math.Clamp(ammoCount, 0, 30);
            magazine.text = ammoInMagazine + "/30";
            ammoCount -= Math.Clamp(ammoCount, 0, 30);
            totalAmmo.text = ammoCount.ToString();
        }
    }
}

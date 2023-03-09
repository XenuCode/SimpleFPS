using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Math = UnityEngine.Polybrush.Math;

public class Strzelanie : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public GameObject light;
    public float bulletSpeed = 10;
    public Animation animation;
    public int ammoCount =30;
    public int ammoInMagazine =30;
    public TextMeshProUGUI magazine, totalAmmo;
    private double lastTime = 0;
    public float shootInterval =0.3f;
    public float lightTime;
    public Gradient ammoGradient;
    public AudioSource shoot,reload;
    public ParticleSystem ParticleSystem;
    private void Start()
    {
        magazine.color = ammoGradient.Evaluate( (float) ammoInMagazine / 30);
        totalAmmo.color = ammoGradient.Evaluate( (float) ammoCount / 120);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)&& Time.timeAsDouble-lastTime > shootInterval && ammoInMagazine >0)
        {
            shoot.Play();
            ParticleSystem.Play(true);
            ammoInMagazine--;
            magazine.text = ammoInMagazine.ToString();
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            lastTime = Time.timeAsDouble;
            //animation.Play("Shoot");
            light.SetActive(true);
            magazine.color = ammoGradient.Evaluate( (float) ammoInMagazine / 30);
            totalAmmo.color = ammoGradient.Evaluate( (float) ammoCount / 240);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            animation.Play("AmmoInspect");
        }
        if (Time.timeAsDouble-lastTime>lightTime)
        {
            light.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.R) && ammoCount + ammoInMagazine > 0)
        {
            reload.Play();
            animation.Play("Reload");
            ammoCount += ammoInMagazine;
            ammoInMagazine = Math.Clamp(ammoCount, 0, 30);
            magazine.text = ammoInMagazine.ToString();
            ammoCount -= Math.Clamp(ammoCount, 0, 30);
            totalAmmo.text = ammoCount.ToString();
            totalAmmo.color = ammoGradient.Evaluate( (float) ammoCount / 240);
            magazine.color = ammoGradient.Evaluate( (float) ammoInMagazine / 30);
        }
    }
}

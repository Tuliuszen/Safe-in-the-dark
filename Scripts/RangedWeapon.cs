using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    public float weaponRange = 50f;
    public GameObject weaponProjectilePrefab;
    public Transform muzzlePos;
    public ParticleSystem muzzleEffect;

    public Camera characterCamera;

    bool canShoot = true;
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //muzzleEffect.Play();
        RaycastHit hit;
        if (Physics.Raycast(characterCamera.transform.position, characterCamera.transform.forward, out hit, weaponRange))
        {   
            if (canShoot)
            {
                GetComponent<Animator>().SetTrigger("isShooting");
                GameObject projectile = Instantiate(weaponProjectilePrefab, muzzlePos.position, Quaternion.identity);
                projectile.transform.LookAt(hit.point);
                FindObjectOfType<SFXManager>().GetComponent<SFXManager>().ShootSFX();
                StartCoroutine(ReloadTime());
            }
        }
    }

    IEnumerator ReloadTime()
    {
        canShoot = false;
        yield return new WaitForSeconds(3f);
        canShoot = true;
    }
}

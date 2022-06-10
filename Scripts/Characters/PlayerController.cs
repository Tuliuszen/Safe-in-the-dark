using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool inLight;
    GameManager manager;
    Scenes scManager;

    public GameObject gun;
    public GameObject sword;

    public void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        scManager = FindObjectOfType<Scenes>().GetComponent<Scenes>();
    }

    void Update()
    {
        CheckWeapon();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Portal"))
        {
            StartCoroutine(Portal());
        }

        //if (other.gameObject.CompareTag("Projectile"))
        //{
        //    FindObjectOfType<SFXManager>().GetComponent<SFXManager>().PlayerDeath();
        //    print("test");
        //    scManager.PlayGame();
        //}
        
        if (other.gameObject.CompareTag("Light"))
        {
            inLight = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Light"))
        {
            inLight = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            FindObjectOfType<SFXManager>().GetComponent<SFXManager>().PlayerDeath();
            print("test");
            scManager.PlayGame();
        }
    }

    void CheckWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //gun.SetActive(true);

            //sword.SetActive(false);

            StartCoroutine(HideSword());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //sword.SetActive(true);

            //gun.SetActive(false);

            StartCoroutine(HideGun());
        }
    }

    IEnumerator HideSword()
    {
        sword.GetComponent<Animator>().SetTrigger("hide");
        yield return new WaitForSeconds(1);
        sword.SetActive(false);
        gun.SetActive(true);
        gun.GetComponent<Animator>().SetTrigger("equip");
    }

    IEnumerator HideGun()
    {
        gun.GetComponent<Animator>().SetTrigger("hide");
        yield return new WaitForSeconds(1);
        gun.SetActive(false);
        sword.SetActive(true);
        sword.GetComponent<Animator>().SetTrigger("equip");
    }

    IEnumerator Portal()
    {
        FindObjectOfType<UIManager>().GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(2);
        manager.Portal();
        scManager.NextScene();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    public bool killedEnemy;
    public bool revenge = false;
    public GameObject mainCamera;
    public Scenes scManager;
    public float killCount;
    public Volume vol;
    public Vignette vg;
    public ColorAdjustments ca;
    public float vDarkness; //0-1
    public float cDarkness; //0-4
    public int playedLevels;
    public bool gamePaused = false;
    UIManager uiManager;
    void Start()
    {
        //vol.profile.TryGet<Vignette>(out Vignette vg);
        //vol.profile.TryGet<ColorAdjustments>(out ColorAdjustments ca);
        //vg = vol.GetComponent<Vignette>();
        uiManager = FindObjectOfType<UIManager>().GetComponent<UIManager>();
        uiManager.GetComponent<Animator>().SetTrigger("FadeOut");
        scManager = GameObject.Find("SceneManager").GetComponent<Scenes>();
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if(mainCamera == null)
            mainCamera = GameObject.Find("Main Camera");

        playedLevels++;
        LoadPrefs();
    }

    void Update()
    {
        SetDarknessValues();
        Menu();
    }

    public void SetDarknessValues()
    {
        vDarkness = killCount/20;
        if (vDarkness > 0.4)
            vDarkness = 0.4f;
        cDarkness = killCount/8;
        if (cDarkness > 1.5)
            cDarkness = 1.5f;

        ManageDarkness();
    }

    public void ManageDarkness()
    {
        //vg.intensity.value = vDarkness;
        vol.profile.TryGet<Vignette>(out Vignette vg);
        vg.intensity.value = vDarkness;

        vol.profile.TryGet<ColorAdjustments>(out ColorAdjustments ca);
        ca.postExposure.value = cDarkness * -1;
    }

    void LoadPrefs()
    {
        killCount = PlayerPrefs.GetFloat("kills");
        LoadRevenge(killCount);
    }

    void LoadRevenge(float val)
    {
        if (val > 0)
            revenge = true;
        else
            revenge = false;

    }

    public void Portal()
    {
        PlayerPrefs.SetInt("revenge", RevengeCheck());
        PlayerPrefs.SetFloat("kills", killCount);
        PlayerPrefs.Save();

        //if (playedLevels >= 4)
        //{
        //    scManager.LoadFinalScene();
        //}
        //else
        //{
        //    scManager.NextScene();
        //}
    }

    int RevengeCheck()
    {
        if (revenge)
            return 1;
        else
            return 0;
    }


    void Menu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gamePaused == false)
        {
            ShowMenu();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && gamePaused)
        {
            HideMenu();
        }
    }

    public void ShowMenu()
    {
        uiManager.OpenMeu();
        gamePaused = true;
        Cursor.visible = true;
        PauseGame();
    }

    public void HideMenu()
    {
        uiManager.HideMenu();
        gamePaused = false;
        Cursor.visible = false;
        ResumeGame();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void SaveData()
    { 
    
    }
}

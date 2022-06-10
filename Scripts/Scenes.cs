using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public List<int> startAvailableLevelIndex = new List<int>();
    public List<int> availableLevelIndex = new List<int>();

    void Start()
    {
        //availableLevelIndex.Add(0);
        //availableLevelIndex.Add(1);
        //availableLevelIndex.Add(2);
        startAvailableLevelIndex = availableLevelIndex;
    }

    //    List<int> myList;
    //    // ...
    //    PlayerPrefs.SetInt("myList_count", myList.Count);
 
    //    for(int i = 0; i<myList.Count; i++)
    //      PlayerPrefs.SetInt("myList_" + i, myList[i]);

    public void NextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextSc = currentScene + 1;
        SceneManager.LoadScene(nextSc);
        //LoadLevelScene(RandomizeScene());
    }

    int RandomizeScene()
    {
        int nextSceneIndex = Random.Range(0, availableLevelIndex.Count);
        availableLevelIndex.RemoveAt(nextSceneIndex);
        return nextSceneIndex;
    }

    
    void LoadLevelScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadFinalScene()
    {
        SceneManager.LoadScene("Final");
    }

    public void Restart()
    {
        availableLevelIndex = startAvailableLevelIndex;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Entry");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void PlayGame()
    {
        //SceneManager.LoadScene("Entry");
        SceneManager.LoadScene("VoidScene");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

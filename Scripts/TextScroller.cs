using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextScroller : MonoBehaviour
{
    TextMeshProUGUI storyText;
    void Start()
    {
        storyText =  GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveText();
    }

    void MoveText()
    {
        storyText.rectTransform.position += new Vector3(0, 0.7f, 0);
        if (storyText.rectTransform.position.y >= 650)
        {
            LoadNxtScene();
        }
    }

    void LoadNxtScene()
    {
        FindObjectOfType<Scenes>().GetComponent<Scenes>().NextScene();
    }
}

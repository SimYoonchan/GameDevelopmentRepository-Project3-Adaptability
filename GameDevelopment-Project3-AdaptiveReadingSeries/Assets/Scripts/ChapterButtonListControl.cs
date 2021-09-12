using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class ChapterButtonListControl : MonoBehaviour
{
    //Cached Reference:
    SceneLoader sceneLoader;


    //Config Param:
    [Header("Number of Chapters")]
    [SerializeField] int totalNumberOfChapters;

    [Serializable]
    public struct Chapters
    {
        public string chapterName;
        //public string numbericValueOfMinutesRead;
    }

    [Header("Chapters Array")]
    [SerializeField] Chapters[] allChapters;

    [Header("Button Template")]
    [SerializeField]
    private GameObject buttonTemplate;


    //private List<int> intList;


    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();

        //To eliminate any potential pausing errors:
        Time.timeScale = 1f;


        for (int i = 0; i < totalNumberOfChapters; i++)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject; //This creates the new button.
            button.SetActive(true); //This sets the button active.
            button.GetComponent<ChapterButtonListButton>().SetChapterName("Chapter " + (i + 1) + " - " + allChapters[i].chapterName);
            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChapterButtonClicked(string chapterName)
    {
        //Debug.Log(myTexString);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ChapterButtonListButton : MonoBehaviour
{
    //Cached References:
    SceneLoader sceneLoader;

    //Config Param:
    [Header("Text SerializeField")]
    [SerializeField]
    private string bookNameConfirmation;
    [SerializeField]
    private TextMeshProUGUI chapterNameOnButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void SetChapterName(string textString)
    {
        chapterNameOnButton.text = textString;
    }


    public void OnButtonClick()
    {
        //Alice's Adventures in Wonderland:
        if (bookNameConfirmation == "Alice's Adventures in Wonderland")
        {
            if (chapterNameOnButton.text == "Chapter 1 - Down the Rabbit-Hole")
            {
                sceneLoader.GoToAliceAdventureInWonderlandChapter1();
            }

            if (chapterNameOnButton.text == "Chapter 2 - The Pool of Tears")
            {
                sceneLoader.GoToAliceAdventureInWonderlandChapter2();
            }

            if (chapterNameOnButton.text == "Chapter 3 - A Caucus-Race and a Long Tale")
            {
                sceneLoader.GoToAliceAdventureInWonderlandChapter3();
            }

            if (chapterNameOnButton.text == "Chapter 4 - The Rabbit Sends in a Little Bill")
            {
                sceneLoader.GoToAliceAdventureInWonderlandChapter4();
            }

            if (chapterNameOnButton.text == "Chapter 5 - Advice from a Caterpillar")
            {
                sceneLoader.GoToAliceAdventureInWonderlandChapter5();
            }

            if (chapterNameOnButton.text == "Chapter 6 - Pig and Pepper")
            {
                sceneLoader.GoToAliceAdventureInWonderlandChapter6();
            }

            if (chapterNameOnButton.text == "Chapter 7 - A Mad Tea-Party")
            {
                sceneLoader.GoToAliceAdventureInWonderlandChapter7();
            }

            if (chapterNameOnButton.text == "Chapter 8 - The Queen’s Croquet-Ground")
            {
                sceneLoader.GoToAliceAdventureInWonderlandChapter8();
            }

            if (chapterNameOnButton.text == "Chapter 9 - The Mock Turtle’s Story")
            {
                sceneLoader.GoToAliceAdventureInWonderlandChapter9();
            }

            if (chapterNameOnButton.text == "Chapter 10 - The Lobster Quadrille")
            {
                sceneLoader.GoToAliceAdventureInWonderlandChapter10();
            }

            if (chapterNameOnButton.text == "Chapter 11 - Who Stole the Tarts") //Got rid of question mark for Unity.
            {
                sceneLoader.GoToAliceAdventureInWonderlandChapter11();
            }

            if (chapterNameOnButton.text == "Chapter 12 - Alice’s Evidence")
            {
                sceneLoader.GoToAliceAdventureInWonderlandChapter12();
            }
        }
        



        //The Great Gatsby:
        if (bookNameConfirmation == "The Great Gatsby")
        {
            if (chapterNameOnButton.text == "Chapter 1 - I")
            {
                sceneLoader.GoToTheGreatGatsbyChapter1();
            }

            if (chapterNameOnButton.text == "Chapter 2 - II")
            {
                sceneLoader.GoToTheGreatGatsbyChapter2();
            }

            if (chapterNameOnButton.text == "Chapter 3 - III")
            {
                sceneLoader.GoToTheGreatGatsbyChapter3();
            }

            if (chapterNameOnButton.text == "Chapter 4 - IV")
            {
                sceneLoader.GoToTheGreatGatsbyChapter4();
            }

            if (chapterNameOnButton.text == "Chapter 5 - V")
            {
                sceneLoader.GoToTheGreatGatsbyChapter5();
            }

            if (chapterNameOnButton.text == "Chapter 6 - VI")
            {
                sceneLoader.GoToTheGreatGatsbyChapter6();
            }

            if (chapterNameOnButton.text == "Chapter 7 - VII")
            {
                sceneLoader.GoToTheGreatGatsbyChapter7();
            }

            if (chapterNameOnButton.text == "Chapter 8 - VIII")
            {
                sceneLoader.GoToTheGreatGatsbyChapter8();
            }

            if (chapterNameOnButton.text == "Chapter 9 - IX")
            {
                sceneLoader.GoToTheGreatGatsbyChapter9();
            }
        }




        //A Scandal in Bohemia:
        if (bookNameConfirmation == "A Scandal in Bohemia")
        {
            if (chapterNameOnButton.text == "Chapter 1 - I")
            {
                sceneLoader.GoToAScandalInBohemiaChapter1();
            }

            if (chapterNameOnButton.text == "Chapter 2 - II")
            {
                sceneLoader.GoToAScandalInBohemiaChapter2();
            }

            if (chapterNameOnButton.text == "Chapter 3 - III")
            {
                sceneLoader.GoToAScandalInBohemiaChapter3();
            }
        }




        //The Coming of the Martians:
        if (bookNameConfirmation == "The Coming of the Martians")
        {
            if (chapterNameOnButton.text == "Chapter 1 - The Eve of War")
            {
                sceneLoader.GoToTheComingOfTheMartiansChapter1();
            }

            if (chapterNameOnButton.text == "Chapter 2 - The Falling Star")
            {
                sceneLoader.GoToTheComingOfTheMartiansChapter2();
            }

            if (chapterNameOnButton.text == "Chapter 3 - One Horsell Common")
            {
                sceneLoader.GoToTheComingOfTheMartiansChapter3();
            }

            if (chapterNameOnButton.text == "Chapter 4 - The Cylinder Opens")
            {
                sceneLoader.GoToTheComingOfTheMartiansChapter4();
            }

            if (chapterNameOnButton.text == "Chapter 5 - The Heat-Ray")
            {
                sceneLoader.GoToTheComingOfTheMartiansChapter5();
            }

            if (chapterNameOnButton.text == "Chapter 6 - The Heart-Ray in the Chobham Road")
            {
                sceneLoader.GoToTheComingOfTheMartiansChapter6();
            }

            if (chapterNameOnButton.text == "Chapter 7 - How I Reached Home")
            {
                sceneLoader.GoToTheComingOfTheMartiansChapter7();
            }

            if (chapterNameOnButton.text == "Chapter 8 - Friday Night")
            {
                sceneLoader.GoToTheComingOfTheMartiansChapter8();
            }

            if (chapterNameOnButton.text == "Chapter 9 - The Fighting Begins")
            {
                sceneLoader.GoToTheComingOfTheMartiansChapter9();
            }

            if (chapterNameOnButton.text == "Chapter 10 - In the Storm")
            {
                sceneLoader.GoToTheComingOfTheMartiansChapter10();
            }

            if (chapterNameOnButton.text == "Chapter 11 - At the Window")
            {
                sceneLoader.GoToTheComingOfTheMartiansChapter11();
            }

            if (chapterNameOnButton.text == "Chapter 12 - What I saw of the destruction of Weybridge and Shepperton")
            {
                sceneLoader.GoToTheComingOfTheMartiansChapter12();
            }

            if (chapterNameOnButton.text == "Chapter 13 - How I fell with the Curate")
            {
                sceneLoader.GoToTheComingOfTheMartiansChapter13();
            }

            if (chapterNameOnButton.text == "Chapter 14 - In London")
            {
                sceneLoader.GoToTheComingOfTheMartiansChapter14();
            }

            if (chapterNameOnButton.text == "Chapter 15 - What had happened in Surrey")
            {
                sceneLoader.GoToTheComingOfTheMartiansChapter15();
            }

            if (chapterNameOnButton.text == "Chapter 16 - The Exodus from London")
            {
                sceneLoader.GoToTheComingOfTheMartiansChapter16();
            }

            if (chapterNameOnButton.text == "Chapter 17 - The 'Thunder Child'")
            {
                sceneLoader.GoToTheComingOfTheMartiansChapter17();
            }
        }



        //The Earth under the Martians:
        if (bookNameConfirmation == "The Earth under the Martians")
        {
            if (chapterNameOnButton.text == "Chapter 1 - Under Foot")
            {
                sceneLoader.GoToTheEarthUnderTheMartiansChapter1();
            }

            if (chapterNameOnButton.text == "Chapter 2 - What we saw from the Ruined House")
            {
                sceneLoader.GoToTheEarthUnderTheMartiansChapter2();
            }

            if (chapterNameOnButton.text == "Chapter 3 - The Days of Imprisonment")
            {
                sceneLoader.GoToTheEarthUnderTheMartiansChapter3();
            }

            if (chapterNameOnButton.text == "Chapter 4 - The Death of Curate")
            {
                sceneLoader.GoToTheEarthUnderTheMartiansChapter4();
            }

            if (chapterNameOnButton.text == "Chapter 5 - The Stillness")
            {
                sceneLoader.GoToTheEarthUnderTheMartiansChapter5();
            }

            if (chapterNameOnButton.text == "Chapter 6 - The Work of Fifteen Days")
            {
                sceneLoader.GoToTheEarthUnderTheMartiansChapter6();
            }

            if (chapterNameOnButton.text == "Chapter 7 - The Man on Putney Hill")
            {
                sceneLoader.GoToTheEarthUnderTheMartiansChapter7();
            }

            if (chapterNameOnButton.text == "Chapter 8 - Dead London")
            {
                sceneLoader.GoToTheEarthUnderTheMartiansChapter8();
            }

            if (chapterNameOnButton.text == "Chapter 9 - Wreckage")
            {
                sceneLoader.GoToTheEarthUnderTheMartiansChapter9();
            }

            if (chapterNameOnButton.text == "Chapter 10 - The Epilogue")
            {
                sceneLoader.GoToTheEarthUnderTheMartiansChapter10();
            }
        }
    }
}

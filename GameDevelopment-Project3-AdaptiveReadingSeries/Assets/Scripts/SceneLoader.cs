using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //Config param:
    [Header("Delay-related")]
    public float endOfSceneTransitionTime = 2.5f;

    [Header("Animators-related")]
    //public Animator sceneTransitions;
    //public Animator musicTransitions;
    int currentScene;
    int justPreviousScene;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToFirstScreen()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene - currentScene);

        //StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransition(0));
    }

    public void GoToMainMenu()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene - currentScene + 1);

        //StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransition(0));
    }

    public void GoToCredits()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);

        //StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransition(2));
    }

    public void RestartCurrentScene()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();

        //StartCoroutine(LoadWithEndOfSceneTransitionAndMusicTransition(currentScene));
    }

    public void GoToNextChapterInBook()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();

    }




    //Alice's Adventures in Wonderland:
    public void GoToAliceAdventureInWonderlandChapter1()
    {
        SceneManager.LoadScene("Book Chapter (Alice's Adventures in Wonderland - Chp 1) - Down the Rabbit-Hole");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToAliceAdventureInWonderlandChapter2()
    {
        SceneManager.LoadScene("Book Chapter (Alice's Adventures in Wonderland - Chp 2) - The Pool of Tears");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToAliceAdventureInWonderlandChapter3()
    {
        SceneManager.LoadScene("Book Chapter (Alice's Adventures in Wonderland - Chp 3) - A Caucus-Race and a Long Tale");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToAliceAdventureInWonderlandChapter4()
    {
        SceneManager.LoadScene("Book Chapter (Alice's Adventures in Wonderland - Chp 4) - The Rabbit Sends in a Little Bill");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToAliceAdventureInWonderlandChapter5()
    {
        SceneManager.LoadScene("Book Chapter (Alice's Adventures in Wonderland - Chp 5) - Advice from a Caterpillar");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToAliceAdventureInWonderlandChapter6()
    {
        SceneManager.LoadScene("Book Chapter (Alice's Adventures in Wonderland - Chp 6) - Pig and Pepper");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToAliceAdventureInWonderlandChapter7()
    {
        SceneManager.LoadScene("Book Chapter (Alice's Adventures in Wonderland - Chp 7) - A Mad Tea-Party");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToAliceAdventureInWonderlandChapter8()
    {
        SceneManager.LoadScene("Book Chapter (Alice's Adventures in Wonderland - Chp 8) - The Queen’s Croquet-Ground");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToAliceAdventureInWonderlandChapter9()
    {
        SceneManager.LoadScene("Book Chapter (Alice's Adventures in Wonderland - Chp 9) - The Mock Turtle’s Story");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToAliceAdventureInWonderlandChapter10()
    {
        SceneManager.LoadScene("Book Chapter (Alice's Adventures in Wonderland - Chp 10) - The Lobster Quadrille");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToAliceAdventureInWonderlandChapter11()
    {
        SceneManager.LoadScene("Book Chapter (Alice's Adventures in Wonderland - Chp 11) - Who Stole the Tarts"); //Can't have question marks in Unity Scene Name.
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToAliceAdventureInWonderlandChapter12()
    {
        SceneManager.LoadScene("Book Chapter (Alice's Adventures in Wonderland - Chp 12) - Alice’s Evidence");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }




    //The Great Gatsby:
    public void GoToTheGreatGatsbyChapter1()
    {
        SceneManager.LoadScene("Book Chapter (The Great Gatsby - Chp 1) - I");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheGreatGatsbyChapter2()
    {
        SceneManager.LoadScene("Book Chapter (The Great Gatsby - Chp 2) - II");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheGreatGatsbyChapter3()
    {
        SceneManager.LoadScene("Book Chapter (The Great Gatsby - Chp 3) - III");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheGreatGatsbyChapter4()
    {
        SceneManager.LoadScene("Book Chapter (The Great Gatsby - Chp 4) - IV");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheGreatGatsbyChapter5()
    {
        SceneManager.LoadScene("Book Chapter (The Great Gatsby - Chp 5) - V");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheGreatGatsbyChapter6()
    {
        SceneManager.LoadScene("Book Chapter (The Great Gatsby - Chp 6) - VI");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheGreatGatsbyChapter7()
    {
        SceneManager.LoadScene("Book Chapter (The Great Gatsby - Chp 7) - VII");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheGreatGatsbyChapter8()
    {
        SceneManager.LoadScene("Book Chapter (The Great Gatsby - Chp 8) - VIII");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheGreatGatsbyChapter9()
    {
        SceneManager.LoadScene("Book Chapter (The Great Gatsby - Chp 9) - IX");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }




    //A Scandal in Bohemia:
    public void GoToAScandalInBohemiaChapter1()
    {
        SceneManager.LoadScene("Book Chapter (A Scandal in Bohemia - Chp 1) - I");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToAScandalInBohemiaChapter2()
    {
        SceneManager.LoadScene("Book Chapter (A Scandal in Bohemia - Chp 2) - II");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToAScandalInBohemiaChapter3()
    {
        SceneManager.LoadScene("Book Chapter (A Scandal in Bohemia - Chp 3) - III");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }



    //The Coming of the Martians:
    public void GoToTheComingOfTheMartiansChapter1()
    {
        SceneManager.LoadScene("Book Chapter (The Coming of the Martians - Chp 1) - The Eve of War");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheComingOfTheMartiansChapter2()
    {
        SceneManager.LoadScene("Book Chapter (The Coming of the Martians - Chp 2) - The Falling Star");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheComingOfTheMartiansChapter3()
    {
        SceneManager.LoadScene("Book Chapter (The Coming of the Martians - Chp 3) - One Horsell Common");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheComingOfTheMartiansChapter4()
    {
        SceneManager.LoadScene("Book Chapter (The Coming of the Martians - Chp 4) - The Cylinder Opens");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheComingOfTheMartiansChapter5()
    {
        SceneManager.LoadScene("Book Chapter (The Coming of the Martians - Chp 5) - The Heat-Ray");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheComingOfTheMartiansChapter6()
    {
        SceneManager.LoadScene("Book Chapter (The Coming of the Martians - Chp 6) - The Heart-Ray in the Chobham Road");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheComingOfTheMartiansChapter7()
    {
        SceneManager.LoadScene("Book Chapter (The Coming of the Martians - Chp 7) - How I Reached Home");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheComingOfTheMartiansChapter8()
    {
        SceneManager.LoadScene("Book Chapter (The Coming of the Martians - Chp 8) - Friday Night");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheComingOfTheMartiansChapter9()
    {
        SceneManager.LoadScene("Book Chapter (The Coming of the Martians - Chp 9) - The Fighting Begins");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheComingOfTheMartiansChapter10()
    {
        SceneManager.LoadScene("Book Chapter (The Coming of the Martians - Chp 10) - In the Storm");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheComingOfTheMartiansChapter11()
    {
        SceneManager.LoadScene("Book Chapter (The Coming of the Martians - Chp 11) - At the Window");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheComingOfTheMartiansChapter12()
    {
        SceneManager.LoadScene("Book Chapter (The Coming of the Martians - Chp 12) - What I saw of the destruction of Weybridge and Shepperton");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheComingOfTheMartiansChapter13()
    {
        SceneManager.LoadScene("Book Chapter (The Coming of the Martians - Chp 13) - How I fell with the Curate");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheComingOfTheMartiansChapter14()
    {
        SceneManager.LoadScene("Book Chapter (The Coming of the Martians - Chp 14) - In London");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheComingOfTheMartiansChapter15()
    {
        SceneManager.LoadScene("Book Chapter (The Coming of the Martians - Chp 15) - What had happened in Surrey");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheComingOfTheMartiansChapter16()
    {
        SceneManager.LoadScene("Book Chapter (The Coming of the Martians - Chp 16) - The Exodus from London");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheComingOfTheMartiansChapter17()
    {
        SceneManager.LoadScene("Book Chapter (The Coming of the Martians - Chp 17) - The 'Thunder Child'");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }



    //The Earth Under the Martians
    public void GoToTheEarthUnderTheMartiansChapter1()
    {
        SceneManager.LoadScene("Book Chapter (The Earth under the Martians - Chp 1) - Under Foot");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheEarthUnderTheMartiansChapter2()
    {
        SceneManager.LoadScene("Book Chapter (The Earth under the Martians - Chp 2) - What we saw from the Ruined House");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheEarthUnderTheMartiansChapter3()
    {
        SceneManager.LoadScene("Book Chapter (The Earth under the Martians - Chp 3) - The Days of Imprisonment");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheEarthUnderTheMartiansChapter4()
    {
        SceneManager.LoadScene("Book Chapter (The Earth under the Martians - Chp 4) - The Death of Curate");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheEarthUnderTheMartiansChapter5()
    {
        SceneManager.LoadScene("Book Chapter (The Earth under the Martians - Chp 5) - The Stillness");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheEarthUnderTheMartiansChapter6()
    {
        SceneManager.LoadScene("Book Chapter (The Earth under the Martians - Chp 6) - The Work of Fifteen Days");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheEarthUnderTheMartiansChapter7()
    {
        SceneManager.LoadScene("Book Chapter (The Earth under the Martians - Chp 7) - The Man on Putney Hill");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheEarthUnderTheMartiansChapter8()
    {
        SceneManager.LoadScene("Book Chapter (The Earth under the Martians - Chp 8) - Dead London");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheEarthUnderTheMartiansChapter9()
    {
        SceneManager.LoadScene("Book Chapter (The Earth under the Martians - Chp 9) - Wreckage");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }

    public void GoToTheEarthUnderTheMartiansChapter10()
    {
        SceneManager.LoadScene("Book Chapter (The Earth under the Martians - Chp 10) - The Epilogue");
        //FindObjectOfType<AdaptiveReadingManager>().ResetAdaptiveReader();
    }


    //private IEnumerator LoadWithEndOfSceneTransitionAndMusicTransition(int currentSceneIndex) //This adds slight delay between scenes.
    //{
    //    //1) Play animation
    //    if (sceneTransitions != null)
    //    {
    //        sceneTransitions.SetTrigger("TriggerEndOfSceneTransitionFade");
    //    }

    //    if (musicTransitions != null)
    //    {
    //        musicTransitions.SetTrigger("TriggerEndOfSceneMusicFade");
    //    }

    //    //2) Wait
    //    yield return new WaitForSeconds(endOfSceneTransitionTime);

    //    //3) Load Scene
    //    SceneManager.LoadScene(currentSceneIndex);
    //}
}
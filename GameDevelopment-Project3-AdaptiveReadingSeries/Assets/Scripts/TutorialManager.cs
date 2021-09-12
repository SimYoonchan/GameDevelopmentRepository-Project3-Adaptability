using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    //Cached Reference:
    SceneLoader sceneLoader;

    //Config Param:
    [Header("Boolean ON/OF - Screen & Buttons")]
    [SerializeField] GameObject tutorialScreenUI;
    [SerializeField] GameObject skipButton;
    [SerializeField] GameObject previousButton;
    [SerializeField] GameObject continueButton;
    [SerializeField] GameObject finishButton;

    [Header("Textbox UI")]
    [SerializeField] TextMeshProUGUI tutorialInstructionsTextbox;

    [Header("Textbox Array")]
    [TextArea(10, 15)] [SerializeField] string[] tutorialInstructionsArray;
    private int indexForTutorialInstructionsDisplay;

    [Header("Enable/Disable Other Scripts")] //We will pause the AdaptiveReadingManager's buttons from working before the tutorial.
    [SerializeField] GameObject tutorialManagerScript;
    [SerializeField] GameObject adaptiveReadingManagerScript;


    // Start is called before the first frame update
    void Start()
    {
        //Cached Reference:
        sceneLoader = FindObjectOfType<SceneLoader>();

        //Boolean ON/OFF:
        tutorialScreenUI.SetActive(false);
        tutorialManagerScript.GetComponent<TutorialManager>().enabled = false;
        adaptiveReadingManagerScript.GetComponent<AdaptiveReadingManager>().enabled = true;

        //Textbox:
        tutorialInstructionsTextbox.text = tutorialInstructionsArray[indexForTutorialInstructionsDisplay];
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorialInstructionsTextbox.text == tutorialInstructionsArray[indexForTutorialInstructionsDisplay] & indexForTutorialInstructionsDisplay > 0)
        {
            previousButton.SetActive(true);
        }

        else
        {
            previousButton.SetActive(false);
        }

        if (tutorialInstructionsTextbox.text == tutorialInstructionsArray[indexForTutorialInstructionsDisplay] & indexForTutorialInstructionsDisplay < tutorialInstructionsArray.Length - 1)
        {
            continueButton.SetActive(true); 
        }

        else
        {
            continueButton.SetActive(false);
        }

        if (indexForTutorialInstructionsDisplay == tutorialInstructionsArray.Length - 1)
        {
            finishButton.SetActive(true);
        }

        else
        {
            finishButton.SetActive(false);
        }  
    }

    public void SkipButtonPressed()
    {
        tutorialScreenUI.SetActive(false);

        tutorialManagerScript.GetComponent<TutorialManager>().enabled = false;
        adaptiveReadingManagerScript.GetComponent<AdaptiveReadingManager>().enabled = true;
    }

    public void PreviousButtonPressed()
    {
        if (indexForTutorialInstructionsDisplay > 0)
        {
            indexForTutorialInstructionsDisplay--;

            tutorialInstructionsTextbox.text = tutorialInstructionsArray[indexForTutorialInstructionsDisplay];
        }
    }

    public void ContinueButtonPressed()
    {
        if (indexForTutorialInstructionsDisplay < tutorialInstructionsArray.Length - 1)
        {
            indexForTutorialInstructionsDisplay++;

            tutorialInstructionsTextbox.text = tutorialInstructionsArray[indexForTutorialInstructionsDisplay];
        }
    }

    public void FinishButtonPressed()
    {
        if (indexForTutorialInstructionsDisplay == tutorialInstructionsArray.Length - 1)
        {
            finishButton.SetActive(true);
            tutorialScreenUI.SetActive(false);

            tutorialManagerScript.GetComponent<TutorialManager>().enabled = false;
            adaptiveReadingManagerScript.GetComponent<AdaptiveReadingManager>().enabled = true;
        }
    }

    public void TutorialButtonPressed()
    {
        tutorialScreenUI.SetActive(true);

        tutorialManagerScript.GetComponent<TutorialManager>().enabled = true;
        adaptiveReadingManagerScript.GetComponent<AdaptiveReadingManager>().enabled = false;

        indexForTutorialInstructionsDisplay = 0; //To restart the Tutorial Index.
        tutorialInstructionsTextbox.text = tutorialInstructionsArray[indexForTutorialInstructionsDisplay];
    }

    public void RestartAdaptiveReaderButtonPressed()
    {
        tutorialScreenUI.SetActive(false);
        sceneLoader.RestartCurrentScene();
    }
}
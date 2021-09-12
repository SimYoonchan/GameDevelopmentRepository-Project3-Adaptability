using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManagerForMainMenu : MonoBehaviour
{
    //Cached Reference:
    MainMenuManager mainMenuManager;

    //Config Param:
    [Header("Boolean ON/OF - Screen & Buttons")]
    [SerializeField] GameObject skipButton;
    [SerializeField] GameObject previousButton;
    [SerializeField] GameObject continueButton;
    [SerializeField] GameObject finishButton;

    [Header("Textbox UI")]
    [SerializeField] TextMeshProUGUI tutorialInstructionsTextbox;

    [Header("Textbox Array")]
    [TextArea(10, 15)] [SerializeField] string[] tutorialInstructionsArray;
    private int indexForTutorialInstructionsDisplay;


    // Start is called before the first frame update
    void Start()
    {
        //Cached Reference:
        mainMenuManager = FindObjectOfType<MainMenuManager>();

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
        mainMenuManager.BackFromTutorialScreen();

        indexForTutorialInstructionsDisplay = 0; //To reset tutorial.
        tutorialInstructionsTextbox.text = tutorialInstructionsArray[indexForTutorialInstructionsDisplay];
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

    public void FinishButtonPressed() //For the main menu, the disappearance of tutorial will occur from the MainMenuManager.cs
    {
        if (indexForTutorialInstructionsDisplay == tutorialInstructionsArray.Length - 1)
        {
            finishButton.SetActive(true);

            mainMenuManager.BackFromTutorialScreen();

            indexForTutorialInstructionsDisplay = 0; //To reset tutorial.
            tutorialInstructionsTextbox.text = tutorialInstructionsArray[indexForTutorialInstructionsDisplay];
        }
    }
}

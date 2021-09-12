using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    //Config Param:
    [Header("Boolean ON/OFF")]
    [SerializeField] GameObject mainMenuFirstScreenUI;
    [SerializeField] GameObject mainMenuStartScreenUI;
    [SerializeField] GameObject mainMenuTutorialScreenUI;
    [SerializeField] GameObject mainMenuResearchScreenUI;
    [SerializeField] GameObject mainMenuAboutTheCreatorsScreenUI;
    [SerializeField] GameObject mainMenuSettingsScreenUI;
    //No credits UI.


    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Main Theme"); //This plays "Main Theme".

        //To eliminate any potential pausing errors:
        Time.timeScale = 1f;

        mainMenuFirstScreenUI.SetActive(true);
        mainMenuStartScreenUI.SetActive(false);
        mainMenuTutorialScreenUI.SetActive(false);
        mainMenuResearchScreenUI.SetActive(false);
        mainMenuAboutTheCreatorsScreenUI.SetActive(false);
        mainMenuSettingsScreenUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToFirstScreen()
    {
        mainMenuFirstScreenUI.SetActive(true);
        mainMenuStartScreenUI.SetActive(false);
        mainMenuResearchScreenUI.SetActive(false);
        mainMenuAboutTheCreatorsScreenUI.SetActive(false);
        mainMenuSettingsScreenUI.SetActive(false);
    }

    public void GoToStartScreen()
    {
        mainMenuFirstScreenUI.SetActive(false);
        mainMenuStartScreenUI.SetActive(true);
    }

    public void BackFromStartScreen()
    {
        mainMenuStartScreenUI.SetActive(false);
        mainMenuFirstScreenUI.SetActive(true);
    }

    public void GoToTutorialScreen()
    {
        mainMenuFirstScreenUI.SetActive(false);
        mainMenuTutorialScreenUI.SetActive(true);
    }

    public void BackFromTutorialScreen()
    {
        mainMenuTutorialScreenUI.SetActive(false);
        mainMenuFirstScreenUI.SetActive(true);
    }

    public void GoToResearchScreen()
    {
        mainMenuFirstScreenUI.SetActive(false);
        mainMenuResearchScreenUI.SetActive(true);
    }

    public void BackFromResearchScreen()
    {
        mainMenuResearchScreenUI.SetActive(false);
        mainMenuFirstScreenUI.SetActive(true);
    }

    public void GoToAboutTheCreatorsScreen()
    {
        mainMenuFirstScreenUI.SetActive(false);
        mainMenuAboutTheCreatorsScreenUI.SetActive(true);
    }

    public void BackFromAboutTheCreatorsScreen()
    {
        mainMenuAboutTheCreatorsScreenUI.SetActive(false);
        mainMenuFirstScreenUI.SetActive(true);
    }

    public void GoToSettingsScreen()
    {
        mainMenuFirstScreenUI.SetActive(false);
        mainMenuSettingsScreenUI.SetActive(true);
    }

    public void BackFromSettingsScreen()
    {
        mainMenuSettingsScreenUI.SetActive(false);
        mainMenuFirstScreenUI.SetActive(true);
    }
}


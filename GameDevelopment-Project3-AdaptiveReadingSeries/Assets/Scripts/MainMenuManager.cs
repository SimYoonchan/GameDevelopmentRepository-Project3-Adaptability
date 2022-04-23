using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    //Config Param:
    [Header("Boolean ON/OFF")]
    [SerializeField] GameObject mainMenuHomeScreenUI;
    [SerializeField] GameObject mainMenuResearchScreenUI;
    [SerializeField] GameObject mainMenuTheCreatorsScreenUI;
    //No credits UI.


    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Main Theme"); //This plays "Main Theme".

        //To eliminate any potential pausing errors:
        Time.timeScale = 1f;

        mainMenuHomeScreenUI.SetActive(true);
        mainMenuResearchScreenUI.SetActive(false);
        mainMenuTheCreatorsScreenUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NavHomeToResearch()
    {
        mainMenuHomeScreenUI.SetActive(false);
        mainMenuResearchScreenUI.SetActive(true);
    }

    public void NavHomeToTheCreators()
    {
        mainMenuHomeScreenUI.SetActive(false);
        mainMenuTheCreatorsScreenUI.SetActive(true);
    }

    public void NavResearchToHome()
    {
        mainMenuResearchScreenUI.SetActive(false);
        mainMenuHomeScreenUI.SetActive(true);
    }

    public void NavResearchToTheCreators()
    {
        mainMenuResearchScreenUI.SetActive(false);
        mainMenuTheCreatorsScreenUI.SetActive(true);
    }

    public void NavTheCreatorsToHome()
    {
        mainMenuTheCreatorsScreenUI.SetActive(false);
        mainMenuHomeScreenUI.SetActive(true);
    }

    public void NavTheCreatorsToResearch()
    {
        mainMenuTheCreatorsScreenUI.SetActive(false);
        mainMenuResearchScreenUI.SetActive(true);
    }
}


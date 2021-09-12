using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

[ExecuteInEditMode]
public class AdaptiveReadingManager : MonoBehaviour
{
    //Cached References:
    SceneLoader sceneLoader;

    //Config Parameters:
    public static bool PauseIsEnabled = false;
    public static bool AdaptiveReaderResumeIsEnabled = false;


    [Header("Boolean ON/OFF")]
    [SerializeField] GameObject mainScreenUI;
    [SerializeField] GameObject mainScreenReaderPlayerUI;
    [SerializeField] GameObject pauseScreenUI;
    [SerializeField] GameObject adaptiveReaderPlayButton;
    [SerializeField] GameObject adaptiveReaderPauseButton;


    [Header("Title Textbook UI")]
    [SerializeField] string bookTitle;
    [SerializeField] TextMeshProUGUI bookTitleUI;
    [SerializeField] string bookChapter;
    [SerializeField] TextMeshProUGUI bookChapterUI;


    [Header("Adaptive Textbox UI")]
    [SerializeField] TextMeshProUGUI adaptiveReadingTextbox; //This is where text goes.
    [TextArea(15, 45)] public string chapterFullText;


    [Header("Dropdown List")]
    [SerializeField] TMP_Dropdown dropdownAverageCharactersPerWord;
    [SerializeField] TMP_Dropdown dropdownWordsPerMinuteRates;
    [SerializeField] TMP_Dropdown dropdownFontSize;


    [Header("Rate Constants")]
    [SerializeField] float averageCharactersPerWord = 4f;
    [SerializeField] float wordsPerMinuteRates = 85f;
    [SerializeField] float setFontSize = 42f;
    [SerializeField] float screenWidthSize = 1920f;
    [SerializeField] float numberOfCharactersIncludingSpaces;
    [SerializeField] float twoPointFourEightTwoFive = 2.482500f;
    [SerializeField] float half = 0.500000f;
    [SerializeField] float zero = 0f;


    [Header("Rate Calculations Equations")]
    public float numberOfCharactersPerMinute;
    public float widthOfTextboxInUnity;
    public float distanceForTextboxToBeUpAgainstScreenRightEdge;


    [Header("Textbox Positioning")]
    [SerializeField] Vector2 startPosition;
    [SerializeField] Vector2 endPosition;
    [SerializeField] Vector2 currentPosition;


    [Header("Time and Lerp")]
    [SerializeField] TextMeshProUGUI currentTimeDisplayHUD;
    [SerializeField] TextMeshProUGUI totalTimeDisplayHUD;
    public float currentTime;
    public float timeRequiredForTextboxToLeaveOffScreen;
    [Range(0f, 1f)] public float percentageOfLerpCompletion;
    public float readerPlayerTimer;
    public float readerPlayerExpirationTime = 4f; //4 seconds for the reader player to appear.


    [Header("Dropdown Current Time Readjustment")]
    private float startingAverageCharactersPerWord = 4f;
    private float oldAverageCharactersPerWord;
    private float newAverageCharactersPerWord;

    private float startingWordsPerMinuteRate = 85f;
    private float oldWordsPerMinuteRate;
    private float newWordsPerMinuteRate;

    private float startingFontSize = 42f;
    private float oldFontSize;
    private float newFontSize;


    [Header("Idle")]
    private Coroutine hideReaderPlayer;
    //private Vector2 lastMousePos = Vector2.zero;


    private void Awake()
    {
        //To do singleton:
        //SingletonReadingSession();

        //To start at pause:
        Time.timeScale = 0f;

        //Cached References:
        sceneLoader = FindObjectOfType<SceneLoader>();

        //Boolean ON/OFF:
        mainScreenUI.SetActive(true);
        mainScreenReaderPlayerUI.SetActive(true);
        pauseScreenUI.SetActive(false);
        adaptiveReaderPlayButton.SetActive(true);
        adaptiveReaderPauseButton.SetActive(false);

        //Textbox Headers:
        bookTitleUI.text = bookTitle;
        bookChapterUI.text = bookChapter;

        //Textbox chapter full text:
        adaptiveReadingTextbox.text = chapterFullText;


        //Dropdown for AverageCharactersPerWord:
        dropdownAverageCharactersPerWord.ClearOptions(); //To ensure that there is no duplicates.
        List<string> dropdownAverageCharactersPerWordOptions = new List<string>();
        dropdownAverageCharactersPerWordOptions.Add("4");
        dropdownAverageCharactersPerWordOptions.Add("5");
        dropdownAverageCharactersPerWordOptions.Add("6");

        foreach (var options in dropdownAverageCharactersPerWordOptions)
        {
            dropdownAverageCharactersPerWord.options.Add(new TMP_Dropdown.OptionData() { text = options });
        }


        ////Dropdown for WordsPerMinuteRates:
        dropdownWordsPerMinuteRates.ClearOptions(); //To ensure that there is no duplicates.
        List<string> dropdownWordsPerMinuteRatesOptions = new List<string>();
        dropdownWordsPerMinuteRatesOptions.Add("85 Words Per Min");
        dropdownWordsPerMinuteRatesOptions.Add("105 Words Per Min");
        dropdownWordsPerMinuteRatesOptions.Add("143 Words Per Min");
        dropdownWordsPerMinuteRatesOptions.Add("173 Words Per Min");
        dropdownWordsPerMinuteRatesOptions.Add("205 Words Per Min");
        dropdownWordsPerMinuteRatesOptions.Add("240 Words Per Min");
        dropdownWordsPerMinuteRatesOptions.Add("275 Words Per Min");

        foreach (var options in dropdownWordsPerMinuteRatesOptions)
        {
            dropdownWordsPerMinuteRates.options.Add(new TMP_Dropdown.OptionData() { text = options });
        }


        ////Dropdown for FontSize:
        dropdownFontSize.ClearOptions(); //To ensure that there is no duplicates.
        List<string> dropdownFontSizeOptions = new List<string>();
        dropdownFontSizeOptions.Add("42");
        dropdownFontSizeOptions.Add("48");
        dropdownFontSizeOptions.Add("54");
        dropdownFontSizeOptions.Add("60");
        dropdownFontSizeOptions.Add("66");
        dropdownFontSizeOptions.Add("72");
        dropdownFontSizeOptions.Add("78");
        dropdownFontSizeOptions.Add("84");
        dropdownFontSizeOptions.Add("90");

        foreach (var options in dropdownFontSizeOptions)
        {
            dropdownFontSize.options.Add(new TMP_Dropdown.OptionData() { text = options });
        }


        //Rate Calculations Equations:
        numberOfCharactersPerMinute = averageCharactersPerWord * wordsPerMinuteRates;

        widthOfTextboxInUnity = (numberOfCharactersIncludingSpaces * setFontSize) / twoPointFourEightTwoFive;

        distanceForTextboxToBeUpAgainstScreenRightEdge = (half * widthOfTextboxInUnity) + (half * screenWidthSize);

        timeRequiredForTextboxToLeaveOffScreen = numberOfCharactersIncludingSpaces / numberOfCharactersPerMinute * 60;


        //Textbox size:
        adaptiveReadingTextbox.GetComponent<RectTransform>().sizeDelta = new Vector2(widthOfTextboxInUnity, setFontSize); //Width, Height


        //Textbox position equations:
        startPosition = new Vector2(distanceForTextboxToBeUpAgainstScreenRightEdge, 0);
        endPosition = new Vector2(-distanceForTextboxToBeUpAgainstScreenRightEdge, 0);


        //Starting Position:
        adaptiveReadingTextbox.GetComponent<RectTransform>().anchoredPosition = startPosition;


        //Starting DropDown Current Time Adjustment:
        oldAverageCharactersPerWord = startingAverageCharactersPerWord; //At 4 characters per word.
        oldWordsPerMinuteRate = startingWordsPerMinuteRate; //At 85 words per minutes.
        oldFontSize = startingFontSize; //At 42 font size.
    }

    //void SingletonReadingSession()
    //{
    //    if (FindObjectsOfType(GetType()).Length > 1)
    //    {
    //        Destroy(gameObject);
    //    }

    //    else
    //    {
    //        DontDestroyOnLoad(gameObject);
    //    }
    //}

    public void ResetAdaptiveReader() //We need this to destroy the Reading Session object.
    {
        Destroy(gameObject);
    }

    void LateUpdate()
    {
        //To check current position:
        currentPosition = adaptiveReadingTextbox.GetComponent<RectTransform>().anchoredPosition;

        //To make Reader Player appear:
        readerPlayerTimer = readerPlayerTimer + Time.smoothDeltaTime;

        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0 || Input.anyKeyDown)
        {
            readerPlayerTimer = 0.0f;

            mainScreenReaderPlayerUI.SetActive(true);
        }

        if (readerPlayerTimer > readerPlayerExpirationTime)
        {
            mainScreenReaderPlayerUI.SetActive(false);
        }


        //To interact with Reader Player:
        if (currentTime > timeRequiredForTextboxToLeaveOffScreen)
        {
            currentTime = timeRequiredForTextboxToLeaveOffScreen;

            if (Input.GetKey(KeyCode.Alpha1)) //Go backwards in time x 1.
            {
                GoBackwardsInTimeX40();
            }

            if (Input.GetKey(KeyCode.Alpha2)) //Go backwards in time x 1.
            {
                GoBackwardsInTimeX10();
            }

            if (Input.GetKey(KeyCode.Alpha3)) //Go backwards in time x 1.
            {
                GoBackwardsInTimeX1();
            }

            if (Input.GetKey(KeyCode.Alpha4)) //Go forwards in time x 1.
            {
                GoForwardInTimeX1();
            }

            if (Input.GetKey(KeyCode.Alpha5)) //Go forwards in time x 1.
            {
                GoForwardInTimeX10();
            }

            if (Input.GetKey(KeyCode.Alpha6)) //Go forwards in time x 1.
            {
                GoForwardInTimeX40();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (AdaptiveReaderResumeIsEnabled)
                {
                    AdaptiveReaderPause();
                }

                else
                {
                    AdaptiveReaderResume();
                }
            }

            currentTime = currentTime + Time.smoothDeltaTime;
            percentageOfLerpCompletion = currentTime / timeRequiredForTextboxToLeaveOffScreen;

            //For current time:
            int daysCurrent = (int)(currentTime / 86400) % 365;
            int hoursCurrent = (int)(currentTime / 3600) % 24;
            int minutesCurrent = (int)(currentTime / 60) % 60;
            int secondsCurrent = (int)(currentTime % 60);
            if (hoursCurrent >= 9 && minutesCurrent >= 9 && secondsCurrent >= 9) { currentTimeDisplayHUD.text = hoursCurrent + ":" + minutesCurrent + ":" + secondsCurrent; }
            if (hoursCurrent >= 9 && minutesCurrent >= 9 && secondsCurrent <= 9) { currentTimeDisplayHUD.text = hoursCurrent + ":" + minutesCurrent + ":" + "0" + secondsCurrent; }
            if (hoursCurrent >= 9 && minutesCurrent <= 9 && secondsCurrent >= 9) { currentTimeDisplayHUD.text = hoursCurrent + ":" + "0" + minutesCurrent + ":" + secondsCurrent; }
            if (hoursCurrent >= 9 && minutesCurrent <= 9 && secondsCurrent <= 9) { currentTimeDisplayHUD.text = hoursCurrent + ":" + "0" + minutesCurrent + ":" + "0" + secondsCurrent; }

            if (hoursCurrent <= 9 && minutesCurrent >= 9 && secondsCurrent >= 9) { currentTimeDisplayHUD.text = "0" + hoursCurrent + ":" + minutesCurrent + ":" + secondsCurrent; }
            if (hoursCurrent <= 9 && minutesCurrent >= 9 && secondsCurrent <= 9) { currentTimeDisplayHUD.text = "0" + hoursCurrent + ":" + minutesCurrent + ":" + "0" + secondsCurrent; }
            if (hoursCurrent <= 9 && minutesCurrent <= 9 && secondsCurrent >= 9) { currentTimeDisplayHUD.text = "0" + hoursCurrent + ":" + "0" + minutesCurrent + ":" + secondsCurrent; }
            if (hoursCurrent <= 9 && minutesCurrent <= 9 && secondsCurrent <= 9) { currentTimeDisplayHUD.text = "0" + hoursCurrent + ":" + "0" + minutesCurrent + ":" + "0" + secondsCurrent; }

            //For total time:
            int daysTotal = (int)(timeRequiredForTextboxToLeaveOffScreen / 86400) % 365;
            int hoursTotal = (int)(timeRequiredForTextboxToLeaveOffScreen / 3600) % 24;
            int minutesTotal = (int)(timeRequiredForTextboxToLeaveOffScreen / 60) % 60;
            int secondsTotal = (int)(timeRequiredForTextboxToLeaveOffScreen % 60);
            if (hoursTotal >= 9 && minutesTotal >= 9 && secondsTotal >= 9) { totalTimeDisplayHUD.text = hoursTotal + ":" + minutesTotal + ":" + secondsTotal; }
            if (hoursTotal >= 9 && minutesTotal >= 9 && secondsTotal <= 9) { totalTimeDisplayHUD.text = hoursTotal + ":" + minutesTotal + ":" + "0" + secondsTotal; }
            if (hoursTotal >= 9 && minutesTotal <= 9 && secondsTotal >= 9) { totalTimeDisplayHUD.text = hoursTotal + ":" + "0" + minutesTotal + ":" + secondsTotal; }
            if (hoursTotal >= 9 && minutesTotal <= 9 && secondsTotal <= 9) { totalTimeDisplayHUD.text = hoursTotal + ":" + "0" + minutesTotal + ":" + "0" + secondsTotal; }

            if (hoursTotal <= 9 && minutesTotal >= 9 && secondsTotal >= 9) { totalTimeDisplayHUD.text = "0" + hoursTotal + ":" + minutesTotal + ":" + secondsTotal; }
            if (hoursTotal <= 9 && minutesTotal >= 9 && secondsTotal <= 9) { totalTimeDisplayHUD.text = "0" + hoursTotal + ":" + minutesTotal + ":" + "0" + secondsTotal; }
            if (hoursTotal <= 9 && minutesTotal <= 9 && secondsTotal >= 9) { totalTimeDisplayHUD.text = "0" + hoursTotal + ":" + "0" + minutesTotal + ":" + secondsTotal; }
            if (hoursTotal <= 9 && minutesTotal <= 9 && secondsTotal <= 9) { totalTimeDisplayHUD.text = "0" + hoursTotal + ":" + "0" + minutesTotal + ":" + "0" + secondsTotal; }

            adaptiveReadingTextbox.GetComponent<RectTransform>().anchoredPosition = Vector2.LerpUnclamped(startPosition, endPosition, percentageOfLerpCompletion);
        }

        else if (currentTime < timeRequiredForTextboxToLeaveOffScreen)
        {
            if (Input.GetKey(KeyCode.Alpha1)) //Go backwards in time x 1.
            {
                GoBackwardsInTimeX40();
            }

            if (Input.GetKey(KeyCode.Alpha2)) //Go backwards in time x 1.
            {
                GoBackwardsInTimeX10();
            }

            if (Input.GetKey(KeyCode.Alpha3)) //Go backwards in time x 1.
            {
                GoBackwardsInTimeX1();
            }

            if (Input.GetKey(KeyCode.Alpha4)) //Go forwards in time x 1.
            {
                GoForwardInTimeX1();
            }

            if (Input.GetKey(KeyCode.Alpha5)) //Go forwards in time x 1.
            {
                GoForwardInTimeX10();
            }

            if (Input.GetKey(KeyCode.Alpha6)) //Go forwards in time x 1.
            {
                GoForwardInTimeX40();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (AdaptiveReaderResumeIsEnabled)
                {
                    AdaptiveReaderPause();
                }

                else
                {
                    AdaptiveReaderResume();
                }
            }

            currentTime = currentTime + Time.smoothDeltaTime;
            percentageOfLerpCompletion = currentTime / timeRequiredForTextboxToLeaveOffScreen;

            //For current time:
            int daysCurrent = (int)(currentTime / 86400) % 365;
            int hoursCurrent = (int)(currentTime / 3600) % 24;
            int minutesCurrent = (int)(currentTime / 60) % 60;
            int secondsCurrent = (int)(currentTime % 60);
            if (hoursCurrent >= 9 && minutesCurrent >= 9 && secondsCurrent >= 9) { currentTimeDisplayHUD.text = hoursCurrent + ":" + minutesCurrent + ":" + secondsCurrent; }
            if (hoursCurrent >= 9 && minutesCurrent >= 9 && secondsCurrent <= 9) { currentTimeDisplayHUD.text = hoursCurrent + ":" + minutesCurrent + ":" + "0" + secondsCurrent; }
            if (hoursCurrent >= 9 && minutesCurrent <= 9 && secondsCurrent >= 9) { currentTimeDisplayHUD.text = hoursCurrent + ":" + "0" + minutesCurrent + ":" + secondsCurrent; }
            if (hoursCurrent >= 9 && minutesCurrent <= 9 && secondsCurrent <= 9) { currentTimeDisplayHUD.text = hoursCurrent + ":" + "0" + minutesCurrent + ":" + "0" + secondsCurrent; }

            if (hoursCurrent <= 9 && minutesCurrent >= 9 && secondsCurrent >= 9) { currentTimeDisplayHUD.text = "0" + hoursCurrent + ":" + minutesCurrent + ":" + secondsCurrent; }
            if (hoursCurrent <= 9 && minutesCurrent >= 9 && secondsCurrent <= 9) { currentTimeDisplayHUD.text = "0" + hoursCurrent + ":" + minutesCurrent + ":" + "0" + secondsCurrent; }
            if (hoursCurrent <= 9 && minutesCurrent <= 9 && secondsCurrent >= 9) { currentTimeDisplayHUD.text = "0" + hoursCurrent + ":" + "0" + minutesCurrent + ":" + secondsCurrent; }
            if (hoursCurrent <= 9 && minutesCurrent <= 9 && secondsCurrent <= 9) { currentTimeDisplayHUD.text = "0" + hoursCurrent + ":" + "0" + minutesCurrent + ":" + "0" + secondsCurrent; }

            //For total time:
            int daysTotal = (int)(timeRequiredForTextboxToLeaveOffScreen / 86400) % 365;
            int hoursTotal = (int)(timeRequiredForTextboxToLeaveOffScreen / 3600) % 24;
            int minutesTotal = (int)(timeRequiredForTextboxToLeaveOffScreen / 60) % 60;
            int secondsTotal = (int)(timeRequiredForTextboxToLeaveOffScreen % 60);
            if (hoursTotal >= 9 && minutesTotal >= 9 && secondsTotal >= 9) { totalTimeDisplayHUD.text = hoursTotal + ":" + minutesTotal + ":" + secondsTotal; }
            if (hoursTotal >= 9 && minutesTotal >= 9 && secondsTotal <= 9) { totalTimeDisplayHUD.text = hoursTotal + ":" + minutesTotal + ":" + "0" + secondsTotal; }
            if (hoursTotal >= 9 && minutesTotal <= 9 && secondsTotal >= 9) { totalTimeDisplayHUD.text = hoursTotal + ":" + "0" + minutesTotal + ":" + secondsTotal; }
            if (hoursTotal >= 9 && minutesTotal <= 9 && secondsTotal <= 9) { totalTimeDisplayHUD.text = hoursTotal + ":" + "0" + minutesTotal + ":" + "0" + secondsTotal; }

            if (hoursTotal <= 9 && minutesTotal >= 9 && secondsTotal >= 9) { totalTimeDisplayHUD.text = "0" + hoursTotal + ":" + minutesTotal + ":" + secondsTotal; }
            if (hoursTotal <= 9 && minutesTotal >= 9 && secondsTotal <= 9) { totalTimeDisplayHUD.text = "0" + hoursTotal + ":" + minutesTotal + ":" + "0" + secondsTotal; }
            if (hoursTotal <= 9 && minutesTotal <= 9 && secondsTotal >= 9) { totalTimeDisplayHUD.text = "0" + hoursTotal + ":" + "0" + minutesTotal + ":" + secondsTotal; }
            if (hoursTotal <= 9 && minutesTotal <= 9 && secondsTotal <= 9) { totalTimeDisplayHUD.text = "0" + hoursTotal + ":" + "0" + minutesTotal + ":" + "0" + secondsTotal; }

            adaptiveReadingTextbox.GetComponent<RectTransform>().anchoredPosition = Vector2.LerpUnclamped(startPosition, endPosition, percentageOfLerpCompletion);
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (PauseIsEnabled)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }

        if (dropdownAverageCharactersPerWord.value == 0) //4 words
        {
            averageCharactersPerWord = 4f;

            numberOfCharactersPerMinute = averageCharactersPerWord * wordsPerMinuteRates;
            timeRequiredForTextboxToLeaveOffScreen = numberOfCharactersIncludingSpaces / numberOfCharactersPerMinute * 60;

            //Current Time Readjustment:
            newAverageCharactersPerWord = 4f;
            currentTime = currentTime * (oldAverageCharactersPerWord / newAverageCharactersPerWord);
            oldAverageCharactersPerWord = 4f;
        }

        if (dropdownAverageCharactersPerWord.value == 1) //5 words
        {
            averageCharactersPerWord = 5f;

            numberOfCharactersPerMinute = averageCharactersPerWord * wordsPerMinuteRates;
            timeRequiredForTextboxToLeaveOffScreen = numberOfCharactersIncludingSpaces / numberOfCharactersPerMinute * 60;

            //Current Time Readjustment:
            newAverageCharactersPerWord = 5f;
            currentTime = currentTime * (oldAverageCharactersPerWord / newAverageCharactersPerWord);
            oldAverageCharactersPerWord = 5f;
        }

        if (dropdownAverageCharactersPerWord.value == 2) //6 words
        {
            averageCharactersPerWord = 6f;

            numberOfCharactersPerMinute = averageCharactersPerWord * wordsPerMinuteRates;
            timeRequiredForTextboxToLeaveOffScreen = numberOfCharactersIncludingSpaces / numberOfCharactersPerMinute * 60;

            //Current Time Readjustment:
            newAverageCharactersPerWord = 6f;
            currentTime = currentTime * (oldAverageCharactersPerWord / newAverageCharactersPerWord);
            oldAverageCharactersPerWord = 6f;
        }


        if (dropdownWordsPerMinuteRates.value == 0) //85 wpm
        {
            wordsPerMinuteRates = 85f;

            numberOfCharactersPerMinute = averageCharactersPerWord * wordsPerMinuteRates;
            timeRequiredForTextboxToLeaveOffScreen = numberOfCharactersIncludingSpaces / numberOfCharactersPerMinute * 60;

            //Current Time Readjustment:
            newWordsPerMinuteRate = 85f;
            currentTime = currentTime * (oldWordsPerMinuteRate / newWordsPerMinuteRate);
            oldWordsPerMinuteRate = 85f;
        }

        if (dropdownWordsPerMinuteRates.value == 1) //105 wpm
        {
            wordsPerMinuteRates = 105f;

            numberOfCharactersPerMinute = averageCharactersPerWord * wordsPerMinuteRates;
            timeRequiredForTextboxToLeaveOffScreen = numberOfCharactersIncludingSpaces / numberOfCharactersPerMinute * 60;

            //Current Time Readjustment:
            newWordsPerMinuteRate = 105f;
            currentTime = currentTime * (oldWordsPerMinuteRate/newWordsPerMinuteRate);
            oldWordsPerMinuteRate = 105f;
        }

        if (dropdownWordsPerMinuteRates.value == 2) //143 wpm
        {
            wordsPerMinuteRates = 143f;

            numberOfCharactersPerMinute = averageCharactersPerWord * wordsPerMinuteRates;
            timeRequiredForTextboxToLeaveOffScreen = numberOfCharactersIncludingSpaces / numberOfCharactersPerMinute * 60;

            //Current Time Readjustment:
            newWordsPerMinuteRate = 143f;
            currentTime = currentTime * (oldWordsPerMinuteRate / newWordsPerMinuteRate);
            oldWordsPerMinuteRate = 143f;
        }

        if (dropdownWordsPerMinuteRates.value == 3) //173 wpm
        {
            wordsPerMinuteRates = 173f;

            numberOfCharactersPerMinute = averageCharactersPerWord * wordsPerMinuteRates;
            timeRequiredForTextboxToLeaveOffScreen = numberOfCharactersIncludingSpaces / numberOfCharactersPerMinute * 60;

            //Current Time Readjustment:
            newWordsPerMinuteRate = 173f;
            currentTime = currentTime * (oldWordsPerMinuteRate / newWordsPerMinuteRate);
            oldWordsPerMinuteRate = 173f;
        }

        if (dropdownWordsPerMinuteRates.value == 4) //205 wpm
        {
            wordsPerMinuteRates = 205f;

            numberOfCharactersPerMinute = averageCharactersPerWord * wordsPerMinuteRates;
            timeRequiredForTextboxToLeaveOffScreen = numberOfCharactersIncludingSpaces / numberOfCharactersPerMinute * 60;

            //Current Time Readjustment:
            newWordsPerMinuteRate = 205f;
            currentTime = currentTime * (oldWordsPerMinuteRate / newWordsPerMinuteRate);
            oldWordsPerMinuteRate = 205f;
        }

        if (dropdownWordsPerMinuteRates.value == 5) //240 wpm
        {
            wordsPerMinuteRates = 240f;

            numberOfCharactersPerMinute = averageCharactersPerWord * wordsPerMinuteRates;
            timeRequiredForTextboxToLeaveOffScreen = numberOfCharactersIncludingSpaces / numberOfCharactersPerMinute * 60;

            //Current Time Readjustment:
            newWordsPerMinuteRate = 240f;
            currentTime = currentTime * (oldWordsPerMinuteRate / newWordsPerMinuteRate);
            oldWordsPerMinuteRate = 240f;
        }

        if (dropdownWordsPerMinuteRates.value == 6) //275 wpm
        {
            wordsPerMinuteRates = 275f;

            numberOfCharactersPerMinute = averageCharactersPerWord * wordsPerMinuteRates;
            timeRequiredForTextboxToLeaveOffScreen = numberOfCharactersIncludingSpaces / numberOfCharactersPerMinute * 60;

            //Current Time Readjustment:
            newWordsPerMinuteRate = 275f;
            currentTime = currentTime * (oldWordsPerMinuteRate / newWordsPerMinuteRate);
            oldWordsPerMinuteRate = 275f;
        }

        if (dropdownFontSize.value == 0) //Font size 42.
        {
            adaptiveReadingTextbox.GetComponent<TextMeshProUGUI>().fontSize = 42;
            setFontSize = 42;

            widthOfTextboxInUnity = (numberOfCharactersIncludingSpaces * setFontSize) / twoPointFourEightTwoFive;
            adaptiveReadingTextbox.GetComponent<RectTransform>().sizeDelta = new Vector2(widthOfTextboxInUnity, setFontSize);

            distanceForTextboxToBeUpAgainstScreenRightEdge = half * widthOfTextboxInUnity + half * screenWidthSize;
            startPosition = new Vector2(distanceForTextboxToBeUpAgainstScreenRightEdge, 0);
            endPosition = new Vector2(-distanceForTextboxToBeUpAgainstScreenRightEdge, 0);

            //Current Time Readjustment:
            newFontSize = 42f;
            currentTime = currentTime * (oldFontSize / newFontSize);
            oldFontSize = 42f;
        }

        if (dropdownFontSize.value == 1) //Font size 48.
        {
            adaptiveReadingTextbox.GetComponent<TextMeshProUGUI>().fontSize = 48;
            setFontSize = 48;

            widthOfTextboxInUnity = (numberOfCharactersIncludingSpaces * setFontSize) / twoPointFourEightTwoFive;
            adaptiveReadingTextbox.GetComponent<RectTransform>().sizeDelta = new Vector2(widthOfTextboxInUnity, setFontSize);

            distanceForTextboxToBeUpAgainstScreenRightEdge = half * widthOfTextboxInUnity + half * screenWidthSize;
            startPosition = new Vector2(distanceForTextboxToBeUpAgainstScreenRightEdge, 0);
            endPosition = new Vector2(-distanceForTextboxToBeUpAgainstScreenRightEdge, 0);

            //Current Time Readjustment:
            newFontSize = 48f;
            currentTime = currentTime * (oldFontSize / newFontSize);
            oldFontSize = 48f;
        }

        if (dropdownFontSize.value == 2) //Font size 54.
        {
            adaptiveReadingTextbox.GetComponent<TextMeshProUGUI>().fontSize = 54;
            setFontSize = 54;

            widthOfTextboxInUnity = (numberOfCharactersIncludingSpaces * setFontSize) / twoPointFourEightTwoFive;
            adaptiveReadingTextbox.GetComponent<RectTransform>().sizeDelta = new Vector2(widthOfTextboxInUnity, setFontSize);

            distanceForTextboxToBeUpAgainstScreenRightEdge = half * widthOfTextboxInUnity + half * screenWidthSize;
            startPosition = new Vector2(distanceForTextboxToBeUpAgainstScreenRightEdge, 0);
            endPosition = new Vector2(-distanceForTextboxToBeUpAgainstScreenRightEdge, 0);

            //Current Time Readjustment:
            newFontSize = 54f;
            currentTime = currentTime * (oldFontSize / newFontSize);
            oldFontSize = 54f;
        }

        if (dropdownFontSize.value == 3) //Font size 60.
        {
            adaptiveReadingTextbox.GetComponent<TextMeshProUGUI>().fontSize = 60;
            setFontSize = 60;

            widthOfTextboxInUnity = (numberOfCharactersIncludingSpaces * setFontSize) / twoPointFourEightTwoFive;
            adaptiveReadingTextbox.GetComponent<RectTransform>().sizeDelta = new Vector2(widthOfTextboxInUnity, setFontSize);

            distanceForTextboxToBeUpAgainstScreenRightEdge = half * widthOfTextboxInUnity + half * screenWidthSize;
            startPosition = new Vector2(distanceForTextboxToBeUpAgainstScreenRightEdge, 0);
            endPosition = new Vector2(-distanceForTextboxToBeUpAgainstScreenRightEdge, 0);

            //Current Time Readjustment:
            newFontSize = 60f;
            currentTime = currentTime * (oldFontSize / newFontSize);
            oldFontSize = 60f;
        }

        if (dropdownFontSize.value == 4) //Font size 66.
        {
            adaptiveReadingTextbox.GetComponent<TextMeshProUGUI>().fontSize = 66;
            setFontSize = 66;

            widthOfTextboxInUnity = (numberOfCharactersIncludingSpaces * setFontSize) / twoPointFourEightTwoFive;
            adaptiveReadingTextbox.GetComponent<RectTransform>().sizeDelta = new Vector2(widthOfTextboxInUnity, setFontSize);

            distanceForTextboxToBeUpAgainstScreenRightEdge = half * widthOfTextboxInUnity + half * screenWidthSize;
            startPosition = new Vector2(distanceForTextboxToBeUpAgainstScreenRightEdge, 0);
            endPosition = new Vector2(-distanceForTextboxToBeUpAgainstScreenRightEdge, 0);

            //Current Time Readjustment:
            newFontSize = 66f;
            currentTime = currentTime * (oldFontSize / newFontSize);
            oldFontSize = 66f;
        }

        if (dropdownFontSize.value == 5) //Font size 72.
        {
            adaptiveReadingTextbox.GetComponent<TextMeshProUGUI>().fontSize = 72;
            setFontSize = 72;

            widthOfTextboxInUnity = (numberOfCharactersIncludingSpaces * setFontSize) / twoPointFourEightTwoFive;
            adaptiveReadingTextbox.GetComponent<RectTransform>().sizeDelta = new Vector2(widthOfTextboxInUnity, setFontSize);

            distanceForTextboxToBeUpAgainstScreenRightEdge = half * widthOfTextboxInUnity + half * screenWidthSize;
            startPosition = new Vector2(distanceForTextboxToBeUpAgainstScreenRightEdge, 0);
            endPosition = new Vector2(-distanceForTextboxToBeUpAgainstScreenRightEdge, 0);

            //Current Time Readjustment:
            newFontSize = 72f;
            currentTime = currentTime * (oldFontSize / newFontSize);
            oldFontSize = 72f;
        }

        if (dropdownFontSize.value == 6) //Font size 78.
        {
            adaptiveReadingTextbox.GetComponent<TextMeshProUGUI>().fontSize = 78;
            setFontSize = 78;

            widthOfTextboxInUnity = (numberOfCharactersIncludingSpaces * setFontSize) / twoPointFourEightTwoFive;
            adaptiveReadingTextbox.GetComponent<RectTransform>().sizeDelta = new Vector2(widthOfTextboxInUnity, setFontSize);

            distanceForTextboxToBeUpAgainstScreenRightEdge = half * widthOfTextboxInUnity + half * screenWidthSize;
            startPosition = new Vector2(distanceForTextboxToBeUpAgainstScreenRightEdge, 0);
            endPosition = new Vector2(-distanceForTextboxToBeUpAgainstScreenRightEdge, 0);

            //Current Time Readjustment:
            newFontSize = 78f;
            currentTime = currentTime * (oldFontSize / newFontSize);
            oldFontSize = 78f;
        }

        if (dropdownFontSize.value == 7) //Font size 84.
        {
            adaptiveReadingTextbox.GetComponent<TextMeshProUGUI>().fontSize = 84;
            setFontSize = 84;

            widthOfTextboxInUnity = (numberOfCharactersIncludingSpaces * setFontSize) / twoPointFourEightTwoFive;
            adaptiveReadingTextbox.GetComponent<RectTransform>().sizeDelta = new Vector2(widthOfTextboxInUnity, setFontSize);

            distanceForTextboxToBeUpAgainstScreenRightEdge = half * widthOfTextboxInUnity + half * screenWidthSize;
            startPosition = new Vector2(distanceForTextboxToBeUpAgainstScreenRightEdge, 0);
            endPosition = new Vector2(-distanceForTextboxToBeUpAgainstScreenRightEdge, 0);

            //Current Time Readjustment:
            newFontSize = 84f;
            currentTime = currentTime * (oldFontSize / newFontSize);
            oldFontSize = 84f;
        }

        if (dropdownFontSize.value == 8) //Font size 90.
        {
            adaptiveReadingTextbox.GetComponent<TextMeshProUGUI>().fontSize = 90;
            setFontSize = 90;

            widthOfTextboxInUnity = (numberOfCharactersIncludingSpaces * setFontSize) / twoPointFourEightTwoFive;
            adaptiveReadingTextbox.GetComponent<RectTransform>().sizeDelta = new Vector2(widthOfTextboxInUnity, setFontSize);

            distanceForTextboxToBeUpAgainstScreenRightEdge = half * widthOfTextboxInUnity + half * screenWidthSize;
            startPosition = new Vector2(distanceForTextboxToBeUpAgainstScreenRightEdge, 0);
            endPosition = new Vector2(-distanceForTextboxToBeUpAgainstScreenRightEdge, 0);

            //Current Time Readjustment:
            newFontSize = 90f;
            currentTime = currentTime * (oldFontSize / newFontSize);
            oldFontSize = 90f;
        }
    }

    public void GoBackwardsInTimeX1()
    {
        if (currentTime >= 0)
        {
            currentTime = currentTime - 0.1f;
            percentageOfLerpCompletion = percentageOfLerpCompletion - 0.1f;
        }
    }

    public void GoBackwardsInTimeX10()
    {
        if (currentTime >= 0)
        {
            currentTime = currentTime - 1f;
            percentageOfLerpCompletion = percentageOfLerpCompletion - 1f;
        }
    }

    public void GoBackwardsInTimeX40()
    {
        if (currentTime >= 0)
        {
            currentTime = currentTime - 4f;
            percentageOfLerpCompletion = percentageOfLerpCompletion - 4f;
        }
    }

    public void GoForwardInTimeX1()
    {
        if (currentTime <= timeRequiredForTextboxToLeaveOffScreen)
        {
            currentTime = currentTime + 0.1f;
            percentageOfLerpCompletion = percentageOfLerpCompletion + 0.1f;
        }
    }

    public void GoForwardInTimeX10()
    {
        if (currentTime <= timeRequiredForTextboxToLeaveOffScreen)
        {
            currentTime = currentTime + 1f;
            percentageOfLerpCompletion = percentageOfLerpCompletion + 1f;
        }
    }

    public void GoForwardInTimeX40()
    {
        if (currentTime <= timeRequiredForTextboxToLeaveOffScreen)
        {
            currentTime = currentTime + 4f;
            percentageOfLerpCompletion = percentageOfLerpCompletion + 4f;
        }
    }

    public void Resume()
    {
        pauseScreenUI.SetActive(false);
        PauseIsEnabled = false;
    }

    public void Pause()
    {
        pauseScreenUI.SetActive(true);
        Time.timeScale = 0f;
        PauseIsEnabled = true;
    }

    public void AdaptiveReaderResume()
    {
        adaptiveReaderPlayButton.SetActive(false);
        adaptiveReaderPauseButton.SetActive(true);
        Time.timeScale = 1f;
        AdaptiveReaderResumeIsEnabled = true;
    }

    public void AdaptiveReaderPause()
    {
        adaptiveReaderPauseButton.SetActive(false);
        adaptiveReaderPlayButton.SetActive(true);
        Time.timeScale = 0f;
        AdaptiveReaderResumeIsEnabled = false;
    }

    public void GoToNextChapterButtonPressed()
    {
        sceneLoader.GoToNextChapterInBook();
    }

    public void GoToMainMenuButtonPressed()
    {
        sceneLoader.GoToMainMenu();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq; 

public class SettingsMenu : MonoBehaviour
{
    [Header("Dropdown List")]
    public TMP_Dropdown dropdownAverageCharactersPerWord;
    public TMP_Dropdown dropdownWordsPerMinuteRates;
    public TMP_Dropdown dropdownFontSize;
    public TMP_Dropdown dropdownScreenWidthSize;

    private bool isFullScreen = false;

    const string averageCharactersPerWordPreferenceName = "averageCharactersPerWordValue";

    public Dictionary<string, int> AverageCharactersPerWordDatabase = new Dictionary<string, int>()
    {
        { "Five", 5 },
        { "Six", 6 },
        { "Seven", 7 }
    };



    private void Awake()
    {
        if (dropdownAverageCharactersPerWord != null)
        {
            dropdownAverageCharactersPerWord.AddOptions(AverageCharactersPerWordDatabase.Keys.ToList());
            dropdownAverageCharactersPerWord.onValueChanged.AddListener(new UnityAction<int>(index =>
            {

                PlayerPrefs.SetInt(averageCharactersPerWordPreferenceName, dropdownAverageCharactersPerWord.value);
                PlayerPrefs.Save();
            }));
        }
    }




}

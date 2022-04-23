using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContentPreviewOverlayDetails : MonoBehaviour
{
    //Config Param:
    [Header("Content Concept Image")]
    [SerializeField] Sprite contentConceptImage;
    [SerializeField] Image contentConceptImageUI;

    [Header("Content Title Text")]
    [SerializeField] string contentTitleText;
    [SerializeField] Text contentTitleTextUI;

    [Header("Content Title Font")]
    [SerializeField] Font contentTitleFont;

    [Header("Content Title Font Size Override (NOTE: NOT ZERO)")]
    [SerializeField] int contentTitleFontSizeOverride;

    [Header("Author Profile")]
    [SerializeField] Sprite authorProfile;
    [SerializeField] Image authorProfilePlaceholder;

    [Header("Author Name")]
    [SerializeField] string authorName;
    [SerializeField] TextMeshProUGUI authorNameUI;

    [Header("Release Date")]
    [SerializeField] string releaseDate;
    [SerializeField] TextMeshProUGUI releaseDateUI;

    [Header("Content Series")]
    [SerializeField] string contentSeries;
    [SerializeField] TextMeshProUGUI contentSeriesUI;

    [Header("Content Genre")]
    [SerializeField] string contentGenre;
    [SerializeField] TextMeshProUGUI contentGenreUI;

    [Header("Content Synopsis")]
    [TextArea(10, 15)] [SerializeField] string contentSynopsis;
    [SerializeField] TextMeshProUGUI contentSynopsisUI;

    // Start is called before the first frame update
    void Awake()
    {
        //Connect Everything:
        contentConceptImageUI.sprite = contentConceptImage;
        contentTitleTextUI.text = contentTitleText;
        contentTitleTextUI.GetComponent<Text>().font = contentTitleFont;
        authorProfilePlaceholder.sprite = authorProfile;
        authorNameUI.text = authorName;
        releaseDateUI.text = releaseDate;
        contentGenreUI.text = contentGenre;
        contentSeriesUI.text = contentSeries;
        contentSynopsisUI.text = contentSynopsis;

        if (contentTitleFontSizeOverride != 0)
        {
            contentTitleTextUI.GetComponent<Text>().fontSize = contentTitleFontSizeOverride;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

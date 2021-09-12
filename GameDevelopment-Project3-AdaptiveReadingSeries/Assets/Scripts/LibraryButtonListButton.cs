using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LibraryButtonListButton : MonoBehaviour
{
    public enum BookGenre
    {
        Action,
        Action_and_Adventure,
        Adventure,
        Fantasy,
        Horror,
        Mystery,
        Romance,
        Sci_Fi,
        Suspense
    }

    //Cached Reference:
    SceneLoader sceneLoader;


    //Config Param:
    [Header("Text SerializeField")]
    [SerializeField]
    private Image bookCoverOnButton;
    [SerializeField]
    private TextMeshProUGUI bookSeriesOnButton;
    [SerializeField]
    private TextMeshProUGUI bookTitleOnButton;
    [SerializeField]
    private TextMeshProUGUI bookAuthorOnButton;
    //[SerializeField]
    //private BookGenre primaryBookGenreOnButton;
    [SerializeField]
    private TextMeshProUGUI bookGenreOnButton;


    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetBookCover(Sprite sprite)
    {
        bookCoverOnButton.sprite = sprite;
    }

    public void SetBookSeries(string textString)
    {
        bookSeriesOnButton.text = textString;
    }

    public void SetBookTitle(string textString)
    {
        bookTitleOnButton.text = textString;
    }

    public void SetBookAuthor(string textString)
    {
        bookAuthorOnButton.text = textString;
    }

    //public void SetPrimaryBookGenre(BookGenre bookGenre)
    //{
    //    primaryBookGenreOnButton = bookGenre;
    //}

    public void SetBookGenres(string bookGenre)
    {
        bookGenreOnButton.text = bookGenre;
    }

    public void OnButtonClick()
    {
        if (bookTitleOnButton.text == "Alice's Adventures in Wonderland")
        {
            sceneLoader.GoToBookHubAliceAdventureInWonderland();
        }

        if (bookTitleOnButton.text == "The Great Gatsby")
        {
            sceneLoader.GoToBookHubTheGreatGatsby();
        }

        if (bookTitleOnButton.text == "A Scandal in Bohemia")
        {
            sceneLoader.GoToBookHubAScandalInBohemia();
        }

        if (bookTitleOnButton.text == "Book 1 - The Coming of the Martians")
        {
            sceneLoader.GoToBookHubTheComingOfTheMartians();
        }

        if (bookTitleOnButton.text == "Book 2 - The Earth Under the Martians")
        {
            sceneLoader.GoToBookHubTheEarthUnderTheMartians();
        }
    }
}
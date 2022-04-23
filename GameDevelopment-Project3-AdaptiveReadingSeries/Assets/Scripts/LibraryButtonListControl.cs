using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class LibraryButtonListControl : MonoBehaviour
{
    //Cached Reference:
    SceneLoader sceneLoader;


    //Objects:
    private GameObject orderVariable;


    //Config Param:
    [Header("Section Title")]
    [SerializeField] string sectionTitle;
    [SerializeField] TextMeshProUGUI sectionTitleUI;


    [Header("Number of Books")]
    [SerializeField] int totalSectionNumberOfBooks;

    [Serializable]
    public struct LibraryBooks
    {
        public Sprite bookCover;
        public string bookTitle;
        public string bookAuthor;
    }

    [Header("Library List")]
    [SerializeField] List<LibraryBooks> allSectionLibraryBooks;

    [Header("Button Template")]
    [SerializeField]
    private GameObject buttonTemplate;

    //[Header("Order By Buttons")]
    //public Button orderBySeriesButtonGetComponent;
    //public Button orderByTitleButtonGetComponent;
    //public Button orderByAuthorButtonGetComponent;
    //public Button orderByGenreButtonGetComponent;

    [Header("Input Field")]
    [SerializeField] TMP_InputField searchForBookInputField;
    private string inputFieldStorageVariable;


    // Start is called before the first frame update
    void Start()
    {
        //Setting up cached references:
        sceneLoader = FindObjectOfType<SceneLoader>();


        ////Setting up order library buttons:
        //Button orderBySeriesButton = orderBySeriesButtonGetComponent.GetComponent<Button>();
        //Button orderByTitleButton = orderByTitleButtonGetComponent.GetComponent<Button>();
        //Button orderByAuthorButton = orderByAuthorButtonGetComponent.GetComponent<Button>();
        //Button orderByGenreButton = orderByGenreButtonGetComponent.GetComponent<Button>();

        ////Setting up onClick for order library buttons:
        //orderBySeriesButton.onClick.AddListener(OrderLibraryBySeries);
        //orderByTitleButton.onClick.AddListener(OrderLibraryByTitle);
        //orderByAuthorButton.onClick.AddListener(OrderLibraryByAuthor);
        //orderByGenreButton.onClick.AddListener(OrderLibraryByGenre);


        //Section Header:
        sectionTitleUI.text = sectionTitle;

        //Start with ordering library by series:
        OrderLibrary();


        //Set up library book buttons:
        for (int i = 0; i < totalSectionNumberOfBooks; i++)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject; //This creates the new button.
            button.SetActive(true); //This sets the button active.

            button.GetComponent<LibraryButtonListButton>().SetBookCover(allSectionLibraryBooks[i].bookCover);
            button.GetComponent<LibraryButtonListButton>().SetBookTitle(allSectionLibraryBooks[i].bookTitle);
            button.GetComponent<LibraryButtonListButton>().SetBookAuthor(allSectionLibraryBooks[i].bookAuthor);

            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //THIS CODE DOESN'T WORK. THIS WAS MADE FOR SEARCHING BOOKS.
        //if (orderVariable != null)
        //{
        //    allSectionLibraryBooks = allSectionLibraryBooks.
        //        Where(orderVariable => inputFieldStorageVariable.Contains(orderVariable.bookSeries)).ToList();
        //}

    }

    public void ReadInputField(string typedInputFieldString)
    {
        inputFieldStorageVariable = typedInputFieldString;
        Debug.Log(inputFieldStorageVariable);
    }

    public void OrderLibrary() //
    {
        allSectionLibraryBooks = allSectionLibraryBooks.
            OrderBy(orderVariable => orderVariable.bookTitle).
            ThenBy(orderVariable => orderVariable.bookAuthor).
            ToList();
    }
}
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
    [Header("Number of Books")]
    [SerializeField] int totalNumberOfBooks;

    [Serializable]
    public struct LibraryBooks
    {
        public Sprite bookCover;
        public string bookSeries;
        public string bookTitle;
        public string bookAuthor;
        public string bookGenre;
    }

    [Header("Library List")]
    [SerializeField] List<LibraryBooks> allLibraryBooks;

    [Header("Button Template")]
    [SerializeField]
    private GameObject buttonTemplate;

    [Header("Order By Buttons")]
    public Button orderBySeriesButtonGetComponent;
    public Button orderByTitleButtonGetComponent;
    public Button orderByAuthorButtonGetComponent;
    public Button orderByGenreButtonGetComponent;

    [Header("Input Field")]
    [SerializeField] TMP_InputField searchForBookInputField;
    private string inputFieldStorageVariable;


    // Start is called before the first frame update
    void Start()
    {
        //Setting up cached references:
        sceneLoader = FindObjectOfType<SceneLoader>();


        //Setting up order library buttons:
        Button orderBySeriesButton = orderBySeriesButtonGetComponent.GetComponent<Button>();
        Button orderByTitleButton = orderByTitleButtonGetComponent.GetComponent<Button>();
        Button orderByAuthorButton = orderByAuthorButtonGetComponent.GetComponent<Button>();
        Button orderByGenreButton = orderByGenreButtonGetComponent.GetComponent<Button>();

        //Setting up onClick for order library buttons:
        orderBySeriesButton.onClick.AddListener(OrderLibraryBySeries);
        orderByTitleButton.onClick.AddListener(OrderLibraryByTitle);
        orderByAuthorButton.onClick.AddListener(OrderLibraryByAuthor);
        orderByGenreButton.onClick.AddListener(OrderLibraryByGenre);


        //Start with ordering library by series:
        OrderLibrary();


        //Set up library book buttons:
        for (int i = 0; i < totalNumberOfBooks; i++)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject; //This creates the new button.
            button.SetActive(true); //This sets the button active.

            button.GetComponent<LibraryButtonListButton>().SetBookCover(allLibraryBooks[i].bookCover);
            button.GetComponent<LibraryButtonListButton>().SetBookSeries(allLibraryBooks[i].bookSeries);
            button.GetComponent<LibraryButtonListButton>().SetBookTitle(allLibraryBooks[i].bookTitle);
            button.GetComponent<LibraryButtonListButton>().SetBookAuthor(allLibraryBooks[i].bookAuthor);
            button.GetComponent<LibraryButtonListButton>().SetBookGenres(allLibraryBooks[i].bookGenre);

            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }    
    }

    // Update is called once per frame
    void Update()
    {
        if (orderVariable != null) 
        {
            allLibraryBooks = allLibraryBooks.
                Where(orderVariable => inputFieldStorageVariable.Contains(orderVariable.bookSeries)).ToList();
        }

    }

    public void ReadInputField(string typedInputFieldString)
    {
        inputFieldStorageVariable = typedInputFieldString;
        Debug.Log(inputFieldStorageVariable);
    }

    public void OrderLibrary() //
    {
        allLibraryBooks = allLibraryBooks.
            OrderBy(orderVariable => orderVariable.bookSeries).
            ThenBy(orderVariable => orderVariable.bookTitle).
            ThenBy(orderVariable => orderVariable.bookAuthor).
            ThenBy(orderVariable => orderVariable.bookGenre).
            ToList();
    }

    public void OrderLibraryBySeries() //
    {
        allLibraryBooks = allLibraryBooks.
            OrderBy(orderVariable => orderVariable.bookSeries).
            ThenBy(orderVariable => orderVariable.bookTitle).
            ThenBy(orderVariable => orderVariable.bookAuthor).
            ThenBy(orderVariable => orderVariable.bookGenre).
            ToList();
    }

    public void OrderLibraryByTitle() //
    {
        allLibraryBooks = allLibraryBooks.
            OrderBy(orderVariable => orderVariable.bookTitle).
            ThenBy(orderVariable => orderVariable.bookSeries).
            ThenBy(orderVariable => orderVariable.bookAuthor).
            ThenBy(orderVariable => orderVariable.bookGenre).
            ToList();
    }

    public void OrderLibraryByAuthor() //
    {
        allLibraryBooks = allLibraryBooks.
            OrderBy(orderVariable => orderVariable.bookAuthor).
            ThenBy(orderVariable => orderVariable.bookSeries).
            ThenBy(orderVariable => orderVariable.bookTitle).
            ThenBy(orderVariable => orderVariable.bookGenre).
            ToList();
    }

    public void OrderLibraryByGenre() //
    {
        allLibraryBooks = allLibraryBooks.
            OrderBy(orderVariable => orderVariable.bookGenre).
            ThenBy(orderVariable => orderVariable.bookSeries).
            ThenBy(orderVariable => orderVariable.bookTitle).
            ThenBy(orderVariable => orderVariable.bookAuthor).
            ToList();
    }
}

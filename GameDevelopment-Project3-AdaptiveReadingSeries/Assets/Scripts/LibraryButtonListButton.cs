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
    ContentPreviewOverlayControl contentPreviewOverlayControl;


    //Config Param:
    [Header("Text SerializeField")]
    [SerializeField]
    private Image bookCoverOnButton;
    [SerializeField]
    private TextMeshProUGUI bookTitleOnButton;
    [SerializeField]
    private TextMeshProUGUI bookAuthorOnButton;


    // Start is called before the first frame update
    void Start()
    {
        contentPreviewOverlayControl = FindObjectOfType<ContentPreviewOverlayControl>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetBookCover(Sprite sprite)
    {
        bookCoverOnButton.sprite = sprite;
    }

    public void SetBookTitle(string textString)
    {
        bookTitleOnButton.text = textString;
    }

    public void SetBookAuthor(string textString)
    {
        bookAuthorOnButton.text = textString;
    }

    public void OnButtonClick()
    {
        if (bookTitleOnButton.text == "Alice's Adventures in Wonderland")
        {
            contentPreviewOverlayControl.OpenAlice_s_Adventures_In_Wonderland_By_Lewis_Carroll();

            //if (bookAuthorOnButton.text == "Lewis Carroll")
            //{
            //    contentPreviewOverlayControl.OpenAlice_s_Adventures_In_Wonderland_By_Lewis_Carroll();
            //}
        }

        if (bookTitleOnButton.text == "The Great Gatsby")
        {
            if (bookAuthorOnButton.text == "F. Scott Fitzgerald")
            {
                contentPreviewOverlayControl.OpenThe_Great_Gatsby_By_F_Scott_Fitzgerald();
            }
        }

        if (bookTitleOnButton.text == "A Scandal in Bohemia")
        {
            if (bookAuthorOnButton.text == "Arthur Conan Doyle")
            {
                contentPreviewOverlayControl.OpenA_Scandal_In_Bohemia_By_Arthur_Conan_Doyle();
            }
        }

        if (bookTitleOnButton.text == "Book 1 - The Coming of the Martians")
        {
            if (bookAuthorOnButton.text == "H. G. Wells")
            {
                contentPreviewOverlayControl.OpenBook_1_The_Coming_Of_The_Martians_By_H_G_Wells();
            }
        }

        if (bookTitleOnButton.text == "Book 2 - The Earth under the Martians")
        {
            if (bookAuthorOnButton.text == "H. G. Wells")
            {
                contentPreviewOverlayControl.OpenBook_2_The_Earth_Under_The_Martians_By_H_G_Wells();
            }
        }
    }
}
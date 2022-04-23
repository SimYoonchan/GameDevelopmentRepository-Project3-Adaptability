using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentPreviewOverlayControl : MonoBehaviour
{
    [Header("Content Item Overlays")]
    [SerializeField] GameObject Alice_s_Adventures_In_Wonderland_By_Lewis_Carroll;
    [SerializeField] GameObject The_Great_Gatsby_By_F_Scott_Fitzgerald;
    [SerializeField] GameObject A_Scandal_In_Bohemia_By_Arthur_Conan_Doyle;
    [SerializeField] GameObject Book_1_The_Coming_Of_The_Martians_By_H_G_Wells;
    [SerializeField] GameObject Book_2_The_Earth_Under_The_Martians_By_H_G_Wells;

    // Start is called before the first frame update
    void Start()
    {
        //Content Item Overlays Boolean ON/OFF:
        Alice_s_Adventures_In_Wonderland_By_Lewis_Carroll.SetActive(false);
        The_Great_Gatsby_By_F_Scott_Fitzgerald.SetActive(false);
        A_Scandal_In_Bohemia_By_Arthur_Conan_Doyle.SetActive(false);
        Book_1_The_Coming_Of_The_Martians_By_H_G_Wells.SetActive(false);
        Book_2_The_Earth_Under_The_Martians_By_H_G_Wells.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenAlice_s_Adventures_In_Wonderland_By_Lewis_Carroll()
    {
        Alice_s_Adventures_In_Wonderland_By_Lewis_Carroll.SetActive(true);
    }

    public void CloseAlice_s_Adventures_In_Wonderland_By_Lewis_Carroll()
    {
        Alice_s_Adventures_In_Wonderland_By_Lewis_Carroll.SetActive(false);
    }

    public void OpenThe_Great_Gatsby_By_F_Scott_Fitzgerald()
    {
        The_Great_Gatsby_By_F_Scott_Fitzgerald.SetActive(true);
    }

    public void CloseThe_Great_Gatsby_By_F_Scott_Fitzgerald()
    {
        The_Great_Gatsby_By_F_Scott_Fitzgerald.SetActive(false);
    }

    public void OpenA_Scandal_In_Bohemia_By_Arthur_Conan_Doyle()
    {
        A_Scandal_In_Bohemia_By_Arthur_Conan_Doyle.SetActive(true);
    }

    public void CloseA_Scandal_In_Bohemia_By_Arthur_Conan_Doyle()
    {
        A_Scandal_In_Bohemia_By_Arthur_Conan_Doyle.SetActive(false);
    }

    public void OpenBook_1_The_Coming_Of_The_Martians_By_H_G_Wells()
    {
        Book_1_The_Coming_Of_The_Martians_By_H_G_Wells.SetActive(true);
    }

    public void CloseBook_1_The_Coming_Of_The_Martians_By_H_G_Wells()
    {
        Book_1_The_Coming_Of_The_Martians_By_H_G_Wells.SetActive(false);
    }

    public void OpenBook_2_The_Earth_Under_The_Martians_By_H_G_Wells()
    {
        Book_2_The_Earth_Under_The_Martians_By_H_G_Wells.SetActive(true);
    }

    public void CloseBook_2_The_Earth_Under_The_Martians_By_H_G_Wells()
    {
        Book_2_The_Earth_Under_The_Martians_By_H_G_Wells.SetActive(false);
    }



}

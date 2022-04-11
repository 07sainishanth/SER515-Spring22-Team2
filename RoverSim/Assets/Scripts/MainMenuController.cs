using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public Slider mapSizeSlider;
    public Slider objectCountSlider;

    // Handle the event when clicking the Start button
    public void clickStartButton()
    {
        Debug.Log("Starting the simulation...");
        SceneManager.LoadScene("NavigationScene");
    }

    // Handle the event when clicking the Options button
    public void clickOptionsButton()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
        mapSizeSlider.value = EnvironmentSettings.mapSliderValue;
        objectCountSlider.value = EnvironmentSettings.objectSliderValue;
    }

    // Handle the event when clicking the Back button
    public void clickBackButton()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    // Handle the event when clicking the Quit button
    public void clickQuitButton()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}

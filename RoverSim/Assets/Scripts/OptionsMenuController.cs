using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject simulationOptions;
    public GameObject environmentOptions;

    // Handle the event when clicking the Start button
    public void clickDoSimulationButton()
    {
        Debug.Log("Starting the simulation...");
        SceneManager.LoadScene("NavigationScene");
    }

    // Handle the event when clicking the Options button
    public void clickAddEnvironmentButton()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    // Handle the event when clicking the Back button
    public void clickBackButton()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

   
}

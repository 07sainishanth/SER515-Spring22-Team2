using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
   // public GameObject simulationOptions;
    public GameObject addEnvironmentMenu;
    public GameObject addRoverMenu;

    // Handle the event when clicking the Do Simulation button
    public void clickDoSimulationButton()
    {
        Debug.Log("Starting the simulation...");
        SceneManager.LoadScene("NavigationScene");
    }

    // Handle the event when clicking the AddEnvironmenr button
    public void clickAddEnvironmentButton()
    {
        addEnvironmentMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    // Handle the event when clicking the add rover button
    public void clickAddRoverButton()
    {
        addRoverMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

   
}

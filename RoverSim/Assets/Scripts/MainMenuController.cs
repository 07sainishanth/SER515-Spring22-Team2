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
    public Slider pyramidCountSlider;
    public Slider monolithCountSlider;
    public Slider boulderCountSlider;

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
        pyramidCountSlider.value = EnvironmentSettings.pyramidCountValue;
        monolithCountSlider.value = EnvironmentSettings.monolithCountValue;
        boulderCountSlider.value = EnvironmentSettings.boulderCountValue;
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

    // Handle the event when selecting the robot model
    public void selectRobot(int sel)
    {
        switch (sel)
        {
            case 0:
                EnvironmentSettings.robot = EnvironmentSettings.Robot.TURTLEBOT;
                break;
            case 1:
                EnvironmentSettings.robot = EnvironmentSettings.Robot.GOPIGO;
                break;
            case 2:
                EnvironmentSettings.robot = EnvironmentSettings.Robot.P_DESTROYER;
                break;
        }
    }

    public void toggleWater(bool sel)
    {
        if (sel)
        {
            EnvironmentSettings.water = true;
        }
        else
        {
            EnvironmentSettings.water = false;
        }
    }
}

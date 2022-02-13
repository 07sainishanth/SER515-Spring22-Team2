using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationToolbarController : MonoBehaviour
{
    // Handle the event when clicking the Back button
    public void clickBackButton()
    {
        Debug.Log("Exiting simulation environment...");
        SceneManager.LoadScene("TitleScene");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>
/// Controller warning.cs
/// Eelco Los
/// 04-01-2019
/// </summary>

public class ControllerWarning : ControllerManager
{
    public Texture2D _controllerWarningBackground;                  // Creates slot in inspector to assign the controller warning background
    public Texture2D _controllerWarningText;                        // Creates slot in inspector to assign the controller warning text message
    public Texture2D _controllerDetectedText;                       // Creates slot in inspector to assign the controller detected text message

    public float _controllerWarningFadeValue;                       // Defines the fade value of the warning text
    private float _controllerWarningFadeSpeed = 0.25f;              // Defines the fade speed
    private bool _controllerConditionsMet;                          // Defines if the controller conditions are met for the game to continue

    // Start is called before the first frame update
    void Start()
    {
        _controllerWarningFadeValue = 1;                            // Fade value equals one on startup
        _controllerConditionsMet = false;                           // Controller conditions met is false on start up
    }

    // Update is called once per frame
    void Update()
    {
        if (_controllerDetected == true)                            // if controller detected equals true
            StartCoroutine("WaitToLoadMainMenu");                 
        if (!_controllerConditionsMet)                              // if controller condition met equals false
            return;

        if(_controllerConditionsMet)                                // if controller condition met equals true
        {
            _controllerWarningFadeValue-=                           // Decrease fade value
                _controllerWarningFadeSpeed                         // by fade speed
                * Time.deltaTime;                                   // times delta time
        }

        if (_controllerWarningFadeValue < 0)                        // if fade value goes below zero
            _controllerWarningFadeValue = 0;                        // then set fade value to zero
        
        if (_controllerWarningFadeValue == 0)                       // if fade value equals zero
        {
            _startupFinished = true;
            SceneManager.LoadScene("MainMenu");
        }
    }

    private IEnumerator WaitToLoadMainMenu()
    {
        yield return new WaitForSeconds(2);                         // Wait for this (x) many seconds

        _controllerConditionsMet = true;                            // Set controller conditions met to true
    }

    private void OnGUI()
    {
        var rect = new Rect(0, 0,                                  // Draw texture starting at 0,0
         Screen.width, Screen.height);                              // by the screen width and height
        GUI.DrawTexture(rect, _controllerWarningBackground);        // draw the warning background

        GUI.color = new Color(1,1,1,                                // GUI color is equal to 1 1 1 (rgb default)
        _controllerWarningFadeValue);                               // plus the fade value

        GUI.DrawTexture(rect, _controllerWarningText);              // Draw the controller warning text

        if(_controllerDetected)                                     // if controller detected equals true
            GUI.DrawTexture(rect, _controllerDetectedText);         // draw the controller detected text
    }
}

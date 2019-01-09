﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]                                     // Add audio source when attaching script
public class MainMenu : MonoBehaviour
{
    public int _selectedButton = 0;                                         // Defines selected GUI Button
    public float _timeBetweenButtonPress = 0.1f;                            // Defines delay time between button presses
    public float _timeDelay;                                                // Defines delay variable value

    public float _mainMenuVerticalInputTimer;                               // Defines vertical input timer
    public float _mainMenuVerticalInputDelay = 1f;                          // Defines vertical input delay

    public Texture2D _mainMenuBackground;                                   // Creates slot in inspector to assign main menu background

    private AudioSource _mainMenuAudio;                                     // Defines naming convention for the main menu audio Component
    public AudioClip _mainMenuMusic;                                        // Creates slot in inspector to assign main menu music
    public AudioClip _mainMenuStartButtonAudio;                             // Creates slot in inspector to assign main menu start button audio
    public AudioClip _mainMenuQuitButtonAudio;                              // Creates slot in inspector to assign main menu quit button audio

    public float _mainMenuFadeValue;                                        // Defines fade Value
    public float _mainMenuFadeSpeed = 0.15f;                                // Defines fade speed

    public float _mainMenuButtonWidth = 100f;                               // Defines main menu button width size
    public float _mainMenuButtonHeight = 25f;                               // Defines main menu button height size
    
    public float _mainMenuGUIOffset = 10f;                                  // Defines main menu GUI Offset

    private bool _startingOnePlayerGame;                                    // Defines if we are starting a one player game
    private bool _startingTwoPlayerGame;                                    // Defines if we are starting a two player game
    private bool _quittingGame;                                             // Defines if we are quitting the game

    private bool _ps4Controller;                                            // Creates bool when a PS4 Controller is connected
    private bool _xBoxController;                                           // Creates bool when a XBox Controller is connected

    private string[] _mainMenuButtons = new string[]                        // Creates an array of GUI Buttons for the main menu scene
    {
        "_onePlayer",
        "_twoPlayer",
        "_quit"
    };

    private MainMenuController _mainMenuController;                         // Defines naming convention for main menu controller
    private enum MainMenuController                                         // Defines states main menu can exist in
    {
        MainMenuFadeIn = 0,
        MainMenuAtIdle = 1,
        MainMenuFadeOut = 2
    }

    // Start is called before the first frame update
    void Start()
    {
        _startingOnePlayerGame = false;                                     // Starting one player game is false on start up
        _startingTwoPlayerGame = false;                                     // Starting two player game is false on start up
        _quittingGame = false;                                              // Quitting is false on start up

        _ps4Controller = false;                                             // PS4 controller is false on start up
        _xBoxController = false;                                            // XBox controller is false on start up

        _mainMenuFadeValue = 0;                                             // fade value is set to 0 on start up

        _mainMenuAudio = GetComponent<AudioSource>();                       // _mainMenuAudio equals the audio source component
        _mainMenuAudio.volume = 0;                                          // Audio Volume equals 0 on start up
        _mainMenuAudio.clip = _mainMenuMusic;                               // audio clip equals main menu music
        _mainMenuAudio.loop = true;                                         // Set audio to loop
        _mainMenuAudio.Play();                                              // Play the audio

        _mainMenuController = MainMenuController.MainMenuFadeIn;            // State equals fade in on start up

        StartCoroutine("MainMenuManager");                                  // Start MainMenuManager on start up
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator MainMenuManager()
    {
        while (true)
        {
            switch (_mainMenuController)
            {
                case MainMenuController.MainMenuFadeIn:
                    MainMenuFadeIn();
                    break;
                case MainMenuController.MainMenuAtIdle:
                    MainMenuAtIdle();
                    break;
                case MainMenuController.MainMenuFadeOut:
                    MainMenuFadeOut();
                    break;
            }
            yield return null;
        }
    }

    private void MainMenuFadeIn()
    {
        Debug.Log("MainMenuFadeIn");

        _mainMenuAudio.volume += _mainMenuFadeSpeed * Time.deltaTime;       // increase volume by the fade speed
        _mainMenuFadeValue += _mainMenuFadeSpeed * Time.deltaTime;          // increase fade value by the fade speed

        if(_mainMenuFadeValue > 1)                                          // if fade value is greater than 1
            _mainMenuFadeValue = 1;                                         // then make fade value equal to 1
        
        if(_mainMenuFadeValue == 1)                                         // if fade value equals 1
        {
            _mainMenuController = MainMenuController.MainMenuAtIdle;        // then make state equal to main menu at idle
        }
    }
    private void MainMenuAtIdle()
    {
        Debug.Log("MainMenuAtIdle");

        if (_startingOnePlayerGame || _quittingGame)                        // if starting one player game OR quitting equals true
            _mainMenuController = MainMenuController.MainMenuFadeOut;       // then make state equals to main menu fade out
    }
    private void MainMenuFadeOut()
    {
        Debug.Log("MainMenuFadeOut");
        _mainMenuAudio.volume -= _mainMenuFadeSpeed * Time.deltaTime;       // decrease volume by the fade speed
        _mainMenuFadeValue -= _mainMenuFadeSpeed * Time.deltaTime;          // decrease fade value by the fade speed

        if(_mainMenuFadeValue < 0)                                          // if fade value is greater than 0
            _mainMenuFadeValue = 0;                                         // then make fade value equal to 0
        
        if (_mainMenuFadeValue == 0 && _startingOnePlayerGame)              // if fade value equals 0 AND starting one player game is equal to true
            SceneManager.LoadScene("ChooseCharacter");                      // Load choose character scene
    }

    private void MainMenuButtonPress()
    {
        Debug.Log("MainMenuButtonPress");
        GUI.FocusControl(_mainMenuButtons[_selectedButton]);

        switch (_selectedButton)
        {
            case 0:
                _mainMenuAudio.PlayOneShot(_mainMenuStartButtonAudio);      // play start button audio clip
                _startingOnePlayerGame = true;                              // set starting one player game to true
                break;
            case 1:
                _mainMenuAudio.PlayOneShot(_mainMenuStartButtonAudio);      // play start button audio clip
                _startingTwoPlayerGame = true;                              // set starting two player game to true
                break;
            case 2:
                _mainMenuAudio.PlayOneShot(_mainMenuQuitButtonAudio);       // play quit button audio clip
                _quittingGame = true;                                       // set quit game to true
                break;
        }
    }
}

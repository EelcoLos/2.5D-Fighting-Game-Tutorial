using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>
/// Choose character.cs
/// Eelco Los
/// 11-01-2019
/// </summary>

[RequireComponent(typeof(AudioSource))]                             // Add audio source when attaching the script
public class ChooseCharacter : ChooseCharacterManager
{
    public float _chooseCharacterInputTimer;                        // Defines choose character input timer
    public float _chooseCharacterInputDelay = 1f;                   // Defines choose character input delay

    private GameObject _characterDemo;                              // Defines naming convention for selected character game object

    public int _characterSelectState;                               // Defines naming convention for selected character state
    private enum CharacterSelectModels                              // Defines which character to load
    {
        BlackRobot = 0,
        WhiteRobot = 1,
        RedRobot = 2,
        BlueRobot = 3,
        BrownRobot = 4,
        GreenRobot = 5,
        PinkRobot = 6,
        GoldRobot = 7
    }

    // Start is called before the first frame update
    void Start()
    {
        CharacterSelectManager();                                   // Call CharacterSelectManager on start up
    }

    // Update is called once per frame
    void Update()
    {
        if (_chooseCharacterInputTimer > 0)                         // if choose character input timer is greater than 0
            _chooseCharacterInputTimer -= 1f * Time.deltaTime;      // then reduce choose character input timer value

        if (_chooseCharacterInputTimer > 0)                         // if choose character input timer is greater than 0
            return;                                                 // then do nothing and return

        SelectCharacterHorizontal(-0.5f, 0.5f);
    }

    private void SelectCharacterHorizontal(float negativeThreshold, float positiveThreshold)
    {
        if (Input.GetAxis("Horizontal") < negativeThreshold ||       // if input equals horizontal less than negativeThreshold OR
                    Input.GetAxis("Horizontal") > positiveThreshold) // if input equals horizontal greater then positiveThreshold
        {
            if (Input.GetAxis("Horizontal") < negativeThreshold)     // if input equals horizontal less than negativeThreshold
            {
                if (_characterSelectState == 0)                      // if character select state equals 0
                    return;                                          // then do nothing and return

                _characterSelectState--;                             // decrease from character select state value
            }

            if (Input.GetAxis("Horizontal") > positiveThreshold)     // if input equals horizontal greater than positiveThreshold
            {
                if (_characterSelectState == 7)                      // if character select state equals 7
                    return;                                          // then do nothing and return

                _characterSelectState++;
            }

            CharacterSelectManager();                                // and call CharacterSelectManager function
            _chooseCharacterInputTimer = _chooseCharacterInputDelay; // make choose character input timer equal to input delay
        }
    }

    void CharacterSelectManager()
    {
        switch (_characterSelectState)
        {
            case 0:
                BlackRobot();
                break;
            case 1:
                WhiteRobot();
                break;
            case 2:
                RedRobot();
                break;
            case 3:
                BlueRobot();
                break;
            case 4:
                BrownRobot();
                break;
            case 5:
                GreenRobot();
                break;
            case 6:
                PinkRobot();
                break;
            case 7:
                GoldRobot();
                break;
            //default:
        }
    }

    private void BlackRobot (){
        Debug.Log("BlackRobot");
    }
    private void WhiteRobot (){
        Debug.Log("WhiteRobot");
    }
    private void RedRobot (){
        Debug.Log("RedRobot");
    }
    private void BlueRobot (){
        Debug.Log("BlueRobot");
    }
    private void BrownRobot (){
        Debug.Log("BrownRobot");
    }
    private void GreenRobot (){
        Debug.Log("GreenRobot");
    }
    private void PinkRobot (){
        Debug.Log("PinkRobot");
    }
    private void GoldRobot (){
        Debug.Log("GoldRobot");
    }

    /// <summary>
    /// OnGUI is called for rendering and handling GUI events.
    /// This function can be called multiple times per frame (one call per event).
    /// </summary>
    void OnGUI()
    {
        
    }
}

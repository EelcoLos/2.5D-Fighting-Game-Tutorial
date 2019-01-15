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

    public AudioClip _cycleCharacterButtonPress;                    // creates slot in inspector to assign audio clip when cycling through the characters

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

            GetComponent<AudioSource>()                              // Get component
                .PlayOneShot(_cycleCharacterButtonPress);            // and play cycle button press audio clip
                
            CharacterSelectManager();                                // and call CharacterSelectManager function
            _chooseCharacterInputTimer = _chooseCharacterInputDelay; // make choose character input timer equal to input delay
        }
    }

    void CharacterSelectManager()
    {
        switch (_characterSelectState)
        {
            case 0:
                templateRobot("BlackRobot", new Vector3(-0.5f, 0 - 7));
                _robotBlack = true;
                break;
            case 1:
                templateRobot("WhiteRobot", new Vector3(-0.5f, 0 - 7));
                _robotWhite = true;
                break;
            case 2:
                templateRobot("RedRobot", new Vector3(-0.5f, 0 - 7));
                _robotRed = true;
                break;
            case 3:
                templateRobot("BlueRobot", new Vector3(-0.5f, 0 - 7));
                _robotBlue = true;
                break;
            case 4:
                templateRobot("BrownRobot", new Vector3(-0.5f, 0 - 7));
                _robotBrown = true;
                break;
            case 5:
                templateRobot("GreenRobot", new Vector3(-0.5f, 0 - 7));
                 _robotGreen = true;
                break;
            case 6:
                templateRobot("PinkRobot", new Vector3(-0.5f, 0 - 7));
                _robotPink = true;
                break;
            case 7:
                templateRobot("GoldRobot", new Vector3(-0.5f, 0 - 7));
                _robotGold = true;
                break;
            //default:
        }
    }

    private void templateRobot(string charName, Vector3 position)
    {
        Debug.Log(charName);
        DestroyAndInstantiateCharacterDemo(charName, position);
        setAllRobotsFalse();
    }

    private void DestroyAndInstantiateCharacterDemo(string resourceName, Vector3 position)
    {
        DestroyObject(_characterDemo);                              // Destroy current character demo object
        _characterDemo =                                            // Character demo game object is equal to
            Instantiate(Resources.Load(resourceName))               // the resourceName fighter within our resources folder
            as GameObject;                                          // as a game object
        _characterDemo.transform.position = position;               // Set character demo position to a new vector3 at provided position
    }

    private static void setAllRobotsFalse()
    {
        _robotBlack = false;                                         // set robot black to false
        _robotWhite = false;                                         // set robot white to false
        _robotRed = false;                                           // set robot red to false
        _robotBlue = false;                                          // set robot blue to false
        _robotBrown = false;                                         // set robot brown to false
        _robotGreen = false;                                         // set robot green to false
        _robotPink = false;                                          // set robot pink to false
        _robotGold = false;                                          // set robot gold to false
    }

    /// <summary>
    /// OnGUI is called for rendering and handling GUI events.
    /// This function can be called multiple times per frame (one call per event).
    /// </summary>
    void OnGUI()
    {
        
    }
}

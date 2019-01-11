using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>
/// Choose character manager.cs
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
        
    }

    void CharacterSelectManager()
    {

    }
}

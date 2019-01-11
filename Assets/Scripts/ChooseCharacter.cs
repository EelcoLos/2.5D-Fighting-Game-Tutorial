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

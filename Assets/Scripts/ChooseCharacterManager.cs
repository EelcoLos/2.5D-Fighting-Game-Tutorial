using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// Choose character manager.cs
/// Eelco Los
/// 11-01-2019
/// </summary>


public class ChooseCharacterManager : MonoBehaviour
{
    public static bool _robotBlack;                                                 // Defines if robot black is selected   
    public static bool _robotWhite;                                                 // Defines if robot white is selected   
    public static bool _robotRed;                                                   // Defines if robot red is selected   
    public static bool _robotBlue;                                                  // Defines if robot blue is selected   
    public static bool _robotBrown;                                                 // Defines if robot brown is selected   
    public static bool _robotGreen;                                                 // Defines if robot green is selected   
    public static bool _robotPink;                                                  // Defines if robot pink is selected   
    public static bool _robotGold;                                                  // Defines if robot gold is selected   

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        _robotBlack = false;                                                        // Robot black is false on start up
        _robotWhite = false;                                                        // Robot white is false on start up
        _robotRed = false;                                                          // Robot red is false on start up
        _robotBlue = false;                                                         // Robot blue is false on start up
        _robotBrown = false;                                                        // Robot brown is false on start up
        _robotGreen = false;                                                        // Robot green is false on start up
        _robotPink = false;                                                         // Robot pink is false on start up
        _robotGold = false;                                                         // Robot gold is false on start up
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);                                                    // Don't destroy this gameobject when loading a scene
    }
}

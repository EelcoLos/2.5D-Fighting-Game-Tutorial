using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{

    private GameObject _playerOneCharacter;                             // Variable to store chosen character for player one
    
    private bool _returnRobotBlack;                                     // Variable to store returned value of robot black bool
    private bool _returnRobotWhite;                                     // Variable to store returned value of robot white bool
    private bool _returnRobotRed;                                       // Variable to store returned value of robot red bool
    private bool _returnRobotBlue;                                      // Variable to store returned value of robot blue bool
    private bool _returnRobotBrown;                                     // Variable to store returned value of robot brown bool
    private bool _returnRobotGreen;                                     // Variable to store returned value of robot green bool
    private bool _returnRobotPink;                                      // Variable to store returned value of robot pink bool
    private bool _returnRobotGold;                                      // Variable to store returned value of robot gold bool

    // Start is called before the first frame update
    void Start()
    {
        _returnRobotBlack   = ChooseCharacterManager._robotBlack;       // _returnRobotBlack equals ChooseCharacterManager script and robot black bool
        _returnRobotWhite   = ChooseCharacterManager._robotWhite;       // _returnRobotWhite equals ChooseCharacterManager script and robot white bool
        _returnRobotRed     = ChooseCharacterManager._robotRed;         // _returnRobotRed equals ChooseCharacterManager script and robot red bool
        _returnRobotBlue    = ChooseCharacterManager._robotBlue;        // _returnRobotBlue equals ChooseCharacterManager script and robot blue bool
        _returnRobotBrown   = ChooseCharacterManager._robotBrown;       // _returnRobotBrown equals ChooseCharacterManager script and robot brown bool
        _returnRobotGreen   = ChooseCharacterManager._robotGreen;       // _returnRobotGreen equals ChooseCharacterManager script and robot green bool
        _returnRobotPink    = ChooseCharacterManager._robotPink;        // _returnRobotPink equals ChooseCharacterManager script and robot pink bool
        _returnRobotGold    = ChooseCharacterManager._robotGold;        // _returnRobotGold equals ChooseCharacterManager script and robot gold bool
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadPlayerOneCharacter()
    {
        Debug.Log("LoadPlayerOneCharacter");

        var selectedCharacter = ChooseCharacterManager.getSelectedCharacterResourceName();
        _playerOneCharacter = 
            Instantiate(Resources.Load(selectedCharacter)) 
                as GameObject;
    }
}

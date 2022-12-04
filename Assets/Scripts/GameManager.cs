using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    #region Manager
    public SpawnManager SpawnManager;
    public UIManager UIManager;
    #endregion
    public GameObject character;
    public GameObject Camera;

    public int CharacterNumber = 0;

    public LevelScriptableObject level;
    [SerializeField]private LevelScriptableObject[] levels;



    private void OnEnable()
    {
        Instance = this;
        LevelSelect(0);
        CharacterSelect(CharacterNumber);
        
    }
    void Start()
    {
        EventManager.Broadcast(GameEvent.OnStart);
        EventManager.Broadcast(GameEvent.OnClosePanels);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CharacterNumberChange()
    {
        CharacterNumber++;
        CharacterSelect(CharacterNumber);
    }

    void LevelSelect(int _levelNumber)
    {
       level = levels[_levelNumber];
    }

    void CharacterSelect(int _characterNumber)
    {
        character = level.Characters[_characterNumber];
    }
   
}

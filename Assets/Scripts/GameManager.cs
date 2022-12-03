using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]private LevelScriptableObject[] levels;
    public LevelScriptableObject level;
    public GameObject character;
    public SpawnManager SpawnManager;
    public UIManager UIManager;

    public GameObject Camera;

    public int CharacterNumber = 0;

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
    void LevelSelect(int _levelNumber)
    {
       level = levels[_levelNumber];
    }
    void CharacterSelect(int _characterNumber)
    {
        character = level.Characters[_characterNumber];
    }
    public void CharacterNumberChange()
    {
        CharacterNumber++;
        CharacterSelect(CharacterNumber);
    }
   
}

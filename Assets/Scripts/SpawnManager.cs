using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    

    public SpawnObject spawnObject;

    [SerializeField] private GameObject _enviorementParentObject;
    
    // Start is called before the first frame update
    private void OnEnable()
    {
        
        EventManager.AddHandler(GameEvent.OnStart,SpawnEnvrionment);
        EventManager.AddHandler(GameEvent.OnStart, SpawnCharacter);
    }
    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnStart, SpawnEnvrionment);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SpawnEnvrionment()
    {
        GameObject _object = spawnObject.Spawn(GameManager.Instance.level.Envrionment);
        _object.transform.parent = _enviorementParentObject.transform;
    }

    void SpawnCharacter()
    {
        GameObject _object = spawnObject.Spawn(GameManager.Instance.character);
        _object.transform.position = GameManager.Instance.level.CharacterPosition;
       
    }

    
    

}

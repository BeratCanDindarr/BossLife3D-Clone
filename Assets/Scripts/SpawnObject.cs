using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{








    public GameObject Spawn(GameObject _object)
    {
        var _prefab = Instantiate(_object);
        return _prefab;
    }
}

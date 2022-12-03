using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewLevel",menuName ="Level/NewLevel")]
public class LevelScriptableObject : ScriptableObject
{
    public string LevelName;

    public GameObject Envrionment;

    #region character
    [Header("Character")]
    public GameObject[] Characters;

    public Vector3 CharacterPosition;
    #endregion
    #region Camera
    [Header("Camera")]
    public Vector3 CameraPosition;
    public Vector3 CameraRotation;
    #endregion
}

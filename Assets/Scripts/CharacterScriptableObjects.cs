using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="CharactersProperty/newCharacterProperty",fileName = "CharactersProperty")]
public class CharacterScriptableObjects : ScriptableObject
{
    public Sprite PropertySprite;
    public Sprite CorrectButtonSprite;
    public Sprite WrongButtonSprite;

    [Header("Character Animation")]
    public string CorrectCharacterAnim;
    public string WrongCharacterAnim;

    [Header("Animation")]
    public GameObject CorrectAnim;
    public GameObject WrongAnim;
    

    [Header("Correct Text")]
    public string CorrectText;
    public Color Correctcolor;

    [Header("Wrong Text")]
    public string WrongText;
    public Color Wrongcolor;

    [Header("End")]
    public GameObject EndAnim;
    public string EndText;

}

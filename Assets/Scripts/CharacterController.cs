using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private CharacterScriptableObjects characterProperty;
    [SerializeField] private Transform characterMouth;
    private Animator characterAnim;
    private UIManager uIManager;

    private void OnEnable()
    {
        uIManager = GameManager.Instance.UIManager;
        characterAnim = this.gameObject.GetComponent<Animator>();
        EventManager.AddHandler(GameEvent.OnOpenPanels, UpdateUI);
        EventManager.AddHandler(GameEvent.OnCorrect, OnCorrect);
        EventManager.AddHandler(GameEvent.OnWrong, OnWrong);

    }
    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnOpenPanels, UpdateUI);
        EventManager.RemoveHandler(GameEvent.OnCorrect, OnCorrect);
        EventManager.RemoveHandler(GameEvent.OnWrong, OnWrong);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCorrect()
    {
        
        characterAnim.SetTrigger(characterProperty.CorrectCharacterAnim);
        uIManager.SetText(characterProperty.CorrectText,characterProperty.Correctcolor);
        CorrectAnim(characterProperty.CorrectAnim);
        Next();
    }
    void CorrectAnim(GameObject correctAnim)
    {
        var _correctAnim = GameManager.Instance.SpawnManager.spawnObject.Spawn(correctAnim);
        var cameraTransform = GameManager.Instance.Camera.transform;
        _correctAnim.transform.position = new Vector3(cameraTransform.position.x,cameraTransform.position.y + 1, cameraTransform.position.z -1);
    }
    void OnWrong()
    {
        
        characterAnim.SetTrigger(characterProperty.WrongCharacterAnim);
        uIManager.SetText(characterProperty.WrongText,characterProperty.Wrongcolor);
        WrongAnim();
        Next();
    }
    void WrongAnim()
    {
        var _wrongAnim = GameManager.Instance.SpawnManager.spawnObject.Spawn(characterProperty.WrongAnim);
        
        _wrongAnim.transform.position = new Vector3(characterMouth.position.x, characterMouth.position.y + 0.1f, characterMouth.position.z + 0.2f);
    }

    public void SetProperty()
    {
        EventManager.Broadcast(GameEvent.OnOpenPanels);
        
    }
    
    public void Next()
    {
        StartCoroutine(TextPanelOpen());
        StartCoroutine(NextLevelWait());
    }

    void UpdateUI()
    {
        uIManager.SetPropertyPanel(characterProperty.PropertySprite);
        uIManager.SetCorrectButton(characterProperty.CorrectButtonSprite);
        uIManager.SetWrongButton(characterProperty.WrongButtonSprite);
        
    }
    IEnumerator NextLevelWait()
    {

        yield return new WaitForSeconds(5f);
        if (GameManager.Instance.CharacterNumber != 1)
        {
            Destroy(this.gameObject);
            GameManager.Instance.CharacterNumberChange();
            EventManager.Broadcast(GameEvent.OnStart);
            EventManager.Broadcast(GameEvent.OnCloseTextPanel);

        }else
        {
            CorrectAnim(characterProperty.EndAnim);
            uIManager.SetText(characterProperty.EndText,characterProperty.Correctcolor);
            Handheld.Vibrate();
        }
    }
    IEnumerator TextPanelOpen()
    {

        yield return new WaitForSeconds(0.5f);
        EventManager.Broadcast(GameEvent.OnOpenTextPanel);
    }

}

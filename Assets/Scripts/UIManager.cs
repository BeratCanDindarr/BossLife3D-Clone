using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [Header("Property Panel")]
    [SerializeField] private GameObject propertyPanel;

    [Header("Button Panels")]
    [SerializeField] private GameObject correctButton;
    [SerializeField] private GameObject wrongButton;

    [SerializeField] private GameObject textPanel;
    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnClosePanels,ClosePanels);
        EventManager.AddHandler(GameEvent.OnOpenPanels, OpenPanels);
        EventManager.AddHandler(GameEvent.OnOpenTextPanel, TextPanelOpen);
        EventManager.AddHandler(GameEvent.OnCloseTextPanel, TextPanelClose);
    }
    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnClosePanels, ClosePanels);
        EventManager.RemoveHandler(GameEvent.OnOpenPanels, OpenPanels);
        EventManager.RemoveHandler(GameEvent.OnOpenTextPanel, TextPanelOpen);
        EventManager.RemoveHandler(GameEvent.OnCloseTextPanel, TextPanelClose);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void ClosePanels()
    {
        propertyPanel.SetActive(false);
        wrongButton.SetActive(false);
        correctButton.SetActive(false);
        
        
    }
    void OpenPanels()
    {
        propertyPanel.SetActive(true);
        wrongButton.SetActive(true);
        correctButton.SetActive(true);
        

    }

    void TextPanelOpen()
    {
        textPanel.SetActive(true);
    }
    void TextPanelClose()
    {
        textPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCorrectButton()
    {
        EventManager.Broadcast(GameEvent.OnCorrect);
        EventManager.Broadcast(GameEvent.OnClosePanels);
    }
    public void OnWrongButton()
    {
        EventManager.Broadcast(GameEvent.OnWrong);
        EventManager.Broadcast(GameEvent.OnClosePanels);
    }
   
    public void SetPropertyPanel(Sprite _image)
    {
        propertyPanel.GetComponent<Image>().sprite = _image;
    }
    public void SetCorrectButton(Sprite _image)
    {
        correctButton.GetComponent<Image>().sprite = _image;
    }
    public void SetWrongButton(Sprite _image)
    {
        wrongButton.GetComponent<Image>().sprite = _image;
    }
    public void SetText(string _text,Color _color)
    {
        var _textPanel = textPanel.GetComponent<Text>();
        _textPanel.text = _text;
        _textPanel.color = _color;
        

    }
}

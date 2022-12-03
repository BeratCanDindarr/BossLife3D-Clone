using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject _camera;
    // Start is called before the first frame update
    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnStart,SetCameraPosition);
        EventManager.AddHandler(GameEvent.OnStart, SetCameraRotation);
    }
    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnStart, SetCameraPosition);
        EventManager.RemoveHandler(GameEvent.OnStart, SetCameraRotation);
    }
    void Start()
    {
        _camera = this.gameObject; 
    }

    void SetCameraPosition()
    {
        _camera.transform.position = GameManager.Instance.level.CameraPosition;
    }
    void SetCameraRotation()
    {
        Vector3 _rotation = GameManager.Instance.level.CameraRotation;
        _camera.transform.rotation = Quaternion.Euler(_rotation);
    }
}

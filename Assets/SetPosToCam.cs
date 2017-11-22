using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class SetPosToCam : MonoBehaviour, IInputClickHandler {

    private bool IsCurrentlyDragging = true;
    private Vector3 startRot = Vector3.zero;

    void Start()
    {
        InputManager.Instance.PushFallbackInputHandler(gameObject);
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        IsCurrentlyDragging = !IsCurrentlyDragging;
        if(IsCurrentlyDragging)
        {
            transform.SetParent(Camera.main.transform, true);
        }
        else
        {
            transform.parent = null;
        }
    }
    
	void Update ()
    {
        var pos = transform.position;
        pos.y = 0.0f;
        transform.position = pos;

        var euler = transform.eulerAngles;
        euler.x = 0.0f;
        euler.z = 0.0f;
        transform.eulerAngles = euler;
    }
}

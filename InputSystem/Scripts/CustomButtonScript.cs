using UnityEngine;
using UnityEngine.Events;

public class CustomButtonScript : MonoBehaviour
{

    public UnityEvent _ButtonEvent;

    public void Awake()
    {
        _ButtonEvent.AddListener(OnPress);
    }

    private void OnPress()
    {
        print("pressed");
    }

    private void OnHold()
    {

    }

    private void OnRelease()
    {

    }

}

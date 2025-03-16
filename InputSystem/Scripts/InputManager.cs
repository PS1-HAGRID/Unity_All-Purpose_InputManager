using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class InputManager : MonoBehaviour
{
    private InputActionAsset _Inputs;
    private InputActionMap _InputMap;
    [HideInInspector] public InputAction tapAction;
    [HideInInspector] public InputAction doubleTapAction;
    [HideInInspector] public InputAction debug;

    private Vector2 _InitialFingerPos = Vector2.zero;
    private Vector2 _FingerPos = Vector2.zero;

    private const string INPUT_MAP_NAME = "Mobile";
    private const string TAP_ACTION_NAME = "Tap";
    private const string DOUBLETAP_ACTION_NAME = "DoubleTap";
    private const string DEBUG = "Debug";

    private float _InitialPinch = 0;
    
    private bool _IsPinching = false;

    private void OnEnable()
    {
        SubscribeToSystem();
    }

    #region Computer Input Simulation
    private void DesktopTouchSimulation()
    {
        TouchSimulation.Enable();
    }

    private void EndDesktopTouchSimulation()
    {
        TouchSimulation.Disable();
    }
    #endregion

    private void Awake()
    {
        // Assigning actions to action map inputs

        _Inputs = new InputMapScript().asset;
        _InputMap = _Inputs.FindActionMap(INPUT_MAP_NAME);
        tapAction = _InputMap.FindAction(TAP_ACTION_NAME);
        doubleTapAction = _InputMap.FindAction(DOUBLETAP_ACTION_NAME);

        debug = _InputMap.FindAction(DEBUG); // debug

        RegisterAction();
    }

    private void SubscribeToSystem()
    {
        EnhancedTouchSupport.Enable();
        Touch.onFingerDown += OnPress;
        Touch.onFingerMove += OnMove;
        Touch.onFingerUp += OnRelease;

        DesktopTouchSimulation();
    }

    #region Tap And Double Tap Control
    // Binding actions to respective functions
    private void RegisterAction()
    {
        tapAction.Enable();
        doubleTapAction.Enable();

        tapAction.performed += OnTap;
        doubleTapAction.performed += OnDoubleTap;

        // debug
        debug.Enable();
        debug.performed += OnDebug;
    }

    // Extra Debug Key Action (mapped to Space by default)
    private void OnDebug(InputAction.CallbackContext pContext)
    {
        print("debug");
    }

    // On Tap Action (>0.2 seconds)
    private void OnTap(InputAction.CallbackContext pContext)
    {
        print("tap!");
    }

    // On Double Tap Action (>0.2 seconds per tap, 0.75 seconds max between taps)
    private void OnDoubleTap(InputAction.CallbackContext pContext)
    {
        print("double tap!");
    }

    private void UnregisterActions()
    {
        tapAction.performed -= OnTap;
        doubleTapAction.performed -= OnDoubleTap;

        tapAction.Disable();
        doubleTapAction.Disable();
    }
    #endregion

    #region Finger Tracking And Pinch Control
    // Detects inital Press to set Variables
    private void OnPress(Finger pFinger)
    {
        _InitialFingerPos = pFinger.screenPosition; // Fixed start finger position variable
        _FingerPos = pFinger.screenPosition; // Last known finger position variable

        if (Touch.activeTouches.Count == 2)
        {
            _InitialPinch = Vector2.Distance(Touch.activeTouches[0].screenPosition, Touch.activeTouches[1].screenPosition);
        }
    }

    // Detects Movement to update variables
    private void OnMove(Finger pFinger)
    {
        _IsPinching = Touch.activeTouches.Count == 2;

        if (_IsPinching) 
        { 
            float lCurrentDistance = Vector2.Distance(Touch.activeTouches[0].screenPosition, Touch.activeTouches[1].screenPosition);

            float lScaling = lCurrentDistance / _InitialPinch; // Scaling variable effectively giving the delta between start pinch and current pinch
        }

        Vector2 lCurrentFingerPos = pFinger.screenPosition;
        Vector2 lDeltaFingerPos = lCurrentFingerPos - _FingerPos; // Variable giving the delta between start finger position and current finger position
        _FingerPos = lCurrentFingerPos;  // Setting last known finger position variable
    }

    // Detects OnRelease to reset variables (pinch excluded, it is already effectively reset above ^^)
    private void OnRelease(Finger pFinger)
    {
        _InitialFingerPos = Vector2.zero;
        _FingerPos = Vector2.zero;
    }

    #endregion

    private void UnsubscribeToSystem()
    {
        Touch.onFingerDown -= OnPress;
        Touch.onFingerMove -= OnMove;
        Touch.onFingerUp -= OnRelease;
        EnhancedTouchSupport.Disable();

        UnregisterActions();

        EndDesktopTouchSimulation();
    }

    private void OnDisable()
    {
        UnsubscribeToSystem();
    }
}

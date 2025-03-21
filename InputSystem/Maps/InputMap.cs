//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/InputSystem/Maps/InputMap.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputMapScript: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMapScript()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMap"",
    ""maps"": [
        {
            ""name"": ""Mobile"",
            ""id"": ""8c48ecf7-cfc9-4517-be14-51597fdf5145"",
            ""actions"": [
                {
                    ""name"": ""Tap"",
                    ""type"": ""Button"",
                    ""id"": ""39e42eca-9ce7-44ea-98f2-ef414c78d193"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DoubleTap"",
                    ""type"": ""Button"",
                    ""id"": ""f4c14587-89be-46e6-bc8a-8515a7a5e020"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Debug"",
                    ""type"": ""Button"",
                    ""id"": ""4477d512-a2cc-4ce5-97bd-752132b54ba1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""88142531-6ad0-494a-b85f-9ddcc5681ac1"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a934094a-e1ea-4cfd-ac4f-d1210f5aa957"",
                    ""path"": ""<Touchscreen>/touch*/Press"",
                    ""interactions"": ""MultiTap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DoubleTap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""128d04a4-dbc8-4e8d-9e1e-b918e0781d96"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Debug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Mobile
        m_Mobile = asset.FindActionMap("Mobile", throwIfNotFound: true);
        m_Mobile_Tap = m_Mobile.FindAction("Tap", throwIfNotFound: true);
        m_Mobile_DoubleTap = m_Mobile.FindAction("DoubleTap", throwIfNotFound: true);
        m_Mobile_Debug = m_Mobile.FindAction("Debug", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Mobile
    private readonly InputActionMap m_Mobile;
    private List<IMobileActions> m_MobileActionsCallbackInterfaces = new List<IMobileActions>();
    private readonly InputAction m_Mobile_Tap;
    private readonly InputAction m_Mobile_DoubleTap;
    private readonly InputAction m_Mobile_Debug;
    public struct MobileActions
    {
        private @InputMapScript m_Wrapper;
        public MobileActions(@InputMapScript wrapper) { m_Wrapper = wrapper; }
        public InputAction @Tap => m_Wrapper.m_Mobile_Tap;
        public InputAction @DoubleTap => m_Wrapper.m_Mobile_DoubleTap;
        public InputAction @Debug => m_Wrapper.m_Mobile_Debug;
        public InputActionMap Get() { return m_Wrapper.m_Mobile; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MobileActions set) { return set.Get(); }
        public void AddCallbacks(IMobileActions instance)
        {
            if (instance == null || m_Wrapper.m_MobileActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MobileActionsCallbackInterfaces.Add(instance);
            @Tap.started += instance.OnTap;
            @Tap.performed += instance.OnTap;
            @Tap.canceled += instance.OnTap;
            @DoubleTap.started += instance.OnDoubleTap;
            @DoubleTap.performed += instance.OnDoubleTap;
            @DoubleTap.canceled += instance.OnDoubleTap;
            @Debug.started += instance.OnDebug;
            @Debug.performed += instance.OnDebug;
            @Debug.canceled += instance.OnDebug;
        }

        private void UnregisterCallbacks(IMobileActions instance)
        {
            @Tap.started -= instance.OnTap;
            @Tap.performed -= instance.OnTap;
            @Tap.canceled -= instance.OnTap;
            @DoubleTap.started -= instance.OnDoubleTap;
            @DoubleTap.performed -= instance.OnDoubleTap;
            @DoubleTap.canceled -= instance.OnDoubleTap;
            @Debug.started -= instance.OnDebug;
            @Debug.performed -= instance.OnDebug;
            @Debug.canceled -= instance.OnDebug;
        }

        public void RemoveCallbacks(IMobileActions instance)
        {
            if (m_Wrapper.m_MobileActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMobileActions instance)
        {
            foreach (var item in m_Wrapper.m_MobileActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MobileActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MobileActions @Mobile => new MobileActions(this);
    public interface IMobileActions
    {
        void OnTap(InputAction.CallbackContext context);
        void OnDoubleTap(InputAction.CallbackContext context);
        void OnDebug(InputAction.CallbackContext context);
    }
}

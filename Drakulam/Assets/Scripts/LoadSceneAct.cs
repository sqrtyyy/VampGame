// GENERATED AUTOMATICALLY FROM 'Assets/Actions/LoadSceneAct.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @LoadSceneAct : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @LoadSceneAct()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""LoadSceneAct"",
    ""maps"": [
        {
            ""name"": ""LoadScene"",
            ""id"": ""06ee4d50-6472-4e4c-9d5c-448d7c2de4ae"",
            ""actions"": [
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""59164464-3c65-457a-9278-9495454574ff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e3bdf46c-34eb-4b13-810e-1398f64f47a6"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // LoadScene
        m_LoadScene = asset.FindActionMap("LoadScene", throwIfNotFound: true);
        m_LoadScene_Escape = m_LoadScene.FindAction("Escape", throwIfNotFound: true);
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

    // LoadScene
    private readonly InputActionMap m_LoadScene;
    private ILoadSceneActions m_LoadSceneActionsCallbackInterface;
    private readonly InputAction m_LoadScene_Escape;
    public struct LoadSceneActions
    {
        private @LoadSceneAct m_Wrapper;
        public LoadSceneActions(@LoadSceneAct wrapper) { m_Wrapper = wrapper; }
        public InputAction @Escape => m_Wrapper.m_LoadScene_Escape;
        public InputActionMap Get() { return m_Wrapper.m_LoadScene; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LoadSceneActions set) { return set.Get(); }
        public void SetCallbacks(ILoadSceneActions instance)
        {
            if (m_Wrapper.m_LoadSceneActionsCallbackInterface != null)
            {
                @Escape.started -= m_Wrapper.m_LoadSceneActionsCallbackInterface.OnEscape;
                @Escape.performed -= m_Wrapper.m_LoadSceneActionsCallbackInterface.OnEscape;
                @Escape.canceled -= m_Wrapper.m_LoadSceneActionsCallbackInterface.OnEscape;
            }
            m_Wrapper.m_LoadSceneActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Escape.started += instance.OnEscape;
                @Escape.performed += instance.OnEscape;
                @Escape.canceled += instance.OnEscape;
            }
        }
    }
    public LoadSceneActions @LoadScene => new LoadSceneActions(this);
    public interface ILoadSceneActions
    {
        void OnEscape(InputAction.CallbackContext context);
    }
}

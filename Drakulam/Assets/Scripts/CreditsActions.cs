// GENERATED AUTOMATICALLY FROM 'Assets/Actions/CreditsActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CreditsActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CreditsActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CreditsActions"",
    ""maps"": [
        {
            ""name"": ""CreditsMap"",
            ""id"": ""f97beaf9-c1a8-418a-bb91-5966629982d3"",
            ""actions"": [
                {
                    ""name"": ""ExitCredits"",
                    ""type"": ""Button"",
                    ""id"": ""f429204a-718b-4d18-8880-e23cc3f9b440"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d3deac57-d31e-4086-89ba-04a77790de2d"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ExitCredits"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CreditsMap
        m_CreditsMap = asset.FindActionMap("CreditsMap", throwIfNotFound: true);
        m_CreditsMap_ExitCredits = m_CreditsMap.FindAction("ExitCredits", throwIfNotFound: true);
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

    // CreditsMap
    private readonly InputActionMap m_CreditsMap;
    private ICreditsMapActions m_CreditsMapActionsCallbackInterface;
    private readonly InputAction m_CreditsMap_ExitCredits;
    public struct CreditsMapActions
    {
        private @CreditsActions m_Wrapper;
        public CreditsMapActions(@CreditsActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @ExitCredits => m_Wrapper.m_CreditsMap_ExitCredits;
        public InputActionMap Get() { return m_Wrapper.m_CreditsMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CreditsMapActions set) { return set.Get(); }
        public void SetCallbacks(ICreditsMapActions instance)
        {
            if (m_Wrapper.m_CreditsMapActionsCallbackInterface != null)
            {
                @ExitCredits.started -= m_Wrapper.m_CreditsMapActionsCallbackInterface.OnExitCredits;
                @ExitCredits.performed -= m_Wrapper.m_CreditsMapActionsCallbackInterface.OnExitCredits;
                @ExitCredits.canceled -= m_Wrapper.m_CreditsMapActionsCallbackInterface.OnExitCredits;
            }
            m_Wrapper.m_CreditsMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ExitCredits.started += instance.OnExitCredits;
                @ExitCredits.performed += instance.OnExitCredits;
                @ExitCredits.canceled += instance.OnExitCredits;
            }
        }
    }
    public CreditsMapActions @CreditsMap => new CreditsMapActions(this);
    public interface ICreditsMapActions
    {
        void OnExitCredits(InputAction.CallbackContext context);
    }
}

// GENERATED AUTOMATICALLY FROM 'Assets/Actions/BrokenWall.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @BrokenWallAction : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @BrokenWallAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""BrokenWall"",
    ""maps"": [
        {
            ""name"": ""BrokenWall"",
            ""id"": ""74fb9fa9-b434-4fd1-8702-5c9cbd125a3a"",
            ""actions"": [
                {
                    ""name"": ""next"",
                    ""type"": ""Button"",
                    ""id"": ""c5647860-3b1e-4b9d-a172-7a36a98a3983"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1fd9cb05-5b27-4548-befd-588307e2f6fb"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""next"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // BrokenWall
        m_BrokenWall = asset.FindActionMap("BrokenWall", throwIfNotFound: true);
        m_BrokenWall_next = m_BrokenWall.FindAction("next", throwIfNotFound: true);
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

    // BrokenWall
    private readonly InputActionMap m_BrokenWall;
    private IBrokenWallActions m_BrokenWallActionsCallbackInterface;
    private readonly InputAction m_BrokenWall_next;
    public struct BrokenWallActions
    {
        private @BrokenWallAction m_Wrapper;
        public BrokenWallActions(@BrokenWallAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @next => m_Wrapper.m_BrokenWall_next;
        public InputActionMap Get() { return m_Wrapper.m_BrokenWall; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BrokenWallActions set) { return set.Get(); }
        public void SetCallbacks(IBrokenWallActions instance)
        {
            if (m_Wrapper.m_BrokenWallActionsCallbackInterface != null)
            {
                @next.started -= m_Wrapper.m_BrokenWallActionsCallbackInterface.OnNext;
                @next.performed -= m_Wrapper.m_BrokenWallActionsCallbackInterface.OnNext;
                @next.canceled -= m_Wrapper.m_BrokenWallActionsCallbackInterface.OnNext;
            }
            m_Wrapper.m_BrokenWallActionsCallbackInterface = instance;
            if (instance != null)
            {
                @next.started += instance.OnNext;
                @next.performed += instance.OnNext;
                @next.canceled += instance.OnNext;
            }
        }
    }
    public BrokenWallActions @BrokenWall => new BrokenWallActions(this);
    public interface IBrokenWallActions
    {
        void OnNext(InputAction.CallbackContext context);
    }
}

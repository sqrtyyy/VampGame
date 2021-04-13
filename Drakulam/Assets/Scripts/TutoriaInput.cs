// GENERATED AUTOMATICALLY FROM 'Assets/Actions/TutorialActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TutorialInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TutorialInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TutorialActions"",
    ""maps"": [
        {
            ""name"": ""Tutorial"",
            ""id"": ""068d01f0-b8d1-451d-b42e-fee00d683f53"",
            ""actions"": [
                {
                    ""name"": ""next"",
                    ""type"": ""Button"",
                    ""id"": ""2d867a5f-e9cd-4c26-8d4d-cf2a235607e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""move"",
                    ""type"": ""Value"",
                    ""id"": ""a8caf1b7-774b-4e46-af50-365069c6dcbb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""atack"",
                    ""type"": ""Button"",
                    ""id"": ""4041bf7a-0ec0-4643-98b4-0019ab61b207"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""task"",
                    ""type"": ""Button"",
                    ""id"": ""417d0178-b3cb-4115-8963-c59b76fecc08"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6ce61a49-ffb4-4f1b-a1c2-ded21c98cc77"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""next"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14436de0-e953-467e-ba6d-7c47bfb344e6"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""6eedbfef-a7cd-4e9d-9e09-969aa674049b"",
                    ""path"": ""Dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""29fb8cac-57da-4daa-8399-e5fb6e8d8c4e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ed70b5ad-1560-42b0-ba1a-3e760bb38c54"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d9ca698f-a5db-4af1-a9bc-a94f1b854ed4"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9f7029b0-5642-486c-b61f-fab99e27c7c7"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b6296566-8349-4c96-b211-45592699a43e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""89dee4c3-95f9-49c3-bcfa-6a245d511d1d"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f55210e9-7ebe-4ea0-890b-718ed83bea2c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""16d3eec9-f358-4d87-9e3e-8d9ee832534b"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""82610211-4cda-4052-8a46-5557c4343926"",
                    ""path"": ""<XRController>/{Primary2DAxis}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f31f0df5-1a6e-4358-930e-b8aa07840294"",
                    ""path"": ""<Joystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6d3c1b9-8831-4227-bb0a-e737e600c11f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""atack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34ccd52e-8f02-4335-87ec-9e0869d4b53f"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""task"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Tutorial
        m_Tutorial = asset.FindActionMap("Tutorial", throwIfNotFound: true);
        m_Tutorial_next = m_Tutorial.FindAction("next", throwIfNotFound: true);
        m_Tutorial_move = m_Tutorial.FindAction("move", throwIfNotFound: true);
        m_Tutorial_atack = m_Tutorial.FindAction("atack", throwIfNotFound: true);
        m_Tutorial_task = m_Tutorial.FindAction("task", throwIfNotFound: true);
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

    // Tutorial
    private readonly InputActionMap m_Tutorial;
    private ITutorialActions m_TutorialActionsCallbackInterface;
    private readonly InputAction m_Tutorial_next;
    private readonly InputAction m_Tutorial_move;
    private readonly InputAction m_Tutorial_atack;
    private readonly InputAction m_Tutorial_task;
    public struct TutorialActions
    {
        private @TutorialInput m_Wrapper;
        public TutorialActions(@TutorialInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @next => m_Wrapper.m_Tutorial_next;
        public InputAction @move => m_Wrapper.m_Tutorial_move;
        public InputAction @atack => m_Wrapper.m_Tutorial_atack;
        public InputAction @task => m_Wrapper.m_Tutorial_task;
        public InputActionMap Get() { return m_Wrapper.m_Tutorial; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TutorialActions set) { return set.Get(); }
        public void SetCallbacks(ITutorialActions instance)
        {
            if (m_Wrapper.m_TutorialActionsCallbackInterface != null)
            {
                @next.started -= m_Wrapper.m_TutorialActionsCallbackInterface.OnNext;
                @next.performed -= m_Wrapper.m_TutorialActionsCallbackInterface.OnNext;
                @next.canceled -= m_Wrapper.m_TutorialActionsCallbackInterface.OnNext;
                @move.started -= m_Wrapper.m_TutorialActionsCallbackInterface.OnMove;
                @move.performed -= m_Wrapper.m_TutorialActionsCallbackInterface.OnMove;
                @move.canceled -= m_Wrapper.m_TutorialActionsCallbackInterface.OnMove;
                @atack.started -= m_Wrapper.m_TutorialActionsCallbackInterface.OnAtack;
                @atack.performed -= m_Wrapper.m_TutorialActionsCallbackInterface.OnAtack;
                @atack.canceled -= m_Wrapper.m_TutorialActionsCallbackInterface.OnAtack;
                @task.started -= m_Wrapper.m_TutorialActionsCallbackInterface.OnTask;
                @task.performed -= m_Wrapper.m_TutorialActionsCallbackInterface.OnTask;
                @task.canceled -= m_Wrapper.m_TutorialActionsCallbackInterface.OnTask;
            }
            m_Wrapper.m_TutorialActionsCallbackInterface = instance;
            if (instance != null)
            {
                @next.started += instance.OnNext;
                @next.performed += instance.OnNext;
                @next.canceled += instance.OnNext;
                @move.started += instance.OnMove;
                @move.performed += instance.OnMove;
                @move.canceled += instance.OnMove;
                @atack.started += instance.OnAtack;
                @atack.performed += instance.OnAtack;
                @atack.canceled += instance.OnAtack;
                @task.started += instance.OnTask;
                @task.performed += instance.OnTask;
                @task.canceled += instance.OnTask;
            }
        }
    }
    public TutorialActions @Tutorial => new TutorialActions(this);
    public interface ITutorialActions
    {
        void OnNext(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnAtack(InputAction.CallbackContext context);
        void OnTask(InputAction.CallbackContext context);
    }
}

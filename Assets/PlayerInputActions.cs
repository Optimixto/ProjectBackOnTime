// GENERATED AUTOMATICALLY FROM 'Assets/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerInputActions : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""PlayerMovementControls"",
            ""id"": ""fa1bff45-9da9-4f3b-8787-5b95b66ee8c1"",
            ""actions"": [
                {
                    ""name"": ""Moving"",
                    ""type"": ""PassThrough"",
                    ""id"": ""59bb29c6-13d2-4f25-8a9b-ca91bea505f8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""dcdb82f2-73bc-40ed-84cc-ae046d13203e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Value"",
                    ""id"": ""d2b50f20-f321-4858-ae73-27a7a8412760"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ab727ddf-192a-4aa0-abf5-3624c91fc288"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""9feee673-715b-41cd-bc6c-4fb7c4f29908"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2461d598-9288-483d-be2a-e9cea70a31e3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f31fa70f-565b-445f-ae55-be8957b2ac60"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0f27f2fd-2bc2-4244-b904-a64abccbd0de"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1f0a68ba-87f7-4506-b72a-0360cc986657"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5260d81e-f3be-42a3-b07c-f1d8a457362e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d293f453-d964-47df-8fdc-30e6a95e9d44"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd133819-c725-459d-92e5-9d551c9d6675"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""729c164e-a3b2-464b-8297-9ca88374b603"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""TimePowersControls"",
            ""id"": ""c6c7d421-349a-47f8-acf3-9f3aa2653108"",
            ""actions"": [
                {
                    ""name"": ""RewindTime"",
                    ""type"": ""Value"",
                    ""id"": ""9d757917-e17b-48c3-8cd7-80cc3a9360b3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StopTime"",
                    ""type"": ""Value"",
                    ""id"": ""5efe8ff4-1b6e-4599-9348-22612196bfac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5b97fb6a-48ae-4c43-8dbe-53f18c671423"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RewindTime"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f124c69c-c3ba-4539-86a8-403354042ff3"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RewindTime"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b641a0f9-5fbc-48f0-915c-918439a95d51"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StopTime"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e84ef0ba-9982-40c6-8c9b-d7cc30403a74"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StopTime"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MenuHandler"",
            ""id"": ""fc9089f9-a44c-4d7f-8cc7-2054ce8a5489"",
            ""actions"": [
                {
                    ""name"": ""PauseMenu"",
                    ""type"": ""Button"",
                    ""id"": ""f824c41c-7b25-4568-8c01-3a7e50d48795"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a53e1644-03a1-40d3-af82-56f82c2ba3c5"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5fbb2209-585c-4ca5-b04c-b9c814f6263e"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMovementControls
        m_PlayerMovementControls = asset.FindActionMap("PlayerMovementControls", throwIfNotFound: true);
        m_PlayerMovementControls_Moving = m_PlayerMovementControls.FindAction("Moving", throwIfNotFound: true);
        m_PlayerMovementControls_Dash = m_PlayerMovementControls.FindAction("Dash", throwIfNotFound: true);
        m_PlayerMovementControls_Interact = m_PlayerMovementControls.FindAction("Interact", throwIfNotFound: true);
        // TimePowersControls
        m_TimePowersControls = asset.FindActionMap("TimePowersControls", throwIfNotFound: true);
        m_TimePowersControls_RewindTime = m_TimePowersControls.FindAction("RewindTime", throwIfNotFound: true);
        m_TimePowersControls_StopTime = m_TimePowersControls.FindAction("StopTime", throwIfNotFound: true);
        // MenuHandler
        m_MenuHandler = asset.FindActionMap("MenuHandler", throwIfNotFound: true);
        m_MenuHandler_PauseMenu = m_MenuHandler.FindAction("PauseMenu", throwIfNotFound: true);
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

    // PlayerMovementControls
    private readonly InputActionMap m_PlayerMovementControls;
    private IPlayerMovementControlsActions m_PlayerMovementControlsActionsCallbackInterface;
    private readonly InputAction m_PlayerMovementControls_Moving;
    private readonly InputAction m_PlayerMovementControls_Dash;
    private readonly InputAction m_PlayerMovementControls_Interact;
    public struct PlayerMovementControlsActions
    {
        private PlayerInputActions m_Wrapper;
        public PlayerMovementControlsActions(PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Moving => m_Wrapper.m_PlayerMovementControls_Moving;
        public InputAction @Dash => m_Wrapper.m_PlayerMovementControls_Dash;
        public InputAction @Interact => m_Wrapper.m_PlayerMovementControls_Interact;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovementControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementControlsActions instance)
        {
            if (m_Wrapper.m_PlayerMovementControlsActionsCallbackInterface != null)
            {
                Moving.started -= m_Wrapper.m_PlayerMovementControlsActionsCallbackInterface.OnMoving;
                Moving.performed -= m_Wrapper.m_PlayerMovementControlsActionsCallbackInterface.OnMoving;
                Moving.canceled -= m_Wrapper.m_PlayerMovementControlsActionsCallbackInterface.OnMoving;
                Dash.started -= m_Wrapper.m_PlayerMovementControlsActionsCallbackInterface.OnDash;
                Dash.performed -= m_Wrapper.m_PlayerMovementControlsActionsCallbackInterface.OnDash;
                Dash.canceled -= m_Wrapper.m_PlayerMovementControlsActionsCallbackInterface.OnDash;
                Interact.started -= m_Wrapper.m_PlayerMovementControlsActionsCallbackInterface.OnInteract;
                Interact.performed -= m_Wrapper.m_PlayerMovementControlsActionsCallbackInterface.OnInteract;
                Interact.canceled -= m_Wrapper.m_PlayerMovementControlsActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_PlayerMovementControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                Moving.started += instance.OnMoving;
                Moving.performed += instance.OnMoving;
                Moving.canceled += instance.OnMoving;
                Dash.started += instance.OnDash;
                Dash.performed += instance.OnDash;
                Dash.canceled += instance.OnDash;
                Interact.started += instance.OnInteract;
                Interact.performed += instance.OnInteract;
                Interact.canceled += instance.OnInteract;
            }
        }
    }
    public PlayerMovementControlsActions @PlayerMovementControls => new PlayerMovementControlsActions(this);

    // TimePowersControls
    private readonly InputActionMap m_TimePowersControls;
    private ITimePowersControlsActions m_TimePowersControlsActionsCallbackInterface;
    private readonly InputAction m_TimePowersControls_RewindTime;
    private readonly InputAction m_TimePowersControls_StopTime;
    public struct TimePowersControlsActions
    {
        private PlayerInputActions m_Wrapper;
        public TimePowersControlsActions(PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @RewindTime => m_Wrapper.m_TimePowersControls_RewindTime;
        public InputAction @StopTime => m_Wrapper.m_TimePowersControls_StopTime;
        public InputActionMap Get() { return m_Wrapper.m_TimePowersControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TimePowersControlsActions set) { return set.Get(); }
        public void SetCallbacks(ITimePowersControlsActions instance)
        {
            if (m_Wrapper.m_TimePowersControlsActionsCallbackInterface != null)
            {
                RewindTime.started -= m_Wrapper.m_TimePowersControlsActionsCallbackInterface.OnRewindTime;
                RewindTime.performed -= m_Wrapper.m_TimePowersControlsActionsCallbackInterface.OnRewindTime;
                RewindTime.canceled -= m_Wrapper.m_TimePowersControlsActionsCallbackInterface.OnRewindTime;
                StopTime.started -= m_Wrapper.m_TimePowersControlsActionsCallbackInterface.OnStopTime;
                StopTime.performed -= m_Wrapper.m_TimePowersControlsActionsCallbackInterface.OnStopTime;
                StopTime.canceled -= m_Wrapper.m_TimePowersControlsActionsCallbackInterface.OnStopTime;
            }
            m_Wrapper.m_TimePowersControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                RewindTime.started += instance.OnRewindTime;
                RewindTime.performed += instance.OnRewindTime;
                RewindTime.canceled += instance.OnRewindTime;
                StopTime.started += instance.OnStopTime;
                StopTime.performed += instance.OnStopTime;
                StopTime.canceled += instance.OnStopTime;
            }
        }
    }
    public TimePowersControlsActions @TimePowersControls => new TimePowersControlsActions(this);

    // MenuHandler
    private readonly InputActionMap m_MenuHandler;
    private IMenuHandlerActions m_MenuHandlerActionsCallbackInterface;
    private readonly InputAction m_MenuHandler_PauseMenu;
    public struct MenuHandlerActions
    {
        private PlayerInputActions m_Wrapper;
        public MenuHandlerActions(PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @PauseMenu => m_Wrapper.m_MenuHandler_PauseMenu;
        public InputActionMap Get() { return m_Wrapper.m_MenuHandler; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuHandlerActions set) { return set.Get(); }
        public void SetCallbacks(IMenuHandlerActions instance)
        {
            if (m_Wrapper.m_MenuHandlerActionsCallbackInterface != null)
            {
                PauseMenu.started -= m_Wrapper.m_MenuHandlerActionsCallbackInterface.OnPauseMenu;
                PauseMenu.performed -= m_Wrapper.m_MenuHandlerActionsCallbackInterface.OnPauseMenu;
                PauseMenu.canceled -= m_Wrapper.m_MenuHandlerActionsCallbackInterface.OnPauseMenu;
            }
            m_Wrapper.m_MenuHandlerActionsCallbackInterface = instance;
            if (instance != null)
            {
                PauseMenu.started += instance.OnPauseMenu;
                PauseMenu.performed += instance.OnPauseMenu;
                PauseMenu.canceled += instance.OnPauseMenu;
            }
        }
    }
    public MenuHandlerActions @MenuHandler => new MenuHandlerActions(this);
    public interface IPlayerMovementControlsActions
    {
        void OnMoving(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface ITimePowersControlsActions
    {
        void OnRewindTime(InputAction.CallbackContext context);
        void OnStopTime(InputAction.CallbackContext context);
    }
    public interface IMenuHandlerActions
    {
        void OnPauseMenu(InputAction.CallbackContext context);
    }
}

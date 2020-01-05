// GENERATED AUTOMATICALLY FROM 'Assets/TitleScreenInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class TitleScreenInput : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public TitleScreenInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TitleScreenInput"",
    ""maps"": [
        {
            ""name"": ""TitleScreen"",
            ""id"": ""959a68ab-79c8-4691-aeff-e84688bbe073"",
            ""actions"": [
                {
                    ""name"": ""Enter"",
                    ""type"": ""Button"",
                    ""id"": ""8fb6c0c2-a043-4e19-b9a2-25c327608faf"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""11b744dd-0b81-4744-9d67-4eb2089b8ac1"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""454dee82-a6d1-4bad-979d-8c9e1a9cf518"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d6ceda4-1716-4287-a243-16cb6f5e45e7"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // TitleScreen
        m_TitleScreen = asset.FindActionMap("TitleScreen", throwIfNotFound: true);
        m_TitleScreen_Enter = m_TitleScreen.FindAction("Enter", throwIfNotFound: true);
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

    // TitleScreen
    private readonly InputActionMap m_TitleScreen;
    private ITitleScreenActions m_TitleScreenActionsCallbackInterface;
    private readonly InputAction m_TitleScreen_Enter;
    public struct TitleScreenActions
    {
        private TitleScreenInput m_Wrapper;
        public TitleScreenActions(TitleScreenInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Enter => m_Wrapper.m_TitleScreen_Enter;
        public InputActionMap Get() { return m_Wrapper.m_TitleScreen; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TitleScreenActions set) { return set.Get(); }
        public void SetCallbacks(ITitleScreenActions instance)
        {
            if (m_Wrapper.m_TitleScreenActionsCallbackInterface != null)
            {
                Enter.started -= m_Wrapper.m_TitleScreenActionsCallbackInterface.OnEnter;
                Enter.performed -= m_Wrapper.m_TitleScreenActionsCallbackInterface.OnEnter;
                Enter.canceled -= m_Wrapper.m_TitleScreenActionsCallbackInterface.OnEnter;
            }
            m_Wrapper.m_TitleScreenActionsCallbackInterface = instance;
            if (instance != null)
            {
                Enter.started += instance.OnEnter;
                Enter.performed += instance.OnEnter;
                Enter.canceled += instance.OnEnter;
            }
        }
    }
    public TitleScreenActions @TitleScreen => new TitleScreenActions(this);
    public interface ITitleScreenActions
    {
        void OnEnter(InputAction.CallbackContext context);
    }
}

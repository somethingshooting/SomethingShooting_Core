// GENERATED AUTOMATICALLY FROM 'Assets/#MYASSET/Scripts/Systems/Inputs/Data/AlphaInputMap.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @AlphaInputMap : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @AlphaInputMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""AlphaInputMap"",
    ""maps"": [
        {
            ""name"": ""Battle"",
            ""id"": ""8aa40925-090c-4a41-9316-ca41ac702a57"",
            ""actions"": [
                {
                    ""name"": ""PlayerMove"",
                    ""type"": ""Value"",
                    ""id"": ""99d9f70b-ad95-4da6-b06f-82d97c8dd235"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NormalSkill"",
                    ""type"": ""Button"",
                    ""id"": ""da05014b-d69f-483b-b506-12af345d5253"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActiveSkill_1"",
                    ""type"": ""Button"",
                    ""id"": ""09caaf08-8222-4d43-a94f-52ae14669f91"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""AWSD"",
                    ""id"": ""b0e061ee-7a9f-43ef-b18a-f64603583bb1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f54752d7-949d-4fa5-b8e7-2ee6bd58f364"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9c3c2b5a-bfe2-459b-b9eb-204ae3f3d49a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1635da20-d838-44ca-a88b-1f4bcf00b1a6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d97f6172-1595-4ff8-9768-6af0106c992c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a7ca3e2f-b476-4624-badd-0418f39c7e37"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NormalSkill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33707cc3-d471-4cf1-888c-259424fb98dc"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActiveSkill_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Story"",
            ""id"": ""c0deff1a-91d8-4f00-9031-132bbff709b6"",
            ""actions"": [
                {
                    ""name"": ""NextText"",
                    ""type"": ""Button"",
                    ""id"": ""94110cae-7c2e-4bcc-af94-d81c869bee89"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ac5637fd-640e-4d39-9aca-4f66ad1f3c7e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextText"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Battle
        m_Battle = asset.FindActionMap("Battle", throwIfNotFound: true);
        m_Battle_PlayerMove = m_Battle.FindAction("PlayerMove", throwIfNotFound: true);
        m_Battle_NormalSkill = m_Battle.FindAction("NormalSkill", throwIfNotFound: true);
        m_Battle_ActiveSkill_1 = m_Battle.FindAction("ActiveSkill_1", throwIfNotFound: true);
        // Story
        m_Story = asset.FindActionMap("Story", throwIfNotFound: true);
        m_Story_NextText = m_Story.FindAction("NextText", throwIfNotFound: true);
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

    // Battle
    private readonly InputActionMap m_Battle;
    private IBattleActions m_BattleActionsCallbackInterface;
    private readonly InputAction m_Battle_PlayerMove;
    private readonly InputAction m_Battle_NormalSkill;
    private readonly InputAction m_Battle_ActiveSkill_1;
    public struct BattleActions
    {
        private @AlphaInputMap m_Wrapper;
        public BattleActions(@AlphaInputMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @PlayerMove => m_Wrapper.m_Battle_PlayerMove;
        public InputAction @NormalSkill => m_Wrapper.m_Battle_NormalSkill;
        public InputAction @ActiveSkill_1 => m_Wrapper.m_Battle_ActiveSkill_1;
        public InputActionMap Get() { return m_Wrapper.m_Battle; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BattleActions set) { return set.Get(); }
        public void SetCallbacks(IBattleActions instance)
        {
            if (m_Wrapper.m_BattleActionsCallbackInterface != null)
            {
                @PlayerMove.started -= m_Wrapper.m_BattleActionsCallbackInterface.OnPlayerMove;
                @PlayerMove.performed -= m_Wrapper.m_BattleActionsCallbackInterface.OnPlayerMove;
                @PlayerMove.canceled -= m_Wrapper.m_BattleActionsCallbackInterface.OnPlayerMove;
                @NormalSkill.started -= m_Wrapper.m_BattleActionsCallbackInterface.OnNormalSkill;
                @NormalSkill.performed -= m_Wrapper.m_BattleActionsCallbackInterface.OnNormalSkill;
                @NormalSkill.canceled -= m_Wrapper.m_BattleActionsCallbackInterface.OnNormalSkill;
                @ActiveSkill_1.started -= m_Wrapper.m_BattleActionsCallbackInterface.OnActiveSkill_1;
                @ActiveSkill_1.performed -= m_Wrapper.m_BattleActionsCallbackInterface.OnActiveSkill_1;
                @ActiveSkill_1.canceled -= m_Wrapper.m_BattleActionsCallbackInterface.OnActiveSkill_1;
            }
            m_Wrapper.m_BattleActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PlayerMove.started += instance.OnPlayerMove;
                @PlayerMove.performed += instance.OnPlayerMove;
                @PlayerMove.canceled += instance.OnPlayerMove;
                @NormalSkill.started += instance.OnNormalSkill;
                @NormalSkill.performed += instance.OnNormalSkill;
                @NormalSkill.canceled += instance.OnNormalSkill;
                @ActiveSkill_1.started += instance.OnActiveSkill_1;
                @ActiveSkill_1.performed += instance.OnActiveSkill_1;
                @ActiveSkill_1.canceled += instance.OnActiveSkill_1;
            }
        }
    }
    public BattleActions @Battle => new BattleActions(this);

    // Story
    private readonly InputActionMap m_Story;
    private IStoryActions m_StoryActionsCallbackInterface;
    private readonly InputAction m_Story_NextText;
    public struct StoryActions
    {
        private @AlphaInputMap m_Wrapper;
        public StoryActions(@AlphaInputMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @NextText => m_Wrapper.m_Story_NextText;
        public InputActionMap Get() { return m_Wrapper.m_Story; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(StoryActions set) { return set.Get(); }
        public void SetCallbacks(IStoryActions instance)
        {
            if (m_Wrapper.m_StoryActionsCallbackInterface != null)
            {
                @NextText.started -= m_Wrapper.m_StoryActionsCallbackInterface.OnNextText;
                @NextText.performed -= m_Wrapper.m_StoryActionsCallbackInterface.OnNextText;
                @NextText.canceled -= m_Wrapper.m_StoryActionsCallbackInterface.OnNextText;
            }
            m_Wrapper.m_StoryActionsCallbackInterface = instance;
            if (instance != null)
            {
                @NextText.started += instance.OnNextText;
                @NextText.performed += instance.OnNextText;
                @NextText.canceled += instance.OnNextText;
            }
        }
    }
    public StoryActions @Story => new StoryActions(this);
    public interface IBattleActions
    {
        void OnPlayerMove(InputAction.CallbackContext context);
        void OnNormalSkill(InputAction.CallbackContext context);
        void OnActiveSkill_1(InputAction.CallbackContext context);
    }
    public interface IStoryActions
    {
        void OnNextText(InputAction.CallbackContext context);
    }
}

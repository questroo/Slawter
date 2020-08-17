// GENERATED AUTOMATICALLY FROM 'Assets/Settings/GameControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""7da6c49e-885e-42da-b50c-8ec75d9505fc"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6cdbdb1d-ea96-4673-8570-a670e2770305"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""47cdae9a-1a52-4160-9703-d575e585d2cd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AimDownSight"",
                    ""type"": ""Button"",
                    ""id"": ""6261faa8-cb69-4891-bc85-e5b102999efb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""e2deaf85-bd97-4202-a687-68174096aee9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwapWeapon1"",
                    ""type"": ""Button"",
                    ""id"": ""53f0b986-494b-42e4-a0b1-773dfaca1884"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwapWeapon2"",
                    ""type"": ""Button"",
                    ""id"": ""862a3c0a-3703-4b6f-87ee-5b6d769bfb1f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwapWeapon3"",
                    ""type"": ""Button"",
                    ""id"": ""7658ca76-4a55-4c0e-8efc-8dda00df6136"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwapWeapon4"",
                    ""type"": ""Button"",
                    ""id"": ""19461efd-774b-43bb-9194-7dbc694ce3d5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwapWeapon5"",
                    ""type"": ""Button"",
                    ""id"": ""a28697ff-05f3-43a4-848f-55bb8a70e1f0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""4efafb5f-f9d9-4d97-9fa4-5eb3510eda07"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""9c2f2a62-5335-4272-bbc0-d5c0e1d255cd"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2ee81fb0-2165-4155-a8d2-687f5df064cf"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1c4309a0-401a-49b8-a789-d974f199022a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""41e10fad-f3e3-4823-9c90-93e5b801e240"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b598783a-cb27-4be5-88e5-347675ae3b3a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3e6d5e89-a761-4960-a2f3-037339c5222a"",
                    ""path"": ""<DualShockGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxControllerGamePad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4793b9b-19af-4fc5-a593-1b411f73e3d9"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1259dc3-ddce-4541-ab12-7a8bd3f3f1bd"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxControllerGamePad"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4a21873-a7d9-42a2-bc79-ea79001d31be"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""AimDownSight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd45904b-8f55-4130-8173-f09ee2fbbd54"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxControllerGamePad"",
                    ""action"": ""AimDownSight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ed64684-3458-4f34-9743-dcbcff1c6237"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f3042b43-de48-493f-bddd-1703dddbe149"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxControllerGamePad"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7815b31-8f41-4678-ba66-e6bc0b3d6b07"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""SwapWeapon1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0882c3cf-1e90-405a-b2a3-3f352c50be18"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""SwapWeapon2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81570eb4-431c-4e82-92ba-56236c428caa"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""SwapWeapon3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""43b94a8a-4f41-4ffe-9d10-8e243079b437"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""SwapWeapon4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f55808f-a3bb-489e-a235-d28792160509"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""SwapWeapon5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""678e1a1f-a029-4537-98fd-216fce0e74f4"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7406371a-c8f6-4df3-aa83-dc727fbff7da"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxControllerGamePad"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XboxControllerGamePad"",
            ""bindingGroup"": ""XboxControllerGamePad"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Shoot = m_Player.FindAction("Shoot", throwIfNotFound: true);
        m_Player_AimDownSight = m_Player.FindAction("AimDownSight", throwIfNotFound: true);
        m_Player_Reload = m_Player.FindAction("Reload", throwIfNotFound: true);
        m_Player_SwapWeapon1 = m_Player.FindAction("SwapWeapon1", throwIfNotFound: true);
        m_Player_SwapWeapon2 = m_Player.FindAction("SwapWeapon2", throwIfNotFound: true);
        m_Player_SwapWeapon3 = m_Player.FindAction("SwapWeapon3", throwIfNotFound: true);
        m_Player_SwapWeapon4 = m_Player.FindAction("SwapWeapon4", throwIfNotFound: true);
        m_Player_SwapWeapon5 = m_Player.FindAction("SwapWeapon5", throwIfNotFound: true);
        m_Player_Sprint = m_Player.FindAction("Sprint", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Shoot;
    private readonly InputAction m_Player_AimDownSight;
    private readonly InputAction m_Player_Reload;
    private readonly InputAction m_Player_SwapWeapon1;
    private readonly InputAction m_Player_SwapWeapon2;
    private readonly InputAction m_Player_SwapWeapon3;
    private readonly InputAction m_Player_SwapWeapon4;
    private readonly InputAction m_Player_SwapWeapon5;
    private readonly InputAction m_Player_Sprint;
    public struct PlayerActions
    {
        private @GameControls m_Wrapper;
        public PlayerActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Shoot => m_Wrapper.m_Player_Shoot;
        public InputAction @AimDownSight => m_Wrapper.m_Player_AimDownSight;
        public InputAction @Reload => m_Wrapper.m_Player_Reload;
        public InputAction @SwapWeapon1 => m_Wrapper.m_Player_SwapWeapon1;
        public InputAction @SwapWeapon2 => m_Wrapper.m_Player_SwapWeapon2;
        public InputAction @SwapWeapon3 => m_Wrapper.m_Player_SwapWeapon3;
        public InputAction @SwapWeapon4 => m_Wrapper.m_Player_SwapWeapon4;
        public InputAction @SwapWeapon5 => m_Wrapper.m_Player_SwapWeapon5;
        public InputAction @Sprint => m_Wrapper.m_Player_Sprint;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Shoot.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @AimDownSight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAimDownSight;
                @AimDownSight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAimDownSight;
                @AimDownSight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAimDownSight;
                @Reload.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
                @SwapWeapon1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwapWeapon1;
                @SwapWeapon1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwapWeapon1;
                @SwapWeapon1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwapWeapon1;
                @SwapWeapon2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwapWeapon2;
                @SwapWeapon2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwapWeapon2;
                @SwapWeapon2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwapWeapon2;
                @SwapWeapon3.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwapWeapon3;
                @SwapWeapon3.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwapWeapon3;
                @SwapWeapon3.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwapWeapon3;
                @SwapWeapon4.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwapWeapon4;
                @SwapWeapon4.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwapWeapon4;
                @SwapWeapon4.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwapWeapon4;
                @SwapWeapon5.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwapWeapon5;
                @SwapWeapon5.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwapWeapon5;
                @SwapWeapon5.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwapWeapon5;
                @Sprint.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @AimDownSight.started += instance.OnAimDownSight;
                @AimDownSight.performed += instance.OnAimDownSight;
                @AimDownSight.canceled += instance.OnAimDownSight;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @SwapWeapon1.started += instance.OnSwapWeapon1;
                @SwapWeapon1.performed += instance.OnSwapWeapon1;
                @SwapWeapon1.canceled += instance.OnSwapWeapon1;
                @SwapWeapon2.started += instance.OnSwapWeapon2;
                @SwapWeapon2.performed += instance.OnSwapWeapon2;
                @SwapWeapon2.canceled += instance.OnSwapWeapon2;
                @SwapWeapon3.started += instance.OnSwapWeapon3;
                @SwapWeapon3.performed += instance.OnSwapWeapon3;
                @SwapWeapon3.canceled += instance.OnSwapWeapon3;
                @SwapWeapon4.started += instance.OnSwapWeapon4;
                @SwapWeapon4.performed += instance.OnSwapWeapon4;
                @SwapWeapon4.canceled += instance.OnSwapWeapon4;
                @SwapWeapon5.started += instance.OnSwapWeapon5;
                @SwapWeapon5.performed += instance.OnSwapWeapon5;
                @SwapWeapon5.canceled += instance.OnSwapWeapon5;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    private int m_XboxControllerGamePadSchemeIndex = -1;
    public InputControlScheme XboxControllerGamePadScheme
    {
        get
        {
            if (m_XboxControllerGamePadSchemeIndex == -1) m_XboxControllerGamePadSchemeIndex = asset.FindControlSchemeIndex("XboxControllerGamePad");
            return asset.controlSchemes[m_XboxControllerGamePadSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnAimDownSight(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnSwapWeapon1(InputAction.CallbackContext context);
        void OnSwapWeapon2(InputAction.CallbackContext context);
        void OnSwapWeapon3(InputAction.CallbackContext context);
        void OnSwapWeapon4(InputAction.CallbackContext context);
        void OnSwapWeapon5(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
    }
}

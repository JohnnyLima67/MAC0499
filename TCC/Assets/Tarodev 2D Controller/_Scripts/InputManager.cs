using UnityEngine;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace TarodevController {
    public class InputManager : MonoBehaviour {
        public static InputManager instance;
        public FrameInput FrameInput { get; private set; }


        private PlayerInput _playerInput;
        private InputAction _move, _jump, _dash, _attack, _attack2, _powerUp,_exampleAction, _escape;

        private void Awake() {

            if (instance == null){
                instance = this;
            }

            _playerInput = GetComponent<PlayerInput>();
            SetupActions();
        }

        private void SetupActions() {
            _move = _playerInput.actions["Move"];
            _jump = _playerInput.actions["Jump"];
            _dash = _playerInput.actions["Dash"];
            _attack = _playerInput.actions["Attack"];
            _attack2 = _playerInput.actions["Attack2"];
            _powerUp = _playerInput.actions["PowerUp"];
            _escape = _playerInput.actions["MenuOpenClose"];
        }

        private void Update() {
            FrameInput = UpdateInputs();
        }

        private FrameInput UpdateInputs() {
            return new FrameInput {
                Move = _move.ReadValue<Vector2>(),
                JumpDown = _jump.WasPressedThisFrame(),
                JumpHeld = _jump.IsPressed(),
                DashDown = _dash.WasPressedThisFrame(),
                AttackDown = _attack.WasPressedThisFrame(),
                Attack2Down = _attack2.WasPressedThisFrame(),
                PowerUp = _powerUp.WasPressedThisFrame(),
                EscapeDown = _escape.WasPressedThisFrame(),
            };
        }
    }

    public struct FrameInput {
        public Vector2 Move;
        public bool JumpDown;
        public bool JumpHeld;
        public bool DashDown;
        public bool AttackDown;
        public bool Attack2Down;
        public bool PowerUp;
        public bool EscapeDown;
        public bool ExampleActionHeld;
    }

}
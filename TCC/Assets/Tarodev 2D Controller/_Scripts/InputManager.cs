using UnityEngine;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace TarodevController {
    public class InputManager : MonoBehaviour {
        public static InputManager instance;
        public FrameInput FrameInput { get; private set; }


        private PlayerInput _playerInput;
        private InputAction _move, _jump, _dash, _attack, _rangedAttack, _exampleAction, _escape;

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
            _rangedAttack = _playerInput.actions["RangedAttack"];
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
                RangedAttackDown = _rangedAttack.WasPressedThisFrame(),
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
        public bool RangedAttackDown;
        public bool EscapeDown;
        public bool ExampleActionHeld;
    }

}

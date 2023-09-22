using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine. EventSystems;

namespace TarodevController {
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject _mainMenuCanvasGO;
        [SerializeField] private GameObject _settingsMenuCanvasGO;
		[SerializeField] private GameObject _audioSettingsMenuGO;
        [SerializeField] private GameObject _keyboardMenuCanvasGO;
        [SerializeField] private GameObject _gamepadMenuCanvasGO;

        [SerializeField] private GameObject _playerController;
        protected FrameInput FrameInput;

        [Header("First Selected Options")]
        [SerializeField] private GameObject _mainMenuFirst;
        [SerializeField] private GameObject _settingsMenuFirst;
		[SerializeField] private GameObject _audioSettingsMenuFirst;
        [SerializeField] private GameObject _keyboardMenuFirst;
        [SerializeField] private GameObject _gamepadMenuFirst;

        private bool isPaused;

        private void Start() {
            _mainMenuCanvasGO.SetActive(false);
            _settingsMenuCanvasGO.SetActive(false);
            _keyboardMenuCanvasGO.SetActive(false);
            _gamepadMenuCanvasGO.SetActive(false);
			_audioSettingsMenuGO.SetActive(false);
        }

        private void Update() {
            if (InputManager.instance.FrameInput.EscapeDown) {
                if(!isPaused){
                    Pause();
                }
                else {
                    Unpause();
                }
            }
        }

        public void Pause() {
            isPaused = true;
            Time.timeScale = 0f;
            _playerController.GetComponent<PlayerController>().enabled=false;

            OpenMainMenu();
        }

        public void Unpause() {
            isPaused = false;
            Time.timeScale = 1f;
            _playerController.GetComponent<PlayerController>().enabled=true;
            CloseAllMenus();
        }

        private void OpenMainMenu() {
            _mainMenuCanvasGO.SetActive(true);
            _settingsMenuCanvasGO.SetActive(false);
            _keyboardMenuCanvasGO.SetActive(false);
            _gamepadMenuCanvasGO.SetActive(false);

            EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
        }

        private void CloseAllMenus() {
			_audioSettingsMenuGO.SetActive(false);
            _mainMenuCanvasGO.SetActive(false);
            _settingsMenuCanvasGO.SetActive(false); 
            _keyboardMenuCanvasGO.SetActive(false);        
            _gamepadMenuCanvasGO.SetActive(false);
       
            EventSystem.current.SetSelectedGameObject(null);

        }

        private void OpenSettingsMenuHandle() {
			_audioSettingsMenuGO.SetActive(false);
             _settingsMenuCanvasGO.SetActive(true);
             _mainMenuCanvasGO.SetActive(false);
            _keyboardMenuCanvasGO.SetActive(false);
            _gamepadMenuCanvasGO.SetActive(false);

            EventSystem.current.SetSelectedGameObject(_settingsMenuFirst);

        }

		private void OpenAudioSettingsMenuHandle()
		{
			_audioSettingsMenuGO.SetActive(true);
			_settingsMenuCanvasGO.SetActive(false);
			_mainMenuCanvasGO.SetActive(false);
            _keyboardMenuCanvasGO.SetActive(false);
            _gamepadMenuCanvasGO.SetActive(false);

            EventSystem.current.SetSelectedGameObject(_audioSettingsMenuFirst);
		}

        private void OpenKeyboardMenuHandle() {
			_audioSettingsMenuGO.SetActive(false);
            _settingsMenuCanvasGO.SetActive(false);
            _mainMenuCanvasGO.SetActive(false);
            _keyboardMenuCanvasGO.SetActive(true);
            _gamepadMenuCanvasGO.SetActive(false);

            EventSystem.current.SetSelectedGameObject(_keyboardMenuFirst);

        }

        private void OpenGamepadMenuHandle() {
			_audioSettingsMenuGO.SetActive(false);
            _settingsMenuCanvasGO.SetActive(false);
            _mainMenuCanvasGO.SetActive(false);
            _keyboardMenuCanvasGO.SetActive(false);
            _gamepadMenuCanvasGO.SetActive(true);

            EventSystem.current.SetSelectedGameObject(_gamepadMenuFirst);

        }
// -----------------Botões Menu Principal -------------------//
        public void OnMainMenuSettingsPress(){
            OpenSettingsMenuHandle();
        }

        public void OnMainMenuResumePress() {
            Unpause();
        }
// -----------------Botões Menu Settings -------------------//

        public void OnSettingsBackPress() {
            OpenMainMenu();
        }

        public void OnSettingsKeyboardPress(){
            OpenKeyboardMenuHandle();
        }

        public void OnSettingsGamepadPress(){
            OpenGamepadMenuHandle();
        }

		public void OnSettingsAudioSettingsPress() {
			OpenAudioSettingsMenuHandle();
		}

 // -----------------Botões Audio Settings -------------------//

		public void OnAudioSettingsBackPress() {
			OpenSettingsMenuHandle();
		}

 // -----------------Botões Menu Teclado -------------------//
       
        public void OnKeyboardBackPress(){
            OpenSettingsMenuHandle();
        }
 // -----------------Botões Menu Gamepad -------------------//
       
        public void OnGamepadBackPress(){
            OpenSettingsMenuHandle();
        }

    }
}

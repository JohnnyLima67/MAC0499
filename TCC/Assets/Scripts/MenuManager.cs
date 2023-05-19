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
        [SerializeField] private GameObject _keyboardMenuCanvasGO;

        [SerializeField] private GameObject _playerController;
        protected FrameInput FrameInput;

        [Header("First Selected Options")]
        [SerializeField] private GameObject _mainMenuFirst;
        [SerializeField] private GameObject _settingsMenuFirst;
        [SerializeField] private GameObject _keyboardMenuFirst;

        private bool isPaused;

        private void Start() {
            _mainMenuCanvasGO.SetActive(false);
            _settingsMenuCanvasGO.SetActive(false);
            _keyboardMenuCanvasGO.SetActive(false);
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

            EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
        }

        private void CloseAllMenus() {
            _mainMenuCanvasGO.SetActive(false);
            _settingsMenuCanvasGO.SetActive(false); 
            _keyboardMenuCanvasGO.SetActive(false);        
       
            EventSystem.current.SetSelectedGameObject(null);

        }

        private void OpenSettingsMenuHandle() {
             _settingsMenuCanvasGO.SetActive(true);
             _mainMenuCanvasGO.SetActive(false);
            _keyboardMenuCanvasGO.SetActive(false);

            EventSystem.current.SetSelectedGameObject(_settingsMenuFirst);

        }

        private void OpenKeyboardMenuHandle() {
             _settingsMenuCanvasGO.SetActive(false);
             _mainMenuCanvasGO.SetActive(false);
            _keyboardMenuCanvasGO.SetActive(true);

            EventSystem.current.SetSelectedGameObject(_keyboardMenuFirst);

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
 // -----------------Botões Menu Teclado -------------------//
       
        public void OnKeyboardBackPress(){
            OpenSettingsMenuHandle();
        }


    }
}
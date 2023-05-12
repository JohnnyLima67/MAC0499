using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TarodevController {
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject _mainMenuCanvasGO;
        [SerializeField] private GameObject _settingsMenuCanvasGO;
        [SerializeField] private GameObject _playerController;
        protected FrameInput FrameInput;

        private bool isPaused;

        private void Start() {
            _mainMenuCanvasGO.SetActive(false);
            _settingsMenuCanvasGO.SetActive(false);
        }

        private void Update() {
            if (PlayerInput.instance.FrameInput.EscapeDown) {
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
        }

        private void CloseAllMenus() {
            _mainMenuCanvasGO.SetActive(false);
            _settingsMenuCanvasGO.SetActive(false);        
        }

        private void OpenSettingsMenuHandle() {
             _settingsMenuCanvasGO.SetActive(true);
             _mainMenuCanvasGO.SetActive(false);
        }

        public void OnSettingsPress(){
            OpenSettingsMenuHandle();
        }

        public void OnResumePress() {
            Unpause();
        }

        public void OnSettingsBackPress() {
            OpenMainMenu();
        }
    }
}
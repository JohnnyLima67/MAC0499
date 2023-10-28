using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine. EventSystems;

namespace TarodevController {
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] Animator anim;
        private SceneLoader sceneLoader;

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
            _mainMenuCanvasGO.SetActive(true);
            _settingsMenuCanvasGO.SetActive(false);
            _keyboardMenuCanvasGO.SetActive(false);
            sceneLoader = GetComponent<SceneLoader>();
            EventSystem.current.SetSelectedGameObject(_mainMenuFirst);

        }

        private void OpenMainMenu() {
            _mainMenuCanvasGO.SetActive(true);
            _settingsMenuCanvasGO.SetActive(false);
            _keyboardMenuCanvasGO.SetActive(false);

            EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
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
        
        public void OnMainMenuPlayPress(){
            anim.SetTrigger("Start");
        }

        public void StartGame(){
            sceneLoader.LoadScene("Tutorial");
        }

        public void OnMainMenuSettingsPress(){
            OpenSettingsMenuHandle();
        }

        public void OnMainMenuExitPress() {
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;

        }
// -----------------Botões Menu Settings -------------------//

        public void OnSettingsBackPress() {
            OpenMainMenu();
            return;
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
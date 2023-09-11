using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine. EventSystems;

namespace TarodevController {
    public class DeathMenu : MonoBehaviour
    {
        private SceneLoader sceneLoader;

        [SerializeField] private GameObject _mainMenuCanvasGO;

        [SerializeField] private GameObject _playerController;
        protected FrameInput FrameInput;

        [Header("First Selected Options")]
        [SerializeField] private GameObject _mainMenuFirst;

        private bool isPaused;

        private void Start() {
            _mainMenuCanvasGO.SetActive(true);
            sceneLoader = GetComponent<SceneLoader>();
            EventSystem.current.SetSelectedGameObject(_mainMenuFirst);

        }

        private void OpenMainMenu() {
            _mainMenuCanvasGO.SetActive(true);

            EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
        }

// -----------------Botões Menu Principal -------------------//
        
        public void OnDeathMenuRestartPress(){
            sceneLoader.LoadCurrentScene();
        }

        public void OnDeathMenuExitPress(){
            sceneLoader.LoadScene("MainMenu");
        }


    }
}
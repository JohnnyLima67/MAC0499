using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TarodevController {
    public class Caller : MonoBehaviour
    {
        [SerializeField] public MainMenu menu;

        public void Call(){
            menu.StartGame();
        }
    }
}
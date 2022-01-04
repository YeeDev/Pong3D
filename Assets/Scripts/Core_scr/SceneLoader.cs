using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pong3D.Core
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] GameController gameController;

        public void LoadGame(int difficulty)
        {
            gameController.SetDifficulty(difficulty);
            SceneManager.LoadScene(1);
        }
    }
}

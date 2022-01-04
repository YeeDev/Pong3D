using UnityEngine;

namespace Pong3D.Core
{
    [CreateAssetMenu(fileName = "New Game Controller", menuName = "Game Controller")]
    public class GameController : ScriptableObject
    {
        public enum Difficulty { Easy, Medium, Hard }

        [SerializeField] Difficulty gameDifficulty = 0;

        public Difficulty GetDifficulty { get => gameDifficulty; }

        public void SetDifficulty(int i)
        {
            gameDifficulty = (Difficulty)i;
        }
    }
}
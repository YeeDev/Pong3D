using UnityEngine;
using UnityEngine.UI;

namespace Pong3D.Core
{
    public class ScoreUpdater : MonoBehaviour
    {
        [SerializeField] Text[] scoresText = null;

        int[] playersScores = new int[] { 0, 0 };

        public void UpdateScore(int scoreIndex)
        {
            playersScores[scoreIndex]++;
            scoresText[scoreIndex].text = playersScores[scoreIndex].ToString();
        }
    }
}
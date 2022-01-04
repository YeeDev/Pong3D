using Pong3D.Movement;
using UnityEngine;

namespace Pong3D.Control
{
    [RequireComponent(typeof(PaddleMover))]
    public class AIController : MonoBehaviour
    {
        Transform ball;
        PaddleMover paddleMover;

        private void Awake()
        {
            ball = GameObject.FindGameObjectWithTag("Ball").transform;
            paddleMover = GetComponent<PaddleMover>();
        }

        private void Update() { MovePaddle(); }

        private void MovePaddle()
        {
            Vector3 clampedXDirection = ball.position - transform.position;
            clampedXDirection.x = 0;

            paddleMover.MoveInDirection(clampedXDirection);
        }
    }
}
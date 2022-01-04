using Pong3D.Core;
using UnityEngine;

namespace Pong3D.Movement
{
    public class PaddleMover : MonoBehaviour
    {
        [SerializeField] float moveSpeed = 0f;
        [SerializeField] float fieldLimits = 2f;
        [SerializeField] GameController gameController = null;

        private void Awake()
        {
            if (transform.name == "AI Player") { moveSpeed += (float)gameController.GetDifficulty * 0.075f; }
        }

        public void MoveInDirection(Vector3 moveDirection)
        {
            transform.position = ClampPosition(moveDirection * moveSpeed);
        }

        private Vector3 ClampPosition(Vector3 moveSpeed)
        {
            moveSpeed *= this.moveSpeed;
            Vector3 clampedPosition = moveSpeed + transform.position;
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, -fieldLimits, fieldLimits);
            clampedPosition.z = Mathf.Clamp(clampedPosition.z, -fieldLimits, fieldLimits);

            return clampedPosition;
        }
    }
}
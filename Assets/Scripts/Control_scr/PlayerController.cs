using Pong3D.Movement;
using UnityEngine;

namespace Pong3D.Control
{
    [RequireComponent(typeof(PaddleMover))]
    public class PlayerController : MonoBehaviour
    {
        bool holdH;
        bool holdV;
        bool lastPressedH;
        Vector3 moveDirection;
        PaddleMover paddleMover;

        private void Awake() { paddleMover = GetComponent<PaddleMover>(); }

        private void Update()
        {
            CheckLastPressedKey();
            CalculateInputDirection();
        }

        private void FixedUpdate() { MoveInDirection(); }

        private void CheckLastPressedKey()
        {
            holdH = Input.GetButton("Horizontal");
            holdV = Input.GetButton("Vertical");

            if (holdH && !holdV || holdV && Input.GetButtonDown("Horizontal")) { lastPressedH = true; }
            if (holdV && !holdH || holdH && Input.GetButtonDown("Vertical")) { lastPressedH = false; }
        }

        private void CalculateInputDirection()
        {
            moveDirection.z = lastPressedH ? Input.GetAxisRaw("Horizontal") : 0;
            moveDirection.y = !lastPressedH ? Input.GetAxisRaw("Vertical") : 0;
        }

        private void MoveInDirection()
        {
            paddleMover.MoveInDirection(moveDirection);
        }
    }
}

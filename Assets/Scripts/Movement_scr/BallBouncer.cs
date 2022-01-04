using UnityEngine;
using System.Collections;

namespace Pong3D.Movement
{
    public class BallBouncer : MonoBehaviour
    {
        [SerializeField] float startingSpeed = 4;
        [SerializeField] float speedMultiplier = 0.05f;
        [SerializeField] float maxRandomizer = 0.75f;
        [SerializeField] float minRandomizer = 0.25f;
        [SerializeField] float waitTimeBeforeLaunch = 1f;

        int speedIncrementor;
        float bounceSpeed;
        Vector3 bounceDirection;
        Rigidbody rb;

        private void Awake() { rb = GetComponent<Rigidbody>(); }
        private void Start() { StartCoroutine(StartMatch()); }

        public IEnumerator StartMatch()
        {
            SetBallSpeed(Vector3.zero);
            transform.position = Vector3.zero;
            bounceSpeed = startingSpeed;
            bounceDirection = Vector3.one;

            yield return new WaitForSeconds(waitTimeBeforeLaunch);

            SetBallSpeed(Vector3.right);
        }

        public void SetBallSpeed(Vector3 direction)
        {
            direction *= bounceSpeed;
            rb.velocity = direction;
        }

        public void BounceBall(Transform collision)
        {
            RandomizeDirection(collision);
            SetBallSpeed(bounceDirection);
            IncreaseSpeed();
        }

        private void RandomizeDirection(Transform collision)
        {
            if (collision.CompareTag("Z Wall") || collision.CompareTag("Player"))
            {
                bounceDirection.z = Mathf.Sign(transform.position.z - collision.position.z) *
                    Random.Range(minRandomizer, maxRandomizer);
            }


            if (collision.CompareTag("Y Wall") || collision.CompareTag("Player"))
            {
                bounceDirection.y = Mathf.Sign(transform.position.y - collision.position.y) *
                    Random.Range(minRandomizer, maxRandomizer);
            }

            bounceDirection.x *= collision.transform.CompareTag("Player") ? -1 : 1;
            bounceDirection = bounceDirection.normalized;
        }

        private void IncreaseSpeed()
        {
            speedIncrementor++;
            bounceSpeed += speedIncrementor * speedMultiplier;
        }
    }
}

using UnityEngine;
using Pong3D.Movement;
using Pong3D.Core;

namespace Pong3D.Collisions
{
    [RequireComponent(typeof(BallBouncer))]
    public class BallCollisioner : MonoBehaviour
    {
        [SerializeField] AudioClip bounceClip = null;
        [SerializeField] AudioClip goalClip = null;

        BallBouncer ballBouncer;
        ScoreUpdater scoreUpdater;

        private void Awake()
        {
            ballBouncer = GetComponent<BallBouncer>();
            scoreUpdater = FindObjectOfType<ScoreUpdater>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            ballBouncer.BounceBall(collision.transform);
            AudioSource.PlayClipAtPoint(bounceClip, transform.position);
        }

        private void OnTriggerEnter(Collider other)
        {
            scoreUpdater.UpdateScore(other.name[other.name.Length - 1] - '0');
            AudioSource.PlayClipAtPoint(goalClip, transform.position);
            StartCoroutine(ballBouncer.StartMatch());
        }
    }
}
using UnityEngine;
using Random = UnityEngine.Random;


namespace FastHand
{
    public class WanderingAI : MonoBehaviour
    {
        [SerializeField] private float _speed = 3.0f;
        [SerializeField] private float _obstacleRange = 5.0f;

        private bool _alive = true;

        private void Update()
        {
            if (_alive)
            {
                transform.Translate(0, 0, _speed * Time.deltaTime);
                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;

                if (Physics.SphereCast(ray, 0.75f, out hit))
                {
                    if (hit.distance < _obstacleRange)
                    {
                        float angle = Random.Range(-110, 110);
                        transform.Rotate(0, angle, 0);
                    }
                }
            }
        }

        public void SetAlive(bool alive)
        {
            _alive = alive;
        }
    }
}

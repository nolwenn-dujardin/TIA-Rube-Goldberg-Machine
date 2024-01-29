using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndFuze : MonoBehaviour
{
    public GameObject fireworksExplosions;
    public GameObject rocket;
    public float speed;

    private bool isRocketLaunched;
    private bool hasRocketExploded = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isRocketLaunched = true;
        }
    }

    private void Update()
    {
        if (isRocketLaunched && !hasRocketExploded)
        {
            rocket.transform.position = Vector3.MoveTowards(rocket.transform.position, fireworksExplosions.transform.position, speed * Time.deltaTime);

            if (rocket.transform.position == fireworksExplosions.transform.position)
            {
                Destroy(rocket);
                hasRocketExploded = true;

                foreach (ParticleSystem particleSystem in fireworksExplosions.GetComponentsInChildren<ParticleSystem>())
                {
                    particleSystem.Play();
                }
            }
        }
    }
}

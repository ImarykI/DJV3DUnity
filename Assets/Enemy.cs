using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] ParticleSystem deathParticles;
    [SerializeField] Transform parent;

    ParticleSystem vfx;

    private void Start()
    {
        parent = GameObject.FindWithTag("SpawnAtRunTime").transform;

    }

    private void OnParticleCollision(GameObject other)
    {
        DeathSequence();
    }

    void DeathSequence()
    {
        vfx = Instantiate(deathParticles, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        Invoke(nameof(DestroySpawnedExplosition), 1);

    }

    void DestroySpawnedExplosition()
    {
        if(vfx != null)
        {
            Destroy(vfx.gameObject);
            vfx = null;
        }
        Destroy(gameObject);
    }
}

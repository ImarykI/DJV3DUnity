using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] ParticleSystem deathParticles;
    [SerializeField] Transform parent;

    [SerializeField] int hitPoints = 1;
    [SerializeField] ParticleSystem hitVFX;

    [SerializeField] int scorePoints = 10;
    ScoreBoard scoreBoard;

    ParticleSystem vfx;

    private void Start()
    {
        parent = GameObject.FindWithTag("SpawnAtRunTime").transform;
        scoreBoard = FindAnyObjectByType<ScoreBoard>();

        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;

    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
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

    void ProcessHit()
    {
        scoreBoard.IncreaseScore(scorePoints);
        hitPoints--;
        if (hitPoints < 1)
        {
            DeathSequence();
        }
        else
        {
            Vector3 vfxPosition = transform.position;
            vfxPosition.z -= transform.localScale.z;
            vfx = Instantiate(hitVFX, vfxPosition, Quaternion.identity);
            vfx.transform.parent = parent;
            Invoke(nameof(DestroySpawnedExplosition), 0.1f);
        }

    }

}

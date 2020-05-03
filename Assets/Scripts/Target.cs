using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float minSpeed = 12f;
    public float maxSpeed = 16f;
    public float maxTorque = 8;
    public float xRange = 4f;
    public float ySpawnPos = -6f;
    private Rigidbody targetRb;
    public int pointValue;
    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomUpwardForce(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        targetRb.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(),ForceMode.Impulse);
    }

    Vector3 RandomUpwardForce()
    {
        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        return Vector3.up * randomSpeed;
    }

    Vector3 RandomSpawnPos()
    {
        float randomXPos = Random.Range(-xRange, xRange);
        return new Vector3(randomXPos, ySpawnPos);
    }
    float RandomTorque()
    {
        return Random.Range(0, maxTorque);
    }

    private void OnMouseDown()
    {
        if (GameManager.Instance.isGameActive)
        {
            Instantiate(explosionEffect, transform.position, explosionEffect.transform.rotation);
            Destroy(gameObject);
            GameManager.Instance.UpdateScore(pointValue);
        }     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Bad")
        {
            GameManager.Instance.GameOver();
        }
        Destroy(gameObject);
    }

}

using UnityEngine;
using System.Collections;

public class DestryParticlesByTime : MonoBehaviour {

    public float destroyTime = 1f;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}

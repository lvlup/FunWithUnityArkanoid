using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {

    void OnTriggerEnter()
    {
        GameManager.instance.LoseLife();
    }
}

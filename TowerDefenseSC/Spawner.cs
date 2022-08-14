using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Character;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0, 4f);
    }

    void Spawn()
    {
        GameObject go = Instantiate(Character, Character.transform.position, Character.transform.rotation);
        go.transform.Rotate(new Vector3(0, Random.Range(-90, 90), 0));
    }
    // Update is called once per frame
}

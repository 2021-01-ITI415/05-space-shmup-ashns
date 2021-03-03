using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Part is another serializable data storage class just like WeaponDefinition
/// </summary>
[System.Serializable]

public class Enemy_5 : Enemy {

    [Header("Set in Inspector: Enemy_5")]
    public Part[] parts; // The array of ship Parts

    private Vector3 p0, p1; // The two points to interpolate
    private float timeStart; // Birth time for this Enemy_4
    private float duration = 8; // Duration of movement
    private Transform target;

    // These two fields are set automatically in Start().
    // Caching like this makes it faster and easier to find these later
    [HideInInspector] // Makes field on the next line not appear in the Inspector
    public GameObject go; // The GameObject of this part
    [HideInInspector]
    public Material mat;
    bool enemyShouldFollow;


    private void Start()
    {
        // There is already an initial position chosen by Main.SpawnEnemy()
        // so add it to points as the initial p0 & p1
        p0 = p1 = pos;
        target = GameObject.FindGameObjectWithTag("Hero").GetComponent<Transform>();
        InitMovement();

        // Cache GameObject & Material of each Part in parts
        Transform t;
        foreach (Part prt in parts)
        {
            t = transform.Find(prt.name);
            if (t != null)
            {
                prt.go = t.gameObject;
                prt.mat = prt.go.GetComponent<Renderer>().material;
            }
        }
        //enemyShouldFollow = true;
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    void InitMovement()
    {

        // Reset the time
        timeStart = Time.time;
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
  

    
}

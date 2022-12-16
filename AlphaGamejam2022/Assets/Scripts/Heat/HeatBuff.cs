using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatBuff : MonoBehaviour
{
    [SerializeField] private float size;
    [SerializeField] private int strength;

    [SerializeField] private Fireplace firePlaceScript;
    // Start is called before the first frame update
    void Start()
    {
        firePlaceScript = GameObject.Find("FirePlace").GetComponent<Fireplace>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(!col.gameObject.CompareTag("Player"))
            return;

        firePlaceScript.AddHeat(strength);
        Destroy(gameObject);
    }
}


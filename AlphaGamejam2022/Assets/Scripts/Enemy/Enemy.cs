
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private int dmg;
    [SerializeField] private int healthPoints;
    [SerializeField] private bool meele;
    public bool isMoving = true;
    private Transform player;

    private Vector2 endposition = new Vector2(0,0);
    private Vector2 target;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        target = endposition;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
            return;
        
        target = ChooseTarget();
        transform.position = Vector3.MoveTowards(transform.position, target , speed * Time.deltaTime); //player.position
    }

    private Vector2 ChooseTarget()
    {
        //var distance = System.Math.Sqrt((System.Math.Pow(player.position.x - transform.position.x , 2) + System.Math.Pow(player.position.y - transform.position.y, 2)));
        var distance = Vector2.Distance(player.position, transform.position); 
        if (distance < 5)
        {
            return player.position;
        }
        else
        {
            return endposition;
        }
    }

    public void TakeDamage(int damage)
    {
        healthPoints -= damage;
        if (CheckIfDead())
        {
            DestroyObject();
        }
    }
    private bool CheckIfDead()
    {
        if (healthPoints < 0)
        {
            return true;
        }
        return false;
    }
    private void DestroyObject()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Fire")){
            col.gameObject.GetComponent<Fireplace>().ReduceHeat();
            DestroyObject();
        }


        if(!col.gameObject.CompareTag("Player"))
            return;

        //col.gameObject.GetComponent<PlayerController>().takeDamage;
        DestroyObject();
    }
}

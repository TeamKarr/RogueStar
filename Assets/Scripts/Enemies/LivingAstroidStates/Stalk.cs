using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalk : EnemyBrain.State
{
    private float eyeContactTime = 0f;
    public float requiredEyeContactTime = 3f; // Set the required eye contact time in seconds

    private EnemyBrain brain;

    public override void Action()
    {
        // look at enemy
        Vector2 direction = (Player.transform.position - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);

        // Check if the asteroid has a clear line of sight to the player
        if (hit.collider != null && hit.collider.gameObject.CompareTag("Player"))
        {
            transform.up = direction;


            eyeContactTime += Time.deltaTime;
            if (eyeContactTime >= requiredEyeContactTime)
            {
                brain.SetState(Charge);
            }

        }
        else
        {
            eyeContactTime = 0f;
        }
    }

    void Start()
    {
        brain = GetComponent<EnemyBrain>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

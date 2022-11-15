using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasparStats : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int lives;
    public bool canJump;

    private Transform spawn;
    private Transform playerPos;

    public UI ui;
    public IsometricCharacterController move_script;
    public Jumping jump_script; 

    // Start is called before the first frame update
    void Start()
    {
        // Grab all Auxillary Scripts
        move_script = GetComponent<IsometricCharacterController>();
        jump_script = GetComponent<Jumping>();
        jump_script.enabled = false;

        //Respawn Mechanics
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        spawn = GameObject.FindGameObjectWithTag("Respawn").transform;

        
    }

    // Update is called once per frame
    void Update()
    {
        lifeAfterDeath(lives);

        if(health <= 0){
            StartCoroutine(ui.die_notice());
            playerDeath();
        }
    }

    void lifeAfterDeath(int lives){
        // Life After Death Mechanics
        if(lives == 9){
            maxHealth = 3;
            move_script.moveSpeed = 7;
        }

        if(lives == 8){
            maxHealth = 3;
            move_script.moveSpeed = 9;
        }

        if(lives == 7){
            maxHealth = 3;
            move_script.moveSpeed = 11;
        }

        if(lives == 6){
            maxHealth = 4;
            move_script.moveSpeed = 12;
        }

        if(lives == 5){
            maxHealth = 4;
            jump_script.enabled = true;
            jump_script.jumpHeight = 20;
        }

        if(lives == 4){
            maxHealth = 5;
        }

        if(lives == 3){
            maxHealth = 5;
            move_script.moveSpeed = 13;
        }

        if(lives == 2){
            maxHealth = 5;
            jump_script.jumpHeight = 500;
        }

        if(lives == 1){
            maxHealth = 5;
            move_script.moveSpeed = 15;
        }

        if(lives == 0){
            //TODO
        }
    }

    public void playerHit(){
        health = health - 1;
    }

    public void playerDeath(){
        lives -= 1;
        lifeAfterDeath(lives);
        health = maxHealth;
        ui.lifeCounter.SetText(lives.ToString());
        playerPos.position = new Vector3(spawn.position.x, spawn.position.y, spawn.position.z);
    }
}

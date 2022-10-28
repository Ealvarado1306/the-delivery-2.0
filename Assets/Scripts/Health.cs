using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    // Caspar Data Fields
    public int health;
    public int maxHealth;
    public int lives;
    public Rigidbody rb;
    public IsometricCharacterController move_script;
    public Jumping jump_script; 

    // Mechanics: Death and Rebirth
    private Transform spawn;
    private Transform playerPos;

    // GUI: Death and Rebirth
    public TMP_Text you_died;
    public TMP_Text new_ability;

    // GUI: Hearts
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // GUI: Life
    public TMP_Text lifeCounter;
    public Image image;
    public Sprite cat_happy;
    public Sprite cat_unhappy;
    public Sprite cat_mad;
    public Sprite cat_furious;

    // Start is called before the first frame update
    void Start()
    {
        //Grab Auxillary Scripts
        move_script = GetComponent<IsometricCharacterController>();
        jump_script = GetComponent<Jumping>();
        jump_script.enabled = false;

        //Respawn Mechanics
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        spawn = GameObject.FindGameObjectWithTag("Respawn").transform;

        // Sets the life counter to 9 when the scene is initialized
        lifeCounter.SetText(lives.ToString());

        // Hides all death notices
        you_died.enabled = false;
        new_ability.enabled = false; // TODO: Implement this changing when player dies

        // This is janky, but need to hide hearts 4 and 5 until caspar loses more lives
        hearts[3].enabled = false;
        hearts[4].enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Life After Death Mechanics
        lifeAfterDeath(lives);


        // Implemented this instead of a deathbox... Super buggy & bad TODO: replace this shit
        if (rb.position.y <= -10) {
            StartCoroutine(die_notice());
            playerDeath();
        }

        // Activating Death 
        if(health <= 0){
            StartCoroutine(die_notice());
            playerDeath();
        }

        // Everything related to damage
        if (Input.GetKeyDown(KeyCode.G)) {
            playerHit();
        } 

        // Everything related to hearts UI
        if(health > numOfHearts){
            health = numOfHearts;
        }
        for(int i = 0; i < hearts.Length; i++){
            if(i < health){
                hearts[i].sprite = fullHeart;
            } else{
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    void lifeAfterDeath(int lives){
        // Life After Death Mechanics
        if(lives == 9){
            image.sprite = cat_happy;
            maxHealth = 3;
            move_script.moveSpeed = 7;
        }

        if(lives == 8){
            image.sprite = cat_happy;
            maxHealth = 3;
            move_script.moveSpeed = 9;
        }

        if(lives == 7){
            image.sprite = cat_unhappy;
            maxHealth = 3;
            move_script.moveSpeed = 11;
        }

        if(lives == 6){
            image.sprite = cat_unhappy;
            hearts[3].enabled = true;
            maxHealth = 4;
            move_script.moveSpeed = 12;
        }

        if(lives == 5){
            image.sprite = cat_mad;
            maxHealth = 4;
            jump_script.enabled = true;
            jump_script.jumpHeight = 20;
        }

        if(lives == 4){
            image.sprite = cat_mad;
            maxHealth = 5;
            hearts[4].enabled = true;
        }

        if(lives == 3){
            image.sprite = cat_furious;
            maxHealth = 5;
            move_script.moveSpeed = 13;
        }

        if(lives == 2){
            image.sprite = cat_furious;
            maxHealth = 5;
            jump_script.jumpHeight = 500;
        }

        if(lives == 1){
            image.sprite = cat_furious;
            maxHealth = 5;
            move_script.moveSpeed = 15;
        }

        if(lives == 0){
            gameOver();
        }
    }

    void playerDeath(){
        lives -= 1;
        lifeAfterDeath(lives);
        health = maxHealth;
        lifeCounter.SetText(lives.ToString());
        playerPos.position = new Vector3(spawn.position.x, spawn.position.y, spawn.position.z);
    }

    void playerHit(){
        health = health - 1;
        Debug.Log(health);
    }

    void gameOver(){
        //TODO: Add some shit that says i'm sorry lmao 
        Application.Quit();
    }

    IEnumerator die_notice(){
        you_died.enabled = true;
        yield return new WaitForSeconds(3);
        you_died.enabled = false;
    }


}

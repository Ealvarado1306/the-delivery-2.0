using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    // Other Scripts
    public CasparStats caspar;

    // For Death Audio 
    public AudioSource deathSound;

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
    public Image avatar;
    public Sprite cat_happy;
    public Sprite cat_unhappy;
    public Sprite cat_mad;
    public Sprite cat_furious;

    // Start is called before the first frame update
    void Start()
    {
        // Sets the life counter to 9 when the scene is initialized
        lifeCounter.SetText(caspar.lives.ToString());

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
        lifeAfterDeathUI(caspar.lives);

        for(int i = 0; i < hearts.Length; i++){
            if(i < caspar.health){
                hearts[i].sprite = fullHeart;
            } else{
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    void lifeAfterDeathUI(int lives){
        if(lives == 9){
            avatar.sprite = cat_happy;
        }

        if(lives == 8){
            avatar.sprite = cat_happy;
            new_ability.text = "Speed +5%!";
        }

        if(lives == 7){
            avatar.sprite = cat_unhappy;
            new_ability.text = "Speed +10%!";
        }

        if(lives == 6){
            avatar.sprite = cat_unhappy;
            hearts[3].enabled = true;
            new_ability.text = "+1 Heart!";
        }

        if(lives == 5){
            avatar.sprite = cat_mad;
            new_ability.text = "Jumping Enabled!";
        }

        if(lives == 4){
            avatar.sprite = cat_mad;
            hearts[4].enabled = true;
            new_ability.text = "+1 Heart!";
        }

        if(lives == 3){
            avatar.sprite = cat_furious;
            new_ability.text = "Speed +20%";
        }

        if(lives == 2){
            avatar.sprite = cat_furious;
            new_ability.text = "Jump Height Increased!";
        }

        if(lives == 1){
            avatar.sprite = cat_furious;
            new_ability.text = "Speed +25%!";
        }

        if(lives == 0){
            //TODO
        }
    }
    
    public IEnumerator die_notice(){
        deathSound.Play();
        you_died.enabled = true;
        new_ability.enabled = true;
        yield return new WaitForSeconds(3);
        you_died.enabled = false;
        new_ability.enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hitbox : MonoBehaviour
{
    public Text ScoreText;
    public int counter = 0;
    

   void Start()
    {
        SetScoreText();
        Scene curentScene = SceneManager.GetActiveScene();
    }

    void Update()
    {
    
    // HitBox Changes Tag on button press
         if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.tag = "Yellow";
        }
        else if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            gameObject.tag = "Red";
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            gameObject.tag = "Green";
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            gameObject.tag = "Blue";
        }

    
    // This changes the scene after a certain amount of points were gained
         if(counter >= 6 && SceneManager.GetActiveScene().name == "level1" )
        {
            SceneManager.LoadScene("level2");
            counter = 0;
   
        }
        else if (counter >= 6 && SceneManager.GetActiveScene().name == "level2")
        {
            SceneManager.LoadScene("level3");
            counter = 0;
            Debug.Log ("Boytime");
        }
        else if (counter >= 6 && SceneManager.GetActiveScene().name == "level3")
        {
            SceneManager.LoadScene("GameEnd");
            counter = 0;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("StartMenu");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
    // This detects if the tags match, if they do they defeat the enemy 
        if (collision.tag == "Yellow" && gameObject.tag == "Yellow")
        {
            SoundManager.Playsound("Hit1");
            counter++;
            SetScoreText();
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Red" && gameObject.tag == "Red")
        {
            SoundManager.Playsound("Hit2");
            counter++;
            SetScoreText();
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Green" && gameObject.tag == "Green")
        {
            SoundManager.Playsound("Hit3");
            counter++;
            SetScoreText();
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Blue" && gameObject.tag == "Blue")
        {
            SoundManager.Playsound("Hit4");
            counter++;
            SetScoreText();
            Destroy(collision.gameObject);
        }

    }
// Sets the score
    void SetScoreText()
    {
        ScoreText.text = "Score: " + counter.ToString();
    }

}

   

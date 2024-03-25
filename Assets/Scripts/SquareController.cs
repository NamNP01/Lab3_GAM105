using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SquareController : MonoBehaviour
{
    public float timeRemaining=60;
    public Text cowndownText;
    public Text ScoreText;
    public Text HPText;
    public float Score;
    public float A;
    public float B;
    public float HP;
    public float Mission;

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown());
        Vector2 fistPosition = new Vector2(A,B);
        transform.position = fistPosition;
        HPText.text = "HP: " + HP.ToString();
    }
    IEnumerator Countdown()
    {
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1);
            timeRemaining--;
            cowndownText.text = "Time: " + timeRemaining. ToString();
            if(timeRemaining==0)
            {
                LoadThisScene();
            }
        }
        cowndownText.text = "Time's up!";
        
    }


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, vertical, 0f).normalized;
        transform.Translate(movement * 5f * Time.deltaTime);
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("CheckPoint"))
        {
            A = collision.gameObject.transform.position.x;
            B = collision.gameObject.transform.position.y;
        }
    }
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadThisScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Circle"))
        {
            if (HP > 0)
            {
                Vector2 fistPosition = new Vector2(A, B);
                transform.position = fistPosition;
                HP--;
                HPText.text = "HP: " + HP.ToString();
            }
            else
            {
                LoadThisScene();
            }
        }
        if (collision.gameObject.name.Equals("Box"))
        {
            if (Mission == Score)
            {
                LoadNextScene();
            }
            
        }
        if(collision.gameObject.tag.Equals("PinWheel"))
        {
            if(HP>0)
            {
                Vector2 fistPosition = new Vector2(A, B);
                transform.position = fistPosition;
                HP--;
                HPText.text = "HP: " + HP.ToString();
            }
            else
            {
                LoadThisScene();
            }

        }
        if (collision.gameObject.tag.Equals("YellowCircle"))
        {
            Destroy(collision.gameObject);
            Score++;
            ScoreText.text = "Score: " + Score.ToString();
        }
    }
}

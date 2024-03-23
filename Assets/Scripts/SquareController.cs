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
    public float Score;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown());
    }
    IEnumerator Countdown()
    {
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1);
            timeRemaining--;
            cowndownText.text = "Time: " + timeRemaining. ToString();
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
            LoadThisScene();
        }
        if (collision.gameObject.name.Equals("Box"))
        {
            Debug.Log("Win");
            LoadNextScene();
        }
        if(collision.gameObject.tag.Equals("PinWheel"))
        {
            //Vector2 fistPosition = new Vector2((float)-5.48, (float)0.9899999);
           // transform.position = fistPosition;
            LoadThisScene();
        }
        if (collision.gameObject.tag.Equals("YellowCircle"))
        {
            Destroy(collision.gameObject);
            Score++;
            ScoreText.text = "Score: " + Score.ToString();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SquareController : MonoBehaviour
{
    public float timeRemaining=60;
    public Text cowndownText;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Circle"))
        {
            Vector2 fistPosition = new Vector2((float)-6.22, (float)1.4);
            transform.position = fistPosition;
        }
        if (collision.gameObject.name.Equals("Box"))
        {
            Debug.Log("Win");
            LoadNextScene();
        }
    }
}

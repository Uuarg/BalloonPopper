using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public float UpSpeed = 0.05f;
    int Score = 0;
    AudioSource audioSource;
    public TextMeshProUGUI scoreText;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 7f)
        {
            //SceneManager.LoadScene("Game");      //// only works for a single level named "Game"
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); ////// Create multiple levels it works by the indexes
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(0, UpSpeed, 0);
    }

    void OnMouseDown()
    {
        Score++;
        float temp = Score/5;

        scoreText.text = Score.ToString();

        if (temp == 1)
        {
            UpSpeed = UpSpeed + 0.01f;
        }

        audioSource.Play();

        ResetPosition();
    }

    private void ResetPosition()
    {
        float randomX = Random.Range(-2.5f,2.5f);
        transform.position = new Vector2(randomX, -7f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10;
    public float leftInput;
    public float forwardInput;
    private float zRange = 3;
    private float xRangeMin = -17;
    private float xRangeMax = -5;
    public GameObject projectilePrefab;
    private float lastCallTime = 0;
    public GameObject powerUpIndicator1;
    public GameObject powerUpIndicator2;
    public Transform bulletSpawner;
    public Transform bulletSpawner1;
    private GameManager gameManager;
    public AudioClip carSound;
    public AudioClip shootSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    public bool hasPowerup;
    public bool hasPowerUp2;
    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerAudio = GetComponent<AudioSource>();
        enemy = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        leftInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");



        if (gameManager.isGameActive)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * leftInput);
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

            if (Input.GetKeyDown(KeyCode.D))
            {
                playerAudio.loop = true;
                playerAudio.clip = carSound;
                playerAudio.Play();
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                playerAudio.loop = true;
                playerAudio.clip = carSound;
                playerAudio.Play();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                playerAudio.loop = true;
                playerAudio.clip = carSound;
                playerAudio.Play();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                playerAudio.loop = true;
                playerAudio.clip = carSound;
                playerAudio.Play();
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                playerAudio.Stop();
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                playerAudio.Stop();
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                playerAudio.Stop();
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                playerAudio.Stop();
            }

            if (Input.GetKeyDown(KeyCode.Space) && Time.time - lastCallTime > 0.5f)
            {
                Instantiate(projectilePrefab, bulletSpawner.position, projectilePrefab.transform.rotation);
                lastCallTime = Time.time;
                playerAudio.PlayOneShot(shootSound, 1.0f);
            }
        }



        if (transform.position.x < xRangeMin)
        {
            transform.position = new Vector3(xRangeMin, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRangeMax)
        {
            transform.position = new Vector3(xRangeMax, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup 1"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
        if (other.CompareTag("Powerup 1"))
        {
            Time.timeScale = 0.5f;
            powerUpIndicator1.gameObject.SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Powerup 2"))
        {
            hasPowerUp2 = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
        if (other.CompareTag("Powerup 2"))
        {
            gameManager.AddHealth(1);
            Destroy(other.gameObject);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        hasPowerup = false;
        hasPowerUp2 = false;
        Time.timeScale = 1.0f;
        powerUpIndicator1.gameObject.SetActive(false);
    }
}

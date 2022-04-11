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
    public Transform bulletSpawner;
    private GameManager gameManager;
    public AudioClip carSound;
    public AudioClip shootSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        leftInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

       if(gameManager.isGameActive)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * leftInput);
            if(Input.GetKeyDown(KeyCode.W))
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed * leftInput);
            }
            
            if(Input.GetKeyDown(KeyCode.S))
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed * leftInput);
            }
            
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
                playerAudio.PlayOneShot(carSound, 0.25f);
            }

            if(Input.GetKeyDown(KeyCode.A))
            {
                transform.Translate(Vector3.back * Time.deltaTime * speed * forwardInput);
                playerAudio.PlayOneShot(carSound, 0.25f);
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
}

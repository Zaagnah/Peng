
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using CrazyGames;
public class PlayerMove : MonoBehaviour
{

    public GameObject player;
    public Joystick joystick;
    public int level;
    public int scoreLvl = 0;
    Animator anim;


    private Rigidbody rigidbody;


    public bool isGrounded;
    [SerializeField]
    float speed = 0.1f;
    [SerializeField]
    float jumpHeight = 0.5f;
    [SerializeField]
    ParticleSystem finishPart;

    public void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        isGrounded = true;
        anim = GetComponent<Animator>();

        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("3978731", false);
        }
        scoreLvl = PlayerPrefs.GetInt("ScoreLvl", scoreLvl);

    }
    public void Update()
    {
       
        Move();
        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Jump();

            }
        }
    }

    public void Jump()
    {
        while (isGrounded)
        {
            Debug.Log("Jump");
            anim.Play("idle");
            rigidbody.velocity = new Vector3(0f, jumpHeight, 0f);
            isGrounded = false;
            
        }
    }

    public void Move()
    {

        float horizontalInput = Input.GetAxis("Horizontal"); //клавиши
        float verticalInput = Input.GetAxis("Vertical");
        //float horizontalInput = joystick.Horizontal;  //мобильное
        //float verticalInput = joystick.Vertical;

        transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * speed * Time.deltaTime);
        if(((horizontalInput != 0)||(verticalInput != 0))&& isGrounded)
        {
            anim.Play("walk");
        }
        
    }

    void OnCollisionEnter(Collision other)
    {
        isGrounded = true;

        switch (other.gameObject.tag)
        {
            case "Finish":
                {

                    Invoke("LoadNextLevel", 3f);
                    break;
                }
        }


    }
    private void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0; // loop back to start
        }
        SceneManager.LoadScene(nextSceneIndex);
        Debug.Log("loaded");
        PlayerPrefs.SetInt("Level", nextSceneIndex);
        PlayerPrefs.Save();
        Debug.Log("saved");
        level = nextSceneIndex;
        scoreLvl++;
        PlayerPrefs.SetInt("ScoreLvl", scoreLvl);
        PlayerPrefs.Save();
        if (scoreLvl == 4)
        {
            Reklama();
        }

    }
    public void Reklama()
    {
        Advertisement.IsReady("video");
        {
            CrazyAds.Instance.beginAdBreak();
            scoreLvl = 0;
            PlayerPrefs.SetInt("ScoreLvl", scoreLvl);
            PlayerPrefs.Save();
        }
    }
        void OnCollisionExit(Collision other)
        {

        }


        public void LoadFirstLevel()
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        public void LoadLevel()
        {
            level = PlayerPrefs.GetInt("Level", level);
            SceneManager.LoadScene(level);
        }
    }


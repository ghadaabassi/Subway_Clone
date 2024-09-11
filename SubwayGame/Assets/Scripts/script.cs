using UnityEngine;
using TMPro;

public class MobileScript : MonoBehaviour
{
    Animator anim;
    int score=0;
    float speed = 190.0f;
    float stepSize = 22.0f;

    private Rigidbody rb;
    public float backwardDistance = 300f;
    private bool isJumping = false;
    public float jumpForce = 3000.0f;
    public float gravityMultiplier = 2.0f;
    bool isRolling = false;
    public TMP_Text txt; 
    int money;
    public TMP_Text text;
    public TMP_Text txtreslt;

    private int tapCount = 0;
    private const float timeBetweenTaps = 0.4f;
    private float lastTapTime;
    public AudioClip FirstAudioClip;
    public AudioClip SecondAudioClip;
    public AudioClip ThirdAudioClip;
    public AudioClip AudioClip4;

    AudioSource audiosrc;
    AudioSource audios;
    AudioSource audios1;
    AudioSource audios2;
    public GameObject deathPanel;
    private bool isDead = false;




    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        money = 0;
        audiosrc = gameObject.AddComponent<AudioSource>();
        audiosrc.clip = FirstAudioClip;

        audios = gameObject.AddComponent<AudioSource>();
        audios.clip = SecondAudioClip;
        audios1 = gameObject.AddComponent<AudioSource>();
        audios1.clip = ThirdAudioClip;
        audios2 = gameObject.AddComponent<AudioSource>();
        audios2.clip = AudioClip4;
        audios2.loop = true;
        audios2.Play();
    }

    void Update()
    {
        float trans = speed * Time.deltaTime;

        anim.SetBool("isRunning", true);
        HandleTouchInput();
        transform.Translate(0, 0, trans);
        money = int.Parse(text.text);
        if (!isDead) 
        {
            score = int.Parse(txt.text);
            score++;
            txt.text = score.ToString();
        }
    }

    void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (Time.time - lastTapTime > timeBetweenTaps)
                {
                    tapCount = 0;
                }

                lastTapTime = Time.time;
                tapCount++;
                if (tapCount == 1)
                {
                    DoubleTap(touch);
                }
                else if (tapCount == 2)
                {
                    SingleTap(touch);
                }

            }
        }
    }

    void SingleTap(Touch touch)
    {
        float middle = Screen.width / 2;

        if (touch.position.x < middle  && (Vector3.left.x * stepSize) + transform.position.x > -87)
        {
                transform.Translate(Vector3.left * stepSize);
           
        }
        else if (touch.position.x >= middle && (Vector3.right.x * stepSize) + transform.position.x < -40)
        {
           
                transform.Translate(Vector3.right * stepSize);
        }
    }


    void DoubleTap(Touch touch)
    {
        if (touch.position.y > Screen.height / 2 && !isJumping)
        {
            Jump();
        }
        if (touch.position.y < Screen.height / 2 && !isRolling)
        {
            isRolling = true;
            Debug.Log("Start Rolling");
            anim.SetBool("isRolling", isRolling);
        }
    }

    void Jump()
    {
        isJumping = true;
        anim.SetBool("isJumping", isJumping);
    }

    public void OnJumpAnimationEnd()
    {
        isJumping = false;
        anim.SetBool("isJumping", isJumping);
    }

    public void OnRollingAnimationEnd()
    {
        isRolling = false;
        anim.SetBool("isRolling", isRolling);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "barrier" || other.tag=="subway" || (other.tag == "minibr" && isJumping == false) || (other.tag == "bigbr" && isRolling == false))
        {
             speed = 0;
             anim.SetBool("isDead", true);
             audios.Play();
            //audios2.loop = false;
            isDead = true;
            txtreslt.text += score.ToString();
            if (audios2.isPlaying)
            {
                audios2.Stop();
            }


            if (deathPanel != null)
            {
                deathPanel.SetActive(true);
            }
        }
        
        if (other.tag == "prize")
        {
          
            money += 10;
            text.text = money.ToString();
            Destroy(other.gameObject);
            audios1.Play();
        }

        if (other.tag == "coin")
        {
            money += 1;
            text.text = money.ToString();
            Destroy(other.gameObject);
            audiosrc.Play();
           
        }

        if (other.tag == "double")
        {
            score+= 200;
            txt.text = score.ToString();
            Destroy(other.gameObject);
            audios1.Play();
        }

    }
}

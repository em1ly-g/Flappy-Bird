using UnityEngine;

public class Player : MonoBehaviour
{
    // Public variables will appear in the editor

    // Sprite fields
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;

    // Motion/position fields
    private Vector3 direction;
    public float gravity = -9.8f; //allows you to customise the gravity
    public float strength = 5f;

    // Called once automatically when initalising
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Automatically called the very first frame that the object is enabled
    private void Start()
    {
        // Will call function every 0.15 s
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void AnimateSprite()
    {
        spriteIndex++;
        
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }


    // Unity automatically calls this every frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
        }

        // can also check for touch if playing on mobile
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }

        // We need to apply gravity every frame
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime; // This makes it frame rate independent

    }

    // Checks if the player has run into another trigger collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver(); // This is expensive to use. Ok for this game.
        }else if (other.gameObject.tag == "Scoring"){
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}


using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{//Deni

    //As you can we create a event action for our score change. This let's us to subcribe our event in our ScoreUI script and let's us change value of numbers.
    //We create our variable for our rigidbody, spped change, a refernce for movementcontroller, Weapon reference,- score and double score mode.
    public event System.Action OnScoreChanged;
    [SerializeField] private float _movementSpeed;
    private Rigidbody _rigidBody;
    private ShipMovementController _movementController;
    private Weapon _weapon;
    public int Score => _score;
    private int _score;
    private bool isDoubleScoreMode;
    private int _highScore;
    [SerializeField] private Screen_Flash screenFlash;



    //We will use this generic code to find out compenets so we can move our player or shoot example.
    //Loads up
    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _movementController = new ShipMovementController(_rigidBody);
        _weapon = GetComponent<Weapon>();
        _highScore = PlayerPrefs.GetInt("HighScore");
    }

    private void FixedUpdate()
    {
        _movementController.Move(_movementSpeed);
    }
    //Here we addding score if a enemy gets hit with the bullet, if the DoubleScoreMode is active, than we going to add double amount of scores that we will gain.
    public void OnEnemyKill()
    {
        if (isDoubleScoreMode)
        {
            _score += 2;
        }
        else
        {
            _score++;

        }
        if (_score > _highScore)
        {
            _highScore = _score;
            PlayerPrefs.SetInt("HighScore", _highScore);
        }
        OnScoreChanged?.Invoke();

    }
    //Here this script checks which type of powerups did we collide exactly. We using trigger enter so we don't get stuck between two object. In this code is there two types of power ups that will activate depends on-
    //script holder it collided with
    private void OnTriggerEnter(Collider col)
    {
        if (col.TryGetComponent(out PowerUp _powerup))
        {
            if (_powerup is MinigunMode)
            {
                StartCoroutine(_weapon.ActiveMinigunMode());
            }
            if (_powerup is DoubleScoreMode)
            {
                StartCoroutine(ActiveDoubleScoreMode());
            }
        }

        if (col.TryGetComponent(out Enemy enemy))
        {
            SceneManager.LoadScene(2);

        }
        
        //Aktiverar flash när man blir träffad -Simon
        if (col.tag == "Enemy")
        {
            screenFlash.flash = true;
        }


    }
    //We we create Ienumen so we create from this to a corutine so we can doublescore time in 10 seconds or longer how much time we want.
    public IEnumerator ActiveDoubleScoreMode()
    {
        isDoubleScoreMode = true;
        yield return new WaitForSeconds(10);
        isDoubleScoreMode = false;
    }

 



}



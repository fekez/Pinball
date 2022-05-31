using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    [SerializeField] private Text _lifeText;
    [SerializeField] private Text _gameOver;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _slider;
    private Rigidbody2D _body;
    private bool _startGame;
    private float _startTime;
    private float _baseSpeed;
    private string _life = " <3 ";
    private int _lifeCount;
    private float _cameraHeight;

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _startGame = true;
        _baseSpeed = _speed;
        _lifeCount = 3;
        StringBuilder strB = new StringBuilder();
        strB.Clear();
        for(int i = _lifeCount; i > 0; i--)
        {
            
            strB.Append(_life);
        }

        _lifeText.text = strB.ToString();

        _cameraHeight = Camera.main.orthographicSize + Camera.main.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _startGame)
        {
            _body.velocity = new Vector2(0, _speed);
            _startGame = false;
        }

        _body.velocity = _body.velocity.normalized * _speed;

        if(transform.position.y < -_cameraHeight)
        {
            if (--_lifeCount > 0)
            {
                _body.velocity = Vector3.zero;
                _body.angularVelocity = 0;
                transform.position = new Vector3(_slider.transform.position.x, _slider.transform.position.y + 0.45f, 0);
                _speed = _baseSpeed;
                _startGame = true;

                StringBuilder strB = new StringBuilder();
                strB.Clear();
                for (int i = _lifeCount; i > 0; i--)
                {

                    strB.Append(_life);
                }

                _lifeText.text = strB.ToString();
            }
            else
            {
                _lifeText.text = "";
                _gameOver.text = "GAME OVER!";
                _body.velocity = Vector3.zero;
                _body.angularVelocity = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "brick(Clone)" && _speed < 20)
        {
            _speed += 0.1f;
            _startTime = Time.time;
        }
        else if(Time.time - _startTime > 15f && collision.gameObject.name != "slider")
        {
            print(Time.time - _startTime);
            _body.velocity = new Vector2(_body.velocity.x + 1f, _body.velocity.y + 1f);
            _startTime = Time.time;
        }


        //if(collision.gameObject.name == "floor")
        //{
        //    if (--_lifeCount > 0)
        //    {
        //        _body.velocity = Vector3.zero;
        //        _body.angularVelocity = 0;
        //        transform.position = new Vector3(_slider.transform.position.x, _slider.transform.position.y + 0.45f, 0);
        //        _speed = _baseSpeed;
        //        _startGame = true;

        //        StringBuilder strB = new StringBuilder();
        //        strB.Clear();
        //        for (int i = _lifeCount; i > 0; i--)
        //        {

        //            strB.Append(_life);
        //        }

        //        _lifeText.text = strB.ToString();
        //    }
        //    else
        //    {
        //        _lifeText.text = "";
        //        _gameOver.text = "GAME OVER!";
        //        _body.velocity = Vector3.zero;
        //        _body.angularVelocity = 0;
        //    }


        //}
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "slider" && _startGame)
        {
            _body.velocity = Vector3.zero;
            _body.angularVelocity = 0;
            transform.position = new Vector3(collision.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}

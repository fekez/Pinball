using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField] private Sprite _life2;
    [SerializeField] private Sprite _life1;
    private SpriteRenderer _spriteRenderer;
    private int _lifeCount;


    // Start is called before the first frame update
    void Start()
    {
        _lifeCount = 0;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "ball")
        {
            switch (_lifeCount)
            {
                case 0: _spriteRenderer.sprite = _life2; break;
                case 1: _spriteRenderer.sprite = _life1; break;
                case 2: Destroy(gameObject); break;
            }

            _lifeCount++;
        }

    }
}

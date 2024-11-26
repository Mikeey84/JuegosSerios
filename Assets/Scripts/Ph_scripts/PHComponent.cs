using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PHComponent : MonoBehaviour
{
    [SerializeField] GameObject _box;
    [SerializeField] GameObject _button;
    [SerializeField] GameObject _book;
    [SerializeField] ColorOption selectedColor;

    public enum ColorOption
    {
        Red,
        Yellow,
        Green,
        Blue,
        Purple
    }

    // Update se ejecuta una vez por frame
    void Update()
    {
        if (transform.position.y < 0)
        {
            SpriteRenderer spriteRenderer = _box.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                switch (selectedColor)
                {
                    case ColorOption.Red:
                        spriteRenderer.color = Color.red;
                        break;
                    case ColorOption.Yellow:
                        spriteRenderer.color = Color.yellow;
                        break;
                    case ColorOption.Green:
                        spriteRenderer.color = Color.green;
                        break;
                    case ColorOption.Blue:
                        spriteRenderer.color = Color.blue;
                        break;
                    case ColorOption.Purple:
                        spriteRenderer.color = new Color(0.5f, 0, 0.5f);
                        break;
                }
                if(_button != null)
                {
                    _button.SetActive(true);
                }
                if(_book != null)
                {
                    _book.SetActive(true);
                }
            }
            else
            {
                Debug.LogError("El GameObject _box no tiene un componente SpriteRenderer.");
            }
        }
    }
}

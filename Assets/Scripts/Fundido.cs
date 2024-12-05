using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fundido : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Color _color = new Color(sprite.color.r, sprite.color.g , sprite.color.b , sprite.color.a );
        sprite.color = ;
    }
}

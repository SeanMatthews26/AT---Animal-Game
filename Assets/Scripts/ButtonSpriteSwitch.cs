using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class ButtonSpriteSwitch : MonoBehaviour
{
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite lookedAtSprite;

    private GazeAware gazeAware;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        gazeAware = GetComponent<GazeAware>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gazeAware.HasGazeFocus)
        {
            spriteRenderer.sprite = lookedAtSprite; 
        }
        else
        {
            spriteRenderer.sprite = normalSprite;
        }
    }
}

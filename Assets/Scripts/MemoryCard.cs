using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    [SerializeField] GameObject cardBack;
    [SerializeField] SceneController sceneController;

    public int Id { get; private set; }

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer SpriteRenderer
    {
        get
        {
            if (spriteRenderer == null)
                spriteRenderer = GetComponent<SpriteRenderer>();
            return spriteRenderer;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (cardBack.activeSelf && sceneController.CanReveal)
        {
            cardBack.SetActive(false);
            sceneController.CardRevealed(this);
        }
    }

    public void SetCard(int id, Sprite image)
    {
        Id = id;
        SpriteRenderer.sprite = image;
    }

    public void Unreveal()
    {
        cardBack.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    [SerializeField] GameObject targetObject;
    [SerializeField] string targetMessage;

    public Color HightlightColor = Color.cyan;

    private SpriteRenderer spriteRenderer_;
    private SpriteRenderer SpriteRenderer
    {
        get
        {
            if (spriteRenderer_ == null)
                spriteRenderer_ = GetComponent<SpriteRenderer>();
            return spriteRenderer_;
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

    void OnMouseEnter()
    {
        if (SpriteRenderer != null)
            SpriteRenderer.color = HightlightColor;
    }

    void OnMouseExit()
    {
        if (SpriteRenderer != null)
            SpriteRenderer.color = Color.white;
    }

    void OnMouseDown()
    {
        // The button's size pops a bit when it's clicked
        transform.localScale *= 1.1f;
    }

    void OnMouseUp()
    {
        transform.localScale = Vector3.one;
        if (targetObject != null)
            targetObject.SendMessage(targetMessage);
    }
}

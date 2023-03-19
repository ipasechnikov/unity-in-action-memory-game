using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float offsetX = 2f;
    public const float offsetY = 2.5f;

    [SerializeField] MemoryCard originalCard;
    [SerializeField] Sprite[] images;

    // Start is called before the first frame update
    void Start()
    {
        // Positio of the first card. All other cards will be offest from here
        var startPos = originalCard.transform.position;

        for (var row = 0; row < gridRows; row++)
            for (var col = 0; col < gridCols; col++)
            {
                var card = (row != 0 || col != 0)
                    ? Instantiate(originalCard)
                    : originalCard;

                var id = Random.Range(0, images.Length);
                var sprite = images[id];
                card.SetCard(id, sprite);

                var posX = (offsetX * col) + startPos.x;
                var posY = -(offsetY * row) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
    }

    // Update is called once per frame
    void Update()
    {
    }
}

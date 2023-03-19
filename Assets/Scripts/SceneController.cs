using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class SceneController : MonoBehaviour
{
    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float offsetX = 2f;
    public const float offsetY = 2.5f;

    [SerializeField] MemoryCard originalCard;
    [SerializeField] Sprite[] images;
    [SerializeField] TMP_Text scoreLabel;

    private int score = 0;

    private MemoryCard firstRevealed;
    private MemoryCard secondRevealed;

    public bool CanReveal => secondRevealed == null;

    // Start is called before the first frame update
    void Start()
    {
        // Position of the first card. All other cards will be offest from here
        var startPos = originalCard.transform.position;

        var cardIds = new[] { 0, 0, 1, 1, 2, 2, 3, 3 };
        ShuffleCards(cardIds);

        for (var row = 0; row < gridRows; row++)
            for (var col = 0; col < gridCols; col++)
            {
                var card = (row != 0 || col != 0)
                    ? Instantiate(originalCard)
                    : originalCard;

                var cardIdIndex = (row * gridCols) + col;
                var cardId = cardIds[cardIdIndex];
                var sprite = images[cardId];
                card.SetCard(cardId, sprite);

                var posX = (offsetX * col) + startPos.x;
                var posY = -(offsetY * row) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void CardRevealed(MemoryCard card)
    {
        if (firstRevealed == null)
            firstRevealed = card;
        else
        {
            secondRevealed = card;
            StartCoroutine(CheckMatch());
        }
    }

    private void ShuffleCards(int[] cardIds)
    {
        for (var i = cardIds.Length - 1; i >= 0; i--)
        {
            var newIndex = Random.Range(0, i);
            var temp = cardIds[i];
            cardIds[i] = cardIds[newIndex];
            cardIds[newIndex] = temp;
        }
    }

    private IEnumerator CheckMatch()
    {
        if (firstRevealed.Id == secondRevealed.Id)
        {
            score++;
            scoreLabel.text = $"Score: {score}";
        }
        else
        {
            yield return new WaitForSeconds(.5f);

            firstRevealed.Unreveal();
            secondRevealed.Unreveal();
        }

        firstRevealed = null;
        secondRevealed = null;
    }
}

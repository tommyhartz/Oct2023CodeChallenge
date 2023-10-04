using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBench : MonoBehaviour
{
    public GameBoard GameBoard;
    public List<Card> Cards;

    public PlayerDeck PlayerDeck;

    public int BenchWidth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddCards(List<Card> cards)
    {
        foreach(Card c in cards) {
            Cards.Add(c);

            var position = transform.position;

            position.x += 0.26f * Cards.Count;
            position.z = 0f - Cards.Count;

            c.SetTarget(position, true);
        }

        BoxCollider2D bc = GetComponent<BoxCollider2D>();

        bc.offset = new Vector2(0f + 0.13f * 5f * Cards.Count, 0f);
        bc.size = new Vector2(6f + 0.26f * 5f * Cards.Count, 9f);

    }

    private void OnMouseDown()
    {
        if (GameBoard.GameState == GameBoard.PlayerTurn)
        {
            Debug.Log("Shuffle player deck");

            foreach (Card c in Cards)
            {
                PlayerDeck.AddCard(c);
            }

            PlayerDeck.Shuffle();

            Cards.Clear();
        }

        BoxCollider2D bc = GetComponent<BoxCollider2D>();

        bc.offset = new Vector2(0f, 0f);
        bc.size = new Vector2(6f, 9f);
    }
}

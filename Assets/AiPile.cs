using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPile : MonoBehaviour
{
    public List<Card> Cards;

    public GameBoard GameBoard;
    public AiDeck AiDeck;
    public PlayerPile PlayerPile;
    public AiBench Bench;

    private float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameBoard.GameState == GameBoard.AiWonRound)
        {
            time += Time.deltaTime;
            
            if (time >= (Cards.Count == 1 ? 1f : 2f))
            {
                time = 0f;
                CollectCards();
            }
        }
    }

    public void AddCard(Card card, bool reveal)
    {
        Cards.Add(card);

        var position = transform.position;
        position.x += 0.26f * Cards.Count;
        position.z = -Cards.Count;

        card.SetTarget(position, reveal);
    }

    private void CollectCards()
    {
        Debug.Log("AI Collect Cards");

        Bench.AddCards(Cards);
        Bench.AddCards(PlayerPile.Cards);

        Cards.Clear();
        PlayerPile.Cards.Clear();

        GameBoard.GameState = GameBoard.PlayerTurn;
    }
}

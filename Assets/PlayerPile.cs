using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPile : MonoBehaviour
{
    public GameBoard GameBoard;
    public List<Card> Cards;

    public AiPile AiPile;

    public PlayerBench Bench;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddCard(Card card, bool reveal)
    {
        Cards.Add(card);

        var position = transform.position;
        position.x -= 0.26f * Cards.Count;
        position.z = -Cards.Count;

        card.SetTarget(position, reveal);
    }

    private void OnMouseDown()
    {
        if (GameBoard.GameState == GameBoard.PlayerWonRound)
        {
            Bench.AddCards(Cards);
            Bench.AddCards(AiPile.Cards);

            Cards.Clear();
            AiPile.Cards.Clear();

            GameBoard.GameState = GameBoard.PlayerTurn;
        }
    }
}

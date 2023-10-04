using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> Cards = new List<Card>();

    public GameBoard GameBoard;

    public PlayerPile PlayerPile;
    public PlayerBench Bench;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCard(Card card)
    {
        Cards.Add(card);

        card.SetTarget(transform.position, false);
    }

    public void Shuffle()
    {
        Cards = Cards.OrderBy(a => Random.Range(int.MinValue, int.MaxValue)).ToList();
    }


    private void OnMouseDown()
    {
        if (GameBoard.GameState == GameBoard.PlayerTurn)
        {
            Play();
        }
    }

    void Play()
    {
        if (GameBoard.IsWar)
        {
            PlayCard(false);
            PlayCard(false);
            PlayCard(false);
            PlayCard(true);
        }
        else
        {
            PlayCard(true);
        }

        GameBoard.GameState = GameBoard.AiTurn;
    }

    void PlayCard(bool reveal)
    {
        if (Cards.Count == 0)
        {
            if (Bench.Cards.Count > 0)

            {
                foreach (Card c in Bench.Cards)
                {
                    Cards.Add(c);

                    var position = transform.position;

                    c.SetTarget(position, false);
                }

                Bench.Cards.Clear();
                Shuffle();
            }
            else
            {
                Debug.Log("Player Death by draw");
                GameBoard.AiWon();
                return;
            }
        }

        Card card = Cards.First();
        Cards.Remove(card);
        PlayerPile.AddCard(card, reveal);
    }
}

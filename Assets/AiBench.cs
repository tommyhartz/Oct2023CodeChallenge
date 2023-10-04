using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBench : MonoBehaviour
{
    public GameBoard GameBoard;
    public List<Card> Cards;

    public AiDeck AiDeck;

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

            position.x -= 0.26f * Cards.Count;
            position.z = 0f - Cards.Count;

            c.SetTarget(position, true);
        }
    }
}

string[] input = Console.ReadLine().Split(", ");
List<Card> cards = new List<Card>();
foreach (var item in input)
{
    string[] faceAndSuit = item.Split(" ");
    string face= faceAndSuit[0];
    string suit= faceAndSuit[1];
    Card card=new Card(face, suit);
	try
	{
        card.CreateCard(face, suit);
        cards.Add(card);
    }
	catch (ArgumentException ex)
	{
        Console.WriteLine(ex.Message);
	}
}
foreach (var card in cards)
{
    Console.Write(card.ToString()+" ");
}



public class Card
{
    public string face { get; private set; }
    public string suit { get; private set; }
    public Card(string face, string suit)
    {
        this.face = face;
        this.suit = suit;
    }
    public Card CreateCard(string face, string suit)
    {
        bool wrongFace = true;
        bool wrongSuit = true;
        Card card = new Card(face, suit);
        string[] validFaces = new string[13] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        foreach (var item in validFaces)
        {
            if (face == item)
            {
                wrongFace = false;
                break;
            }
        }
        if (wrongFace)
        {
            throw new ArgumentException("Invalid card!");
        }
        switch (suit)
        {
            case "S":
                suit = "\u2660";
                break;
            case "H":
                suit = "\u2665";
                break;
            case "D":
                suit = "\u2666";
                break;
            case "C":
                suit = "\u2663";
                break;
            default:
                break;
        }
        string[] suits = new string[4] { "\u2660", "\u2665", "\u2666", "\u2663" };
        foreach (var item in suits)
        {
            if (suit.Equals(item))
            {
                wrongSuit = false;
            }
        }
        if (wrongSuit)
        {
            throw new ArgumentException("Invalid card!");
        }
        return card;
    }
    public override string ToString()
    {
        switch (suit)
        {
            case "S":
                suit = "\u2660";
                break;
            case "H":
                suit = "\u2665";
                break;
            case "D":
                suit = "\u2666";
                break;
            case "C":
                suit = "\u2663";
                break;
        }
        return $"[{face}{suit}]";
    }
}
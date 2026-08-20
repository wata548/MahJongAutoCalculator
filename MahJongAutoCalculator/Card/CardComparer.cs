public class CardComparer: IComparer<Card> {
    public int Compare(Card? x, Card? y) {
        if (x is null && y is null) return 0;
        if (x is null) return -1;
        if (y is null) return 1;
        return x.CompareTo(y);
    }
}
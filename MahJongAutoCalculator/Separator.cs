namespace MahJongAutoCalculator;

public class Separator {
    public Separator(IOrderedEnumerable<Card> pHands) {
        IReadOnlyList<Card> hands = pHands.ToList();
        var find = false;
        var bodies = new List<Body>();
        Head head = null;
        var numberCardCnt = new byte[3 * 9];

        //theory maximum 18(四槓子) < 32(int)bit
        bool DFS(bool pFindHead = false, int pStartIdx = 0, int pStartFlag = 0, int pVisit = 0) {
            if (hands.Count == pStartIdx) return pFindHead;
            if (find) return false;
            var subFlag = pStartFlag == 0 ? 1 : pStartFlag;
            if (hands[pStartIdx] is not NumberCard number) {
                return CheckSameCardForm();
            }

            //TODO: Check straight with many condition branches 
            //f = four, t = triple, h = head, s = straight
            //switch(Same card cnt)
            //1 => s
            //2 => s * 2 or h
            //3 => s * 3 or h + s or t
            //4 => f or t + s or h + s * 2 or s * 4
            
            
            return CheckSameCardForm();

            //Head, Triple, Four
            bool CheckSameCardForm() {
                if (!pFindHead && hands[pStartFlag].Equals(hands[pStartFlag + 1])) {
                    if (DFS(true, pStartIdx + 2, subFlag << 2, pVisit)) {
                        head = new Head(hands[pStartIdx]);
                        return true;
                    }
                }
                if (hands.Count < pStartFlag + 2) return false;
                var isAbleToTriple = hands[pStartFlag].Equals(hands[pStartFlag + 1]) &&
                                     hands[pStartFlag].Equals(hands[pStartFlag + 2]);
                if (isAbleToTriple && DFS(pFindHead, pStartFlag + 3, subFlag << 3, pVisit)) {
                    bodies.Add(Body.Triple(hands[pStartIdx]));
                    return true;
                }
                                
                var isAbleToFour = isAbleToTriple && hands.Count > pStartIdx + 3 && 
                                   hands[pStartFlag].Equals(hands[pStartFlag + 3]);
                if (isAbleToFour && DFS(pFindHead, pStartFlag + 4, subFlag << 4, pVisit)) {
                    bodies.Add(Body.Four(hands[pStartIdx]));
                    return true;
                }
                return false;
            }
        }
    }
}
namespace MahJongAutoCalculator;

public static class Separator {
    public static Form? Separate(IOrderedEnumerable<Card> pHands) {
        IReadOnlyList<Card> hands = pHands.ToList();
        var bodies = new List<Body>();
        Head? head = null;
        var result = DFS();
        bodies.Reverse();
        return result
            ? new Form(head!, bodies)
            : null;

        //theory maximum 18(四槓子) < 32(int)bit (bit flag)
        bool DFS(bool pFindHead = false, int pStartIdx = 0, int pVisit = 0, int pDepth = 0) {
            var startFlag = 1 << (pStartIdx + 1);
            while ((startFlag & pVisit) != 0) {
                startFlag <<= 1;
                pStartIdx++;
            }
            if (hands.Count == pStartIdx) return pFindHead && pDepth == 5;
            pVisit |= startFlag;
            
            if (CheckStraight()) return true;
            return CheckSameCardForm();

            bool CheckStraight() {
                if (hands[pStartIdx] is NumberCard number) {
                    var checkFlag = startFlag << 1;
                    var tempVisit = pVisit;
                    var straightDelta = 1;
                    for (int i = pStartIdx + 1; i < hands.Count; i++, checkFlag <<= 1) {
                        if (hands[i] is not NumberCard candidate) break;
                        if (candidate.NumberType != number.NumberType) break;
                        if((pVisit & checkFlag) != 0) continue;
                        if(candidate.Number != number.Number + straightDelta) continue;
                                
                        straightDelta++;
                        tempVisit |= checkFlag;
                        if (straightDelta != 3) continue;
                        if (DFS(pFindHead, pStartIdx + 1, tempVisit, pDepth + 1)) {
                            bodies.Add(Body.Straight(number));
                            return true;        
                        }
                        break;
                    }
                }
                return false;
            }
            
            //Head, Triple, Four
            bool CheckSameCardForm() {
                var checkFlag = startFlag << 1;
                var tempVisit = pVisit | checkFlag;
                if ((pVisit & checkFlag) != 0) return false;
                if (hands.Count <= pStartIdx + 1) return false;
                
                //head
                if (!hands[pStartIdx].Equals(hands[pStartIdx + 1])) return false;
                if (!pFindHead && DFS(true, pStartIdx + 2, tempVisit, pDepth + 1)) {
                    head = new Head(hands[pStartIdx]);
                    return true;
                }

                checkFlag <<= 1;
                tempVisit |= checkFlag;
                if ((pVisit & checkFlag) != 0) return false;
                if (hands.Count <= pStartIdx + 2) return false;
                
                //triple
                if (!hands[pStartIdx].Equals(hands[pStartIdx + 2])) return false;
                if (DFS(pFindHead, pStartIdx + 3, tempVisit, pDepth + 1)) {
                    bodies.Add(Body.Triple(hands[pStartIdx]));
                    return true;
                }
                
                checkFlag <<= 1;
                tempVisit |= checkFlag;
                if ((pVisit & checkFlag) != 0) return false;
                if (hands.Count <= pStartIdx + 3) return false;
                
                //four
                if (!hands[pStartIdx].Equals(hands[pStartIdx + 3])) return false;
                if (DFS(pFindHead, pStartIdx + 4, tempVisit, pDepth + 1)) {
                    bodies.Add(Body.Four(hands[pStartIdx]));
                    return true;
                }
                return false;
            }
        }
    }
}
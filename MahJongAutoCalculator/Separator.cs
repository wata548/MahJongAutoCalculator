namespace MahJongAutoCalculator;

public static class Separator {
	public static Form? Separate(IEnumerable<Card> pCryHands, IOrderedEnumerable<Card> pHands) {
		IReadOnlyList<Card> hands = pHands.ToList();
		IReadOnlyList<Card> cries = pCryHands.ToList();
		var bodies = new List<Body>();
		Head? head = null;
		if (!DFS(cries, true, pIgnoreCnt: true)) throw new ArgumentException("Cry hand is wrong");
		foreach (var body in bodies) body.IsOpen = true;
		var result = DFS(hands, pDepth: bodies.Count);
		bodies.Reverse();
		return result
			? new Form(head!, bodies)
			: null;

		//theory maximum 18(四槓子) < 32(int)bit (bit flag)
		bool DFS(IReadOnlyList<Card> pHands, bool pFindHead = false, int pStartIdx = 0, int pVisit = 0, int pDepth = 0, bool pIgnoreCnt = false) {
			var startFlag = 1 << (pStartIdx + 1);
			while ((startFlag & pVisit) != 0) {
				startFlag <<= 1;
				pStartIdx++;
			}
			if (pHands.Count == pStartIdx) return pFindHead && (pIgnoreCnt || pDepth == 5);
			pVisit |= startFlag;
            
			if (CheckStraight()) return true;
			return CheckSameCardForm();
		
			bool CheckStraight() {
				if (pHands[pStartIdx] is NumberCard number) {
					var idxFlag = startFlag << 1;
					var tempVisit = pVisit;
					var sum = number.Number;
					var min = number;
					var duplicateChecker = 1 << (number.Number - 1);
					var cnt = 1;
					for (int i = pStartIdx + 1; i < pHands.Count; i++, idxFlag <<= 1) {
						if (pHands[i] is not NumberCard candidate) break;
						if (candidate.NumberType != number.NumberType) break;
						if((pVisit & idxFlag) != 0) continue;
						//Check duplicate
						var duplicateFlag = 1 << (candidate.Number - 1);
						if((duplicateChecker & duplicateFlag) != 0) continue;
						sum += candidate.Number;
						if (min.Number > candidate.Number)
							min = candidate;
						cnt++;
						tempVisit |= idxFlag;
						duplicateChecker |= duplicateFlag;
						if (cnt != 3) continue;
						if (min.Number * 3 + 3 != sum) break;
						if (DFS(pHands, pFindHead, pStartIdx + 1, tempVisit, pDepth + 1, pIgnoreCnt)) {
							bodies.Add(Body.Straight(min));
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
				if (pHands.Count <= pStartIdx + 1) return false;
                
				//head
				if (!pHands[pStartIdx].Equals(pHands[pStartIdx + 1])) return false;
				if (!pFindHead && DFS(pHands, true, pStartIdx + 2, tempVisit, pDepth + 1, pIgnoreCnt)) {
					head = new Head(pHands[pStartIdx]);
					return true;
				}

				checkFlag <<= 1;
				tempVisit |= checkFlag;
				if ((pVisit & checkFlag) != 0) return false;
				if (pHands.Count <= pStartIdx + 2) return false;
                
				//triple
				if (!pHands[pStartIdx].Equals(pHands[pStartIdx + 2])) return false;
				if (DFS(pHands, pFindHead, pStartIdx + 3, tempVisit, pDepth + 1, pIgnoreCnt)) {
					bodies.Add(Body.Triple(pHands[pStartIdx]));
					return true;
				}
                
				checkFlag <<= 1;
				tempVisit |= checkFlag;
				if ((pVisit & checkFlag) != 0) return false;
				if (pHands.Count <= pStartIdx + 3) return false;
                
				//four
				if (!pHands[pStartIdx].Equals(pHands[pStartIdx + 3])) return false;
				if (DFS(pHands, pFindHead, pStartIdx + 4, tempVisit, pDepth + 1, pIgnoreCnt)) {
					bodies.Add(Body.Four(pHands[pStartIdx]));
					return true;
				}
				return false;
			}
		}
	}
}
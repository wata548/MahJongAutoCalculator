using System.Text;

namespace MahJongAutoCalculator;

public record Form(Head pHead, params IEnumerable<Body> pBodies) {
	public readonly IReadOnlyList<Body> Bodies = pBodies.ToList();
	public readonly Head Head = pHead;
	public ICardCollection LastCollection { get; private set; }
	public WaitType WaitType { get; private set; }

	public int GetFu(Setting pSetting, Card pLastCard) {
		var minWaitType = WaitType.Except;
		ICardCollection? minCollection = null;
		
		foreach (var body in Bodies) {
			if(body.IsOpen) continue; 
			Min(body);
		}
		Min(Head);
		LastCollection = minCollection;
		WaitType = minWaitType;	

		if (minCollection == null)
			throw new ArgumentException("LastCard error. This card didn't included any collection");
		
		if (pSetting.IsRon) minCollection.IsOpen = true;
		var waitFu = minWaitType is WaitType.NoMiddle or WaitType.SingleFace or WaitType.SingleHead
			? 2 : 0;
		var fu = Bodies.Aggregate(0, (fu, body) => fu + body.GetFu(pSetting));
		fu += Head.GetFu(pSetting);
		return fu + waitFu;

		void Min(ICardCollection pCollection) {
			var waitType = pCollection.GetWaitType(pLastCard);
			if(minWaitType > waitType) {
				minWaitType = waitType;
				minCollection = pCollection;
			}	
		}
	}
	public override string ToString() {
		var stringBuilder = new StringBuilder();
		if (Head != LastCollection) {
			stringBuilder.Append("Head: \n\t");
			stringBuilder.AppendLine(Head.ToString());	
		}
		stringBuilder.AppendLine("Body:");
		foreach (var body in Bodies) {
			if(body == LastCollection) continue;
			stringBuilder.Append("\t");
			stringBuilder.AppendLine(body.ToString());
		}
		stringBuilder.Append($"Last: \n\tWait type: {WaitType}\n\t");
		stringBuilder.AppendLine(LastCollection.ToString());
		return stringBuilder.ToString();
	}
}
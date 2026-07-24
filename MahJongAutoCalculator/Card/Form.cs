using System.Text;

namespace MahJongAutoCalculator;

public record Form(Head pHead, params IEnumerable<Body> pBodies) {
    public readonly IReadOnlyList<Body> Bodies = pBodies.ToList();
    public readonly Head Head = pHead;
    public override string ToString() {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append("Head: \n\t");
        stringBuilder.AppendLine(Head.ToString());
        stringBuilder.AppendLine("Body:");
        foreach (var body in Bodies) {
            stringBuilder.Append("\t");
            stringBuilder.AppendLine(body.ToString());
        }

        return stringBuilder.ToString();
    }
}
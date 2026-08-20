using System.Text;

namespace MahJongAutoCalculator;

public class Score(bool pContainCount) {
	public readonly bool ContainCount = pContainCount;
	public bool IsYakuman { get; private set; }
	public int Han { get; private set; }
	public int Fu { get; private set; }
	public bool HanLock { get; set; }
	public bool FuLock { get; set; }
	public IEnumerable<string> Applied => _appliedYakuman.Count == 0 
		? _applied 
		: _appliedYakuman;
	private List<string> _applied = new();
	private List<string> _appliedYakuman = new();

	public void CeilFu() {
		var mod = Fu % 10;
		if (mod == 0) return;
		Fu += 10 - mod;  
	} 
    
	public void Set(int pHan = -1, int pFu = -1) {
		if (IsYakuman) return;
		if(!HanLock && pHan != -1)
			Han = pHan;
		if (!FuLock && pFu != -1)
			Fu = pFu;
	}
    
	public void ApplyForm(string pName, int pAmount, bool pIsYakuman = false) {
		if (ContainCount) {
			if(pIsYakuman)
				_appliedYakuman.Add($"{pName}: {pAmount}");
			else
				_applied.Add($"{pName}: {pAmount}");    
		}
		else {
			if(pIsYakuman)
				_appliedYakuman.Add(pName);
			else
				_applied.Add(pName);    
		}
		if(pIsYakuman)
			AddYakuman(pAmount);
		else
			Add(pAmount);
	}

	public void AddFu(int pFu = 0) {
		if (FuLock) return;
		Fu += pFu;
	}
    
	private void Add(int pHan = 0) {
		if (IsYakuman) return;
		if (!HanLock) 
			Han += pHan;
	}

	public void AddYakuman(int pConstant) {
		if (HanLock) return;
		if (!IsYakuman) {
			Han = pConstant;
			Fu = 0;
			IsYakuman = true;
			return;
		}
		Han += pConstant;
	}

	public override string ToString() {
		var builder = new StringBuilder();
		if (IsYakuman)
			builder.AppendLine($"Yakuman * {Han}");
		else {
			builder.AppendLine($"Han: {Han}");
			builder.AppendLine($"Fu: {Fu}");
		}

		builder.AppendLine("Applies:");
		foreach (var apply in Applied) {
			builder.Append("\t");
			builder.AppendLine(apply);
		}

		return builder.ToString();
	}
}
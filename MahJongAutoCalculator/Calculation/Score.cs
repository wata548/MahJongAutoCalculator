using System.Text;

namespace MahJongAutoCalculator;

public class Score(bool pContainCount) {
	public readonly bool ContainCount = pContainCount;
	public bool IsYakuman { get; private set; }
	public int Han { get; private set; }
	public int Fu { get; private set; }
	public bool HanLock { get; set; }
	public bool FuLock { get; set; }

	public readonly static IReadOnlyList<(int, int)> ValueList = new List<(int, int)>() {
		(5, 8000),
		(6, 12000),
		(8, 16000),
		(11, 24000),
		(13, 32000),
	};
	public IEnumerable<string> Applied => _appliedYakuman.Count == 0 
		? _applied 
		: _appliedYakuman;
	private List<string> _applied = new();
	private List<string> _appliedYakuman = new();

	public (int, int) GetScore(Setting pSetting) {
		if (IsYakuman) {
			var point = Han * ValueList[^1].Item2;
			if (pSetting.IsParent) {
				return (0, point / 2);
			}
			return (point / 2, point / 4);
		}
		var defaultScore = 960;
		var term = 32;
		if (ValueList[0].Item1 <= Han) {
			var point = 0;
			for (int i = 0; i < ValueList.Count; i++) {
				if(Han >= ValueList[i].Item1) continue;
				point = ValueList[i - 1].Item2;
				break;
			}
			if (point == 0) point = ValueList[^1].Item2;
			if (pSetting.IsParent) return (0, point / 2);
			return (point / 2, point / 4);
		}

		var fu = Fu * (1 << (Han - 1)) - 30;
		var result = Math.Min(defaultScore + fu * term, 8000);
		if (pSetting.IsParent) return (0, Ceil(result / 2));
		return (Ceil(result / 2), Ceil(result / 4));

		int Ceil(int pPoint) {
			if (pPoint % 100 == 0) return pPoint;
			return pPoint - pPoint % 100 + 100;
		} 
	}
	
	public void CeilFu() {
		if (FuLock) return;
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

	public string ToString(Setting pSetting) {
		var builder = new StringBuilder();
		if (IsYakuman)
			builder.AppendLine($"Yakuman * {Han}");
		else {
			builder.AppendLine($"Han: {Han}");
			builder.AppendLine($"Fu: {Fu}");
		}

		var point = GetScore(pSetting);
		if(point.Item1 == 0) 
			builder.AppendLine($"All {point.Item2}");
		else
			builder.AppendLine($"親: {point.Item1} 子: {point.Item2}");

		builder.AppendLine("Applies:");
		foreach (var apply in Applied) {
			builder.Append("\t");
			builder.AppendLine(apply);
		}

		return builder.ToString();
	}
}
namespace MahJongAutoCalculator;

public class Score {
    public bool IsYakuman { get; private set; }
    public int Han { get; private set; }
    public int Fu { get; private set; }
    public bool Lock { get; set; }

    public void Set(int pHan = -1, int pFu = -1) {
        if (Lock) return;
        if(pHan != -1)
            Han = pHan;
        if (pFu != -1)
            Fu = pFu;
    }
    
    public void Add(int pHan = 0, int pFu = 0) {
        if (Lock) return;
        if (IsYakuman) return;
        Han += pHan;
        Fu += pFu;
    }

    public void AddYakuman(int pConstant) {
        if (Lock) return;
        if (IsYakuman) return;
        if (!IsYakuman) {
            Han = pConstant;
            Fu = 0;
            IsYakuman = true;
            return;
        }
        Han += pConstant;
    }
}
using System.Reflection.Metadata.Ecma335;
using static Program;

class Program
{
   /* public enum NamaBuah
    {
        Apel,
        Aprikot,
        Alpukat,
        Pisang,
        Paprika,
        Blackberry,
        Ceri,
        Kelapa,
        Jagung,
        Kurma,
        Durian,
        Anggur,
        Melon,
        Semangka
    }

    public static string getKodeBuah(NamaBuah Kode)
    {
        string[] KodeBuah = { "A00", "B00", "C00", "D00", "E00", "F00", "H00", "I00", "J00", "K00", "L00", "M00", "N00", "O00" };
        return KodeBuah[(int)Kode];
    }*/

    public enum PosisiKarakterGame
    {
        Jongkok,
        Berdiri,
        Tengkurap,
        Terbang
    }
    public enum Trigger
    {
        TombolW,
        TombolS,
        TombolX
    }

    class Karakter
    {
        public class Transition
        {
            public PosisiKarakterGame stateAwal;
            public PosisiKarakterGame stateAkhir;
            public Trigger trigger;

            public Transition(PosisiKarakterGame stateAwal, PosisiKarakterGame stateAkhir, Trigger trigger)
            {
                this.stateAwal = stateAwal;
                this.stateAkhir = stateAkhir;
                this.trigger = trigger;
            }
        }
        Transition[] transisi =
        {
            new Transition(PosisiKarakterGame.Jongkok, PosisiKarakterGame.Berdiri, Trigger.TombolW),
            new Transition(PosisiKarakterGame.Berdiri, PosisiKarakterGame.Jongkok, Trigger.TombolS),
            new Transition(PosisiKarakterGame.Berdiri, PosisiKarakterGame.Terbang, Trigger.TombolW),
            new Transition(PosisiKarakterGame.Terbang, PosisiKarakterGame.Berdiri, Trigger.TombolS),
            new Transition(PosisiKarakterGame.Terbang, PosisiKarakterGame.Jongkok, Trigger.TombolX),
            new Transition(PosisiKarakterGame.Jongkok, PosisiKarakterGame.Tengkurap, Trigger.TombolS),
            new Transition(PosisiKarakterGame.Tengkurap, PosisiKarakterGame.Jongkok, Trigger.TombolW)
        };

        public PosisiKarakterGame currentState = PosisiKarakterGame.Berdiri;

        public PosisiKarakterGame GetNextState(PosisiKarakterGame stateAwal, Trigger trigger)
        {
            PosisiKarakterGame stateAkhir = stateAwal;

            for (int i = 0; i < transisi.Length; i++)
            {
                Transition perubahan = transisi[i];
                
                if (stateAwal == perubahan.stateAwal && trigger == perubahan.trigger)
                {
                    stateAkhir = perubahan.stateAkhir;
                }
            }
            return stateAkhir;
        }

        public void ActivateTrigger(Trigger trigger)
        {
            currentState = GetNextState(currentState, trigger);
            if(Trigger == Trigger.TombolX)
            {
                Console.WriteLine("Posisi Landing");
            }
        }

    }

}

class program
{
    static void Main(string[] args)
    {
        PosisiKarakterGame posisi = new PosisiKarakterGame();
        Console.WriteLine("Posisi saat ini" + posisi.currentState);
    }
}
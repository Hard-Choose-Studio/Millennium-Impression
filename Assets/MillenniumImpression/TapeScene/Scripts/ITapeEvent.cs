namespace MillenniumImpression.TapeScene
{
    public interface ITapeEvent : IEvent
    {
        void OnTapeReachedMachine();
        void OnMachineClose();
    }
}
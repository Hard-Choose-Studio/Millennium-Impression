namespace MillenniumImpression.AquaOilScene
{
    public interface IAquaOilEvent : IEvent
    {
        void OnBottleOpened();
        void OnVanishing();
    }
}
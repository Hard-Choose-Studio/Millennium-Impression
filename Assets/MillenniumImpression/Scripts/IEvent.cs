namespace MillenniumImpression
{
    /**
     * 所有事件的root
     * 包含了target found和taget lost
     */
    public interface IEvent
    {
        void OnTargetFound();

        void OnTargetLost();
    }
}
namespace MillenniumImpression
{
    /**
     * �Ҧ��ƥ�root
     * �]�t�Ftarget found�Mtaget lost
     */
    public interface IEvent
    {
        void OnTargetFound();

        void OnTargetLost();
    }
}
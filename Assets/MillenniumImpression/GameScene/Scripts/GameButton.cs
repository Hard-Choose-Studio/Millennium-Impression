namespace MillenniumImpression.GameScene
{
    public class GameButton : GenericButton
    {
        private bool isPressed = false;

        public override void OnClick() { }

        public void OnButtonPressed() => isPressed = true;

        public void OnButtonReleased() => isPressed = false;

        public bool IsPressed() => isPressed;
    }
}
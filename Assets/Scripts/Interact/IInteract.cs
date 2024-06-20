namespace Interact
{
    public interface IInteract
    {
        /// <summary>
        /// Interact with the object
        /// </summary>
        public void Interact();
        
        /// <summary>
        /// Highlight the object in the screen
        /// </summary>
        public void Highlight();
        
        /// <summary>
        /// Hide the highlight effect in the object
        /// </summary>
        public void Hide();
    }
}
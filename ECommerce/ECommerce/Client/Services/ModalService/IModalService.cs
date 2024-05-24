namespace ECommerce.Client.Services.ModalService
{
    public interface IModalService
    {
        public event Action? ModalStateChanged;
        bool AuthModalState { get; set; }
        bool SidebarModalState { get; set; }
        bool SearchModalState { get; set; } 

        void ToggleAuthModalState(bool state);
        void ToggleSidebarModalState(bool state);
        void ToggleSearchModalState(bool state);
        void RedirectToLogin();
        void RedirectToRegister();
    }
}

using System;
using Microsoft.AspNetCore.Components;

namespace ECommerce.Client.Services.ModalService
{
    public class ModalService : IModalService
    {
        public event Action? ModalStateChanged;

        public bool AuthModalState { get; set; } = false;
        public bool SidebarModalState { get; set; } = false;
        public bool SearchModalState { get; set; } = false;

        private NavigationManager navigationManager;

        public ModalService(NavigationManager navigationManager)
        {
            this.navigationManager = navigationManager;
        }

        public void ToggleAuthModalState(bool state)
        {
            AuthModalState = state;
            ModalStateChanged?.Invoke();
        }

        public void ToggleSidebarModalState(bool state)
        {
            SidebarModalState = state;
            ModalStateChanged?.Invoke();
        }

        public void ToggleSearchModalState(bool state)
        {
            SearchModalState = state;
            ModalStateChanged?.Invoke();
        }

        public void RedirectToLogin()
        {
            navigationManager.NavigateTo("/user/login");
        }

        public void RedirectToRegister()
        {
            navigationManager.NavigateTo("/user/register");
        }
    }
}

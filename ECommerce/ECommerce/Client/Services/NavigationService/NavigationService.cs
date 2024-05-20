namespace ECommerce.Client.Services.NavigationService
{
    public class NavigationService : INavigationService
    {
        public event Action? NavStateChanged;
        public bool NavState { get; set; } = false;

        public void ChangeNavState(bool state)
        {
            NavState = state;
            NavStateChanged?.Invoke();
        }
    }
}


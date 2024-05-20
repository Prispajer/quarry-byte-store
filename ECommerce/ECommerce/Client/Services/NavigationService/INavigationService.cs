namespace ECommerce.Client.Services.NavigationService
{
    public interface INavigationService
    {
        event Action? NavStateChanged;
        bool NavState { get; set; }
        void ChangeNavState(bool state);
    }
}

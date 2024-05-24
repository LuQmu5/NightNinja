public interface IStateSwitcher
{
    public void SwitchState<T>(IState state) where T : IState;
}

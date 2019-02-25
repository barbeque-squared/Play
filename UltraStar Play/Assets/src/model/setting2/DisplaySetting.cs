public abstract class DisplaySetting<T> : BaseSetting<T>
{
  protected abstract string GetSubIdentifier();

  protected sealed override string GetIdentifier()
  {
    return "display."+GetSubIdentifier();
  }
}

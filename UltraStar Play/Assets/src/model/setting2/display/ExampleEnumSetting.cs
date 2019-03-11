public class ExampleEnumSetting : SimpleEnumSetting<ELanguage>
{
  public override ELanguage GetDefaultValue()
  {
    return ELanguage.English;
  }
}

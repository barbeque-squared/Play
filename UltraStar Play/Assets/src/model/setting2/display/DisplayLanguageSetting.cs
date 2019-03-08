public class DisplayLanguageSetting : SimpleEnumSetting<ELanguage>
{
  public override ELanguage GetDefaultValue()
  {
    return ELanguage.English;
  }
}

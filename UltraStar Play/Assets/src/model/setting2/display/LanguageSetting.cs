public class DisplayLanguageSetting : SimpleEnumSetting<ELanguage>
{
  protected override ELanguage GetDefaultValue()
  {
    return ELanguage.English;
  }
}

/// <summary>
/// Creates *infinite* stream of initialElement, f(initialElement), f(f(initialElement)), ...
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="initialElement"></param>
/// <param name="f"></param>
/// <returns></returns>
internal static IEnumerable<T> MakeStream<T>(T initialElement, Func<T, T> f)
{
  yield return initialElement;
  var element = initialElement;
  while (true)
  {
    element = f(element);
    yield return element;
  }
}

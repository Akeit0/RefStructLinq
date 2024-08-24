namespace RefStructLinq;

public ref struct SelectEnumerator<T, TOut, TEnumerator>(TEnumerator enumerator, Func<T, TOut> transform) : IRefStructEnumerator<TOut,SelectEnumerator<T, TOut, TEnumerator>>
    where T : allows ref struct
    where TOut : allows ref struct
    where TEnumerator : IRefStructEnumerator<T,TEnumerator>, allows ref struct
{
    TEnumerator enumerator = enumerator;

    public SelectEnumerator<T, TOut, TEnumerator> GetEnumerator() => new (enumerator.GetEnumerator(), transform);
    public TOut Current { get; private set; }

    public bool MoveNext()
    {
        while (enumerator.MoveNext())
        {
            Current = transform(enumerator.Current);
            return true;
        }

        return false;
    }

    public void Dispose() => enumerator.Dispose();
}
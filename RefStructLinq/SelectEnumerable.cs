namespace RefStructLinq;

public ref struct SelectEnumerable<T, TOut, TEnumerable, TEnumerator>(in TEnumerable inner, Func<T, TOut> transform)
    : IRefStructEnumerable<TOut, SelectEnumerator<T, TOut, TEnumerator>>
    where TEnumerator : struct, IRefStructEnumerator<T>, allows ref struct
    where TEnumerable : IRefStructEnumerable<T, TEnumerator>, allows ref struct
    where T : allows ref struct
    where TOut : allows ref struct
{
    TEnumerable inner = inner;

    public SelectEnumerator<T, TOut, TEnumerator> GetEnumerator()
        => new(inner.GetEnumerator(), transform);
}
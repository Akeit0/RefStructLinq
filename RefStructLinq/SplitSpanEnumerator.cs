namespace RefStructLinq;

public ref struct SpanSplitEnumerator<T> (ReadOnlySpan<T> span, MemoryExtensions.SpanSplitEnumerator<T> enumerator)
    :IRefStructEnumerator<ReadOnlySpan<T>> where T : IEquatable<T>
{
    MemoryExtensions.SpanSplitEnumerator<T> enumerator = enumerator;
    ReadOnlySpan<T> span = span;
    public ReadOnlySpan<T> Current => span[enumerator.Current];
    public bool MoveNext() => enumerator.MoveNext();
    public void Dispose() { }
}
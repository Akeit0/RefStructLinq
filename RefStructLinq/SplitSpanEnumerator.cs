namespace RefStructLinq;

public ref struct SpanSplitEnumerator<T>(ReadOnlySpan<T> span, ReadOnlySpan<T> separator )
    : IRefStructEnumerator<ReadOnlySpan<T>,SpanSplitEnumerator<T>> where T : IEquatable<T>
{
    MemoryExtensions.SpanSplitEnumerator<T> enumerator = span.Split(separator).GetEnumerator();
    ReadOnlySpan<T> span = span;
    readonly ReadOnlySpan<T> separator = separator;
    
    public  readonly SpanSplitEnumerator<T> GetEnumerator()=>
        new (span, separator);

    public ReadOnlySpan<T> Current => span[enumerator.Current];
    public bool MoveNext() => enumerator.MoveNext();

    public void Dispose()
    {
    }
}
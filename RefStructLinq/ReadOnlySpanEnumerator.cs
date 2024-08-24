namespace RefStructLinq;

public ref struct ReadOnlySpanEnumerator<T>(ReadOnlySpan<T> span) : IRefStructEnumerator<T,ReadOnlySpanEnumerator<T>>
{
    readonly ReadOnlySpan<T> span = span;
    int index = -1;

    public  readonly ReadOnlySpanEnumerator<T> GetEnumerator() => new (span);

    public T Current => span[index];

    public bool MoveNext() => ++index < span.Length;

    public void Dispose()
    {
    }
}
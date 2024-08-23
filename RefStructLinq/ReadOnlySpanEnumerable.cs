namespace RefStructLinq;

public readonly ref struct ReadOnlySpanEnumerable<T>(ReadOnlySpan<T> span) : IRefStructEnumerable<T, ReadOnlySpanEnumerator<T>>
{
    readonly ReadOnlySpan<T> span = span;
    public ReadOnlySpanEnumerator<T> GetEnumerator() => new(span);
}

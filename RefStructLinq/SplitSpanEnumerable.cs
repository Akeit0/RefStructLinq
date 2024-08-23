namespace RefStructLinq;

public readonly ref struct SpanSplitEnumerable<T> (ReadOnlySpan<T> span, ReadOnlySpan<T> separator):IRefStructEnumerable<ReadOnlySpan<T>, SpanSplitEnumerator<T>> where T : IEquatable<T>
{
  
    readonly  ReadOnlySpan<T> span = span;
    readonly ReadOnlySpan<T> separator = separator;
    public SpanSplitEnumerator<T> GetEnumerator() => new(span, span.Split(separator));
}
// ReSharper disable GenericEnumeratorNotDisposed

namespace RefStructLinq;

public static class RefStructLinqExtensions
{
    public static RefStructIterator<ReadOnlySpan<T>,  SpanSplitEnumerator<T>>
        SplitEnumerable<T>(this ReadOnlySpan<T> span, ReadOnlySpan<T> separator)
        where T : IEquatable<T>
        => new(new(span, separator));

    public static RefStructIterator<T,ReadOnlySpanEnumerator<T>> ToRefStructEnumerable<T>(this ReadOnlySpan<T> span)
        => new(new(span));


    public static  RefStructIterator<T,  WhereEnumerator<T, TEnumerator>>
        Where<T,  TEnumerator>(in this RefStructIterator<T, TEnumerator> enumerable, Func<T, bool> predicate)
        where TEnumerator : struct, IRefStructEnumerator<T,TEnumerator>, allows ref struct
        where T : allows ref struct
        => new(new( enumerable.Enumerator, predicate));

    public static RefStructIterator<TOut, SelectEnumerator<T, TOut, TEnumerator>>
        Select<T, TOut,TEnumerator>(in this RefStructIterator<T, TEnumerator> enumerable, Func<T, TOut> transform)
        where TEnumerator : struct, IRefStructEnumerator<T,TEnumerator>, allows ref struct
        where T : allows ref struct
        where TOut : allows ref struct
        => new(new(enumerable.Enumerator, transform));


    public static RefStructIterator<T,  ReadOnlySpanEnumerator<T>> ToRefStructEnumerable<T>(this Span<T> span)
        => ToRefStructEnumerable(((ReadOnlySpan<T>)span));
}